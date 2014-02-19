using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCard.Domain.Services
{
    public class PersonScheduleService : DomainServiceBase<PersonSchedule>
    {
        public PersonScheduleService() { }

        public PersonScheduleService(TestCardContext context)
            : base(context) { }

        public bool SavePersonSchedule(int personID, int? responsiblePersonID, List<PersonScheduleChangeRequestDetail> request)
        {
            var now = DateTime.Now;

            var person = _DbContext.People.FirstOrDefault(x => x.PersonID == personID);

            //Archive old person record
            if (person != null)
            {
                foreach (var item in person.PersonSchedules.ToList())
                {
                    _DbContext.PersonScheduleHistories.Add(new PersonScheduleHistory
                    {
                        BreakEndTime = item.BreakEndTime,
                        BreakStartTime = item.BreakStartTime,
                        EffectiveDate = item.EffectiveDate,
                        EndTime = item.EndTime,
                        PersonID = item.PersonID,
                        ResponsiblePersonID = item.ResponsiblePersonID,
                        StartTime = item.StartTime,
                        WeekDayNumber = item.WeekDayNumber,
                        CreateDate = now
                    });

                    _DbContext.PersonSchedules.Remove(item);
                }
            }

            foreach (var sch in request)
            {
                person.PersonSchedules.Add(new PersonSchedule
                {
                    BreakEndTime = sch.BreakEndTime,
                    BreakStartTime = sch.BreakStartTime,
                    EffectiveDate = now,
                    EndTime = sch.EndTime,
                    PersonID = personID,
                    ResponsiblePersonID = responsiblePersonID,
                    StartTime = sch.StartTime,
                    WeekDayNumber = sch.WeekDayNumber
                });
            }

            return true;
        }
    }
}
