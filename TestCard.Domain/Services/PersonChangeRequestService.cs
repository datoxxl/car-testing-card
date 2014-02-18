using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
