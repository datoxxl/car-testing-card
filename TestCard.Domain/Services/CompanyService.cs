using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCard.Properties;

namespace TestCard.Domain.Services
{
    public class CompanyService : DomainServiceBase<Company>
    {
        public bool AddCompany(Company company, int responsiblePersonID, byte[] companyLogo)
        {
            if (companyLogo != null)
            {
                var fileName = string.Empty;
                var filePath = string.Empty;

                do
                {
                    fileName = Guid.NewGuid().ToString() + ".jpeg";
                    filePath = System.IO.Path.GetFullPath(Config.FilePath + fileName);
                } while (System.IO.File.Exists(filePath));

                using (var file = System.IO.File.Open(filePath, System.IO.FileMode.OpenOrCreate))
                {
                    file.Write(companyLogo, 0, companyLogo.Length);
                }

                company.File = new File { FileName = fileName, FilePath = filePath };
            }

            var today = DateTime.Now;

            company.EffectiveDate = today;
            company.ResponsiblePersonID = responsiblePersonID;

            _DbContext.Companies.Add(company);

            SaveChanges();

            return company.CompanyID > 0;
        }
    }
}
