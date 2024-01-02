using MediatR;
using PrudentProcessActionsAPI.Commands;
using PrudentProcessActionsAPI.Models;

namespace PrudentProcessActionsAPI.CommandHandlers
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, OrderCancellation>
    {
        public Task<OrderCancellation> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            // Logic to cancel the order
            // For simplicity, just returning the cancellation details
            return Task.FromResult(new OrderCancellation { OrderId = request.OrderId });
        }
    }
}
