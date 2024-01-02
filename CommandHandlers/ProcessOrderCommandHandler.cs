using MediatR;
using PrudentProcessActionsAPI.Commands;
using PrudentProcessActionsAPI.Models;

namespace PrudentProcessActionsAPI.CommandHandlers
{
    public class ProcessOrderCommandHandler : IRequestHandler<ProcessOrderCommand, Order>
    {
        public Task<Order> Handle(ProcessOrderCommand request, CancellationToken cancellationToken)
        {
            // Logic to process the order
            // For simplicity, just returning the order details
            return Task.FromResult(new Order { Id = 101, CustomerId = request.CustomerId });
        }
    }
}
