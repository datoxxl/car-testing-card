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
        [PermissionFilter(TestCard.Domain.Permissions.View)]
        public ActionResult List()
        {
            return View();
        }

        [PermissionFilter(TestCard.Domain.Permissions.View)]
        public ActionResult View(int? id)
        {
            return GetModel(id ?? -1);
        }

        [PermissionFilter(TestCard.Domain.Permissions.Add)]
        public ActionResult Add()
        {
            var model = new TestCard.Web.Models.RegisterModel();
            ModelDataHelper.Populate(model);

            return View(model);
        }

        [HttpPost]
        [PermissionFilter(TestCard.Domain.Permissions.Add)]
        public ActionResult Add(TestCard.Web.Models.RegisterModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var service = new PersonChangeRequestService())
                    {
                        var per = AutoMapper.Mapper.Map<Models.RegisterModel, TestCard.Domain.PersonChangeRequest>(model);

                        bool? hasUnconfirmedRequest = null;
                        var saved = service.SaveChangeRequest(per, CurrentUser, ref hasUnconfirmedRequest);

                        if (saved)
                        {
                            SetSuccessMessage();
                            if (CurrentUser.AccountType == Domain.AccountTypes.Administrator)
                            {
                                //return RedirectToAction("Edit", new { @id = per.PersonID });
                                return RedirectToAction("List");
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

        [PermissionFilter(TestCard.Domain.Permissions.Edit)]
        public ActionResult Edit(int? id)
        {
            return GetModel(id ?? -1);
        }

        [HttpPost]
        [PermissionFilter(TestCard.Domain.Permissions.Edit)]
        public ActionResult Edit(int id, Models.PersonModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var service = new PersonChangeRequestService())
                    {
                        var per = AutoMapper.Mapper.Map<Domain.PersonChangeRequest>(model);

                        bool? hasUnconfirmedRequest = null;
                        var saved = service.SaveChangeRequest(per, CurrentUser, ref hasUnconfirmedRequest);

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
                using (var service = new PersonService(CurrentUser))
                {
                    var source = service.Get(id, true);

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
