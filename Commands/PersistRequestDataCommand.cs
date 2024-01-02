using MediatR;
using PrudentProcessActionsAPI.Models;

namespace PrudentProcessActionsAPI.Commands
{
    public class PersistRequestDataCommand: IRequest<RequestData>
    {
        public string JsonData { get; set; }
    }
}
