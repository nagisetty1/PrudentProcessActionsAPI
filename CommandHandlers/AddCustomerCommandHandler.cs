using MediatR;
using PrudentProcessActionsAPI.Commands;
using PrudentProcessActionsAPI.Models;
using System.Diagnostics;

namespace PrudentProcessActionsAPI.CommandHandlers
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Customer>
    {  

        public Task<Customer> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"AddCustomerCommandHandler.Handle: {request.Name}");
            // Logic to add a new customer
            // For simplicity, just returning the customer details
            return Task.FromResult(new Customer { Id = 1, Name = request.Name });
        }
    }
}
