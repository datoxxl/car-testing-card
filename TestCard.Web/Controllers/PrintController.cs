using ReportManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCard.Properties.Resources;
using TestCard.Web.Filters;

namespace TestCard.Web.Controllers
{
    [AuthorizationFilter]
    public class PrintController : PdfViewController
    {
        public ActionResult TestingCard(int id)
        {
            try
            {
                var model = GetTestingCardModel(id);
                if (model != null)
                {
                    return View(model);
                }
                else
                {
                    SetErrorMessage(GeneralResource.RecordNotExists);
                }
            }
            catch
            {
                SetErrorMessage();
            }

            return RedirectTo(Request.UrlReferrer.AbsoluteUri);
        }
    }
}
