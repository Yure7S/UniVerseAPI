using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.OpenXmlFormats.Dml;
using System.Data.Entity.Infrastructure;
using System.Security.Cryptography.Xml;
using UniVerseAPI.Application.DTOs;
using UniVerseAPI.Application.DTOs.Request;
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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _ICourseService.GetAll();
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); // StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            if(ModelState.IsValid)
            {
                var response = await _ICourseService.GetById(id);

                if(response.BaseResponse!.Success)
                return Ok(response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCourse(CourseRegisterDTO course)
        {
            if (ModelState.IsValid)
            {
                var response = await _ICourseService.Create(course);

                if (response.BaseResponse!.Success)
                return Created("Successfully created!", response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpGet("delet/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteCourse(Guid id)
        {
            return Ok("Testando");
        }

        [HttpGet("modify/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateCourse(Guid id)
        {
            return Ok("Testando");
        }
    }
}
