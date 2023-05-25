using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Controllers
{
    [Route("Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public readonly IStudentInterface _IStudent;

        public StudentsController(IStudentInterface IStudent)
        {
            _IStudent = IStudent;
        }

        [HttpGet("")]
        //[ProducesResponseType(200)]
        //[ProducesErrorResponseType(typeof(Exception))]
        public IActionResult GetAllStudents()
        {
            return Ok(_IStudent.GetAllStudents());
        }
    }
}
