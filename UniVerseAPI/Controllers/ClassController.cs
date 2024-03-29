﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniVerseAPI.Application.DTOs.Request.MasterEntitiesDTO;
using UniVerseAPI.Application.DTOs.Request.MasterInputsDTO;
using UniVerseAPI.Application.IServices;

namespace UniVerseAPI.Controllers
{
    [Route("class")]
    [ApiController]
    [Authorize(Roles = "Director, Administrator")]
    public class ClassController : ControllerBase
    {

        private readonly IClassService _IClassService;

        public ClassController(IClassService classInjection)
        {
            _IClassService = classInjection;
        }


        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllAsync()
        {
            try
            {
                var response = _IClassService.GetAllAsync();
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
        public async Task<IActionResult> GetByIdAsync(int code)
        {
            if (ModelState.IsValid)
            {
                var response = await _IClassService.GetByCodeAsync(code);

                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpGet("all-students-this-class")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AllStudentsThisClass(int code)
        {
            if (ModelState.IsValid)
            {
                var response = _IClassService.AllStudentsThisClass(code);
                return Ok(response);
            }
            return StatusCode(500);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsyncClass(ClassInputDTO classInput)
        {
            if (ModelState.IsValid)
            {
                var response = await _IClassService.CreateAsync(classInput);

                if (response.Success)
                    return Created("Successfully Created!", response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsyncClass(ClassInputDTO classInput, Guid id)
        {
            if (ModelState.IsValid)
            {
                var response = await _IClassService.UpdateAsync(classInput, id);

                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsyncClass(Guid id)
        {
            if (ModelState.IsValid)
            {
                var response = await _IClassService.DeleteAsync(id);
                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }

    }
}
