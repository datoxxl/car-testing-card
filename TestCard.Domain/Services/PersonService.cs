using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TestCard.Domain.Helpers;

namespace TestCard.Domain.Services
{
    public class PersonService : DomainServiceBase<Person>
    {
        public PersonService() { }

        public PersonService(TestCardContext context)
            : base(context) { }

        public v_person Login(string idNumber, string password)
        {
            var per = _DbContext.People
                .FirstOrDefault(x => x.IDNo == idNumber && x.Password == password);

            if (per != null)
            {
                return new v_person
                    {
                        AccountTypeID = per.AccountTypeID,
                        AccountTypeName = per.AccountType.AccountTypeName,
                        CompanyID = per.CompanyID,
                        CompanyName = per.Company.CompanyName,
                        EffectiveDate = per.EffectiveDate,
                        Email = per.Email,
                        FileID = per.FileID,
                        FirstName = per.FirstName,
                        IDNo = per.IDNo,
                        LastName = per.LastName,
                        Mobile = per.Mobile,
                        Password = per.Password,
                        PersonID = per.PersonID,
                        ResponsiblePersonID = per.ResponsiblePersonID,
                        SystemIDNo = per.SystemIDNo
                    };
            }

            return null;
        }

        public bool SavePerson(PersonChangeRequest request)
        {
            var now = DateTime.Now;

            var id = request.PersonID;

            var person = Get(id);

            //Archive old person record
            if (person != null)
            {
                _DbContext.PersonHistories.Add(new PersonHistory
                {
                    AccountTypeID = person.AccountTypeID,
                    CompanyID = person.CompanyID ?? 0,
                    EffectiveDate = person.EffectiveDate,
                    Email = person.Email,
                    FileID = person.FileID,
                    FirstName = person.FirstName,
                    IDNo = person.IDNo,
                    LastName = person.LastName,
                    Mobile = person.Mobile,
                    Password = person.Password,
                    PersonID = person.PersonID,
                    ResponsiblePersonID = person.ResponsiblePersonID,
                    SystemIDNo = person.SystemIDNo,
                    CreateDate = now
                });

                foreach (var sch in person.PersonSchedules.ToList())
                {
                    _DbContext.PersonSchedules.Remove(sch);

                    _DbContext.PersonScheduleHistories.Add(new PersonScheduleHistory
                    {
                        BreakEndTime = sch.BreakEndTime,
                        BreakStartTime = sch.BreakStartTime,
                        EffectiveDate = sch.EffectiveDate,
                        EndTime = sch.EndTime,
                        PersonID = sch.PersonID,
                        ResponsiblePersonID = sch.ResponsiblePersonID,
                        StartTime = sch.StartTime,
                        WeekDayNumber = sch.WeekDayNumber,
                        CreateDate = now
                    });
                }

                Update(person);
            }
            else
            {
                person = new Person();
                person.EffectiveDate = now;

                Add(person);
            }

            //Update person
            person.AccountTypeID = request.AccountTypeID;
            person.CompanyID = request.CompanyID;
            person.Email = request.Email;
            person.FileID = request.FileID;
            person.FirstName = request.FirstName;
            person.IDNo = request.IDNo;
            person.LastName = request.LastName;
            person.Mobile = request.Mobile;
            person.Password = request.Password;
            person.ResponsiblePersonID = request.ResponsiblePersonID;
            person.SystemIDNo = request.SystemIDNo;

            foreach (var sch in request.PersonScheduleChangeRequests)
            {
                person.PersonSchedules.Add(new PersonSchedule
                {
                    BreakEndTime = sch.BreakEndTime,
                    BreakStartTime = sch.BreakStartTime,
                    EffectiveDate = sch.EffectiveDate,
                    EndTime = sch.EndTime,
                    PersonID = sch.PersonID ?? 0,
                    ResponsiblePersonID = sch.ResponsiblePersonID,
                    StartTime = sch.StartTime,
                    WeekDayNumber = sch.WeekDayNumber
                });
            }

            return true;
        }
    }
}
