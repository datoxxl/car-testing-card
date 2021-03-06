﻿using System;
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
        [PermissionFilter(TestCard.Domain.Permissions.View)]
        public ActionResult List()
        {
            return View();
        }

        [PermissionFilter(TestCard.Domain.Permissions.View)]
        public ActionResult View(int? id)
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

        [PermissionFilter(TestCard.Domain.Permissions.Add)]
        public ActionResult Add()
        {
            var model = GetTestingCardModel();

            return View(model);
        }

        [HttpPost]
        [PermissionFilter(TestCard.Domain.Permissions.Add)]
        public ActionResult Add(Models.TestingCardModel model, HttpPostedFileWrapper[] files)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var service = new TestingCardService(CurrentUser))
                    {
                        var testingCard = AutoMapper.Mapper.Map<TestCard.Domain.TestingCard>(model);

                        bool incorrectFormat = false;

                        var images = GetImages(files, ref incorrectFormat);

                        if (incorrectFormat)
                        {
                            SetErrorMessage(GeneralResource.ImageAllowedMessage);
                        }
                        else
                        {
                            var testingCardID = service.SaveTestingCard(testingCard, images, CurrentUser);

                            SetSuccessMessage();

                            return RedirectToAction("Edit", new { id = testingCardID });
                        }
                    }
                }
            }
            catch
            {
                SetErrorMessage();
            }

            return View(model);
        }

        [PermissionFilter(TestCard.Domain.Permissions.Edit)]
        public ActionResult Edit(int? id)
        {
            try
            {
                var cardModel = GetTestingCardModel(id);
                var model = new Models.TestingCardChangeRequestModel();

                AutoMapper.Mapper.Map(cardModel, model);

                ModelDataHelper.Populate(model);

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

        [HttpPost]
        [PermissionFilter(TestCard.Domain.Permissions.Edit)]
        public ActionResult Edit(int id, Models.TestingCardChangeRequestModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var service = new TestingCardChangeRequestService(CurrentUser))
                    {
                        var testingCard = AutoMapper.Mapper.Map<Domain.TestingCardChangeRequest>(model);

                        bool? hasUnconfirmedRequest = null;
                        var saved = service.SaveChangeRequest(testingCard, CurrentUser, ref hasUnconfirmedRequest);

                        if (saved)
                        {
                            SetSuccessMessage();

                            if (CurrentUser.AccountType == Domain.AccountTypes.Administrator)
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

        [PermissionFilter(TestCard.Domain.Permissions.View)]
        public ActionResult Images(int? id)
        {
            return GetTestingCardImages(id ?? -1);
        }

        [PermissionFilter(TestCard.Domain.Permissions.Add)]
        public ActionResult AddImages(int? id)
        {
            return GetTestingCardImages(id ?? -1);
        }

        [HttpPost]
        [PermissionFilter(TestCard.Domain.Permissions.Add)]
        public ActionResult AddImages(int id, HttpPostedFileWrapper[] files)
        {
            try
            {
                if (files.Length == 0)
                {
                    SetErrorMessage(GeneralResource.NoImagesFound);

                    return RedirectTo(Request.UrlReferrer.AbsoluteUri);
                }

                bool incorrectFormat = false;

                var images = GetImages(files, ref incorrectFormat);

                if (incorrectFormat)
                {
                    SetErrorMessage(GeneralResource.ImageAllowedMessage);
                }
                else
                {
                    using (var service = new TestingCardService(CurrentUser))
                    {
                        service.SaveTestingCardImages(id, images);
                    }

                    SetSuccessMessage();
                }
            }
            catch
            {
                SetErrorMessage();
            }

            return RedirectTo(Request.UrlReferrer.AbsoluteUri);
        }

        [PermissionFilter(TestCard.Domain.Permissions.View)]
        private ActionResult GetTestingCardImages(int id)
        {
            using (var service = new TestingCardService(CurrentUser))
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

        public List<byte[]> GetImages(HttpPostedFileWrapper[] files, ref bool incorrectFormat)
        {
            var fileDatas = new List<byte[]>();

            files = files.Where(x => x != null).ToArray();

            foreach (var file in files)
            {
                if (FileHelper.IsNullOrOfType(file, FileHelper.FileType.WebImage))
                {
                    fileDatas.Add(FileHelper.GetFileData(file));
                }
                else
                {
                    incorrectFormat = true;
                }
            }

            return fileDatas;
        }
    }
}
