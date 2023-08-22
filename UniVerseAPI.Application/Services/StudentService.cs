using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
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
using System.Web.Helpers;
using UniVerseAPI.Application.DTOs.Request;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Application.DTOs.Response.GradesDTO;
using UniVerseAPI.Application.DTOs.Response.StudentsDTO;
using UniVerseAPI.Application.DTOs.Response.SubjectDTO;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Application.IServices;
using UniVerseAPI.Domain.Enums;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Services
{
    public class StudentService : IStudentService 
    {
        private readonly IStudent _student;
        private readonly ICourse _course;
        private readonly IAddressEntity _addressEntity;
        private readonly IPeople _people;
        private readonly IMapper _mapper;
        private readonly IClass _class;
        private readonly IGrades _grades;
        private readonly IUser _user;
        private readonly ISubject _subject;
        private readonly IRoles _roles;

        public StudentService(
            IStudent iStudent, 
            ICourse iCourse,
            IAddressEntity iAddressEntity, 
            IPeople iPeople,
            IMapper mapper,
            IClass iClass, 
            IGrades grades,
            ISubject subject, 
            IUser user,
            IRoles roles)
        {
            _student = iStudent;
            _course = iCourse;
            _class = iClass;
            _addressEntity = iAddressEntity;
            _people = iPeople;
            _grades = grades;
            _subject = subject;
            _user = user;
            _mapper = mapper;
            _roles = roles;
        }

        public List<StudentResponseDTO> GetAll()
        {
            return _student.GetAllStudentAsync()
                .Result
                .ConvertAll(std => new StudentResponseDTO(std));
        }

        public async Task<StudentResponseDetailsDTO> GetByRegistrationAsync(string registration)
        {
            try
            {
                Student? studentFound =  await _student.GetStudentDetailAsync(registration);
                StudentResponseDetailsDTO response = new();

                if (studentFound == null)
                {
                    response.Message = "*** We couldn't find the Student in our database!";
                    response.Success = false;
                }
                else
                {
                    AddressEntity addressResponse = _mapper.Map<AddressEntity>(studentFound.People.AddressEntity);
                    PeopleResponseDTO peopleResponse = _mapper.Map<PeopleResponseDTO>(studentFound.People);
                    peopleResponse.Email = studentFound.People.User.Email;

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

        public void SaveStudent(AddressEntity newAddress, People newPeople, Student newStudent, User user)
        {
            _addressEntity.CreateAsync(newAddress);
            _people.CreateAsync(newPeople);
            _student.CreateAsync(newStudent);
            _user.CreateAsync(user);
        } 

        public async Task<StudentResponseDetailsDTO> CreateAsync(StudentInputDTO student)
        {
            try
            {
                Student? studentFoundEmail = await _student.GetStudentByEmailAsync(student.User.Email!);
                Course? courseFound = await _course.GetByCodeAsync(student.CourseCode);
                StudentResponseDetailsDTO response = new();

                if (courseFound == null)
                {
                    response.Message = "*** We couldn't find any courses with the given code!";
                    response.Success = false;
                }
                else if (studentFoundEmail?.People.User.Email != null)
                {
                    response.Message = "*** This email has already been registered!";
                    response.Success = false;
                }
                else
                {
                    string code = DateTime.Now.Year + courseFound!.FullName[..3].ToUpper() + new Random().Next(100, 999);

                    Roles? roleFound = await _roles.GetRoleByRoleValue(RolesEnum.Student);

                    AddressEntity newAddress = _mapper.Map<AddressEntity>(student.Address);
                    People newPeople = _mapper.Map<People>(student.People);
                    User newUser = _mapper.Map<User>(student.User);
                    newUser.Password = Crypto.HashPassword(student.User.Password);

                    Student newStudent = new()
                    {
                        CourseId = courseFound.Id,
                        Registration = code,
                        PeopleId = newPeople.Id,
                    };

                    newPeople.AddressId = newAddress.Id;
                    newPeople.UserId = newUser.Id;
                    newUser.RoleId = roleFound!.Id;

                    SaveStudent(newAddress, newPeople, newStudent, newUser);

                    response.StudentInput = student;
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
                Student? studentFound = await _student.GetStudentDetailAsync(registration);
                BaseResponseDTO response = new();

                if (studentFound == null)
                {
                    response.Update("*** We couldn't find the Student in our database!", false);
                }
                else
                {
                    studentFound.DeleteAsync();
                    await _student.UpdateAsync(studentFound);
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
            await _addressEntity.UpdateAsync(addressEntity);
            await _people.UpdateAsync(people);
        }

        public async Task<BaseResponseDTO> UpdateAsync(StudentUpdateDTO student, string registration)
        {
            try
            {
                Student studentFound = await _student.GetStudentDetailAsync(registration);

                BaseResponseDTO response = new();

                if (studentFound == null)
                {
                    response.Update(message: "*** We couldn't find the student in our database!", success: false);
                }
                else
                {
                    People? peopleFound = await _people.GetByIdAsync(studentFound.PeopleId);
                    AddressEntity? addressFound = await _addressEntity.GetByIdAsync(studentFound.People.AddressId);

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

        public async Task<BaseResponseDTO> AddStudentInClassAsync(int codeClass, string registrationStudent )
        {
            try
            {
                BaseResponseDTO response = new();

                Student studentFound = await _student.GetStudentDetailAsync(registrationStudent);
                Class? classFound = await _class.GetByCodeAsync(codeClass);

                if (studentFound == null || classFound == null)
                    response.Update(message: "*** We couldn't find the information you entered in our database!", success: false);
                else
                {

                    classFound.Students.Add(studentFound);
                    await _class.UpdateAsync(classFound);

                    response.Update(message: $"*** The student has been entered into the class that contains the code: {codeClass}", success: true);
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

        public async Task<List<SubjectResponseDTO>> GetSubjectsDoneAsync(string registration)
        {
            try
            {
                
                Student studentFound = await _student.GetStudentDetailAsync(registration);
                //return _IGroupStudentClass.GetAllByStudentId(studentFound.Id)
                //    .Result
                //    .ConvertAll(std => new SubjectResponseDTO(std));
                return null;
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

        public async Task<GradesResponseDTO> RegisterGradeAsync(GradeInputDTO grade)
        {
            try
            {
                Student? studentFound = await _student.GetStudentDetailAsync(grade.StudentRegistration);
                Subject? subjectFound = await _subject.GetSubjectDetailAsync(grade.SubjectCode);
                GradesResponseDTO response = new();

                if (studentFound == null)
                {
                    response.Message = $"*** We did not find this student in our database.";
                    response.Success = false;
                }
                else
                {
                    Grades newGrade = _mapper.Map<Grades>(grade);
                    newGrade.SubjectId = subjectFound.Id;
                    newGrade.StudentId = studentFound.Id;

                    await _grades.CreateAsync(newGrade);
                    response = _mapper.Map<GradesResponseDTO>(grade);

                    response.Message = "*** Note registered successfully";
                    response.Success = true;
                }

                return response;
            }
            catch (Exception)
            {
                GradesResponseDTO response = new()
                {
                    Message = "*** We encountered an error trying to fetch this student's grades",
                    Success = false
                };

                return response;
            }
        }

        public async Task<GradesResponseListsDTO> AllGradesForThisStudentAsync(string registration)
        {
            try
            {
                Student? studentFound = await _student.GetStudentDetailAsync(registration);
                GradesResponseListsDTO response = new();

                if (studentFound == null)
                {
                    response.Message = $"*** We did not find any students with the registration {studentFound!.Registration} in our database";
                    response.Success = false;
                }
                else
                {
                    response.Grade = _grades.AllGradesForThisStudent(studentFound.Registration)
                        .Result
                        .ConvertAll(grades => new GradesResponseDTO(grades));
                }

                return response;
            }
            catch (Exception) 
            {
                GradesResponseListsDTO response = new()
                {
                    Message = "*** We encountered an error trying to fetch this student's grades",
                    Success = false
                };

                return response;
            }
        }
    }
}