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
        public bool SaveCompany(Company company, int responsiblePersonID, byte[] companyLogo)
        {
            string fileName = null;
            string filePath = null;
            string oldFilePath = null;

            try
            {
                if (companyLogo != null)
                {
                    do
                    {
                        fileName = Guid.NewGuid().ToString() + ".jpeg";
                        filePath = System.IO.Path.GetFullPath(Config.FilePath + fileName);
                    } while (System.IO.File.Exists(filePath));

                    using (var file = System.IO.File.Open(filePath, System.IO.FileMode.OpenOrCreate))
                    {
                        file.Write(companyLogo, 0, companyLogo.Length);
                    }

                    if (company.File != null)
                    {
                        oldFilePath = company.File.FilePath;
                    }

                    company.File = new File { FileName = fileName, FilePath = filePath };
                }

                var today = DateTime.Now;

                company.EffectiveDate = today;
                company.ResponsiblePersonID = responsiblePersonID;

                if (company.CompanyID == 0)
                {
                    Add(company);
                }
                else
                {
                    Update(company);
                }

                SaveChanges();

                if (oldFilePath != null)
                {
                    System.IO.File.Delete(oldFilePath);
                }
            }
            catch(Exception ex)
            {
                if (filePath != null)
                {
                    System.IO.File.Delete(filePath);
                }

                throw ex;
            }

            return company.CompanyID > 0;
        }


    }
}
