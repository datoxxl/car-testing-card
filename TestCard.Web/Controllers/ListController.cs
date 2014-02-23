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
        public PartialViewResult Person(int? companyID, int pageIndex = 1)
        {
            using (var service = new PersonService())
            {
                string filterExpression = null;

                if (companyID.HasValue)
                {
                    filterExpression = string.Format("CompanyID == {0}", companyID);
                }

                var filter = new DataFilterOption
                {
                    PageIndex = pageIndex,
                    MaximumRows = 3,
                    SortByExpression = "LastName",
                    FilterExpression = filterExpression
                };

                var list = AutoMapper.Mapper.Map<List<Models.PersonListModel>>(service.GetAll(filter).ToList());

                return PartialView(new Models.PagedList<Models.PersonListModel>(list, filter.PageIndex, filter.MaximumRows, filter.TotalRowCount));
            }
        }

        public PartialViewResult Company(int pageIndex = 1)
        {
            using (var service = new CompanyService())
            {
                var filter = new DataFilterOption
                {
                    PageIndex = pageIndex,
                    MaximumRows = 3,
                    SortByExpression = "CompanyName",
                    //FilterExpression = string.Format("CompanyID == {0}", companyID)
                };

                var list = AutoMapper.Mapper.Map<List<Models.CompanyListModel>>(service.GetAll(filter).ToList());

                return PartialView(new Models.PagedList<Models.CompanyListModel>(list, filter.PageIndex, filter.MaximumRows, filter.TotalRowCount));
            }
        }

        public PartialViewResult PersonChangeRequest(int pageIndex = 1)
        {
            using (var service = new PersonChangeRequestService())
            {
                var filter = new DataFilterOption
                {
                    PageIndex = pageIndex,
                    MaximumRows = 3,
                    SortByExpression = "CreateDate DESC",
                    //FilterExpression = string.Format("CompanyID == {0}", companyID)
                };

                var list = AutoMapper.Mapper.Map<List<Models.PersonChangeRequestListModel>>(service.GetList(CurrentUser, filter));

                return PartialView(new Models.PagedList<Models.PersonChangeRequestListModel>(list, filter.PageIndex, filter.MaximumRows, filter.TotalRowCount));
            }
        }

        public PartialViewResult PersonScheduleChangeRequest(int pageIndex = 1)
        {
            using (var service = new PersonScheduleChangeRequestService())
            {
                var filter = new DataFilterOption
                {
                    PageIndex = pageIndex,
                    MaximumRows = 3,
                    SortByExpression = "CreateDate DESC",
                    //FilterExpression = string.Format("CompanyID == {0}", companyID)
                };

                var list = AutoMapper.Mapper.Map<List<Models.PersonScheduleChangeRequestListModel>>(service.GetList(CurrentUser, filter));

                return PartialView(new Models.PagedList<Models.PersonScheduleChangeRequestListModel>(list, filter.PageIndex, filter.MaximumRows, filter.TotalRowCount));
            }
        }

        public PartialViewResult TestingCard(int pageIndex = 1)
        {
            using (var service = new TestingCardService())
            {
                var filter = new DataFilterOption
                {
                    PageIndex = pageIndex,
                    MaximumRows = 3,
                    SortByExpression = "EffectiveDate DESC",
                    //FilterExpression = string.Format("CompanyID == {0}", companyID)
                };

                var list = AutoMapper.Mapper.Map<List<Models.TestingCardListModel>>(service.GetList(CurrentUser, filter));

                return PartialView(new Models.PagedList<Models.TestingCardListModel>(list, filter.PageIndex, filter.MaximumRows, filter.TotalRowCount));
            }
        }

        public PartialViewResult TestingCardChangeRequest(int pageIndex = 1)
        {
            using (var service = new TestingCardChangeRequestService())
            {
                var filter = new DataFilterOption
                {
                    PageIndex = pageIndex,
                    MaximumRows = 3,
                    SortByExpression = "CreateDate DESC",
                    //FilterExpression = string.Format("CompanyID == {0}", companyID)
                };

                var list = AutoMapper.Mapper.Map<List<Models.TestingCardChangeRequestListModel>>(service.GetList(CurrentUser, filter));

                return PartialView(new Models.PagedList<Models.TestingCardChangeRequestListModel>(list, filter.PageIndex, filter.MaximumRows, filter.TotalRowCount));
            }
        }
    }
}
