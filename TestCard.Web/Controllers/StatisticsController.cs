using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

    }
}
