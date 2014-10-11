using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCard.Domain.Helpers;
using System.Data.Entity;

namespace TestCard.Domain.Services
{
    public class TestingCardChangeRequestService : DomainServiceBase<TestingCardChangeRequest>
    {
        public TestingCardChangeRequestService() { }

        public TestingCardChangeRequestService(User currentUser)
            : base(currentUser) { }

        public bool SaveChangeRequest(TestingCardChangeRequest request, User currentPerson, ref bool? hasUnconfirmedRequest)
        {
            var now = DateTime.Now;
            int? personID = null;

            if (currentPerson != null)
            {
                personID = currentPerson.PersonID;
            }

            var codeService = new CodeService(this);

            //request.Number = codeService.NextCode(CodeTypes.TestingCardOrderNumber);
            if (request.TestingCardNumber == null)
            {
                request.TestingCardNumber = codeService.NextCode(CodeTypes.TestingCardNumber);
            }
            request.EffectiveDate = now;
            request.CreateDate = now;
            request.ResponsiblePersonID = personID;
            request.IsValid = !request.TestingCardDetailChangeRequests.Any(x => x.IsInvalid);

            if (personID.HasValue)
            {
                var accountType = currentPerson.AccountType;
                var rejectStatusID = (int)ConfirmStatuses.Rejected;
                hasUnconfirmedRequest = GetAll().Any(x => x.ResponsiblePersonID == request.ResponsiblePersonID
                    && !x.AdministratorConfirmStatusID.HasValue
                    && x.QualityManagerConfirmStatusID != rejectStatusID);

                switch (accountType)
                {
                    case AccountTypes.Administrator:
                        request.AdministratorConfirmDate = now;
                        request.AdministratorPersonID = personID;
                        request.AdministratorConfirmStatusID = (int)ConfirmStatuses.Approved;

                        request.QualityManagerConfirmDate = now;
                        request.QualityManagerPersonID = personID;
                        request.QualityManagerConfirmStatusID = (int)ConfirmStatuses.Approved;

                        new TestingCardService(this).SaveTestingCard(request);
                        break;
                    case AccountTypes.QualityManager:

                        if (hasUnconfirmedRequest == true)
                        {
                            return false;
                        }

                        request.QualityManagerConfirmDate = now;
                        request.QualityManagerPersonID = personID;
                        request.QualityManagerConfirmStatusID = (int)ConfirmStatuses.Approved;
                        break;
                    case AccountTypes.Operator:
                        if (hasUnconfirmedRequest == true)
                        {
                            return false;
                        }
                        break;
                    default:
                        break;
                }
            }

            Add(request);

            SaveChanges();

            return request.TestingCardChangeRequestID > 0;
        }

        public bool ChangeRequestStatus(int id, ConfirmStatuses status, AccountTypes type, int personID, ref bool? alreadyProcessed, ref bool? notApprovedByQualityManager)
        {
            var now = DateTime.Now;

            var request = Get(id);

            if (request == null)
            {
                return false;
            }

            switch (type)
            {
                case AccountTypes.Administrator:

                    if (request.QualityManagerConfirmStatusID == (int)ConfirmStatuses.Approved)
                    {
                        if (!request.AdministratorConfirmStatusID.HasValue)
                        {
                            request.AdministratorConfirmStatusID = (int)status;
                            request.AdministratorConfirmDate = now;
                            request.AdministratorPersonID = personID;

                            Update(request);

                            if (status == ConfirmStatuses.Approved)
                            {
                                new TestingCardService(this).SaveTestingCard(request);
                            }

                            SaveChanges();

                            return true;
                        }
                        else
                        {
                            alreadyProcessed = true;
                        }
                    }
                    else
                    {
                        notApprovedByQualityManager = true;
                    }
                    break;
                case AccountTypes.QualityManager:

                    if (!request.QualityManagerConfirmStatusID.HasValue)
                    {
                        request.QualityManagerConfirmStatusID = (int)status;
                        request.QualityManagerConfirmDate = now;
                        request.QualityManagerPersonID = personID;

                        Update(request);

                        SaveChanges();

                        return true;
                    }
                    else
                    {
                        alreadyProcessed = true;
                    }
                    break;
                default:
                    break;
            }

            return false;
        }

        public override IQueryable<TestingCardChangeRequest> GetAll(DataFilterOption option, bool secureObject = false)
        {
            return base.GetAll(option, secureObject)
                .Include(x => x.ResponsiblePerson)
                .Include(x => x.AdminConfirmStatus)
                .Include(x => x.QualityManagerConfirmStatus);
        }

        public override IQueryable<TestingCardChangeRequest> SecurityFilter(IQueryable<TestingCardChangeRequest> query)
        {
            var approvedStatus = (int)ConfirmStatuses.Approved;

            switch (_CurrentUser.AccountType)
            {
                case AccountTypes.Administrator:
                    query = query.Where(x => x.QualityManagerConfirmStatusID == approvedStatus);
                    break;
                case AccountTypes.QualityManager:
                    break;
                case AccountTypes.Operator:
                    query = query.Where(x => x.ResponsiblePersonID == _CurrentUser.PersonID);
                    break;
                default:
                    break;
            }

            return base.SecurityFilter(query);
        }
    }
}
