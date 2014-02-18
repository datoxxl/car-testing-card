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
            Mapper.CreateMap<Models.RegisterModel, Domain.PersonChangeRequest>();
            Mapper.CreateMap<Models.PersonScheduleModel.Day, Domain.PersonScheduleChangeRequest>();
            Mapper.CreateMap<Models.CompanyModel, Domain.Company>();

            Mapper.CreateMap<Domain.Person, Models.RegisterModel>()
                .ForMember(dest => dest.CompanyName, src => src.MapFrom(x => x.Company.CompanyName))
                .ForMember(dest => dest.AccountTypeName, src => src.MapFrom(x => x.AccountType.AccountTypeName));
            Mapper.CreateMap<Domain.PersonChangeRequest, Models.RegisterModel>()
                .ForMember(dest => dest.CompanyName, src => src.MapFrom(x => x.Company.CompanyName))
                .ForMember(dest => dest.AccountTypeName, src => src.MapFrom(x => x.AccountType.AccountTypeName));
            Mapper.CreateMap<Domain.PersonScheduleChangeRequest, Models.PersonScheduleModel.Day>();
            Mapper.CreateMap<Domain.PersonSchedule, Models.PersonScheduleModel.Day>();
            Mapper.CreateMap<Domain.Company, Models.CompanyListModel>();
            Mapper.CreateMap<Domain.Company, Models.CompanyModel>()
                .ForMember(dest => dest.FileName, src => src.MapFrom(x => x.File.FileName));
            Mapper.CreateMap<Domain.Person, Models.PersonListModel>()
                .ForMember(dest => dest.CompanyName, src => src.MapFrom(x => x.Company.CompanyName))
                .ForMember(dest => dest.AccountTypeName, src => src.MapFrom(x => x.AccountType.AccountTypeName));
            Mapper.CreateMap<Domain.PersonChangeRequest, Models.PersonListModel>()
                .ForMember(dest => dest.CompanyName, src => src.MapFrom(x => x.Company.CompanyName))
                .ForMember(dest => dest.AccountTypeName, src => src.MapFrom(x => x.AccountType.AccountTypeName));
        }
    }
}