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
    public class TestingCardChangeRequestController : BaseController
    {
        public static object lockObject = new object();

        public ActionResult List()
        {
            return View();
        }

        public ActionResult View(int? id)
        {
            try
            {
                using (var service = new TestingCardChangeRequestService())
                {
                    var source = service.Get(id);

                    if (source != null)
                    {
                        var model = new Models.TestingCardChangeRequestModel();
                        model = AutoMapper.Mapper.Map(source, model);
                        var subSteps = AutoMapper.Mapper.Map<List<Models.TestingSubStep>>(source.TestingCardDetailChangeRequests);

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

            return RedirectToAction("List", "TestingCardChangeRequest");
        }

        [HttpPost]
        public ActionResult ProcessRequest(int id, Domain.ConfirmStatuses status)
        {
            try
            {
                lock (lockObject)
                {
                    using (var service = new TestingCardChangeRequestService())
                    {
                        bool? alreadyProcessed = null;
                        bool? notApprovedByQualityManager = null;

                        var saved = service.ChangeRequestStatus(id,
                            status,
                            (Domain.AccountTypes)CurrentUser.AccountTypeID,
                            CurrentUser.PersonID,
                            ref alreadyProcessed,
                            ref notApprovedByQualityManager);

                        if (saved)
                        {
                            if (status == Domain.ConfirmStatuses.Approved)
                            {
                                SetSuccessMessage(GeneralResource.RequestApproved);
                            }
                            else
                            {
                                SetSuccessMessage(GeneralResource.RequestRejected);
                            }
                        }
                        else
                        {
                            if (alreadyProcessed == true)
                            {
                                SetErrorMessage(GeneralResource.RequestAlreadyProcessed);
                            }

                            if (notApprovedByQualityManager == true)
                            {
                                SetErrorMessage(GeneralResource.RequestNotApprovedByQualityManager);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                SetErrorMessage();
            }

            return RedirectToAction("List", "TestingCardChangeRequest");
        }
    }
}
