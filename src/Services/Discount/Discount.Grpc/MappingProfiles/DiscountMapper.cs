using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;

namespace Discount.Grpc.MappingProfiles
{
    public class DiscountMapper : Profile
    {
        public DiscountMapper()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
