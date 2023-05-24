using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniVerseAPI.Controllers
{
    [Route("Course")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            return Ok("Testando");
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById()
        {
            return Ok("Testando");
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateCourse()
        {
            return Ok("Testando");
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteCourse()
        {
            return Ok("Testando");
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateCourse()
        {
            return Ok("Testando");
        }
    }
}
