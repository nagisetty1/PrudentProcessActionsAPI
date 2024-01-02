using MediatR;
using PrudentProcessActionsAPI.Commands;
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
            // For simplicity, just returning the customer details
            return Task.FromResult(new RequestData {  JsonData = request.JsonData });
        }
    }
}
