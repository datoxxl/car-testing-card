using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TestCard.Domain.Services
{
    public class PersonService : DomainServiceBase<Person>
    {
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
    }
}
