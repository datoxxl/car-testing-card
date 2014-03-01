using System;
using System.Collections.Generic;
using System.Linq;
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

                        service.SaveTestingCard(testingCard, CurrentUser);

                        SetSuccessMessage();

                        return RedirectToAction("List");
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
    }
}
