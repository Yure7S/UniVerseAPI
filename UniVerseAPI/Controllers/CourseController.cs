using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.OpenXmlFormats.Dml;
using System.Security.Cryptography.Xml;
using UniVerseAPI.Application.DTOs;
using UniVerseAPI.Application.DTOs.Request.MasterEntitiesDTO;
using UniVerseAPI.Application.DTOs.Response;
using UniVerseAPI.Application.IServices;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Controllers
{
    [Route("courses")]
    [ApiController]
    [Authorize(Roles = "Teacher, Director, Administrator")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _ICourseService;

        public CourseController(ICourseService course)
        {
            _ICourseService = course;
        }

        [Authorize]
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            try
            {
                var response = _ICourseService.GetAllAsync();
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(string code)
        {
            if(ModelState.IsValid)
            {
                var response = await _ICourseService.GetByCodeAsync(code);

                if(response.Success)
                    return Ok(response);
                    return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpGet("all-subjects-this-course/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AllSubjectsThisCourse(string code)
        {
            if (ModelState.IsValid)
            {
                var response = _ICourseService.AllSubjectsThisCourseAsync(code);
                return Ok(response);
            }
            return StatusCode(500);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Director, Administrator")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCourseAsync(CourseInputDTO course)
        {
            if (ModelState.IsValid)
            {
                var response = await _ICourseService.CreateAsync(course);

                if (response.Success)
                    return Created("Successfully Created!", response);
                    return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpPut("modify/{code}")]
        [Authorize(Roles = "Director, Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCourseAsync(CourseInputDTO course, string code)
        {
            if (ModelState.IsValid)
            {
                var response = await _ICourseService.UpdateAsync(course, code);

                if (response.Success)
                    return Ok(response);
                    return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpDelete("delet/{code}")]
        [Authorize(Roles = "Director, Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCourseAsync(string code)
        {
            if (ModelState.IsValid)
            {
                var response = await _ICourseService.DeleteAsync(code);
                if (response.Success)
                    return Ok(response);
                    return BadRequest(response);
            }
            return StatusCode(500);
        }

    }
}
