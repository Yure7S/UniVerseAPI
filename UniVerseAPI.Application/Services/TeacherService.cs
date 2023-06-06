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

        public TeacherService(ITeacher teacher, IAddressEntity addressEntity, IPeople people)
        {
            _teacher = teacher;
            _addressEntity = addressEntity;
            _people = people;

        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _teacher.GetAllAsync();
        }

        public async Task<ICollection<Teacher>> GetTeacherDetailsAsync(Guid id)
        {
            return await _teacher.GetTeacherDetailAsync(id);
        }

        public async Task<TeacherActionResponseDTO> GetByIdAsync(Guid id)
        {
            try
            {
                Teacher? teacherFound = await _teacher.GetByIdAsync(id);
                if (teacherFound == null)
                {
                    BaseResponseDTO baseRespNull = new(
                        message: "We could not find this item in our database.",
                        success: false);

                    TeacherActionResponseDTO respNull = new(baseResponse: baseRespNull);
                    return respNull;
                }

                BaseResponseDTO baseResponse = new(
                        message: "Found successfully!",
                        success: true);

                TeacherActionResponseDTO response = new(baseResponse: baseResponse, teacher: teacherFound);
                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO baseResponse = new(message: "*** We encountered an error trying to find the Teacher!", success: false, error: e.Message);
                TeacherActionResponseDTO response = new(baseResponse: baseResponse);
                return response;
            }
        }

        public void SaveTeacher(AddressEntity newAddress, People newPeople, Teacher newTeacher)
        {
            _addressEntity.CreateAsync(newAddress);
            _people.CreateAsync(newPeople);
            _teacher.CreateAsync(newTeacher);
        } 

        public TeacherActionResponseDTO CreateAsync(TeacherInputDTO teacher)
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
                TeacherActionResponseDTO response = new(teacherInput: teacher, baseResponse: baseResponse);

                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO baseResponse = new(message: "*** We encountered an error trying to register a new Teacher!", success: false, error: e.Message);
                TeacherActionResponseDTO responseError = new(baseResponse: baseResponse);
                return responseError;
            }
        }


        public async Task<BaseResponseDTO> DeleteAsync(Guid id)
        {
            try
            {
                Teacher? teacherFound = await _teacher.GetByIdAsync(id);

                if (teacherFound == null)
                {
                    BaseResponseDTO respNull = new(message: "*** We couldn't find the Teacher in our database!",
                    success: false);
                    return respNull;
                }

                teacherFound.DeleteAsync(true);
                await _teacher.UpdateAsync(teacherFound);

                BaseResponseDTO response = new(message: "*** Deleted successfully!",
                success: true);
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

        public async Task<BaseResponseDTO> EnableOrDisable(Guid id, bool status)
        {
            try
            {
                Teacher? teacherFound = await _teacher.GetByIdAsync(id);
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

        public async Task<BaseResponseDTO> UpdateAsync(TeacherInputDTO teacher, Guid id)
        {
            try
            {
                Teacher? teacherFound = await _teacher.GetByIdAsync(id);
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
