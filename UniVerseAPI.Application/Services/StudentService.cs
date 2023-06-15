using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Request;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Application.DTOs.Response.StudentsDTO;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Application.IServices;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Services
{
    public class StudentService : IStudentService 
    {
        private readonly IStudent _IStudent;
        private readonly ICourse _ICourse;
        private readonly IAddressEntity _IAddressEntity;
        private readonly IPeople _IPeople;
        private readonly IMapper _mapper;

        public StudentService(IStudent iStudent, ICourse iCourse, IAddressEntity iAddressEntity, IPeople iPeople, IMapper mapper)
        {
            _IStudent = iStudent;
            _ICourse = iCourse;
            _IAddressEntity = iAddressEntity;
            _IPeople = iPeople;
            _mapper = mapper;
        }

        public List<StudentResponseDTO> GetAllAsync()
        {
            return _IStudent.GetAllStudentAsync()
                .Result
                .ConvertAll(std => new StudentResponseDTO(std));
        }

        public async Task<StudentResponseDetailsDTO> GetByRegistrationAsync(string registration)
        {
            try
            {
                Student? studentFound =  await _IStudent.GetStudentDetailAsync(registration);
                StudentResponseDetailsDTO response = new();

                if (studentFound == null)
                {
                    response.Message = "*** We couldn't find the Student in our database!";
                    response.Success = false;
                }
                else
                {
                    AddressResponseDTO addressResponse = _mapper.Map<AddressResponseDTO>(studentFound.People.AddressEntity);
                    PeopleResponseDTO peopleResponse = _mapper.Map<PeopleResponseDTO>(studentFound.People);

                    response.Registration = registration;
                    response.People = peopleResponse;
                    response.Message = "Found successfully!";
                    response.Success = true;
                }
                
                return response;
            }
            catch (Exception e)
            {
                StudentResponseDetailsDTO response = new()
                {
                    Message = "*** We encountered an error trying to find the Student!",
                    Success = false,
                    Error = e.Message
                };
                return response;
            }
        }

        public void SaveStudent(AddressEntity newAddress, People newPeople, Student newStudent)
        {
            _IAddressEntity.CreateAsync(newAddress);
            _IPeople.CreateAsync(newPeople);
            _IStudent.CreateAsync(newStudent);
        } 

        public async Task<StudentResponseDetailsDTO> CreateAsync(StudentInputDTO student)
        {
            try
            {
                Student? studentFoundEmail = await _IStudent.GetStudentByEmailAsync(student.People.Email);
                Course? courseFound = await _ICourse.GetByCodeAsync(student.CourseCode);
                StudentResponseDetailsDTO response = new();

                if (courseFound == null)
                {
                    response.Message = "*** We couldn't find any courses with the given code!";
                    response.Success = false;
                }
                else if (studentFoundEmail?.People.Email != null)
                {
                    response.Message = "*** This email has already been registered!";
                    response.Success = false;
                }
                else
                {
                    string code = DateTime.Now.Year + courseFound!.FullName[..3].ToUpper() + new Random().Next(100, 999);
                    AddressEntity newAddress = _mapper.Map<AddressEntity>(student.Address);
                    People newPeople = _mapper.Map<People>(student.People);
                    Student newStudent = new();
                    newPeople.AddressId = newAddress.Id;
                    newStudent.PeopleId = newPeople.Id;
                    newStudent.CourseId = courseFound.Id;
                    newStudent.Registration = code;

                    AddressResponseDTO addressResponse = _mapper.Map<AddressResponseDTO>(newAddress);
                    PeopleResponseDTO peopleResponse = _mapper.Map<PeopleResponseDTO>(newPeople);
                    peopleResponse.AddressEntity = addressResponse;

                    SaveStudent(newAddress, newPeople, newStudent);

                    response.Registration = code;
                    response.People = peopleResponse;
                    response.Message = "*** Student Created successfully!";
                    response.Success = true;
                }
                
                return response;
            }
            catch (Exception e)
            {
                StudentResponseDetailsDTO responseError = new()
                {
                    Message = "*** We encountered an error trying to register a new Student!",
                    Success = false,
                    Error = e.Message
                };
                return responseError;
            }
        }

        public async Task<BaseResponseDTO> DeleteAsync(string registration)
        {
            try
            {
                Student? studentFound = await _IStudent.GetStudentDetailAsync(registration);
                BaseResponseDTO response = new();

                if (studentFound == null)
                {
                    response.Update("*** We couldn't find the Student in our database!", false);
                }
                else
                {
                    studentFound.DeleteAsync(true);
                    await _IStudent.UpdateAsync(studentFound);
                    response.Update("*** Deleted successfully!", true);
                }

                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO response = new(message: "*** We encountered an error trying to delete the Student!",
                    success: false,
                    error: e.Message);

                return response;
            }
        }

        public async Task UpdateStudent(People people, AddressEntity addressEntity)
        {
            await _IAddressEntity.UpdateAsync(addressEntity);
            await _IPeople.UpdateAsync(people);
        }

        public async Task<BaseResponseDTO> UpdateAsync(StudentUpdateDTO student, string registration)
        {
            try
            {
                Student studentFound = await _IStudent.GetStudentDetailAsync(registration);

                BaseResponseDTO response = new();

                if (studentFound == null)
                {
                    response.Update(message: "*** We couldn't find the Student in our database!", success: false);
                }
                else
                {
                    People? peopleFound = await _IPeople.GetByIdAsync(studentFound.PeopleId);
                    AddressEntity? addressFound = await _IAddressEntity.GetByIdAsync(studentFound.People.AddressId);

                    peopleFound = _mapper.Map<People>(student.People);
                    addressFound = _mapper.Map<AddressEntity>(student.Address);

                    await UpdateStudent(peopleFound!, addressFound!);

                    response.Update(message: "*** Student UpdateAsyncd successfully!", success: true);
                }

                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO response = new(
                    message: "*** We encountered an error trying to UpdateAsync the Student!",
                    success: false, 
                    error: e.Message);

                return response;
            }
        }
    }
}