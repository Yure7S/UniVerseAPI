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

        public StudentService(IStudent iStudent, ICourse iCourse, IAddressEntity iAddressEntity, IPeople iPeople)
        {
            _IStudent = iStudent;
            _ICourse = iCourse;
            _IAddressEntity = iAddressEntity;
            _IPeople = iPeople;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _IStudent.GetAllAsync();
        }

        public async Task<ICollection<Student>> GetStudentDetailsAsync(Guid id)
        {
            return await _IStudent.GetStudentDetailAsync(id);
        }

        public async Task<StudentActionResponseDTO> GetByIdAsync(Guid id)
        {
            try
            {
                Student? studentFound =  await _IStudent.GetByIdAsync(id);
                BaseResponseDTO response = new();

                if (studentFound == null)
                {
                    response.Update("We could not find this item in our database.", false);
                    StudentActionResponseDTO respNull = new(baseResponse: response);
                    return respNull;
                }
                else
                {
                    response.Update("Found successfully!", true);
                    StudentActionResponseDTO studentResponse = new(baseResponse: response, student: studentFound);
                    return studentResponse;
                }
            }
            catch (Exception e)
            {
                BaseResponseDTO baseResponse = new(message: "*** We encountered an error trying to find the Student!", success: false, error: e.Message);
                StudentActionResponseDTO response = new(baseResponse: baseResponse);
                return response;
            }
        }

        public void SaveStudent(AddressEntity newAddress, People newPeople, Student newStudent)
        {
            _IAddressEntity.CreateAsync(newAddress);
            _IPeople.CreateAsync(newPeople);
            _IStudent.CreateAsync(newStudent);
        } 

        public async Task<StudentActionResponseDTO> CreateAsync(StudentInputDTO student)
        {
            try
            {
                Course? courseFound = await _ICourse.GetByCodeAsync(student.CourseCode);

                if (courseFound == null)
                {
                    BaseResponseDTO baseResponseNull = new(
                        message: "*** We couldn't find any courses with the given code!",
                        success: false);
                    StudentActionResponseDTO responseNull = new(baseResponse: baseResponseNull);
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

                Student newStudent = new(
                    courseId: courseFound.Id,
                    peopleId: newPeople.Id,
                    registration: student.Registration);

                SaveStudent(newAddress, newPeople, newStudent);

                BaseResponseDTO baseResponse = new(message: "*** Student Created successfully!", success: true);
                StudentActionResponseDTO response = new(studentInput: student, baseResponse: baseResponse);

                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO baseResponse = new(message: "*** We encountered an error trying to register a new Student!", success: false, error: e.Message);
                StudentActionResponseDTO responseError = new(baseResponse: baseResponse);
                return responseError;
            }
        }

        public async Task<BaseResponseDTO> DeleteAsync(Guid id)
        {
            try
            {
                Student? studentFound = await _IStudent.GetByIdAsync(id);
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

        public async Task<BaseResponseDTO> UpdateAsync(StudentInputDTO student, Guid id)
        {
            try
            {
                Course? courseFound = await _ICourse.GetByCodeAsync(student.CourseCode);
                Student? studentFound = await _IStudent.GetByIdAsync(id);
                People? peopleFound = await _IPeople.GetByIdAsync(studentFound!.PeopleId);
                AddressEntity? addressFound = await _IAddressEntity.GetByIdAsync(peopleFound!.AddressId);

                if (studentFound == null)
                {
                    BaseResponseDTO respNull = new(
                        message: "*** We couldn't find the Student in our database!",
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

                UpdateStudent(studentFound, peopleFound, addressFound!);

                BaseResponseDTO response = new(
                    message: "*** Student UpdateAsyncd successfully!",
                    success: true);
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
