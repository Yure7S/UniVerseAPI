using Microsoft.AspNetCore.Mvc;
using UniVerseAPI.Application.DTOs.Request.Common;
using UniVerseAPI.Application.IServices;

namespace UniVerseAPI.Controllers
{
    [Route("autentication")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        //private readonly IClassService _IClassService;

        //public AuthenticationController(IClassService classInjection)
        //{
        //    _IClassService = classInjection;
        //}

        [HttpPost("")]
        public IActionResult Login(LoginInputDTO login)
        {
            return Ok(login);
        }
    }
}
