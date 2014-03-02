using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCard.Domain.Helpers;
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
                    FileHelper.SaveImage(companyLogo, ref fileName, ref filePath);

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
                    FileHelper.Delete(oldFilePath);
                }
            }
            catch (Exception ex)
            {
                if (filePath != null)
                {
                    FileHelper.Delete(oldFilePath);
                }

                throw ex;
            }

            return company.CompanyID > 0;
        }
    }
}
