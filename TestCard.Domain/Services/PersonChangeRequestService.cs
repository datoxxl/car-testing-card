using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCard.Domain.Helpers;

namespace TestCard.Domain.Services
{
    public class PersonChangeRequestService : DomainServiceBase<PersonChangeRequest>
    {
        public bool SavePersonChangeRequest(PersonChangeRequest personRequest, IEnumerable<PersonScheduleChangeRequest> scheduleRequest, int? responsiblePerson)
        {
            var now = DateTime.Now;

            personRequest.EffectiveDate = now;
            personRequest.CreateDate = now;
            personRequest.ResponsiblePersonID = responsiblePerson;

            if (personRequest.PersonID.HasValue)
            {
                if (scheduleRequest != null)
                {
                    foreach (var item in scheduleRequest)
                    {
                        item.EffectiveDate = now;
                        item.ResponsiblePersonID = responsiblePerson;
                        item.CreateDate = now;
                        item.PersonID = personRequest.PersonID.Value;

                        personRequest.PersonScheduleChangeRequests.Add(item);
                    }
                }
            }

            Add(personRequest);
            SaveChanges();

            return personRequest.PersonChangeRequestID > 0;
        }

        public bool ChangeRequestStatus(int id, ConfirmStatuses status, AccountTypes type, int personID, ref bool? alreadyProcessed, ref bool? notApprovedByQualityManager)
        {
            var now = DateTime.Now;

            PersonChangeRequest request = Get(id);

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

                            new PersonService(_DbContext).SavePerson(request);

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

        public List<PersonChangeRequest> GetList(int companyID, AccountTypes type, DataFilterOption filter)
        {
            var result = GetAll().Where(x => x.CompanyID == companyID);

            switch (type)
            {
                case AccountTypes.Administrator:
                    var approvedStatus = (int)ConfirmStatuses.Approved;
                    result = result.Where(x => x.QualityManagerConfirmStatusID == approvedStatus 
                        && !x.AdministratorConfirmStatusID.HasValue);
                    break;
                case AccountTypes.QualityManager:
                    result = result.Where(x => !x.QualityManagerConfirmStatusID.HasValue);
                    break;
                default:
                    return null;
            }

            return result.SortAndFilter(filter).ToList();
        }
    }
}
