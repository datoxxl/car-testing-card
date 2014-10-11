using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TestCard.Domain.Helpers;
using System.Data.Entity;

namespace TestCard.Domain.Services
{
    public class PersonService : DomainServiceBase<Person>
    {
        public PersonService(User currentUser)
            : base(currentUser) { }

        public PersonService(DomainServiceBase service)
            : base(service) { }

        public User Login(string idNumber, string password)
        {
            var per = _DbContext.People
                .FirstOrDefault(x => x.IDNo == idNumber && x.Password == password);

            if (per != null)
            {
                return new User
                    {
                        AccountType = (AccountTypes)per.AccountTypeID,
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
                        SystemIDNo = per.SystemIDNo,
                        Permissions = per.AccountType.ObjectPermissions
                            .ToDictionary(x => (Objects)x.ObjectID, x => (Permissions)x.Permission)
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

                Update(person);
            }
            else
            {
                person = new Person();
                person.EffectiveDate = now;
                person.Password = request.Password;

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
            person.ResponsiblePersonID = request.ResponsiblePersonID;
            person.SystemIDNo = request.SystemIDNo;

            if (request.Person == null)
            {
                request.Person = person;
            }

            return true;
        }

        public override IQueryable<Person> GetAll(DataFilterOption option, bool secureObject = false)
        {
            return base.GetAll(option, secureObject).Include(x => x.Company).Include(x => x.AccountType);
        }

        public override IQueryable<Person> SecurityFilter(IQueryable<Person> query)
        {
            switch (_CurrentUser.AccountType)
            {
                case AccountTypes.Administrator:
                    break;
                case AccountTypes.QualityManager:
                    query = query.Where(x => x.CompanyID == _CurrentUser.CompanyID);
                    break;
                case AccountTypes.Operator:
                    query = query.Where(x => x.PersonID == _CurrentUser.PersonID);
                    break;
                default:
                    break;
            }

            return base.SecurityFilter(query);
        }
    }
}
