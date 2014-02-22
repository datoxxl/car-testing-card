using ReportManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCard.Web.Filters;

namespace TestCard.Web.Controllers
{
    [AuthorizationFilter]
    public class PrintController : PdfViewController
    {
        public ActionResult TestingCard(int id)
        {
            return View(GetTestingCardModel(id));
        }
    }
}
