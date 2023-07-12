using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using UniVerseAPI.Application.DTOs.Request.Common;
using UniVerseAPI.Application.IServices;

namespace UniVerseAPI.Controllers
{
    [Route("authentication")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _IAuthenticationService;

        public AuthenticationController(IAuthenticationService autentication)
        {
            _IAuthenticationService = autentication;
        }

        [HttpPost("")]
        public async Task<IActionResult> Login(LoginInputDTO login)
        {
            if (ModelState.IsValid)
            {
                var response = await _IAuthenticationService.Login(login);

                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            return StatusCode(500);
        }
    }
}
