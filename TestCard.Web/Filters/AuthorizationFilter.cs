using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using TestCard.Web.Controllers;
using TestCard.Web.Security;

namespace TestCard.Web.Filters
{
    public class AuthorizationFilter : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (AppAuth.CurrentUser == null)
            {
                return false;
            }

            return base.AuthorizeCore(httpContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                AppAuth.Logout();
            }

            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}