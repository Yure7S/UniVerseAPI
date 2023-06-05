using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniVerseAPI.Application.IServices;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Controllers
{
    [Route("Teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        public readonly ITeacherService _ITeacherService;

        public TeacherController(ITeacherService iTeacher)
        {
            _ITeacherService = iTeacher;
        }

        //[HttpGet("")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetAllAsync()
        //{
        //    try
        //    {
        //        var response = await _ITeacherService.GetAllAsync();
        //        return Ok(response);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500);
        //    }
        //}

        //[HttpGet("details/{id}")]
        //public async Task<IActionResult> GetTeacherDetailsAsync(Guid id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _ITeacherService.GetTeacherDetailsAsync(id);
        //        return Ok(response);
        //    }
        //    return StatusCode(500);
        //}

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateTeacher(TeacherInputDTO teacher)
        {
            if (ModelState.IsValid)
            {
                var response = _ITeacherService.CreateAsync(teacher);

                if (response.BaseResponse!.Success)
                    return Created("Successfully created!", response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        //[HttpPut("delet/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> DeleteCourse(Guid id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _ITeacherService.DeleteAsync(id);
        //        if (response.Success)
        //            return Ok(response);
        //        return BadRequest(response);
        //    }
        //    return StatusCode(500);
        //}

        //[HttpPut("modify/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> UpdateCourse(TeacherInputDTO teacher, Guid id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _ITeacherService.UpdateAsync(teacher, id);

        //        if (response.Success)
        //            return Ok(response);
        //        return BadRequest(response);
        //    }
        //    return StatusCode(500);
        //}

    }
}