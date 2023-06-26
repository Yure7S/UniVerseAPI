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

        [HttpGet("subjects-done")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SubjectsDone(string registration)
        {
            if (ModelState.IsValid)
            {
                var response = await _IStudentService.GetSubjectsDone(registration);

                return Ok(response);

                //if (response.Success)
                //    return Ok(response);
                //return BadRequest(response);
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

                if (response.Success)
                    return Created("Successfully created!", response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpPost("add-student-in-class")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddStudentInClass(int codeClass,  string registrationStudent)
        {
            if (ModelState.IsValid)
            {
                var response = await _IStudentService.AddStudentInClass(codeClass, registrationStudent);

                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpPut("{registration}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCourse(StudentUpdateDTO student, string registration)
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

        [HttpDelete("delet/{registration}")]
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

        [HttpDelete("remove-student-from-class")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public /*async Task<IActionResult>*/ IActionResult RemoveStudentFromClass()
        {
            if (ModelState.IsValid)
            {
                var response = "to-do";
                return Ok(response);
                //if (response.Success)
                //    return Ok(response);
                //return BadRequest(response);
            }
            return StatusCode(500);
        }
    }
}
