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
using UniVerseAPI.Application.DTOs.Response;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Application.IServices;
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

        public List<TeacherActionResponseDTO> GetAllAsync()
        {
            return _teacher.GetAllTeacherAsync()
                .Result
                .ConvertAll(tchr => new TeacherActionResponseDTO(tchr));
        }

        public async Task<TeacherActionResponseDetailsDTO> GetTeacherDetailAsync(string code)
        {
            try
            {
                Teacher teacherFound = await _teacher.GetTeacherDetailAsync(code);
                BaseResponseDTO response = new();

                if (teacherFound == null)
                {
                    response.Update("We could not find this item in our database.", false);
                    TeacherActionResponseDetailsDTO respNull = new(baseResponse: response);
                    return respNull;
                }

                response.Update("Found successfully!", true);

                AddressResponseDTO addressResponse = new(
                    addressValue: teacherFound.People.AddressEntity.AddressValue,
                    number: teacherFound.People.AddressEntity.Number,
                    neighborhood: teacherFound.People.AddressEntity.Neighborhood,
                    cep: teacherFound.People.AddressEntity.Cep);

                PeopleResponseDTO peopleResponse = new(
                    fullName: teacherFound.People.FullName,
                    birthDate: teacherFound.People.BirthDate,
                    cpf: teacherFound.People.Cpf,
                    gender: teacherFound.People.Gender,
                    phone: teacherFound.People.Phone,
                    email: teacherFound.People.Email,
                    password: teacherFound.People.Password,
                    addressEntity: addressResponse);

                TeacherActionResponseDetailsDTO teacherResponse = new(
                    code: teacherFound.Code,
                    people: peopleResponse,
                    baseResponse: response);

                return teacherResponse;
            }
            catch (Exception e)
            {
                BaseResponseDTO baseResponse = new(message: "*** We encountered an error trying to find the Teacher!", success: false, error: e.Message);
                TeacherActionResponseDetailsDTO response = new(baseResponse: baseResponse);
                return response;
            }
        }

        public void SaveTeacher(AddressEntity newAddress, People newPeople, Teacher newTeacher)
        {
            _addressEntity.CreateAsync(newAddress);
            _people.CreateAsync(newPeople);
            _teacher.CreateAsync(newTeacher);
        } 

        public TeacherActionResponseDetailsDTO CreateAsync(TeacherInputDTO teacher)
        {
            try
            {

                AddressEntity newAddress = new(
                    addressValue: teacher.Address.AddressValue,
                    number: teacher.Address.Number,
                    neighborhood: teacher.Address.Neighborhood,
                    cep: teacher.Address.Cep);

                People newPeople = new(
                    addressId: newAddress.Id,
                    fullName: teacher.People.FullName,
                    birthDate: teacher.People.BirthDate,
                    cpf: teacher.People.Cpf,
                    gender: teacher.People.Gender,
                    phone: teacher.People.Phone,
                    email: teacher.People.Email,
                    password: teacher.People.Password);

                Teacher newTeacher = new(
                    peopleId: newPeople.Id,
                    code: teacher.Code);

                SaveTeacher(newAddress, newPeople, newTeacher);

                BaseResponseDTO baseResponse = new(message: "*** Teacher Created successfully!", success: true);
                TeacherActionResponseDetailsDTO response = new(baseResponse: baseResponse);

                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO baseResponse = new(message: "*** We encountered an error trying to register a new Teacher!", success: false, error: e.Message);
                TeacherActionResponseDetailsDTO responseError = new(baseResponse: baseResponse);
                return responseError;
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
                    teacherFound.DeleteAsync(true);
                    await _teacher.UpdateAsync(teacherFound);
                    response.Update("*** Deleted successfully!", true);
                }

                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO response = new(message: "*** We encountered an error trying to delete the Teacher!",
                    success: false,
                    error: e.Message);

                return response;
            }
        }

        public async Task<BaseResponseDTO> EnableOrDisable(string code, bool status)
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
                BaseResponseDTO response = new(message: "*** We encountered an error trying to perform such an action!",
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

                if (teacherFound == null)
                {
                    BaseResponseDTO respNull = new(message: "*** We couldn't find the Teacher in our database!",
                    success: false);
                    return respNull;
                }


                addressFound!.UpdateAsync(
                    addressValue: teacher.Address.AddressValue,
                    number: teacher.Address.Number,
                    neighborhood: teacher.Address.Neighborhood,
                    cep: teacher.Address.Cep);

                peopleFound.UpdateAsync(
                    fullName: teacher.People.FullName,
                    birthDate: teacher.People.BirthDate,
                    cpf: teacher.People.Cpf,
                    gender: teacher.People.Gender,
                    phone: teacher.People.Phone,
                    email: teacher.People.Email,
                    password: teacher.People.Password);

                UpdateTeacher(peopleFound, addressFound!);

                BaseResponseDTO response = new(message: "*** Teacher UpdateAsyncd successfully!",
                success: true);
                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO response = new(message: "*** We encountered an error trying to UpdateAsync the Teacher!",
                    success: false,
                    error: e.Message);

                return response;
            }
        }
    }
    }