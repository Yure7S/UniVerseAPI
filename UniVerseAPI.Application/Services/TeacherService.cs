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
        private readonly IMapper _mapper;

        public TeacherService(ITeacher teacher, IAddressEntity addressEntity, IPeople people, IMapper mapper)
        {
            _teacher = teacher;
            _addressEntity = addressEntity;
            _people = people;
            _mapper = mapper;
        }

        public List<TeacherResponseDTO> GetAllAsync()
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

                    AddressResponseDTO addressResponse = _mapper.Map<AddressResponseDTO>(teacherFound);
                    PeopleResponseDTO peopleResponse = _mapper.Map<PeopleResponseDTO>(teacherFound.People);
                    response = _mapper.Map<TeacherResponseDetailsDTO>(teacherFound);
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

        public void SaveTeacher(AddressEntity newAddress, People newPeople, Teacher newTeacher)
        {
            _addressEntity.CreateAsync(newAddress);
            _people.CreateAsync(newPeople);
            _teacher.CreateAsync(newTeacher);
        } 

        public TeacherResponseDetailsDTO Create(TeacherInputDTO teacher)
        {
            try
            {
                // Inputs do banco
                AddressEntity newAddress = _mapper.Map<AddressEntity>(teacher.Address);
                People newPeople = _mapper.Map<People>(teacher.People);
                Teacher newTeacher = new() { Code = teacher.Code };

                newPeople.AddressId = newAddress.Id;
                newPeople.Role = Roles.Teacher;
                newTeacher.PeopleId = newPeople.Id;

                SaveTeacher(newAddress, newPeople, newTeacher);

                // Response do cliente
                TeacherResponseDetailsDTO teacherResponse = new() { Code = teacher.Code };
                teacherResponse.Message = "*** Teacher Created successfully!";
                teacherResponse.Success = true;

                return teacherResponse;
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
                    teacherFound.DeleteAsync();
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

        public async Task<BaseResponseDTO> EnableOrDisableAsync(string code, bool status)
        {
            try
            {
                Teacher? teacherFound = await _teacher.GetTeacherDetailAsync(code);
                BaseResponseDTO response = new();

                if (teacherFound == null)
                {
                    response.Update("*** We couldn't find the Teacher in our database!", false);
                }
                else if (teacherFound.Active == status)
                {
                    response.Update("*** This action has already been performed", false);
                }
                else
                {
                    teacherFound.Activate(status);
                    await _teacher.UpdateAsync(teacherFound);
                    response.Update(status ? "*** Successfully enabled" : "*** Successfully disabled", true);
                }

                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO response = new(
                    message: "*** We encountered an error trying to perform such an action!",
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
                    addressFound = _mapper.Map<AddressEntity>(teacher.Address);
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