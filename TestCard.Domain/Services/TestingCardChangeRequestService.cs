using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCard.Domain.Helpers;

namespace TestCard.Domain.Services
{
    public class TestingCardChangeRequestService : DomainServiceBase<TestingCardChangeRequest>
    {
        public bool SaveChangeRequest(TestingCardChangeRequest request, v_person currentPerson, ref bool? hasUnconfirmedRequest)
        {
            var now = DateTime.Now;
            int? personID = null;

            if (currentPerson != null)
            {
                personID = currentPerson.PersonID;
            }

            request.EffectiveDate = now;
            request.CreateDate = now;
            request.ResponsiblePersonID = personID;

            if (personID.HasValue)
            {
                var accountType = (AccountTypes)currentPerson.AccountTypeID;
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

                        new TestingCardService(_DbContext).SaveTestingCard(request);
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

                            new TestingCardService(_DbContext).SaveTestingCard(request);

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

        public List<TestingCardChangeRequest> GetList(v_person person, DataFilterOption filter)
        {
            var type = (AccountTypes)person.AccountTypeID;
            var result = GetAll().Where(x => x.ResponsiblePerson.Company.CompanyID == person.CompanyID);
            var personID = person.PersonID;

            switch (type)
            {
                case AccountTypes.Administrator:
                    var approvedStatus = (int)ConfirmStatuses.Approved;
                    result = result.Where(x => x.QualityManagerConfirmStatusID == approvedStatus);
                    break;
                case AccountTypes.QualityManager:
                    break;
                case AccountTypes.Operator:
                    result = result.Where(x => x.ResponsiblePersonID == personID);
                    break;
                default:
                    break;
            }

            return result.SortAndFilter(filter).ToList();
        }
    }
}
