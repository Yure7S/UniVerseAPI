﻿using Microsoft.AspNetCore.Http;
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
        public IActionResult GetAllAsync()
        {
            try
            {
                var response = _IStudentService.GetAllAsync();
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("details/{registration}")]
        public async Task<IActionResult> GetStudentDetailsAsync(string registration)
        {
            if (ModelState.IsValid)
            {
                var response = await _IStudentService.GetByRegistrationAsync(registration);
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

        [HttpPut("delet/{registration}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCourse(string registration)
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

        [HttpPut("modify/{registration}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCourse(StudentInputDTO student, string registration)
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
    }
}
