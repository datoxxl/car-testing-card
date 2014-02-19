﻿using System;
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
    public class PersonController : BaseController
    {
        public ActionResult List()
        {
            return View();
        }

        public ActionResult View(int id)
        {
            return GetModel(id);
        }

        public ActionResult Edit(int id)
        {
            return GetModel(id);
        }

        [HttpPost]
        public ActionResult Edit(int id, Models.PersonModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var service = new PersonChangeRequestService())
                    {
                        var per = AutoMapper.Mapper.Map<Domain.PersonChangeRequest>(model);

                        List<Domain.PersonScheduleChangeRequest> scheduleList = new List<Domain.PersonScheduleChangeRequest>();

                        service.SaveChangeRequest(per, CurrentUser.PersonID);
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

        public ActionResult GetModel(int id)
        {
            try
            {
                using (var service = new PersonService())
                {
                    var source = service.Get(id);

                    if (source != null)
                    {
                        var model = new Models.PersonModel();
                        model = AutoMapper.Mapper.Map(source, model);
                        //model.Schedule = new Models.PersonScheduleModel();
                        //model.Schedule.Days = AutoMapper.Mapper.Map<List<Models.PersonScheduleModel.Day>>(source.PersonSchedules.ToList());

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

            return RedirectToAction("List");
        }
    }
}