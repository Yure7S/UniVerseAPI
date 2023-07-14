using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Request.MasterEntitiesDTO;
using UniVerseAPI.Application.DTOs.Request.MasterInputsDTO;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Application.DTOs.Response.ClassDTO;
using UniVerseAPI.Application.DTOs.Response.CoursesDTO;
using UniVerseAPI.Application.DTOs.Response.StudentsDTO;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.IServices
{
    public interface ITokenService
    {
        public string GenerateToken(UserTokenDTO token);
        public string GenerateRefreshToken();
        public ClaimsPrincipal GetClaimsFromExpiredToken(string token);
    }
}
