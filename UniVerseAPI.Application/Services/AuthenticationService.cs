using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Request.Common;
using UniVerseAPI.Application.DTOs.Request.MasterInputsDTO;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Application.DTOs.Response.ClassDTO;
using UniVerseAPI.Application.DTOs.Response.CoursesDTO;
using UniVerseAPI.Application.DTOs.Response.StudentsDTO;
using UniVerseAPI.Application.IServices;
using UniVerseAPI.Application.Services.Utils;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IPeople _people;
        private readonly IConfiguration _Configuration;

        public AuthenticationService(IPeople people, IConfiguration configuration) 
        {
            _people = people;
            _Configuration = configuration;
        }

        public async Task<LoginResponseDTO> Login(LoginInputDTO login)
        {
            try
            {
                LoginResponseDTO response = new();
                string userMaster = _Configuration["Administrator:Username"]!;
                string passwordMaster = _Configuration["Administrator:Password"]!;
                string roleMaster = _Configuration["Administrator:Role"]!;

                if (userMaster == login.Email && passwordMaster == login.Password)
                {
                    UserTokenDTO user = new()
                    {
                        Username = "SuperUser",
                        Role = roleMaster
                    };

                    string token = TokenService.GeneratedToken(user);
                    response.Token = token;
                    response.Success = true;

                    return response;
                }
                People? peopleFound = await _people.GetByEmailAndPassword(email: login.Email!, password: login.Password!);

                if (peopleFound == null)
                {
                    response.Message = "*** *** Invalid email or password";
                    response.Success = false;
                }
                else
                {
                    UserTokenDTO user = new()
                    {
                        Username = peopleFound.Cpf,
                        Role = peopleFound.Role.ToString()
                    };

                    string token = TokenService.GeneratedToken(user);
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
