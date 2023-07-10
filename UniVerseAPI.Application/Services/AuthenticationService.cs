using AutoMapper;
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
        public AuthenticationService(IPeople people) 
        {
            _people = people;
        }

        public async Task<LoginResponseDTO> Login(LoginInputDTO login)
        {
            try
            {
                People? people = await _people.GetByEmailAndPassword(email: login.Email!, password: login.Password!);
                LoginResponseDTO response = new();

                if(people == null)
                {
                    response.Message = "*** *** Invalid email or password";
                    response.Success = false;
                }
                else
                {
                    string token = TokenService.GeneratedToken(people);
                    response.Email = people.Email;
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
