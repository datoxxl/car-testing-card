using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCard.Web.Filters;
using TestCard.Web;
using TestCard.Properties.Resources;
using TestCard.Domain.Services;
using System.Net.Mime;

namespace TestCard.Web.Controllers
{
    [AuthorizationFilter]
    public class CompanyController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = new List<Models.CompanyListModel>();

            using (var service = new CompanyService())
            {
                service.GetAll()
                    .ToList()
                    .ForEach(x => list.Add(AutoMapper.Mapper.Map<TestCard.Domain.Company, Models.CompanyListModel>(x)));
            }

            return View(list);
        }

        public ActionResult Add()
        {
            var model = new Models.CompanyModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Models.CompanyModel model, HttpPostedFileWrapper file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null && file.ContentType != MediaTypeNames.Image.Jpeg)
                    {
                        ViewBag.ErrorMessage = GeneralResource.ImageAllowedMessage;
                    }
                    else
                    {
                        using (var service = new CompanyService())
                        {
                            var per = AutoMapper.Mapper.Map<Models.CompanyModel, TestCard.Domain.Company>(model);
                            per.ResponsiblePersonID = CurrentUser.PersonID;

                            service.AddCompany(per, CurrentUser.PersonID, GetFileData(file));
                        }

                        ViewBag.SuccessMessage = GeneralResource.DataSaved;
                    }
                }
            }
            catch
            {
                ViewBag.ErrorMessage = GeneralResource.ErrorOccured;
            }

            return View(model);
        }

        public ActionResult Edit()
        {

            return View();
        }
    }
}
