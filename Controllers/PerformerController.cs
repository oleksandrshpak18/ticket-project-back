using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ticket_project_back.Data.Services;

namespace ticket_project_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformerController : ControllerBase
    {
        public PerformerService _service;
        public PerformerController(PerformerService service)
        {
            _service = service;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
            //return Ok(_service.Get());
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
