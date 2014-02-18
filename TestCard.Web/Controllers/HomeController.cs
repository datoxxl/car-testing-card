using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCard.Web.Filters;
using TestCard.Web;

namespace TestCard.Web.Controllers
{
    [AuthorizationFilter]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult UserOptions()
        {
            var user = CurrentUser;

            return PartialView(new Models.UserOptions { AccountType = user.AccountTypeName, FullName = user.FirstName + " " + user.LastName });
        }

        public ImageResult GetImage(string id)
        {
            return new ImageResult(Properties.Config.FilePath + id);
        }
    }
}
