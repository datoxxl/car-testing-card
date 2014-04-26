﻿using TestCard.Properties;
using TestCard.Properties.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TestCard.Domain;
using TestCard.Domain.Services;
using TestCard.Web.Helpers;

namespace TestCard.Web.Controllers
{
    public class BaseController : Controller
    {
        public User CurrentUser
        {
            get
            {
                try
                {
                    return Session["CurrentUser"] as User;
                }
                catch { return null; }
            }
            set
            {
                Session["CurrentUser"] = value;
            }
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            var culture = new CultureInfo(Config.DefaultCulture);

            culture.NumberFormat.NumberDecimalSeparator = ".";

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            base.Initialize(requestContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as BaseController;

            if (controller.CurrentUser != null)
            {
                controller.ViewBag.AccountType = controller.CurrentUser.AccountType;
                controller.ViewBag.Permissions = controller.CurrentUser.Permissions;
            }

            base.OnActionExecuting(filterContext);
        }

        public class ImageResult : ActionResult
        {
            public string SourceFilename { get; set; }
            public MemoryStream SourceStream { get; set; }
            public string ContentType { get; set; }

            public ImageResult(string sourceFilename)
            {
                SourceFilename = sourceFilename;
                ContentType = FileHelper.GetContentType(SourceFilename);
            }

            public ImageResult(MemoryStream sourceStream, string contentType)
            {
                SourceStream = sourceStream;
                ContentType = contentType;
            }

            public override void ExecuteResult(ControllerContext context)
            {
                var res = context.HttpContext.Response;
                res.Clear();
                res.Cache.SetCacheability(HttpCacheability.NoCache);
                res.ContentType = ContentType;

                if (SourceStream != null)
                {
                    SourceStream.WriteTo(res.OutputStream);
                }
                else
                {
                    res.TransmitFile(SourceFilename);
                }
            }
        }

        protected JsonResult JsonError()
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = GeneralResource.ErrorOccured });
        }

        protected void SetErrorMessage(string message = null)
        {
            message = message ?? GeneralResource.ErrorOccured;
            ViewBag.ErrorMessage = message;
            TempData["ErrorMessage"] = message;
        }

        protected void SetSuccessMessage(string message = null)
        {
            message = message ?? GeneralResource.DataSaved;
            ViewBag.SuccessMessage = message;
            TempData["SuccessMessage"] = message;
        }

        protected ActionResult RedirectTo(string url = null)
        {
            if (url != null)
            {
                return Redirect(url);
            }

            return RedirectToAction("Index", "Home");
        }

        #region Model sources

        protected Models.TestingCardModel GetTestingCardModel(int id)
        {
            using (var service = new TestingCardService(CurrentUser))
            {
                var source = service.Get(id, true);

                if (source != null)
                {
                    var model = new Models.TestingCardModel();
                    model = AutoMapper.Mapper.Map(source, model);
                    var subSteps = AutoMapper.Mapper.Map<List<Models.TestingSubStep>>(source.TestingCardDetails);

                    ModelDataHelper.Populate(model);

                    model.TestingSteps.SelectMany(x => x.TestingSubSteps).ToList().ForEach(
                        x =>
                        {
                            var item = subSteps.FirstOrDefault(y => y.TestingSubStepID == x.TestingSubStepID);
                            x.IsInvalid = item.IsInvalid;
                            x.IsChecked = item.IsChecked;
                        }
                    );

                    return model;
                }
            }

            return null;
        }

        #endregion
    }
}