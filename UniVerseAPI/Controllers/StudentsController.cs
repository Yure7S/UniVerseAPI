using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Models;

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

        [HttpPost("Register")]
        public IActionResult Create(Student _student)
        {
            Task<Student> studentAdd = _IStudent.Create(_student);
            return Ok(studentAdd);
        }
    }
}
