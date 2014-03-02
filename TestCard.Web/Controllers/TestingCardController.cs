using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using TestCard.Domain.Services;
using TestCard.Properties.Resources;
using TestCard.Web.Filters;
using TestCard.Web.Helpers;

namespace TestCard.Web.Controllers
{
    [AuthorizationFilter]
    public class TestingCardController : BaseController
    {
        public ActionResult List()
        {
            return View();
        }

        public ActionResult View(int? id)
        {
            return GetModel(id ?? -1);
        }

        public ActionResult Add()
        {
            var model = new Models.TestingCardModel();
            ModelDataHelper.Populate(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Models.TestingCardModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var service = new TestingCardService())
                    {
                        var testingCard = AutoMapper.Mapper.Map<TestCard.Domain.TestingCard>(model);

                        testingCard.TestingCardDetails = AutoMapper.Mapper.Map<List<TestCard.Domain.TestingCardDetail>>(model.TestingSteps.SelectMany(x => x.TestingSubSteps));

                        var testingCardID = service.SaveTestingCard(testingCard, CurrentUser);

                        SetSuccessMessage();

                        return RedirectToAction("Edit", new { id = testingCardID });
                    }
                }
            }
            catch
            {
                SetErrorMessage();
            }

            ModelDataHelper.Populate(model);

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            return GetModel(id ?? -1);
        }

        [HttpPost]
        public ActionResult Edit(int id, Models.TestingCardModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var service = new TestingCardChangeRequestService())
                    {
                        var testingCard = AutoMapper.Mapper.Map<Domain.TestingCardChangeRequest>(model);

                        testingCard.TestingCardDetailChangeRequests = AutoMapper.Mapper.Map<List<TestCard.Domain.TestingCardDetailChangeRequest>>(model.TestingSteps.SelectMany(x => x.TestingSubSteps));

                        bool? hasUnconfirmedRequest = null;
                        var saved = service.SaveChangeRequest(testingCard, CurrentUser, ref hasUnconfirmedRequest);

                        if (saved)
                        {
                            SetSuccessMessage();

                            if ((Domain.AccountTypes)CurrentUser.AccountTypeID == Domain.AccountTypes.Administrator)
                            {
                                //return RedirectToAction("Edit", RouteData.Values);
                                return RedirectToAction("List");
                            }
                            else
                            {
                                return RedirectToAction("List", "TestingCardChangeRequest");
                            }
                        }
                        else if (hasUnconfirmedRequest == true)
                        {
                            SetErrorMessage(GeneralResource.UserHasUnconfirmedRequest);
                        }
                    }
                }
            }
            catch
            {
                SetErrorMessage();
            }

            ModelDataHelper.Populate(model);

            return View(model);
        }

        public ActionResult Images(int? id)
        {
            return GetTestingCardImages(id ?? -1);
        }

        public ActionResult AddImages(int? id)
        {
            return GetTestingCardImages(id ?? -1);
        }

        [HttpPost]
        public ActionResult AddImages(int id, HttpPostedFileWrapper[] files)
        {
            try
            {
                var fileDatas = new List<byte[]>();

                files = files.Where(x => x != null).ToArray();

                if (files.Length == 0)
                {
                    SetErrorMessage(GeneralResource.NoImagesFound);

                    return RedirectTo(Request.UrlReferrer.AbsoluteUri);
                }

                foreach (var file in files)
                {
                    if (file != null && file.ContentType != MediaTypeNames.Image.Jpeg)
                    {
                        SetErrorMessage(GeneralResource.ImageAllowedMessage);

                        return RedirectTo(Request.UrlReferrer.AbsoluteUri);
                    }
                    else
                    {
                        fileDatas.Add(GetFileData(file));
                    }
                }

                using (var service = new TestingCardService())
                {
                    service.SaveTestingCardImages(id, fileDatas);
                }

                SetSuccessMessage();
            }
            catch
            {
                SetErrorMessage();
            }

            return RedirectTo(Request.UrlReferrer.AbsoluteUri);
        }

        private ActionResult GetModel(int id)
        {
            try
            {
                var model = GetTestingCardModel(id);
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

        private ActionResult GetTestingCardImages(int id)
        {
            using (var service = new TestingCardService())
            {
                var card = service.Get(id);

                if (card == null)
                {
                    SetErrorMessage(GeneralResource.RecordNotExists);

                    return RedirectTo(Request.UrlReferrer.AbsoluteUri);
                }

                return View(card.Files.Select(x => x.FileName));
            }
        }
    }
}
