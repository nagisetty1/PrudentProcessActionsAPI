using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PrudentProcessActionsAPI.Commands;
using PrudentProcessActionsAPI.Data;
using PrudentProcessActionsAPI.Models;
using System.Diagnostics;

namespace PrudentProcessActionsAPI.CommandHandlers
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, OrderCancellation>
    {
        public Task<OrderCancellation> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"CancelOrderCommandHandler.Handle: {request.OrderId}");

            EntityEntry<OrderCancellation> orderCancellation = null;
            using (var context = new ApplicationDbContext())
            {
                orderCancellation = context.CancelledOrders.Add(new OrderCancellation { OrderCancellationId = request.OrderId });
                context.SaveChanges();
            }

            // For simplicity, just returning the cancellation details
            return Task.FromResult(orderCancellation.Entity);
        }
    }
}
