using MediatR;

namespace Order.Application.Features.Orders.GetOrderList
{
    public class GetOrderListQuery : IRequest<List<OrderDto>>
    {
        public string Username { get; set; }

        public GetOrderListQuery(string username)
        {
            Username = username;
        }
    }
}
