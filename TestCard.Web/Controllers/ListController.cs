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
    [AuthorizationFilter, ListFilter]
    public class ListController : BaseController
    {
        [PermissionFilter(Domain.Permissions.View, TestCard.Domain.Objects.Person)]
        public PartialViewResult Person(int? companyID, int pageIndex = 1)
        {
            using (var service = new PersonService(CurrentUser))
            {
                string filterExpression = null;

                if (companyID.HasValue)
                {
                    filterExpression = string.Format("CompanyID == {0}", companyID);
                }

                var filter = new DataFilterOption
                {
                    PageIndex = pageIndex,
                    MaximumRows = 10,
                    SortByExpression = "LastName",
                    FilterExpression = filterExpression
                };

                var list = AutoMapper.Mapper.Map<List<Models.PersonListModel>>(service.GetAll(filter, true).ToList());

                return PartialView(new Models.PagedList<Models.PersonListModel>(list, filter.PageIndex, filter.MaximumRows, filter.TotalRowCount));
            }
        }

        [PermissionFilter(Domain.Permissions.View, TestCard.Domain.Objects.Company)]
        public PartialViewResult Company(int pageIndex = 1)
        {
            using (var service = new CompanyService(CurrentUser))
            {
                var filter = new DataFilterOption
                {
                    PageIndex = pageIndex,
                    MaximumRows = 10,
                    SortByExpression = "CompanyName"
                };

                var list = AutoMapper.Mapper.Map<List<Models.CompanyListModel>>(service.GetAll(filter, true).ToList());

                return PartialView(new Models.PagedList<Models.CompanyListModel>(list, filter.PageIndex, filter.MaximumRows, filter.TotalRowCount));
            }
        }

        [PermissionFilter(Domain.Permissions.View, TestCard.Domain.Objects.PersonChangeRequest)]
        public PartialViewResult PersonChangeRequest(int pageIndex = 1, bool showAll = false)
        {
            using (var service = new PersonChangeRequestService(CurrentUser))
            {
                var filter = new DataFilterOption
                {
                    PageIndex = pageIndex,
                    MaximumRows = 10,
                    SortByExpression = "CreateDate DESC",
                    FilterExpression = GetChangeRequestFilter(showAll)
                };

                var list = AutoMapper.Mapper.Map<List<Models.PersonChangeRequestListModel>>(service.GetAll(filter, true));

                return PartialView(new Models.PagedList<Models.PersonChangeRequestListModel>(list, filter.PageIndex, filter.MaximumRows, filter.TotalRowCount));
            }
        }

        [PermissionFilter(Domain.Permissions.View, TestCard.Domain.Objects.PersonScheduleChangeRequest)]
        public PartialViewResult PersonScheduleChangeRequest(int pageIndex = 1, bool showAll = false)
        {
            using (var service = new PersonScheduleChangeRequestService(CurrentUser))
            {
                var filter = new DataFilterOption
                {
                    PageIndex = pageIndex,
                    MaximumRows = 10,
                    SortByExpression = "CreateDate DESC",
                    FilterExpression = GetChangeRequestFilter(showAll)
                };

                var list = AutoMapper.Mapper.Map<List<Models.PersonScheduleChangeRequestListModel>>(service.GetAll(filter, true));

                return PartialView(new Models.PagedList<Models.PersonScheduleChangeRequestListModel>(list, filter.PageIndex, filter.MaximumRows, filter.TotalRowCount));
            }
        }

        [PermissionFilter(Domain.Permissions.View, TestCard.Domain.Objects.TestingCard)]
        public PartialViewResult TestingCard(int pageIndex = 1)
        {
            using (var service = new TestingCardService(CurrentUser))
            {
                var filter = new DataFilterOption
                {
                    PageIndex = pageIndex,
                    MaximumRows = 10,
                    SortByExpression = "EffectiveDate DESC"
                };

                var list = AutoMapper.Mapper.Map<List<Models.TestingCardListModel>>(service.GetAll(filter, true));

                return PartialView(new Models.PagedList<Models.TestingCardListModel>(list, filter.PageIndex, filter.MaximumRows, filter.TotalRowCount));
            }
        }

        [PermissionFilter(Domain.Permissions.View, TestCard.Domain.Objects.TestingCardChangeRequest)]
        public PartialViewResult TestingCardChangeRequest(int pageIndex = 1, bool showAll = false)
        {
            using (var service = new TestingCardChangeRequestService(CurrentUser))
            {
                var filter = new DataFilterOption
                {
                    PageIndex = pageIndex,
                    MaximumRows = 10,
                    SortByExpression = "CreateDate DESC",
                    FilterExpression = GetChangeRequestFilter(showAll)
                };

                var list = AutoMapper.Mapper.Map<List<Models.TestingCardChangeRequestListModel>>(service.GetAll(filter, true));

                return PartialView(new Models.PagedList<Models.TestingCardChangeRequestListModel>(list, filter.PageIndex, filter.MaximumRows, filter.TotalRowCount));
            }
        }

        private string GetChangeRequestFilter(bool showAll)
        {
            if (!showAll)
            {
                return string.Format("!AdministratorConfirmStatusID.HasValue && (!QualityManagerConfirmStatusID.HasValue || QualityManagerConfirmStatusID == {0})",
                    (int)TestCard.Domain.ConfirmStatuses.Approved);
            }

            return null;
        }
    }
}
