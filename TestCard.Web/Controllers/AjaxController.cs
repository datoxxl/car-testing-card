using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCard.Domain.Services;

namespace TestCard.Web.Controllers
{
    public class AjaxController : BaseController
    {
        public JsonResult GetBrands(string term)
        {
            TestCard.Domain.Brand[] arr = null;

            using (var service = new BrandService())
            {
                arr = service.Search(term);
            }

            return Json(arr.Select(x => new { label = x.Name }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetModels(string brandName, string term)
        {
            TestCard.Domain.Model[] arr = null;

            using (var service = new ModelService())
            {
                arr = service.Search(brandName, term);
            }

            return Json(arr.Select(x => new { label = x.Name }), JsonRequestBehavior.AllowGet);
        }
    }
}
