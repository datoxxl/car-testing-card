using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCard.Domain.Helpers;
using TestCard.Domain.Services;
using TestCard.Properties.Resources;
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

                var list = AutoMapper.Mapper.Map<Models.ModelList<Models.PersonListModel>>(service.GetAll(filter, true).ToList());

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

                var list = AutoMapper.Mapper.Map<Models.ModelList<Models.CompanyListModel>>(service.GetAll(filter, true).ToList());

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

                var list = AutoMapper.Mapper.Map<Models.ModelList<Models.PersonChangeRequestListModel>>(service.GetAll(filter, true));

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

                var list = AutoMapper.Mapper.Map<Models.ModelList<Models.PersonScheduleChangeRequestListModel>>(service.GetAll(filter, true));

                return PartialView(new Models.PagedList<Models.PersonScheduleChangeRequestListModel>(list, filter.PageIndex, filter.MaximumRows, filter.TotalRowCount));
            }
        }

        [PermissionFilter(Domain.Permissions.View, TestCard.Domain.Objects.TestingCard)]
        public PartialViewResult TestingCard(int? companyID, int pageIndex = 1)
        {
            companyID = companyID ?? CurrentUser.CompanyID;

            using (var service = new TestingCardService(CurrentUser))
            {
                var filter = new DataFilterOption
                {
                    PageIndex = pageIndex,
                    MaximumRows = 10,
                    SortByExpression = "EffectiveDate DESC",
                    FilterExpression = companyID != -1
                        ? string.Format("Person.CompanyID == {0}", companyID) : null
                };

                var list = AutoMapper.Mapper.Map<Models.ModelList<Models.TestingCardListModel>>(service.GetAll(filter, true));

                if (CurrentUser.AccountType == Domain.AccountTypes.Administrator)
                {
                    var filterItems = new List<Models.ListFilter.Item>();

                    using (var companyService = new CompanyService(service))
                    {
                        filterItems.AddRange(companyService.GetAll()
                            .Select(x => new { x.CompanyID, x.CompanyName })
                            .ToList()
                            .Select(x => new Models.ListFilter.Item
                        {
                            Name = x.CompanyName,
                            Value = x.CompanyID.ToString(),
                            Selected = x.CompanyID == CurrentUser.CompanyID
                        }));
                    }

                    filterItems.Add(new Models.ListFilter.Item { Name = GeneralResource.All, Value = "-1" });

                    list.Filter = new Models.ListFilter
                    {
                        Name = "CompanyID",
                        Items = filterItems
                    };
                }

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

                var list = AutoMapper.Mapper.Map<Models.ModelList<Models.TestingCardChangeRequestListModel>>(service.GetAll(filter, true));

                return PartialView(new Models.PagedList<Models.TestingCardChangeRequestListModel>(list, filter.PageIndex, filter.MaximumRows, filter.TotalRowCount));
            }
        }

        [PermissionFilter(Domain.Permissions.View, TestCard.Domain.Objects.Statistics)]
        public PartialViewResult CompanyStatistic(int pageIndex = 1)
        {
            using (var service = new CompanyStatisticService(CurrentUser))
            {
                var filter = new DataFilterOption
                {
                    PageIndex = pageIndex,
                    MaximumRows = int.MaxValue,
                    SortByExpression = "Company.CompanyName"
                };

                var list = AutoMapper.Mapper.Map<Models.ModelList<Models.CompanyStatisticListModel>>(service.GetAll(filter, true).ToList());

                return PartialView(new Models.PagedList<Models.CompanyStatisticListModel>(list, filter.PageIndex, filter.MaximumRows, filter.TotalRowCount));
            }
        }

        [PermissionFilter(Domain.Permissions.View, TestCard.Domain.Objects.Statistics)]
        public PartialViewResult PersonStatistic(int pageIndex = 1)
        {
            using (var service = new PersonStatisticService(CurrentUser))
            {
                var filter = new DataFilterOption
                {
                    PageIndex = pageIndex,
                    MaximumRows = 10,
                    SortByExpression = "Person.Company.CompanyName"
                };

                var list = AutoMapper.Mapper.Map<Models.ModelList<Models.PersonStatisticListModel>>(service.GetAll(filter, true).ToList());

                return PartialView(new Models.PagedList<Models.PersonStatisticListModel>(list, filter.PageIndex, filter.MaximumRows, filter.TotalRowCount));
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
