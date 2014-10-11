using ReportManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCard.Domain.Services;
using TestCard.Properties.Resources;
using TestCard.Web.Filters;
using TestCard.Web.Helpers;
using TestCard.Web.Models;

namespace TestCard.Web.Controllers
{
    [AuthorizationFilter]
    public class PrintController : BaseController
    {
        public ActionResult TestingCard(int id)
        {
            try
            {
                var model = new TestingCardPrintModel();

                using (var service = new TestingCardService(CurrentUser))
                {
                    var card = service.GetForPrint(id);

                    AutoMapper.Mapper.Map(card, model);
                }

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
