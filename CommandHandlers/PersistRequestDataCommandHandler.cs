using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PrudentProcessActionsAPI.Commands;
using PrudentProcessActionsAPI.Data;
using PrudentProcessActionsAPI.Models;
using System.Diagnostics;

namespace PrudentProcessActionsAPI.CommandHandlers
{
    public class PersistRequestDataCommandHandler : IRequestHandler<PersistRequestDataCommand, RequestData>
    {
        public Task<RequestData> Handle(PersistRequestDataCommand request, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"PersistRequestDataCommand.Handle: {request.JsonData}");
            // Logic to add a request data into db

            EntityEntry<RequestData> requestData = null;
            using (var context = new ApplicationDbContext())
            {
                requestData = context.RequestDataSet.Add(new RequestData { JsonData = request.JsonData});
                context.SaveChanges();
            }

            // For simplicity, just returning the customer details
            return Task.FromResult(requestData.Entity);
        }
    }
}
