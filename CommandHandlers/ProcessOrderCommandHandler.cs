using MediatR;
using PrudentProcessActionsAPI.Commands;
using PrudentProcessActionsAPI.Models;
using System.Diagnostics;

namespace PrudentProcessActionsAPI.CommandHandlers
{
    public class ProcessOrderCommandHandler : IRequestHandler<ProcessOrderCommand, Order>
    {
        public Task<Order> Handle(ProcessOrderCommand request, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"ProcessOrderCommandHandler.Handle: {request.CustomerId}");
            // Logic to process the order
            // For simplicity, just returning the order details
            return Task.FromResult(new Order { Id = 101, CustomerId = request.CustomerId });
        }
    }
}
