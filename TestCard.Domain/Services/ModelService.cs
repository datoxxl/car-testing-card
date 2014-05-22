using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TestCard.Domain.Services
{
    public class ModelService : DomainServiceBase<Model>
    {
        public ModelService() { }

        public ModelService(DomainServiceBase service)
            : base(service) { }

        public Model[] Search(string brandName, string searchString)
        {
            return this.GetAll()
                .Where(x => x.Visible && x.Brand.Name.Equals(brandName) && x.Name.Contains(searchString))
                .OrderBy(x => x.Name)
                .ToArray();
        }

        public void Save(string carBrand, string carModel)
        {
            var brandService = new BrandService(this);
            var brand = brandService.Save(carBrand);

            if (brand != null && !string.IsNullOrEmpty(carModel) 
                && !brand.Models.Any(x => x.Name.ToLower().Equals(carModel.ToLower())))
            {
                var model = new Model
                {
                    Name = carModel,
                    CreateDate = DateTime.Now,
                    CreatePersonID = _CurrentUser.PersonID,
                    Visible = true
                };

                brand.Models.Add(model);
                if (brand.BrandID > 0)
                {
                    brandService.Update(brand);
                }
            }
        }
    }
}
