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
    public class StatisticsController : BaseController
    {
        [PermissionFilter(TestCard.Domain.Permissions.View)]
        public ActionResult Index()
        {
            return View();
        }

        [PermissionFilter(TestCard.Domain.Permissions.Edit)]
        [HttpPost]
        public ActionResult RecalculateCompanyStatistics()
        {
            using (var service = new CompanyStatisticService(CurrentUser))
            {
                service.Recalculate();
            }

            return RedirectToAction("Index");
        }

        [PermissionFilter(TestCard.Domain.Permissions.Edit)]
        [HttpPost]
        public ActionResult RecalculatePErsonStatistics()
        {
            using (var service = new PersonStatisticService(CurrentUser))
            {
                service.Recalculate();
            }

            return RedirectToAction("Index");
        }
    }
}
