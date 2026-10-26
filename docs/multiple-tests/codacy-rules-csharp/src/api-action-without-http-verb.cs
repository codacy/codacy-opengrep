using Microsoft.AspNetCore.Mvc;

namespace Tests.Web
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        [Route("Customer")]
        public IActionResult ChangeCustomer(int id) // Noncompliant
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        [NonAction]
        public IActionResult Helper()
        {
            return Ok();
        }
    }
}
