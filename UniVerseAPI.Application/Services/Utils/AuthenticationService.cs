using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using UniVerseAPI.Application.DTOs.Request.Common;
using UniVerseAPI.Application.DTOs.Request.MasterInputsDTO;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Application.DTOs.Response.ClassDTO;
using UniVerseAPI.Application.DTOs.Response.CoursesDTO;
using UniVerseAPI.Application.DTOs.Response.StudentsDTO;
using UniVerseAPI.Application.IServices;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;
using IUser = UniVerseAPI.Domain.Interface.IUser;

namespace UniVerseAPI.Application.Services.Utils
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IPeople _people;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _Configuration;
        private readonly IUser _user;

        public AuthenticationService(IPeople people, IConfiguration configuration, ITokenService tokenService, IUser user)
        {
            _people = people;
            _Configuration = configuration;
            _tokenService = tokenService;
            _user = user;
        }

        public LoginResponseDTO Login(LoginOrUserInputDTO login)
        {
            try
            {
                string adminPassword = Crypto.HashPassword(login.Password); 
                LoginResponseDTO response = new();
                User? userFound = _user.GetByEmail(login.Email!);
                bool passwordCheck = Crypto.VerifyHashedPassword(userFound?.Password, login.Password);

                if (userFound == null || !passwordCheck)
                {
                    response.Message = "*** Invalid email or password";
                    response.Success = false;
                }
                else
                {
                    UserTokenDTO user = new()
                    {
                        Username = userFound.Email,
                        Role = userFound.Roles.RoleValue
                    };

                    string token = _tokenService.GenerateToken(user);
                    response.Token = token;
                    response.Success = true;
                }

                return response;
            }
            catch (Exception e)
            {
                LoginResponseDTO responseError = new()
                {
                    Message = "*** We encountered errors when trying to login",
                    Success = false,
                    Error = e.Message
                };
                return responseError;
            }
        }

    }
}
