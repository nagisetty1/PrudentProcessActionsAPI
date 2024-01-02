using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrudentProcessActionsAPI.Commands;
using PrudentProcessActionsAPI.Requests;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace PrudentProcessActionsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessActionController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<WeatherForecastController> _logger;

        public ProcessActionController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessRequest([FromBody] ActionContextApiRequest actionContextApiRequest)
        {
            try
            {
                _logger.LogInformation($"Request received for action: {actionContextApiRequest.Action} and data: {actionContextApiRequest.Data}");
                //store request directly to database
                await _mediator.Send(new PersistRequestDataCommand() { JsonData = JsonConvert.SerializeObject(actionContextApiRequest) });

                switch (actionContextApiRequest.Action)
                {
                    case "AddCustomer":
                        var addCustomerCommand = new AddCustomerCommand { Name = actionContextApiRequest.Data };
                        var addedCustomer = await _mediator.Send(addCustomerCommand);
                        //TODO: send response to amazon for adding customer info in prudent daabase
                        return Ok(addedCustomer);

                    case "ProcessOrder":
                        var processOrderCommand = new ProcessOrderCommand { CustomerId = int.Parse(actionContextApiRequest.Data) };
                        var processedOrder = await _mediator.Send(processOrderCommand);
                        //TODO: send response to amazon for processing order in prudent daabase
                        return Ok(processedOrder);

                    case "CancelOrder":
                        var cancelOrderCommand = new CancelOrderCommand { OrderId = int.Parse(actionContextApiRequest.Data) };
                        var canceledOrder = await _mediator.Send(cancelOrderCommand);
                        //TODO: send response to amazon for cancelled order in prudent daabase
                        return Ok(canceledOrder);

                    default:
                        return BadRequest("Invalid action");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
