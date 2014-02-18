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
    public class UserChangeRequestController : BaseController
    {
        public ActionResult List()
        {
            return View();
        }

        public ActionResult View(int id)
        {
            try
            {
                using (var service = new PersonChangeRequestService())
                {
                    var source = service.Get(id);

                    if (source != null)
                    {
                        var model = new Models.PersonModel();
                        model.UserInfo = AutoMapper.Mapper.Map(source, model.UserInfo);
                        model.Schedule = new Models.PersonScheduleModel();
                        model.Schedule.Days = AutoMapper.Mapper.Map<List<Models.PersonScheduleModel.Day>>(source.PersonScheduleChangeRequests.ToList());

                        ModelDataHelper.PopulateRegisterModel(model.UserInfo);
                        ModelDataHelper.PopulatePersonScheduleModel(model.Schedule);

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
