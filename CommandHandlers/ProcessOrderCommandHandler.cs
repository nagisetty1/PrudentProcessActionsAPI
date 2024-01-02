using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PrudentProcessActionsAPI.Commands;
using PrudentProcessActionsAPI.Data;
using PrudentProcessActionsAPI.Models;
using System.Diagnostics;

namespace PrudentProcessActionsAPI.CommandHandlers
{
    public class ProcessOrderCommandHandler : IRequestHandler<ProcessOrderCommand, Order>
    {
        public Task<Order> Handle(ProcessOrderCommand request, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"ProcessOrderCommandHandler.Handle: {request.CustomerId}");

            EntityEntry<Order> order = null;
            using (var context = new ApplicationDbContext())
            {
                order = context.Orders.Add(new Order { CustomerId = request.CustomerId });
                context.SaveChanges();
            }

            // For simplicity, just returning the customer details
            return Task.FromResult(order.Entity);
        }
    }
}
