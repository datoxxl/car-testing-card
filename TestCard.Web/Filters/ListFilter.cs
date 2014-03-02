using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCard.Web.Controllers;

namespace TestCard.Web.Filters
{
    public class ListFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as BaseController;
            var actionParams = filterContext.ActionParameters;
            if (actionParams.ContainsKey("showAll"))
            {
                controller.RouteData.Values.Add("showAll", actionParams["showAll"]);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}