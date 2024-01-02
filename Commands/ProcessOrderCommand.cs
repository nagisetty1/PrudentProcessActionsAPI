using MediatR;
using PrudentProcessActionsAPI.Models;

namespace PrudentProcessActionsAPI.Commands
{
    public class ProcessOrderCommand : IRequest<Order>
    {
        public int CustomerId { get; set; }
    }
}
