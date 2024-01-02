using MediatR;
using PrudentProcessActionsAPI.Commands;
using PrudentProcessActionsAPI.Models;
using System.Diagnostics;

namespace PrudentProcessActionsAPI.CommandHandlers
{
    public class ProcessOrderCommandHandler : IRequestHandler<ProcessOrderCommand, Order>
    {
        ILogger _logger;
        public ProcessOrderCommandHandler(ILogger logger)
        {
            _logger = logger;
        }
        public Task<Order> Handle(ProcessOrderCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"ProcessOrderCommandHandler.Handle: {request.CustomerId}");
            // Logic to process the order
            // For simplicity, just returning the order details
            return Task.FromResult(new Order { Id = 101, CustomerId = request.CustomerId });
        }
    }
}
