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
            Mapper.CreateMap<Models.PersonScheduleModel.Day, Domain.PersonScheduleChangeRequestDetail>();
            Mapper.CreateMap<Models.CompanyModel, Domain.Company>();

            Mapper.CreateMap<Models.PersonModel, Domain.PersonChangeRequest>();
            Mapper.CreateMap<Models.PersonModel, Domain.Person>();

            Mapper.CreateMap<Domain.Person, Models.RegisterModel>()
                .ForMember(dest => dest.CompanyName, src => src.MapFrom(x => x.Company.CompanyName))
                .ForMember(dest => dest.AccountTypeName, src => src.MapFrom(x => x.AccountType.AccountTypeName));
            Mapper.CreateMap<Domain.Person, Models.PersonModel>()
                .ForMember(dest => dest.CompanyName, src => src.MapFrom(x => x.Company.CompanyName))
                .ForMember(dest => dest.AccountTypeName, src => src.MapFrom(x => x.AccountType.AccountTypeName));
            Mapper.CreateMap<Domain.Person, Models.PersonListModel>()
                .ForMember(dest => dest.CompanyName, src => src.MapFrom(x => x.Company.CompanyName))
                .ForMember(dest => dest.AccountTypeName, src => src.MapFrom(x => x.AccountType.AccountTypeName));

            Mapper.CreateMap<Domain.PersonChangeRequest, Models.RegisterModel>()
                .ForMember(dest => dest.CompanyName, src => src.MapFrom(x => x.Company.CompanyName))
                .ForMember(dest => dest.AccountTypeName, src => src.MapFrom(x => x.AccountType.AccountTypeName));
            Mapper.CreateMap<Domain.PersonChangeRequest, Models.PersonModel>()
                .ForMember(dest => dest.CompanyName, src => src.MapFrom(x => x.Company.CompanyName))
                .ForMember(dest => dest.AccountTypeName, src => src.MapFrom(x => x.AccountType.AccountTypeName));
            Mapper.CreateMap<Domain.PersonChangeRequest, Models.PersonListModel>()
                .ForMember(dest => dest.CompanyName, src => src.MapFrom(x => x.Company.CompanyName))
                .ForMember(dest => dest.AccountTypeName, src => src.MapFrom(x => x.AccountType.AccountTypeName));

            Mapper.CreateMap<Domain.PersonScheduleChangeRequestDetail, Models.PersonScheduleModel.Day>();
            Mapper.CreateMap<Domain.PersonSchedule, Models.PersonScheduleModel.Day>();

            Mapper.CreateMap<Domain.PersonScheduleChangeRequest, Models.PersonScheduleChangeRequestListModel>()
                .ForMember(dest => dest.PersonFirstName, src => src.MapFrom(x => x.Person.FirstName))
                .ForMember(dest => dest.PersonLastName, src => src.MapFrom(x => x.Person.LastName))
                .ForMember(dest => dest.ResponsiblePersonFirstName, src => src.MapFrom(x => x.ResponsiblePerson.FirstName))
                .ForMember(dest => dest.ResponsiblePersonLastName, src => src.MapFrom(x => x.ResponsiblePerson.LastName))
                .ForMember(dest => dest.QualityManagerConfirmStatusName, src => src.MapFrom(x => x.QualityManagerConfirmStatus.ConfirmStatusName))
                .ForMember(dest => dest.AdministratorConfirmStatusName, src => src.MapFrom(x => x.AdminConfirmStatus.ConfirmStatusName))
                ;

            Mapper.CreateMap<Domain.Company, Models.CompanyListModel>();
            Mapper.CreateMap<Domain.Company, Models.CompanyModel>()
                .ForMember(dest => dest.FileName, src => src.MapFrom(x => x.File.FileName));

            Mapper.CreateMap<Domain.TestingCard, Models.TestingCardModel>()
               .ForMember(dest => dest.CompanyName, src => src.MapFrom(x => x.Person.Company.CompanyName))
               .ForMember(dest => dest.CompanyID, src => src.MapFrom(x => x.Person.CompanyID))
               .ForMember(dest => dest.RespPersonFullName, src => src.MapFrom(x => x.Person.FirstName + " " + x.Person.LastName));
        }
    }
}
