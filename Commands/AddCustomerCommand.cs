using MediatR;
using PrudentProcessActionsAPI.Models;

namespace PrudentProcessActionsAPI.Commands
{
    public class AddCustomerCommand : IRequest<Customer>
    {
        public string Name { get; set; }
    }
}
