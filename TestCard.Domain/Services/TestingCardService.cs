using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCard.Domain.Helpers;
using TestCard.Properties;
using System.Data.Entity;

namespace TestCard.Domain.Services
{
    public class TestingCardService : DomainServiceBase<TestingCard>
    {
        public TestingCardService(User currentUser)
            : base(currentUser)
        { }

        public TestingCardService(DomainServiceBase service)
            : base(service) { }

        public TestingCard Get(int id, bool includeDetails)
        {
            return _DbContext
                   .TestingCards
                   .Include(x => x.TestingCardDetails)
                   .Where(x => x.TestingCardID == id)
                   .FirstOrDefault();
        }

        public bool SaveTestingCard(TestingCardChangeRequest request)
        {
            var now = DateTime.Now;

            var id = request.TestingCardID;

            var card = Get(id);

            //Archive old person record
            var history = new TestingCardHistory
            {
                TestingCardID = card.TestingCardID,
                Number = card.Number,
                TestingCardNumber = card.TestingCardNumber,
                VIN = card.VIN,
                CarBrand = card.CarBrand,
                CarModel = card.CarModel,
                CarNumber = card.CarNumber,
                CarSerialNo = card.CarSerialNo,
                Odometer = card.Odometer,
                OwnerName = card.OwnerName,
                OwnerIDNo = card.OwnerIDNo,
                IsValid = card.IsValid,
                IsFirstTesting = card.IsFirstTesting,
                FirnishNumber = card.FirnishNumber,
                FirnishDate = card.FirnishDate,
                Comment = card.Comment,
                ResponsiblePersonID = card.ResponsiblePersonID,
                EffectiveDate = card.EffectiveDate,
                CreateDate = now
            };

            _DbContext.TestingCardHistories.Add(history);

            foreach (var item in card.TestingCardDetails)
            {
                history.TestingCardDetailHistories.Add(new TestingCardDetailHistory
                {
                    TestingCardID = item.TestingCardID,
                    TestingSubStepID = item.TestingSubStepID,
                    IsInvalid = item.IsInvalid,
                    IsChecked = item.IsChecked
                });
            }

            card.TestingCardNumber = request.TestingCardNumber;
            card.VIN = request.VIN;
            card.CarBrand = request.CarBrand;
            card.CarModel = request.CarModel;
            card.CarNumber = request.CarNumber;
            card.CarSerialNo = request.CarSerialNo;
            card.Odometer = request.Odometer;
            card.OwnerName = request.OwnerName;
            card.OwnerIDNo = request.OwnerIDNo;
            card.IsValid = request.IsValid;
            card.FirnishNumber = request.FirnishNumber;
            card.FirnishDate = request.FirnishDate;
            card.Comment = request.Comment;
            card.ResponsiblePersonID = request.ResponsiblePersonID;

            foreach (var item in card.TestingCardDetails.ToList())
            {
                card.TestingCardDetails.Remove(item);
            }

            foreach (var item in request.TestingCardDetailChangeRequests.ToList())
            {
                card.TestingCardDetails.Add(new TestingCardDetail
                {
                    IsChecked = item.IsChecked,
                    IsInvalid = item.IsInvalid,
                    TestingSubStepID = item.TestingSubStepID
                });
            }

            if (request.TestingCard == null)
            {
                request.TestingCard = card;
            }

            Update(card);

            return true;
        }

        public int SaveTestingCard(TestingCard testingCard, List<byte[]> images, User currentPerson)
        {
            List<string> savedFiles = new List<string>();

            try
            {
                var now = DateTime.Now;

                var codeService = new CodeService(this);

                testingCard.Number = codeService.NextCode(CodeTypes.TestingCardOrderNumber);
                if (testingCard.TestingCardNumber == null)
                {
                    testingCard.TestingCardNumber = codeService.NextCode(CodeTypes.TestingCardNumber);
                }
                testingCard.EffectiveDate = now;
                testingCard.ResponsiblePersonID = currentPerson.PersonID;
                testingCard.IsValid = !testingCard.TestingCardDetails.Any(x => x.IsInvalid);

                var similiarCards = GetAll().Any(x => x.VIN == testingCard.VIN || x.CarSerialNo == testingCard.CarSerialNo);
                testingCard.IsFirstTesting = !similiarCards;

                Add(testingCard);

                if (images.Count > 0)
                {
                    SaveTestingCardImages(testingCard, images, savedFiles);
                }

                SaveChanges();
            }
            catch (Exception e)
            {
                DeleteTestingCardImages(savedFiles);

                throw e;
            }

            return testingCard.TestingCardID;
        }

        public void SaveTestingCardImages(int testingCardID, List<byte[]> images)
        {
            List<string> savedFiles = new List<string>();

            try
            {
                var testingCard = Get(testingCardID);

                SaveTestingCardImages(testingCard, images, savedFiles);

                SaveChanges();
            }
            catch (Exception e)
            {
                DeleteTestingCardImages(savedFiles);

                throw e;
            }
        }

        protected void SaveTestingCardImages(TestingCard testingCard, List<byte[]> images, List<string> savedFiles)
        {
            string fileName = null;
            string filePath = null;

            foreach (var item in images.Where(x => x != null))
            {
                FileHelper.SaveImage(item, ref fileName, ref filePath);

                savedFiles.Add(filePath);

                testingCard.Files.Add(new File
                {
                    FileName = fileName,
                    FilePath = filePath
                });
            }
        }

        protected void DeleteTestingCardImages(List<string> images)
        {
            foreach (var item in images)
            {
                FileHelper.Delete(item);
            }
        }

        public override void Add(TestingCard entity)
        {
            BeforeSave(entity);

            base.Add(entity);
        }

        public override void Update(TestingCard entity)
        {
            BeforeSave(entity);

            base.Update(entity);
        }

        private void BeforeSave(TestingCard entity)
        {
            entity.CarBrand = entity.CarBrand.Trim();
            entity.CarModel = entity.CarModel.Trim();

            var service = new ModelService(this);
            service.Save(entity.CarBrand, entity.CarModel);
        }
    }
}
