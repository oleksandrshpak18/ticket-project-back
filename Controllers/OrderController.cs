using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ticket_project_back.Data.Services;
using ticket_project_back.Data.ViewModels;

namespace ticket_project_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderService _service;
        public OrderController(OrderService service)
        {
            _service = service;
        }

        [HttpPut]
        public IActionResult AddNewOrder([FromBody] OrderVM order)
        {
            try
            {
                return Ok(_service.AddNew(order));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
