using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniVerseAPI.Application.IServices;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Controllers
{
    [Route("Teacher")]
    [ApiController]
    [Authorize(Roles = "Director, Administrator")]
    public class TeacherController : ControllerBase
    {
        public readonly ITeacherService _ITeacherService;

        public TeacherController(ITeacherService iTeacher)
        {
            _ITeacherService = iTeacher;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            try
            {
                var response = _ITeacherService.GetAllAsync();
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetTeacherDetailsAsync(string code)
        {
            if (ModelState.IsValid)
            {
                var response = await _ITeacherService.GetTeacherDetailAsync(code);
                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpPost("")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTeacherAsync(TeacherInputDTO teacher)
        {
            if (ModelState.IsValid)
            {
                var response = await _ITeacherService.Create(teacher);

                if (response.Success)
                    return Created("Successfully created!", response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpPut("enableordisable/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EnableOrDisableAsync(string code, bool status)
        {
            if (ModelState.IsValid)
            {
                var response = await _ITeacherService.EnableOrDisableAsync(code, status);
                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpPut("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCourseAsync(TeacherInputDTO teacher, string code)
        {
            if (ModelState.IsValid)
            {
                var response = await _ITeacherService.UpdateAsync(teacher, code);

                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }
        
        [HttpDelete("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCourseAsync(string code)
        {
            if (ModelState.IsValid)
            {
                var response = await _ITeacherService.DeleteAsync(code);
                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

    }
}