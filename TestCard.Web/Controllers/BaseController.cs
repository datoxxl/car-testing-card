using TestCard.Properties;
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
        public v_person CurrentUser
        {
            get
            {
                try
                {
                    return Session["CurrentUser"] as v_person;
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

        protected byte[] GetFileData(HttpPostedFileWrapper file)
        {
            if (file == null)
            {
                return null;
            }

            var arr = new byte[file.ContentLength];

            file.InputStream.Read(arr, 0, file.ContentLength);

            return arr;
        }

        #region Model sources

        protected Models.TestingCardModel GetTestingCardModel(int id)
        {
            using (var service = new TestingCardService())
            {
                var source = service.Get(id);

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
                            x.IsValid = item.IsValid;
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