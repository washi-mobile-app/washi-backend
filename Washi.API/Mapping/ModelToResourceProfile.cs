using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Resources;

namespace Washi.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<PaymentMethod, PaymentMethodResource>();
            CreateMap<Service, ServiceResource>();
            CreateMap<Material, MaterialResource>();
            CreateMap<UserProfile, UserProfileResource>();
            CreateMap<Subscription, SubscriptionResource>();
            CreateMap<UserSubscription, UserSubscriptionResource>();
            CreateMap<Order, OrderResource>();
            CreateMap<OrderStatus, OrderStatusResource>();
            CreateMap<Country, CountryResource>();
            CreateMap<District, DistrictResource>()
                .ForMember(src => src.Department,
                opt => opt.MapFrom(src => src.Department.Name));
            CreateMap<Department, DepartmentResource>()
                .ForMember(src => src.Country,
                opt => opt.MapFrom(src => src.Country.Name));
            CreateMap<Currency, CurrencyResource>();
            CreateMap<CountryCurrency, CountryCurrencyResource>();
            CreateMap<ServiceMaterial, ServiceMaterialResource>();
            CreateMap<LaundryServiceMaterial, LaundryServiceMaterialResource>();
            CreateMap<Promotion, PromotionResource>();
            CreateMap<OrderDetail, OrderDetailResource>();
        }
    }
}
