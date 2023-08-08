using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using UniVerseAPI.Application.DTOs.Request.MasterEntitiesDTO;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Application.IServices;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Controllers
{
    [Route("students")]
    [ApiController]
    [Authorize(Roles = "Director, Administrator")]
    public class StudentsController : ControllerBase
    {
        public readonly IStudentService _IStudentService;
        public readonly IConfiguration _configuration;

        public StudentsController(IStudentService IStudent, IConfiguration configuration)
        {
            _IStudentService = IStudent;
            _configuration = configuration;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            try
            {
                var response = _IStudentService.GetAll();
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        } 

        [HttpGet("{registration}")]
        public async Task<IActionResult> GetStudentDetailsAsync(string registration)
        {
            if (ModelState.IsValid)
            {
                var response = await _IStudentService.GetByRegistrationAsync(registration);
                return Ok(response);
            }
            return StatusCode(500);
        }

        [HttpGet("subjects-done")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SubjectsDoneAsync(string registration)
        {
            if (ModelState.IsValid)
            {
                var response = await _IStudentService.GetSubjectsDoneAsync(registration);

                return Ok(response);

                //if (response.Success)
                //    return Ok(response);
                //return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpGet("grades/{registration}")]
        [Authorize(Roles = "Student, Teacher, Director, Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AllGradesForThisStudentAsync(string registration)
        {
            if (ModelState.IsValid)
            {
                var response = await _IStudentService.AllGradesForThisStudentAsync(registration);
                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpPost("grades/add")]
        [Authorize(Roles = "Teacher, Director, Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterNoteAsync(GradeInputDTO grade)
        {
            if (ModelState.IsValid)
            {
                var response = await _IStudentService.RegisterGradeAsync(grade);
                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateStudentAsync(StudentInputDTO student)
        {
            if (ModelState.IsValid)
            {
                var response = await _IStudentService.CreateAsync(student);

                if (response.Success)
                    return Created("Successfully created!", response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpPost("add-student-in-class")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddStudentInClassAsync(int codeClass,  string registrationStudent)
        {
            if (ModelState.IsValid)
            {
                var response = await _IStudentService.AddStudentInClassAsync(codeClass, registrationStudent);

                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpPut("{registration}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCourseAsync(StudentUpdateDTO student, string registration)
        {
            if (ModelState.IsValid)
            {
                var response = await _IStudentService.UpdateAsync(student, registration);

                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpDelete("{registration}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCourseAsync(string registration)
        {
            if (ModelState.IsValid)
            {
                var response = await _IStudentService.DeleteAsync(registration);
                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpDelete("remove-student-from-class")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public /*async Task<IActionResult>*/ IActionResult RemoveStudentFromClass()
        {
            if (ModelState.IsValid)
            {
                return Ok("TO-DO");
            }
            return StatusCode(500);
        }
    }
}
