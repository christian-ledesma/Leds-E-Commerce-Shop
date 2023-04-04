using MediatR;

namespace Order.Application.Features.Orders.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
