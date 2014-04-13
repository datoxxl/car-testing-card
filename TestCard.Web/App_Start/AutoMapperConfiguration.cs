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

            Mapper.CreateMap<Models.TestingCardChangeRequestModel, Domain.TestingCardChangeRequest>();

            Mapper.CreateMap<Models.TestingCardModel, Domain.TestingCard>();
            Mapper.CreateMap<Models.TestingCardModel, Models.TestingCardChangeRequestModel>();

            Mapper.CreateMap<Models.TestingSubStep, Domain.TestingCardDetailChangeRequest>();
            Mapper.CreateMap<Models.TestingSubStep, Domain.TestingCardDetail>();

            //--

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

            Mapper.CreateMap<Domain.PersonChangeRequest, Models.PersonChangeRequestListModel>()
                .ForMember(dest => dest.PersonFirstName, src => src.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.PersonLastName, src => src.MapFrom(x => x.LastName))
                .ForMember(dest => dest.ResponsiblePersonFirstName, src => src.MapFrom(x => x.ResponsiblePerson.FirstName))
                .ForMember(dest => dest.ResponsiblePersonLastName, src => src.MapFrom(x => x.ResponsiblePerson.LastName))
                .ForMember(dest => dest.QualityManagerConfirmStatusName, src => src.MapFrom(x => x.QualityManagerConfirmStatus.ConfirmStatusName))
                .ForMember(dest => dest.AdministratorConfirmStatusName, src => src.MapFrom(x => x.AdminConfirmStatus.ConfirmStatusName));

            Mapper.CreateMap<Domain.PersonScheduleChangeRequest, Models.PersonScheduleChangeRequestListModel>()
                .ForMember(dest => dest.PersonFirstName, src => src.MapFrom(x => x.Person.FirstName))
                .ForMember(dest => dest.PersonLastName, src => src.MapFrom(x => x.Person.LastName))
                .ForMember(dest => dest.ResponsiblePersonFirstName, src => src.MapFrom(x => x.ResponsiblePerson.FirstName))
                .ForMember(dest => dest.ResponsiblePersonLastName, src => src.MapFrom(x => x.ResponsiblePerson.LastName))
                .ForMember(dest => dest.QualityManagerConfirmStatusName, src => src.MapFrom(x => x.QualityManagerConfirmStatus.ConfirmStatusName))
                .ForMember(dest => dest.AdministratorConfirmStatusName, src => src.MapFrom(x => x.AdminConfirmStatus.ConfirmStatusName));

            Mapper.CreateMap<Domain.TestingCardChangeRequest, Models.TestingCardChangeRequestListModel>()
                .ForMember(dest => dest.ResponsiblePersonFirstName, src => src.MapFrom(x => x.ResponsiblePerson.FirstName))
                .ForMember(dest => dest.ResponsiblePersonLastName, src => src.MapFrom(x => x.ResponsiblePerson.LastName))
                .ForMember(dest => dest.QualityManagerConfirmStatusName, src => src.MapFrom(x => x.QualityManagerConfirmStatus.ConfirmStatusName))
                .ForMember(dest => dest.AdministratorConfirmStatusName, src => src.MapFrom(x => x.AdminConfirmStatus.ConfirmStatusName));

            Mapper.CreateMap<Domain.PersonScheduleChangeRequest, Models.PersonScheduleModel>();

            Mapper.CreateMap<Domain.Company, Models.CompanyListModel>();
            Mapper.CreateMap<Domain.Company, Models.CompanyModel>()
                .ForMember(dest => dest.LogoFileName, src => src.MapFrom(x => x.CompanyLogoFile.FileName))
                .ForMember(dest => dest.AccreditationLogoFileName, src => src.MapFrom(x => x.AccreditationLogoFile.FileName));

            Mapper.CreateMap<Domain.TestingCard, Models.TestingCardListModel>()
               .ForMember(dest => dest.CompanyName, src => src.MapFrom(x => x.Person.Company.CompanyName))
               .ForMember(dest => dest.CompanyID, src => src.MapFrom(x => x.Person.CompanyID))
               .ForMember(dest => dest.RespPersonFullName, src => src.MapFrom(x => x.Person.FirstName + " " + x.Person.LastName));
            Mapper.CreateMap<Domain.TestingCard, Models.TestingCardModel>()
               .ForMember(dest => dest.CompanyName, src => src.MapFrom(x => x.Person.Company.CompanyName))
               .ForMember(dest => dest.CompanyID, src => src.MapFrom(x => x.Person.CompanyID))
               .ForMember(dest => dest.CompanyName, src => src.MapFrom(x => x.Person.Company.CompanyName))
               .ForMember(dest => dest.CompanyAccreditationNumber, src => src.MapFrom(x => x.Person.Company.AccreditationNumber))
               .ForMember(dest => dest.CompanyAccreditationScope, src => src.MapFrom(x => x.Person.Company.AccreditationScope))
               .ForMember(dest => dest.CompanyAddress, src => src.MapFrom(x => x.Person.Company.Address))
               .ForMember(dest => dest.CompanyLogoFileName, src => src.MapFrom(x => x.Person.Company.CompanyLogoFile.FileName))
               .ForMember(dest => dest.AccreditationLogoFileName, src => src.MapFrom(x => x.Person.Company.AccreditationLogoFile.FileName))
               .ForMember(dest => dest.RespPersonFullName, src => src.MapFrom(x => x.Person.FirstName + " " + x.Person.LastName)); ;

            Mapper.CreateMap<Domain.TestingCardDetail, Models.TestingSubStep>();

            Mapper.CreateMap<Domain.TestingStep, Models.TestingStep>();

            Mapper.CreateMap<Domain.TestingSubStep, Models.TestingSubStep>();

            Mapper.CreateMap<Domain.TestingCardChangeRequest, Models.TestingCardChangeRequestModel>()
               .ForMember(dest => dest.ReasonName, src => src.MapFrom(x => x.ChangeRequestReason.Title));

            Mapper.CreateMap<Domain.TestingCardDetailChangeRequest, Models.TestingSubStep>();
        }
    }
}
