using AutoMapper;
using Order.Application.Features.Orders.GetOrderList;

namespace Order.Application.Mappings
{
    using Order.Domain.Entities;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>();
        }
    }
}
