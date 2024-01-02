using MediatR;
using PrudentProcessActionsAPI.Commands;
using PrudentProcessActionsAPI.Models;
using System.Diagnostics;

namespace PrudentProcessActionsAPI.CommandHandlers
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, OrderCancellation>
    {
        ILogger _logger;
        public CancelOrderCommandHandler(ILogger logger)
        {
            _logger = logger;
        }
        public Task<OrderCancellation> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CancelOrderCommandHandler.Handle: {request.OrderId}");
            // Logic to cancel the order
            // For simplicity, just returning the cancellation details
            return Task.FromResult(new OrderCancellation { OrderId = request.OrderId });
        }
    }
}
