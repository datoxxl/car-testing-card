﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using TestCard.Domain.Services;
using TestCard.Properties.Resources;
using TestCard.Web.Helpers;

namespace TestCard.Web.Controllers
{
    public class AuthorizationController : BaseController
    {
        public ActionResult Login()
        {
            return View(new TestCard.Web.Models.LoginModel());
        }

        [HttpPost]
        public ActionResult Login(TestCard.Web.Models.LoginModel model, [QueryString]string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (var service = new PersonService())
                {
                    var per = service.Login(model.IdNumber, model.Password);

                    if (per != null)
                    {
                        CurrentUser = per;
                        //TO DO: Authentication cookie Request.Cookies.Add(new HttpCookie("auth", per.PersonID));

                        return RedirectTo(returnUrl);
                    }
                }
            }

            SetErrorMessage(GeneralResource.PasswordNotValid);
            return View(model);
        }

        public ActionResult Logout()
        {
            CurrentUser = null;

            return RedirectTo();
        }

        public ActionResult Register()
        {
            var model = new TestCard.Web.Models.RegisterModel();
            ModelDataHelper.Populate(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Register(TestCard.Web.Models.RegisterModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var service = new PersonChangeRequestService())
                    {
                        var per = AutoMapper.Mapper.Map<Models.RegisterModel, TestCard.Domain.PersonChangeRequest>(model);

                        bool? hasUnconfirmedRequest = null;
                        service.SaveChangeRequest(per, null, ref hasUnconfirmedRequest);
                    }

                   SetSuccessMessage(GeneralResource.RegistrationComplete);

                   return RedirectTo();
                }
            }
            catch
            {
                SetErrorMessage();
            }

            ModelDataHelper.Populate(model);

            return View(model);
        }
    }
}
