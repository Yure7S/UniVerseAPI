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
    [Route("subject")]
    [ApiController]
    [Authorize(Roles = "Director, Administrator")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _ISubjectService;

        public SubjectController(ISubjectService subject)
        {
            _ISubjectService = subject;
        }


        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            try
            {
                var response = _ISubjectService.GetAllAsync();
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
                var response = await _ISubjectService.GetByCodeAsync(code);

                if(response.Success)
                    return Ok(response);
                    return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSubjectAsync(SubjectInputDTO subject)
        {
            if (ModelState.IsValid)
            {
                var response = await _ISubjectService.CreateAsync(subject);

                if (response.Success)
                    return Created("Successfully Created!", response);
                    return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpPut("modify/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSubjectAsync(SubjectInputDTO subject, string code)
        {
            if (ModelState.IsValid)
            {
                var response = await _ISubjectService.UpdateAsync(subject, code);

                if (response.Success)
                    return Ok(response);
                    return BadRequest(response);
            }
            return StatusCode(500);
        }

        [HttpDelete("delet/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteSubjectAsync(string code)
        {
            if (ModelState.IsValid)
            {
                var response = await _ISubjectService.DeleteAsync(code);
                if (response.Success)
                    return Ok(response);
                    return BadRequest(response);
            }
            return StatusCode(500);
        }

    }
}
