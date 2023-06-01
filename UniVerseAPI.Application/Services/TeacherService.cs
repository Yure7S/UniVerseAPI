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
        private readonly ITeacher _ITeacher;
        private readonly ICourse _ICourse;
        private readonly IAddressEntity _IAddressEntity;
        private readonly IPeople _IPeople;

        public TeacherService(ITeacher iTeacher, ICourse iCourse, IAddressEntity iAddressEntity, IPeople iPeople)
        {
            _ITeacher = iTeacher;
            _ICourse = iCourse;
            _IAddressEntity = iAddressEntity;
            _IPeople = iPeople;
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _ITeacher.GetAllAsync();
        }

        public async Task<ICollection<Teacher>> GetTeacherDetailsAsync(Guid id)
        {
            return await _ITeacher.GetTeacherDetailAsync(id);
        }

        public async Task<TeacherActionResponseDTO> GetByIdAsync(Guid id)
        {
            try
            {
                Teacher? studentFound =  await _ITeacher.GetByIdAsync(id);
                if (studentFound == null)
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

                TeacherActionResponseDTO response = new(baseResponse: baseResponse, teacher: studentFound);
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
            _IAddressEntity.CreateAsync(newAddress);
            _IPeople.CreateAsync(newPeople);
            _ITeacher.CreateAsync(newTeacher);
        } 

        public async Task<TeacherActionResponseDTO> CreateAsync(TeacherInputDTO student)
        {
            try
            {
                Course? courseFound = await _ICourse.GetByCodeAsync(student.CourseCode);

                if (courseFound == null)
                {
                    BaseResponseDTO baseResponseNull = new(
                        message: "*** We couldn't find any courses with the given code!",
                        success: false);
                    TeacherActionResponseDTO responseNull = new(baseResponse: baseResponseNull);
                    return responseNull;
                }

                AddressEntity newAddress = new(
                    addressValue: student.Address.AddressValue,
                    number: student.Address.Number,
                    neighborhood: student.Address.Neighborhood,
                    cep: student.Address.Cep);

                People newPeople = new(
                    addressId: newAddress.Id,
                    fullName: student.People.FullName,
                    birthDate: student.People.BirthDate,
                    cpf: student.People.Cpf,
                    gender: student.People.Gender,
                    phone: student.People.Phone,
                    email: student.People.Email,
                    password: student.People.Password);

                Teacher newTeacher = new(
                    courseId: courseFound.Id,
                    peopleId: newPeople.Id,
                    registration: student.Registration);

                SaveTeacher(newAddress, newPeople, newTeacher);

                BaseResponseDTO baseResponse = new(message: "*** Teacher Created successfully!", success: true);
                TeacherActionResponseDTO response = new(studentInput: student, baseResponse: baseResponse);

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
                Teacher? studentFound = await _ITeacher.GetByIdAsync(id);

                if (studentFound == null)
                {
                    BaseResponseDTO respNull = new(message: "*** We couldn't find the Teacher in our database!",
                    success: false);
                    return respNull;
                }

                studentFound.DeleteAsync(true);
                await _ITeacher.UpdateAsync(studentFound);

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

        public void UpdateTeacher(Teacher student, People people,AddressEntity addressEntity)
        {
            _IAddressEntity.UpdateAsync(addressEntity);
            _IPeople.UpdateAsync(people);
            _ITeacher.UpdateAsync(student);
        }

        public async Task<BaseResponseDTO> UpdateAsync(TeacherInputDTO student, Guid id)
        {
            try
            {
                Course? courseFound = await _ICourse.GetByCodeAsync(student.CourseCode);
                Teacher? studentFound = await _ITeacher.GetByIdAsync(id);
                People? peopleFound = await _IPeople.GetByIdAsync(studentFound!.PeopleId);
                AddressEntity? addressFound = await _IAddressEntity.GetByIdAsync(peopleFound!.AddressId);

                if (studentFound == null)
                {
                    BaseResponseDTO respNull = new(message: "*** We couldn't find the Teacher in our database!",
                    success: false);
                    return respNull;
                }

                studentFound.CourseTransfer(
                    courseId: courseFound!.Id);

                addressFound!.UpdateAsync(
                    addressValue: student.Address.AddressValue,
                    number: student.Address.Number,
                    neighborhood: student.Address.Neighborhood,
                    cep: student.Address.Cep);

                peopleFound.UpdateAsync(
                    fullName: student.People.FullName,
                    birthDate: student.People.BirthDate,
                    cpf: student.People.Cpf,
                    gender: student.People.Gender,
                    phone: student.People.Phone,
                    email: student.People.Email,
                    password: student.People.Password);

                UpdateTeacher(studentFound, peopleFound, addressFound!);

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
