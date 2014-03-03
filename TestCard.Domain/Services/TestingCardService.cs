using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCard.Domain.Helpers;
using TestCard.Properties;

namespace TestCard.Domain.Services
{
    public class TestingCardService : DomainServiceBase<TestingCard>
    {
        public TestingCardService() { }

        public TestingCardService(TestCardContext context)
            : base(context) { }

        public List<TestingCard> GetList(v_person person, DataFilterOption filter)
        {
            var type = (AccountTypes)person.AccountTypeID;
            var personID = person.PersonID;

            var result = GetAll().Where(x => x.ResponsiblePersonID == personID);

            return result.SortAndFilter(filter).ToList();
        }

        public bool SaveTestingCard(TestingCardChangeRequest request)
        {
            var now = DateTime.Now;

            var id = request.TestingCardID;

            var card = Get(id);

            //Archive old person record
            if (card != null)
            {
                var history = new TestingCardHistory
                {
                    TestingCardID = card.TestingCardID,
                    Number = card.Number,
                    TestingCardNumber = card.TestingCardNumber,
                    VIN = card.VIN,
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
                        IsValid = item.IsValid
                    });
                }

                Update(card);
            }
            //else
            //{
            //    card = new TestingCard();

            //    card.EffectiveDate = request.EffectiveDate;

            //    Add(card);
            //}

            card.TestingCardNumber = request.TestingCardNumber;
            card.VIN = request.VIN;
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
                    IsValid = item.IsValid,
                    TestingSubStepID = item.TestingSubStepID
                });
            }

            if (request.TestingCard == null)
            {
                request.TestingCard = card;
            }

            return true;
        }

        public int SaveTestingCard(TestingCard testingCard, v_person currentPerson)
        {
            var now = DateTime.Now;

            var codeService = new CodeService(_DbContext);

            testingCard.Number = codeService.NextCode(CodeTypes.TestingCardOrderNumber);
            if (testingCard.TestingCardNumber == null)
            {
                testingCard.TestingCardNumber = codeService.NextCode(CodeTypes.TestingCardNumber);
            }
            testingCard.EffectiveDate = now;
            testingCard.ResponsiblePersonID = currentPerson.PersonID;
            testingCard.IsValid = testingCard.TestingCardDetails.All(x => x.IsValid);

            var similiarCards = GetAll().Any(x => x.VIN == testingCard.VIN || x.CarSerialNo == testingCard.CarSerialNo);
            testingCard.IsFirstTesting = !similiarCards;

            Add(testingCard);

            SaveChanges();

            return testingCard.TestingCardID;
        }

        public void SaveTestingCardImages(int testingCardID, IEnumerable<byte[]> fileDatas)
        {
            var card = Get(testingCardID);

            string fileName = null;
            string filePath = null;

            var files = new List<string>();

            try
            {
                foreach (var item in fileDatas.Where(x => x != null))
                {
                    FileHelper.SaveImage(item, ref fileName, ref filePath);

                    files.Add(filePath);

                    card.Files.Add(new File
                    {
                        FileName = fileName,
                        FilePath = filePath
                    });
                }
            }
            catch
            {
                foreach (var item in files)
                {
                    FileHelper.Delete(item);
                }
            }

            SaveChanges();
        }
    }
}
