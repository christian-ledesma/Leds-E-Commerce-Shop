using AutoMapper;
using Order.Application.Features.Orders.CheckoutOrder;

namespace Order.Application.Mappings
{
    using Order.Application.Features.Orders.UpdateOrder;
    using Order.Application.Responses;
    using Order.Domain.Entities;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
