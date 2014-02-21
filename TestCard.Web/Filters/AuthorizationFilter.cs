using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestCard.Web.Controllers;

namespace TestCard.Web.Filters
{
    public class AuthorizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as BaseController;

            if (controller.CurrentUser != null)
            {
                controller.ViewBag.AccountType = (TestCard.Domain.AccountTypes)controller.CurrentUser.AccountTypeID;
                base.OnActionExecuting(filterContext);
                return;
            }

            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { 
                { "controller", "Authorization" },
                { "action", "Login" },
                { "returnUrl", filterContext.HttpContext.Request.Url.PathAndQuery } 
            });
        }
    }
}