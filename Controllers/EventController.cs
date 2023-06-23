using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ticket_project_back.Data.Services;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace ticket_project_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public EventService _service;
        public EventController(EventService service)
        {
            _service = service;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }
        [HttpGet("get-by-id")]
        public IActionResult GetById([FromQuery] int id)
        {
            var res = _service.GetById(id);
            if (res == null)
            {
                return BadRequest($"Event with id {id} does not exist.");
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpGet("get-by-performer-id")]
        public IActionResult GetByPerformerId([FromQuery] int id)
        {
            var res = _service.GetByPerformerId(id);
            if (res.Any())
            {
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("get-by-venue-id")]
        public IActionResult GetByVenueId([FromQuery] int id)
        {
            var res = _service.GetByVenueId(id);
            if (res.Any())
            {
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("search-by-keyword")]
        public IActionResult SearchByKeyword(string keyword)
        {
            var res = _service.SearchByKeyword(keyword);
            if (res.Any())
            {
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("update-image-url")]
        public IActionResult UpdateImageUrl([FromQuery] int id, [FromBody] string imageUrl)
        {
            var res = _service.updateImage(id, imageUrl);
            if (res == null)
            {
                return BadRequest($"Event with id {id} does not exist.");
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpPut("update-description")]
        public IActionResult UpdateDescription([FromQuery] int id, [FromBody] string descr)
        {
            var res = _service.updateDescription(id, descr);
            if (res == null)
            {
                return BadRequest($"Event with id {id} does not exist.");
            }
            else
            {
                return Ok(res);
            }
        }
    }
}
