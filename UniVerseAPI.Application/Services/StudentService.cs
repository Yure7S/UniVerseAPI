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

        public List<StudentActionResponseDTO> GetAllAsync()
        {
            return _IStudent.GetAllStudentAsync()
                .Result
                .ConvertAll(std => new StudentActionResponseDTO(std));
        }

        public async Task<StudentActionResponseDetailsDTO> GetByRegistrationAsync(string registration)
        {
            try
            {
                Student? studentFound =  await _IStudent.GetStudentDetailAsync(registration);
                StudentActionResponseDetailsDTO response = new();
                BaseResponseDTO baseResponsse = new();

                if (studentFound == null)
                {
                    baseResponsse.Update("We could not find this item in our database.", false);
                    response.Update(baseResponse: baseResponsse);
                }
                else
                {
                    AddressResponseDTO addressResponse = _mapper.Map<AddressResponseDTO>(studentFound.People.AddressEntity);
                    PeopleResponseDTO peopleResponse = _mapper.Map<PeopleResponseDTO>(studentFound.People);
                    
                    baseResponsse.Update("Found successfully!", true);
                    response.Update(
                        registration: studentFound.Registration, 
                        people: peopleResponse, 
                        baseResponse: baseResponsse);
                }
                
                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO baseResponse = new(message: "*** We encountered an error trying to find the Student!", success: false, error: e.Message);
                StudentActionResponseDetailsDTO response = new(baseResponse: baseResponse);
                return response;
            }
        }

        public void SaveStudent(AddressEntity newAddress, People newPeople, Student newStudent)
        {
            _IAddressEntity.CreateAsync(newAddress);
            _IPeople.CreateAsync(newPeople);
            _IStudent.CreateAsync(newStudent);
        } 

        public async Task<StudentActionResponseDetailsDTO> CreateAsync(StudentInputDTO student)
        {
            try
            {
                Course? courseFound = await _ICourse.GetByCodeAsync(student.CourseCode);
                BaseResponseDTO baseResponse = new();
                StudentActionResponseDetailsDTO response = new();

                if (courseFound == null)
                {
                    baseResponse.Update(message: "*** We couldn't find any courses with the given code!", success: false);
                    response.Update(baseResponse: baseResponse);
                }
                else
                {
                    AddressEntity newAddress = _mapper.Map<AddressEntity>(student.Address);
                    People newPeople = _mapper.Map<People>(student.People);
                    Student newStudent = new();
                    newPeople.AddressId = newAddress.Id;
                    newStudent.PeopleId = newPeople.Id;
                    newStudent.CourseId = courseFound.Id;

                    AddressResponseDTO addressResponse = _mapper.Map<AddressResponseDTO>(newAddress);
                    PeopleResponseDTO peopleResponse = _mapper.Map<PeopleResponseDTO>(newPeople);
                    peopleResponse.AddressEntity = addressResponse;

                    SaveStudent(newAddress, newPeople, newStudent);

                    baseResponse.Update(message: "*** Student Created successfully!", success: true);
                    response.Update(registration: newStudent.Registration, people: peopleResponse, baseResponse: baseResponse);
                }
                
                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO baseResponse = new(message: "*** We encountered an error trying to register a new Student!", success: false, error: e.Message);
                StudentActionResponseDetailsDTO responseError = new(baseResponse: baseResponse);
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

        public void UpdateStudent(Student student, People people,AddressEntity addressEntity)
        {
            _IAddressEntity.UpdateAsync(addressEntity);
            _IPeople.UpdateAsync(people);
            _IStudent.UpdateAsync(student);
        }

        public async Task<BaseResponseDTO> UpdateAsync(StudentInputDTO student, string registration)
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
                    studentFound.People.AddressEntity = _mapper.Map<AddressEntity>(student.Address);
                    studentFound.People = _mapper.Map<People>(student.People);
                    studentFound = _mapper.Map<Student>(student);

                    UpdateStudent(
                        studentFound,
                        studentFound.People,
                        studentFound.People.AddressEntity);

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