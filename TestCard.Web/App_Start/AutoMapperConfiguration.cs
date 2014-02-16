using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCard.Web
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new GeneralProfile());
            });
        }
    }

    public class GeneralProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Models.RegisterModel, TestCard.Domain.PersonChangeRequest>();
            Mapper.CreateMap<Models.CompanyListModel, TestCard.Domain.Company>();
            Mapper.CreateMap<TestCard.Domain.Company, Models.CompanyListModel>();
            Mapper.CreateMap<Models.CompanyModel, TestCard.Domain.Company>();
        }
    }
}