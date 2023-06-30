using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ticket_project_back.Data.Services;
using ticket_project_back.Data.ViewModels;

namespace ticket_project_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerService _service;
        public CustomerController(CustomerService service)
        {
            _service = service;
        }

        [HttpPost("add-customer")]
        public IActionResult AddCustomer([FromBody] CustomerVM customer)
        {
            var res = _service.AddNew(customer);
            if (res != null)
            {
                return Ok(res);
            }
            else { return BadRequest("Not valid customer data."); }
        }

        [HttpGet("get-customer-by-phone")]
        public IActionResult GetCustomerByPhone([FromQuery] string phone)
        {
            var res = _service.getByPhone(phone);
            if(res == null)
            {
                return BadRequest($"User with phone number {phone} does not exist.");
            }
            else
            {
                return Ok(res);
            }
        }
    }
}
