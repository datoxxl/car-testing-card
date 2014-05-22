using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TestCard.Domain.Services
{
    public class BrandService : DomainServiceBase<Brand>
    {
        public BrandService() { }

        public BrandService(DomainServiceBase service)
            : base(service) { }

        public Brand[] Search(string searchString)
        {
            return this.GetAll()
                .Where(x => x.Visible && x.Name.Contains(searchString))
                .OrderBy(x => x.Name)
                .ToArray();
        }

        public Brand Save(string carBrand)
        {
            if(string.IsNullOrEmpty(carBrand))
            {
                return null;
            }

            var item = this.GetAll()
                .Include(x => x.Models)
                .FirstOrDefault(x => x.Name.ToLower().Equals(carBrand.ToLower()));

            if(item == null)
            {
                item = new Brand
                {
                    Name = carBrand,
                    CreateDate = DateTime.Now,
                    CreatePersonID = _CurrentUser.PersonID,
                    Visible = true
                };

                this.Add(item);
            }

            return item;
        }
    }
}
