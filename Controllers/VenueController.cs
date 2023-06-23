using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ticket_project_back.Data.Services;

namespace ticket_project_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        public VenueService _service;
        public VenueController(VenueService service)
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
                return BadRequest($"Performer with id {id} does not exist.");
            }
            else
            {
                return Ok(res);
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
                return BadRequest($"Performer with id {id} does not exist.");
            }
            else
            {
                return Ok(res);
            }
        }
    }
}
