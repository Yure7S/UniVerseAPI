using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using UniVerseAPI.Application.DTOs;
using UniVerseAPI.Application.DTOs.Request;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourse _ICourse;

        public CourseController(ICourse course)
        {
            _ICourse = course;  
        }


        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            return Ok("Testando");
        }

        [HttpGet("Find/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            return Ok("Testando");
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCourse(CourseRegisterDTO course)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Course newCourse = new(
                        fullName: course.FullName,
                        description: course.Description,
                        startDate: course.StartDate,
                        endDate: course.EndDate,
                        instructor: course.Instructor,
                        seats: course.Seats,
                        spotsAvailable: course.SpotsAvailable,
                        price: course.Price,
                        category: course.Category);

                    Course courseCreated = await _ICourse.Create(newCourse);
                    return Created("Item adicionado com sucesso!", courseCreated);
                }
                else
                {
                    return BadRequest("Falha ao tentar cadastrar curso");
                }
            }
            catch (Exception e)
            {
                BaseResponseDTO response = new(message: "Nos deparamos com erros ao tentar cadastrar um novo curso!", false, error: e.Message);
                return BadRequest(response);
            }
        }

        [HttpGet("Deletar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteCourse(Guid id)
        {
            return Ok("Testando");
        }

        [HttpGet("Modificar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateCourse(Guid id)
        {
            return Ok("Testando");
        }
    }
}
