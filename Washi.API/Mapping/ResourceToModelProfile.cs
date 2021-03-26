using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Resources;

namespace Washi.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
            CreateMap<SavePaymentMethodResource, PaymentMethod>();
            CreateMap<SaveServiceResource, Service>();
            CreateMap<SaveMaterialResource, Material>();
            CreateMap<SaveUserProfileResource, UserProfile>();
            CreateMap<SaveSubscriptionResource, Subscription>();
            CreateMap<SaveUserSubscriptionResource, UserSubscription>();
            CreateMap<SaveOrderResource, Order>();
            CreateMap<SaveOrderStatusResource, OrderStatus>();
            CreateMap<SaveLaundryServiceMaterialResource, LaundryServiceMaterial>();
            CreateMap<SavePromotionResource, Promotion>();
            CreateMap<SaveOrderDetailResource, OrderDetail>();
        }
    }
}
