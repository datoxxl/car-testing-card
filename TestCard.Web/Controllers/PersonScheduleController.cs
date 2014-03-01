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
    public class PersonScheduleController : BaseController
    {
        public ActionResult List()
        {
            return View();
        }

        public ActionResult View(int? id)
        {
            return GetModel(id ?? -1);
        }

        public ActionResult Edit(int? id)
        {
            return GetModel(id ?? -1);
        }

        [HttpPost]
        public ActionResult Edit(int id, Models.PersonScheduleModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var service = new PersonScheduleChangeRequestService())
                    {
                        var request = new Domain.PersonScheduleChangeRequest { PersonID = id };
                        var details = AutoMapper.Mapper.Map<List<Domain.PersonScheduleChangeRequestDetail>>(model.Days);

                        bool? hasUnconfirmedRequest = null;
                        var saved = service.SaveChangeRequest(request, details, CurrentUser, ref hasUnconfirmedRequest);

                        if (saved)
                        {
                            SetSuccessMessage();
                            if ((Domain.AccountTypes)CurrentUser.AccountTypeID == Domain.AccountTypes.Administrator)
                            {
                                //return RedirectToAction("Edit", RouteData.Values);
                                return RedirectToAction("List", "Person");
                            }
                            else
                            {
                                return RedirectToAction("List", "PersonChangeRequest");
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

        public ActionResult GetModel(int id)
        {
            try
            {
                using (var service = new PersonService())
                {
                    var source = service.Get(id);

                    if (source != null)
                    {
                        var model = new Models.PersonScheduleModel();
                        model.PersonID = id;
                        model.Days = AutoMapper.Mapper.Map<List<Models.PersonScheduleModel.Day>>(source.PersonSchedules.ToList());

                        ModelDataHelper.Populate(model);

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
