using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCard.Web.Helpers
{
    public static class UrlHelper
    {
        public static string FullUrl(this System.Web.Mvc.UrlHelper helper, string url)
        {
            var request = HttpContext.Current.Request;

            var resultUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, helper.Content("~"));

            resultUrl += url;

            return resultUrl;
        }
    }
}