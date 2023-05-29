using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.OpenXmlFormats.Dml;
using System.Data.Entity.Infrastructure;
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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            if(ModelState.IsValid)
            {
                var response = await _ICourseService.GetByIdAsync(id);

                if(response.BaseResponse!.Success)
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

                if (response.BaseResponse!.Success)
                    return Created("Successfully Created!", response);
                    return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpPut("delet/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsyncCourse(Guid id)
        {
            if (ModelState.IsValid)
            {
                var response = await _ICourseService.DeleteAsync(id);
                if (response.Success)
                    return Ok(response);
                    return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpPut("modify/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsyncCourse(CourseInputDTO course, Guid id)
        {
            if (ModelState.IsValid)
            {
                var response = await _ICourseService.UpdateAsync(course, id);

                if (response.Success)
                    return Ok(response);
                    return BadRequest(response);
            }
            return StatusCode(500);
        }
    }
}
