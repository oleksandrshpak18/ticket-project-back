using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ticket_project_back.Data;

namespace ticket_project_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformerController : ControllerBase
    {
        private readonly TicketDbContext _context;

        public PerformerController(TicketDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() 
        { 
            return Ok(_context.Performers.ToList());
        }
    }
}
