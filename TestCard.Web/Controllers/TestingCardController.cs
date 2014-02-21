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

        public ActionResult View(int id)
        {
            return GetModel(id);
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
                    using (var service = new TestingCardChangeRequestService())
                    {
                        var testingCard = AutoMapper.Mapper.Map<TestCard.Domain.TestingCardChangeRequest>(model);

                        testingCard.TestingCardDetailChangeRequests = AutoMapper.Mapper.Map<List<TestCard.Domain.TestingCardDetailChangeRequest>>(model.TestingSteps.SelectMany(x => x.TestingSubSteps));

                        bool? hasUnconfirmedRequest = null;
                        var saved = service.SaveChangeRequest(testingCard, CurrentUser, ref hasUnconfirmedRequest);

                        if (saved)
                        {
                            SetSuccessMessage();
                            return RedirectToAction("List");
                        }
                        else if (hasUnconfirmedRequest == true)
                        {
                            SetErrorMessage(GeneralResource.UserHasUnconfirmedRequest);
                        }

                        SetSuccessMessage();

                        return RedirectToAction("Edit", new { @id = testingCard.TestingCardID });
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

        public ActionResult Edit(int id)
        {
            return GetModel(id);
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
                            return RedirectToAction("Edit", RouteData.Values);
                        }
                        else if (hasUnconfirmedRequest == true)
                        {
                            SetErrorMessage(GeneralResource.UserHasUnconfirmedRequest);
                        }
                    }

                    SetSuccessMessage();
                    return RedirectToAction("Edit", RouteData.Values);
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
                using (var service = new TestingCardService())
                {
                    var source = service.Get(id);

                    if (source != null)
                    {
                        var model = new Models.TestingCardModel();
                        model = AutoMapper.Mapper.Map(source, model);
                        var subSteps = AutoMapper.Mapper.Map<List<Models.TestingCardModel.TestingSubStep>>(source.TestingCardDetails);

                        ModelDataHelper.Populate(model);

                        model.TestingSteps.SelectMany(x => x.TestingSubSteps).ToList().ForEach(
                            x =>
                            {
                                var item = subSteps.FirstOrDefault(y => y.TestingSubStepID == x.TestingSubStepID);
                                x.IsValid = item.IsValid;
                            }
                        );

                        return View(model);
                    }
                    else
                    {
                        SetErrorMessage(GeneralResource.RecordNotExists);
                    }
                }
            }
            catch
            {
                SetErrorMessage();
            }

            return RedirectToAction("List");
        }
    }
}
