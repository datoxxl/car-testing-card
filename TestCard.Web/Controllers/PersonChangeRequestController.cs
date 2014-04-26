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
    public class PersonChangeRequestController : BaseController
    {
        public static object lockObject = new object();

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
                using (var service = new PersonChangeRequestService(CurrentUser))
                {
                    var source = service.Get(id ?? -1, true);

                    if (source != null)
                    {
                        var model = new Models.PersonModel();
                        model = AutoMapper.Mapper.Map(source, model);
                        //model.Schedule = new Models.PersonScheduleModel();
                        //model.Schedule.Days = AutoMapper.Mapper.Map<List<Models.PersonScheduleModel.Day>>(source.PersonScheduleChangeRequests.ToList());

                        ModelDataHelper.Populate(model);
                        //ModelDataHelper.PopulatePersonScheduleModel(model.Schedule);

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

            return RedirectToAction("List", "PersonChangeRequest");
        }

        [HttpPost]
        [PermissionFilter(TestCard.Domain.Permissions.Edit)]
        public ActionResult ProcessRequest(int id, Domain.ConfirmStatuses status)
        {
            try
            {
                lock (lockObject)
                {
                    using (var service = new PersonChangeRequestService())
                    {
                        bool? alreadyProcessed = null;
                        bool? notApprovedByQualityManager = null;

                        var saved = service.ChangeRequestStatus(id,
                            status,
                            CurrentUser.AccountType,
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

            return RedirectToAction("List", "PersonChangeRequest");
        }
    }
}
