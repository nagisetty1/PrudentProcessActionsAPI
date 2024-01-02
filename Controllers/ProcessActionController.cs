using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrudentProcessActionsAPI.Commands;
using PrudentProcessActionsAPI.Requests;

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
                switch (actionContextApiRequest.Action)
                {
                    case "AddCustomer":
                        var addCustomerCommand = new AddCustomerCommand { Name = actionContextApiRequest.Data };
                        var addedCustomer = await _mediator.Send(addCustomerCommand);
                        return Ok(addedCustomer);

                    case "ProcessOrder":
                        var processOrderCommand = new ProcessOrderCommand { CustomerId = int.Parse(actionContextApiRequest.Data) };
                        var processedOrder = await _mediator.Send(processOrderCommand);
                        return Ok(processedOrder);

                    case "CancelOrder":
                        var cancelOrderCommand = new CancelOrderCommand { OrderId = int.Parse(actionContextApiRequest.Data) };
                        var canceledOrder = await _mediator.Send(cancelOrderCommand);
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
