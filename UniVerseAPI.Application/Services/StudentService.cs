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
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Request;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Application.DTOs.Response.StudentsDTO;
using UniVerseAPI.Application.DTOs.Response.SubjectDTO;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Application.IServices;
using UniVerseAPI.Domain.Entities.MasterEntities;
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
        private readonly IGroupStudentClass _IGroupStudentClass;
        private readonly IClass _IClass;


        public StudentService(IStudent iStudent, ICourse iCourse, IAddressEntity iAddressEntity, IPeople iPeople, IMapper mapper, IGroupStudentClass groupStudentClass, IClass iClass)
        {
            _IStudent = iStudent;
            _ICourse = iCourse;
            _IClass = iClass;
            _IAddressEntity = iAddressEntity;
            _IPeople = iPeople;
            _mapper = mapper;
            _IGroupStudentClass = groupStudentClass;
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
                    response.Update(message: "*** We couldn't find the student in our database!", success: false);
                }
                else
                {
                    People? peopleFound = await _IPeople.GetByIdAsync(studentFound.PeopleId);
                    AddressEntity? addressFound = await _IAddressEntity.GetByIdAsync(studentFound.People.AddressId);

                    peopleFound = _mapper.Map<People>(student.People);
                    addressFound = _mapper.Map<AddressEntity>(student.Address);

                    await UpdateStudent(peopleFound!, addressFound!);

                    response.Update(message: "*** Student updated successfully!", success: true);
                }

                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO response = new(
                    message: "*** We encountered an error trying to update the student!",
                    success: false, 
                    error: e.Message);

                return response;
            }
        }

        public async Task<BaseResponseDTO> AddStudentInClass(GroupStudentClassInputDTO gscInput)
        {
            try
            {
                BaseResponseDTO response = new();

                Student studentFound = await _IStudent.GetStudentDetailAsync(gscInput.StudentRegistration);
                Class? classFound = await _IClass.GetByCodeAsync(gscInput.ClassCode);
                GroupStudentClass? gscFound = await _IGroupStudentClass.GetByClassIdAndStudentId(studentId: studentFound.Id, classId: classFound!.Id);

                if (studentFound == null || classFound == null)
                    response.Update(message: "*** We couldn't find the information you entered in our database!", success: false);
                else if(gscFound != null)
                    response.Update(message: "*** The student is already included in this class!", success: false);
                else
                {
                    GroupStudentClass gsc = new()
                    {
                        StudentId = studentFound.Id,
                        ClassId = classFound.Id
                    };
                    await _IGroupStudentClass.CreateAsync(gsc);

                    response.Update(message: $"*** The student has been entered into the class that contains the code: {gscInput.ClassCode}", success: true);
                }

                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO response = new(
                    message: "*** We encountered an error trying to insert the student with into the class!",
                    success: false,
                    error: e.Message);

                return response;
            }
        }

        public async Task<List<SubjectResponseDTO>> GetSubjectsDone(string registration)
        {
            try
            {
                
                Student studentFound = await _IStudent.GetStudentDetailAsync(registration);
                return _IGroupStudentClass.GetAllByStudentId(studentFound.Id)
                    .Result
                    .ConvertAll(std => new SubjectResponseDTO(std));

            }
            catch (Exception)
            {

                //BaseResponseDTO response = new()
                //{
                //    Message = "*** We came across errors when trying to fetch the materials made by the student.",
                //    Success = false,
                //    Error = e.Message
                //};
                List<SubjectResponseDTO> response = new();

                return response;
            }
        }
    }
}