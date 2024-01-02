using MediatR;
using PrudentProcessActionsAPI.Commands;
using PrudentProcessActionsAPI.Models;
using System.Diagnostics;

namespace PrudentProcessActionsAPI.CommandHandlers
{
    public class PersistRequestDataCommandHandler : IRequestHandler<PersistRequestDataCommand, RequestData>
    {
        ILogger _logger;
        public PersistRequestDataCommandHandler(ILogger logger)
        {
            _logger = logger;
        }
        public Task<RequestData> Handle(PersistRequestDataCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"PersistRequestDataCommand.Handle: {request.JsonData}");
            // Logic to add a request data into db
            // For simplicity, just returning the customer details
            return Task.FromResult(new RequestData {  JsonData = request.JsonData });
        }
    }
}
