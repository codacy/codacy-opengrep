using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Web
{
    public class Foo { }

    [ApiController]
    [Route("[controller]")]
    public class FooController : ControllerBase
    {
        [HttpGet("foo")]
        public IActionResult GetFoo() // Noncompliant
        {
            return Ok(new Foo());
        }

        [HttpGet("bar")]
        [ProducesResponseType(typeof(Foo), StatusCodes.Status200OK)]
        public IActionResult GetBar()
        {
            return Ok(new Foo());
        }
    }
}
