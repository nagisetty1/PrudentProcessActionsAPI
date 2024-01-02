using MediatR;
using PrudentProcessActionsAPI.Models;

namespace PrudentProcessActionsAPI.Commands
{
    public class CancelOrderCommand : IRequest<OrderCancellation>
    {
        public int OrderId { get; set; }
    }
}
