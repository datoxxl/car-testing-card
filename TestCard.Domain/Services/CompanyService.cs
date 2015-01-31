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
        public CompanyService()
        { }

        public CompanyService(PersonInfo currentUser)
            : base(currentUser)
        { }

        public bool SaveCompany(Company company, int responsiblePersonID, byte[] companyLogo, byte[] accreditationLogo)
        {
            string[] filePath = new string[2];
            string[] oldFilePath = new string[2];

            try
            {
                if (companyLogo != null)
                {
                    company.CompanyLogoFile =
                        CreateImageFile(company.CompanyLogoFile, companyLogo, ref filePath[0], ref oldFilePath[0]);
                }

                if (accreditationLogo != null)
                {
                    company.AccreditationLogoFile =
                        CreateImageFile(company.AccreditationLogoFile, accreditationLogo, ref filePath[1], ref oldFilePath[1]);
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

                foreach (var item in oldFilePath)
                {
                    if (item != null)
                    {
                        FileHelper.Delete(item);
                    }
                }
            }
            catch (Exception ex)
            {
                foreach (var item in filePath)
                {
                    if (item != null)
                    {
                        FileHelper.Delete(item);
                    }
                }

                throw ex;
            }

            return company.CompanyID > 0;
        }

        private File CreateImageFile(File oldFile, byte[] data, ref string filePath, ref string oldFilePath)
        {
            string fileName = null;

            FileHelper.SaveImage(data, ref fileName, ref filePath);

            if (oldFile != null)
            {
                oldFilePath = oldFile.FilePath;
            }

            return new File { FileName = fileName, FilePath = filePath };
        }

        public override IQueryable<Company> SecurityFilter(IQueryable<Company> query)
        {
            switch (_CurrentUser.AccountType)
            {
                case AccountTypes.Administrator:
                    break;
                case AccountTypes.QualityManager:
                case AccountTypes.Operator:
                    query = query.Where(x => x.CompanyID == _CurrentUser.CompanyID);
                    break;
                default:
                    break;
            }

            return query;
        }
    }
}
