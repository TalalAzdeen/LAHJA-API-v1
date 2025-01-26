using AutoMapper;
using Dto;
using Dto.ModelAi;
using Dto.ModelGateway;
using Dto.Plan;
using Dto.PlanServices;
using Dto.Request;
using Dto.Role;
using Dto.Service;
using Dto.ServiceMethod;
using Dto.Setting;
using Dto.Subscription;
using Dto.User;
using Entities;
 

namespace Api.Config
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Service, ServiceResponse>();
            CreateMap<ServiceCreate, Service>();

            
            CreateMap<PlanCreate, Plan>().ForMember(p => p.Id, pr => pr.MapFrom(pr => pr.PriceId));


            //CreateMap<Plan, PlanGrouping>().ReverseMap().ReverseMap();

     //       CreateMap<PlanCreate, Plan>()
     //.ForMember(
     //    pr => pr.PlanFeatures,
     //    opt => opt.MapFrom(src => HelperTranslation.ConvertTextToTranslationData(src.ProductId))
     //)
     //.ReverseMap();
            CreateMap<Plan, PlanResponse>();


            CreateMap<PlanServices, PlanServicesResponse>()
                .ForMember(pr => pr.Name, p => p.MapFrom(p => p.Service.Name))
                .ForMember(pr => pr.Token, p => p.MapFrom(p => p.Service.Token))
                .ForMember(pr => pr.AbsolutePath, p => p.MapFrom(p => p.Service.AbsolutePath))
                ;
            CreateMap<PlanServicesCreate, PlanServices>();


            CreateMap<Subscription, SubscriptionResponse>();
            CreateMap<ApplicationUser, UserResponse>()
                .ForMember(ur => ur.IsEmailConfirmed, u => u.MapFrom(u => u.EmailConfirmed))
                .ForMember(ur => ur.IsPhoneNumberConfirmed, u => u.MapFrom(u => u.PhoneNumberConfirmed));


            CreateMap<ModelGateway, ModelGatewayResponse>();
            CreateMap<ModelGatewayCreate, ModelGateway>();
            CreateMap<ModelGateway, ModelGatewayUpdate>();

            CreateMap<ModelAi, ModelAiResponse>();
            CreateMap<ModelAiCreate, ModelAi>();
            CreateMap<ModelAi, ModelAiUpdate>();
            CreateMap<ModelAiUpdate, ModelAi>();

            CreateMap<ServiceMethod, ServiceMethodResponse>()
                 .ForMember(sm => sm.InputParameters, smc => smc.MapFrom(smc => smc.InputParams))
                .ForMember(sm => sm.OutputParameters, smc => smc.MapFrom(smc => smc.OutputParams));
            CreateMap<ServiceMethodCreate, ServiceMethod>()
                .ForMember(sm => sm.InputParameters, smc => smc.MapFrom(smc => smc.Inputs))
                .ForMember(sm => sm.OutputParameters, smc => smc.MapFrom(smc => smc.Outputs));
            CreateMap<ServiceMethodUpdate, ServiceMethod>()
            .ForMember(sm => sm.InputParameters, smc => smc.MapFrom(smc => smc.Inputs))
            .ForMember(sm => sm.OutputParameters, smc => smc.MapFrom(smc => smc.Outputs));

            CreateMap<Setting, SettingResponse>();
            CreateMap<SettingCreate, Setting>();
            CreateMap<Request, RequestResponse>();
            CreateMap<EventRequest, EventRequestResponse>();

            CreateMap<ApplicationRole, RoleResponse>().ForMember(rr => rr.Permissions, ar => ar.MapFrom(ar => ar.RoleClaims.Select(rc => rc.ClaimValue)));


        }
    }
}