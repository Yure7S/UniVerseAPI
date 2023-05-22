using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniVerseAPI.Controllers
{
    [Route("Course")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        [HttpGet("")]
        public IActionResult Principal()
        {
            return Ok("Testando");
        }
    }
}
