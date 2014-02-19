using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCard.Domain.Helpers;

namespace TestCard.Domain.Services
{
    public class PersonScheduleChangeRequestService : DomainServiceBase<PersonScheduleChangeRequest>
    {
        public bool SaveChangeRequest(int personID, List<PersonScheduleChangeRequestDetail> scheduleRequestDetails, int? responsiblePersonID)
        {
            var now = DateTime.Now;

            var request = new PersonScheduleChangeRequest();
            request.CreateDate = now;
            request.ResponsiblePersonID = responsiblePersonID;
            request.PersonID = personID;

            Add(request);

            foreach (var item in scheduleRequestDetails)
            {
                request.PersonScheduleChangeRequestDetails.Add(item);
            }

            SaveChanges();

            return request.PersonScheduleChangeRequestID > 0;
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

                            new PersonScheduleService(_DbContext).SavePersonSchedule(request.PersonID.Value, request.ResponsiblePersonID, request.PersonScheduleChangeRequestDetails.ToList());

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

        public List<PersonScheduleChangeRequest> GetList(v_person person, DataFilterOption filter)
        {
            var type = (AccountTypes)person.AccountTypeID;
            var result = GetAll().Where(x => x.Person.CompanyID == person.CompanyID);
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
                    result = result.Where(x => x.PersonID == personID);
                    break;
                default:
                    break;
            }

            return result.SortAndFilter(filter).ToList();
        }
    }
}
