using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniVerseAPI.Application.DTOs.Request.MasterEntitiesDTO;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Application.IServices;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Controllers
{
    [Route("Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public readonly IStudentService _IStudentService;

        public StudentsController(IStudentService IStudent)
        {
            _IStudentService = IStudent;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var response = await _IStudentService.GetAllAsync();
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetStudentDetailsAsync(Guid id)
        {
            if (ModelState.IsValid)
            {
                var response = await _IStudentService.GetStudentDetailsAsync(id);
                return Ok(response);
            }
            return StatusCode(500);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCourse(StudentInputDTO student)
        {
            if (ModelState.IsValid)
            {
                var response = await _IStudentService.CreateAsync(student);

                if (response.BaseResponse!.Success)
                    return Created("Successfully created!", response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpPut("delet/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            if (ModelState.IsValid)
            {
                var response = await _IStudentService.DeleteAsync(id);
                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpPut("modify/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCourse(StudentInputDTO student, Guid id)
        {
            if (ModelState.IsValid)
            {
                var response = await _IStudentService.UpdateAsync(student, id);

                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }
    }
}
