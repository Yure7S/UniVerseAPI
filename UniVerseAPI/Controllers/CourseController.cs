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
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _ICourseService;

        public CourseController(ICourseService course)
        {
            _ICourseService = course;
        }


        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var response = await _ICourseService.GetAllAsync();
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

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsyncCourse(CourseInputDTO course)
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

        [HttpPut("delet/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsyncCourse(string code)
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

        [HttpPut("modify/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsyncCourse(CourseInputDTO course, string code)
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
    }
}
