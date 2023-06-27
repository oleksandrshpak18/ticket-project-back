using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ticket_project_back.Data.Services;

namespace ticket_project_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        public TicketService _service;
        public TicketController(TicketService service)
        {
            _service = service;
        }

        [HttpGet("get-sold-by-event-id")]
        public IActionResult GetSoldTicketsByEventId([FromQuery] int id) 
        {
            return Ok(_service.GetSoldByEventId(id));
        }
    }
}
