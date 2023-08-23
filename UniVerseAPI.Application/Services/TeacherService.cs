using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using UniVerseAPI.Application.DTOs.Request;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Application.DTOs.Response.TeachersDTO;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Application.IServices;
using UniVerseAPI.Domain.Enums;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Services
{
    public class TeacherService : ITeacherService 
    {
        private readonly ITeacher _teacher;
        private readonly IAddressEntity _addressEntity;
        private readonly IPeople _people;
        private readonly IUser _user;
        private readonly IMapper _mapper;
        private readonly IRoles _roles;

        public TeacherService(ITeacher teacher, IAddressEntity addressEntity, IPeople people, IMapper mapper, IUser user, IRoles roles)
        {
            _teacher = teacher;
            _addressEntity = addressEntity;
            _people = people;
            _mapper = mapper;
            _user = user;
            _roles = roles;
        }

        public List<TeacherResponseDTO> GetAll()
        {
            return _teacher.GetAllTeacherAsync()
                .Result
                .ConvertAll(tchr => new TeacherResponseDTO(tchr));
        }

        public async Task<TeacherResponseDetailsDTO> GetTeacherDetailAsync(string code)
        {
            try
            {
                Teacher teacherFound = await _teacher.GetTeacherDetailAsync(code);
                TeacherResponseDetailsDTO response = new();

                if (teacherFound == null)
                {
                    response.Message = "We could not find this item in our database.";
                    response.Success = false;
                }
                else
                {
                    response.Update("Found successfully!", true);

                    AddresResponseDTO addressResponse = _mapper.Map<AddresResponseDTO>(teacherFound.People.AddressEntity);
                    PeopleResponseDTO peopleResponse = _mapper.Map<PeopleResponseDTO>(teacherFound.People);
                    peopleResponse.Email = teacherFound.People.User.Email;
                    peopleResponse.AddressEntity = addressResponse;

                    response.Code = code;
                    response.People = peopleResponse;
                    response.Message = "Found successfully!";
                    response.Success = true;
                }

                return response;
            }
            catch (Exception e)
            {
                TeacherResponseDetailsDTO response = new()
                {
                    Message = "*** We encountered an error trying to find the Teacher!",
                    Success = false,
                    Error = e.Message
                };
                return response;
            }
        }

        public void SaveTeacher(AddressEntity newAddress, People newPeople, Teacher newTeacher, User user)
        {
            _addressEntity.CreateAsync(newAddress);
            _people.CreateAsync(newPeople);
            _teacher.CreateAsync(newTeacher);
            _user.CreateAsync(user);    
        } 

        public async Task<TeacherResponseDetailsDTO> CreateAsync(TeacherInputDTO teacher)
        {
            try
            {
                AddressEntity newAddress = _mapper.Map<AddressEntity>(teacher.AddressEntity);
                People newPeople = _mapper.Map<People>(teacher.People);
                User newUser = _mapper.Map<User>(teacher.User);
                Teacher newTeacher = new() { Code = teacher.Code };

                Roles? roleFound = await _roles.GetRoleByRoleValue(RolesEnum.Teacher);

                newPeople.AddressId = newAddress.Id;
                newPeople.UserId = newUser.Id;
                newUser.RoleId = roleFound!.Id;
                newTeacher.PeopleId = newPeople.Id;
                newUser.Password = Crypto.HashPassword(teacher.User.Password);

                SaveTeacher(newAddress, newPeople, newTeacher, newUser);

                TeacherResponseDetailsDTO response = new() { 
                    Code = teacher.Code,
                    Message = "*** Teacher Created successfully!",
                    Success = true
                };

                return response;
            }
            catch (Exception e)
            {
                TeacherResponseDetailsDTO response = new()
                {
                    Message = "*** We encountered an error trying to register a new Teacher!",
                    Success = false,
                    Error = e.Message
                };
                return response;
            }
        }

        public async Task<BaseResponseDTO> DeleteAsync(string code)
        {
            try
            {
                Teacher? teacherFound = await _teacher.GetTeacherDetailAsync(code);
                BaseResponseDTO response = new();

                if (teacherFound == null)
                {
                    response.Update("*** We couldn't find the Teacher in our database!", false);
                }
                else
                {
                    teacherFound.Deleted = true;
                    await _teacher.UpdateAsync(teacherFound);
                    response.Update("*** Deleted successfully!", true);
                }

                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO response = new(
                    message: "*** We encountered an error trying to delete the Teacher!",
                    success: false,
                    error: e.Message);

                return response;
            }
        }

        public void UpdateTeacher(People people, AddressEntity addressEntity)
        {
            _addressEntity.UpdateAsync(addressEntity);
            _people.UpdateAsync(people);
        }

        public async Task<BaseResponseDTO> UpdateAsync(TeacherInputDTO teacher, string code)
        {
            try
            {
                Teacher? teacherFound = await _teacher.GetTeacherDetailAsync(code);
                People? peopleFound = await _people.GetByIdAsync(teacherFound!.PeopleId);
                AddressEntity? addressFound = await _addressEntity.GetByIdAsync(peopleFound!.AddressId);
                BaseResponseDTO response = new();

                if (teacherFound == null)
                {
                    response.Update(message: "*** We couldn't find the Teacher in our database!", success: false);
                }
                else
                {
                    addressFound = _mapper.Map<AddressEntity>(teacher.AddressEntity);
                    peopleFound = _mapper.Map<People>(teacher.People);
                    UpdateTeacher(peopleFound, addressFound!);

                    response.Update(message: "*** Teacher UpdateAsyncd successfully!", success: true);
                }

                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO response = new(
                    message: "*** We encountered an error trying to UpdateAsync the Teacher!",
                    success: false,
                    error: e.Message);

                return response;
            }
        }
    }
    }