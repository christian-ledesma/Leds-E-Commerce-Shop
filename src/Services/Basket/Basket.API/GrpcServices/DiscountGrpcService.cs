using Discount.Grpc.Protos;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _grpcClient;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient grpcClient)
        {
            _grpcClient = grpcClient ?? throw new ArgumentNullException(nameof(grpcClient));
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var getDiscountRequest = new GetDiscountRequest
            {
                ProductName = productName
            };

            return await _grpcClient.GetDiscountAsync(getDiscountRequest);
        }
    }
}
