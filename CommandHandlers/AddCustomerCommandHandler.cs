using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PrudentProcessActionsAPI.Commands;
using PrudentProcessActionsAPI.Data;
using PrudentProcessActionsAPI.Models;
using System.Diagnostics;

namespace PrudentProcessActionsAPI.CommandHandlers
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Customer>
    {  

        public Task<Customer> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"AddCustomerCommandHandler.Handle: {request.Name}");
            EntityEntry<Customer> customer = null;
            using (var context = new ApplicationDbContext())
            {
                customer = context.Customers.Add(new Customer { Name = request.Name, Address = request.Name, Email = request.Name, Phone = request.Name });
                context.SaveChanges();
            }

            // For simplicity, just returning the customer details
            return Task.FromResult(customer.Entity);
        }
    }
}
