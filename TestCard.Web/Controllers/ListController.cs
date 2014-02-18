using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCard.Domain.Services;
using TestCard.Web.Filters;

namespace TestCard.Web.Controllers
{
    [AuthorizationFilter]
    public class ListController : BaseController
    {
        public PartialViewResult Person()
        {
            var list = new List<Models.PersonListModel>();

            using (var service = new PersonService())
            {
                service.GetAll()
                    .ToList()
                    .ForEach(x => list.Add(AutoMapper.Mapper.Map<Domain.Person, Models.PersonListModel>(x)));
            }

            return PartialView(list);
        }

        public PartialViewResult Company()
        {
            var list = new List<Models.CompanyListModel>();

            using (var service = new CompanyService())
            {
                service.GetAll()
                    .ToList()
                    .ForEach(x => list.Add(AutoMapper.Mapper.Map<TestCard.Domain.Company, Models.CompanyListModel>(x)));
            }

            return PartialView(list);
        }

        public PartialViewResult PersonChangeRequest()
        {
            var list = new List<Models.PersonListModel>();

            using (var service = new PersonChangeRequestService())
            {
                service.GetAll()
                    .ToList()
                    .ForEach(x => list.Add(AutoMapper.Mapper.Map<Domain.PersonChangeRequest, Models.PersonListModel>(x)));
            }

            return PartialView(list);
        }
    }
}
