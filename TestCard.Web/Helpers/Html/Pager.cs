using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Mvc.Ajax;
using TestCard.Web.Models;
using TestCard.Properties.Resources;

namespace TestCard.Web.Helpers.Html
{
    public static class PagerHelper
    {
        public static void Pager(this HtmlHelper helper, IPagedList list, string targetID, string actionName, string controllerName = null)
        {
            var html = string.Empty;

            controllerName = controllerName ?? "List";

            var pageIndex = list.PageIndex;
            var totalPageCount = list.TotalPageCount;
            var totalItemCount = list.TotalItemCount;

            if (pageIndex > totalPageCount)
            {
                pageIndex = totalPageCount;
            }
            else if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            var prevPageIndex = pageIndex > 1 ? pageIndex - 1 : -1;
            var nextPageIndex = pageIndex < totalPageCount ? pageIndex + 1 : -1;
            var firstPageIndex = pageIndex > 1 ? 1 : -1;
            var lastPageIndex = pageIndex < totalPageCount ? totalPageCount : -1;

            using (new AjaxHelper(helper.ViewContext, helper.ViewDataContainer).BeginForm(actionName, controllerName, helper.ViewContext.GetCombinedRouteValues(null), new AjaxOptions
            {
                UpdateTargetId = targetID,
                InsertionMode = InsertionMode.Replace,
                HttpMethod = "POST",
            }))
            {
                var container = new TagBuilder("div");
                container.AddCssClass("x-pager");

                var firstLink = GetNavLink(firstPageIndex, "first");
                var prevLink = GetNavLink(prevPageIndex, "prev");
                var nextLink = GetNavLink(nextPageIndex, "next");
                var lastLink = GetNavLink(lastPageIndex, "last");
                var refreshLink = GetNavLink(pageIndex, "refresh");

                var pageInput = new TagBuilder("input");
                pageInput.Attributes.Add("type", "text");
                pageInput.AddCssClass("page-num");
                pageInput.Attributes.Add("value", pageIndex.ToString());

                var pageHidden = new TagBuilder("input");
                pageHidden.Attributes.Add("name", "pageIndex");
                pageHidden.Attributes.Add("id", "pageIndex");
                pageHidden.Attributes.Add("type", "hidden");
                pageHidden.Attributes.Add("value", pageIndex.ToString());

                var pageTotalHidden = new TagBuilder("input");
                pageTotalHidden.Attributes.Add("id", "pageTotal");
                pageTotalHidden.Attributes.Add("type", "hidden");
                pageTotalHidden.Attributes.Add("value", totalPageCount.ToString());

                var pageText = new TagBuilder("span");
                pageText.AddCssClass("page-text");
                pageText.InnerHtml = string.Format(" of {0}", totalPageCount);

                var recordText = new TagBuilder("span");
                recordText.AddCssClass("record-text");
                recordText.InnerHtml = string.Format("{0}: {1}", GeneralResource.TotalRecords, totalItemCount);

                var separator = new TagBuilder("span");
                separator.AddCssClass("sep");

                container.InnerHtml =
                      firstLink
                    + prevLink
                    + separator.ToString(TagRenderMode.Normal)
                    + pageInput.ToString(TagRenderMode.SelfClosing)
                    + pageHidden.ToString(TagRenderMode.SelfClosing)
                    + pageTotalHidden.ToString(TagRenderMode.SelfClosing)
                    + pageText.ToString(TagRenderMode.Normal)
                    + separator.ToString(TagRenderMode.Normal)
                    + nextLink
                    + lastLink
                    + separator.ToString(TagRenderMode.Normal)
                    + refreshLink
                    + recordText.ToString(TagRenderMode.Normal);

                helper.ViewContext.Writer.Write(new MvcHtmlString(container.ToString(TagRenderMode.Normal)));
            }
        }

        private static string GetNavLink(int pageIndex, string cssClass)
        {
            var result = new TagBuilder("span");
            result.AddCssClass(cssClass);

            if (pageIndex != -1)
            {
                result.Attributes.Add("data-page", pageIndex.ToString());
            }
            else
            {
                result.AddCssClass("dis");
            }

            return result.ToString(TagRenderMode.Normal);
        }
    }
}