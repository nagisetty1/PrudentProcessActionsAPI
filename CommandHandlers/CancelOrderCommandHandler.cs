using MediatR;
using PrudentProcessActionsAPI.Commands;
using PrudentProcessActionsAPI.Models;
using System.Diagnostics;

namespace PrudentProcessActionsAPI.CommandHandlers
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, OrderCancellation>
    {
        public Task<OrderCancellation> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"CancelOrderCommandHandler.Handle: {request.OrderId}");
            // Logic to cancel the order
            // For simplicity, just returning the cancellation details
            return Task.FromResult(new OrderCancellation { OrderId = request.OrderId });
        }
    }
}
