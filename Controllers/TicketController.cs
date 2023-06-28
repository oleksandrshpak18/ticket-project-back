using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ticket_project_back.Data.Services;
using ticket_project_back.Data.ViewModels;

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

        [HttpPost("is-ticket-availble")]
        public IActionResult isTicketAvailable([FromBody] TicketVM ticket)
        {
            bool res = !_service.isPresent(ticket);
            if (res == true) { return Ok(res); }
            else return BadRequest("The seat has been already sold. Choose another one, please.");
        }
    }
}
