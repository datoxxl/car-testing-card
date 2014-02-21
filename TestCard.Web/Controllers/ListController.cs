using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCard.Domain.Helpers;
using TestCard.Domain.Services;
using TestCard.Web.Filters;

namespace TestCard.Web.Controllers
{
    [AuthorizationFilter]
    public class ListController : BaseController
    {
        public PartialViewResult Person(int? companyID)
        {
            using (var service = new PersonService())
            {
                string filterExpression = null;

                if(companyID.HasValue)
                {
                    filterExpression = string.Format("CompanyID == {0}", companyID);
                }

                var option = new DataFilterOption
                {
                    StartRowIndex = 0,
                    MaximumRows = 100,
                    SortByExpression = "LastName",
                    FilterExpression = filterExpression
                };

                var list = AutoMapper.Mapper.Map<List<Models.PersonListModel>>(service.GetAll(option).ToList());

                return PartialView(list);
            }
        }

        public PartialViewResult Company()
        {
            using (var service = new CompanyService())
            {
                var option = new DataFilterOption
                {
                    StartRowIndex = 0,
                    MaximumRows = 100,
                    SortByExpression = "CompanyName",
                    //FilterExpression = string.Format("CompanyID == {0}", companyID)
                };

                var list = AutoMapper.Mapper.Map<List<Models.CompanyListModel>>(service.GetAll(option).ToList());

                return PartialView(list);
            }
        }

        public PartialViewResult PersonChangeRequest()
        {
            using (var service = new PersonChangeRequestService())
            {
                var filter = new DataFilterOption
                {
                    StartRowIndex = 0,
                    MaximumRows = 100,
                    SortByExpression = "CreateDate DESC",
                    //FilterExpression = string.Format("CompanyID == {0}", companyID)
                };

                var list = AutoMapper.Mapper.Map<List<Models.PersonChangeRequestListModel>>(service.GetList(CurrentUser, filter));

                return PartialView(list);
            }
        }

        public PartialViewResult PersonScheduleChangeRequest()
        {
            using (var service = new PersonScheduleChangeRequestService())
            {
                var filter = new DataFilterOption
                {
                    StartRowIndex = 0,
                    MaximumRows = 100,
                    SortByExpression = "CreateDate DESC",
                    //FilterExpression = string.Format("CompanyID == {0}", companyID)
                };

                var list = AutoMapper.Mapper.Map<List<Models.PersonScheduleChangeRequestListModel>>(service.GetList(CurrentUser, filter));

                return PartialView(list);
            }
        }
    }
}
