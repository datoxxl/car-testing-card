using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCard.Domain;
using TestCard.Web.Controllers;

namespace TestCard.Web.Filters
{
    public class PermissionFilter : ActionFilterAttribute
    {
        private Permissions _Permission;
        private Objects _Object = Objects.Other;

        public PermissionFilter(Permissions permission)
        {
            _Permission = permission;
        }

        public PermissionFilter(Permissions permission, Objects obj)
            : this(permission)
        {
            _Object = obj;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as BaseController;

            if (_Object == Objects.Other)
            {
                Enum.TryParse<TestCard.Domain.Objects>(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, true, out _Object);
            }

            var allowAccess = true;

            if (_Object != Domain.Objects.Other)
            {
                var perm = controller.CurrentUser.Permissions[_Object];

                allowAccess = perm.HasFlag(_Permission);
            }

            if (allowAccess)
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                filterContext.Result = new EmptyResult();
            }
        }
    }
}