﻿using AutoMapper;
using Azure;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Request.MasterEntitiesDTO;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Application.DTOs.Response.SubjectDTO;
using UniVerseAPI.Application.Interface;
using UniVerseAPI.Application.IServices;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubject _subject;
        private readonly ITeacher _teacher;
        private readonly ICourse _course;
        private readonly IClass _class;
        private readonly IMapper _mapper;

        public SubjectService(ISubject iSubject, IMapper mapper, ITeacher teacher, ICourse course, IClass iClass)
        {
            _subject = iSubject;
            _mapper = mapper;
            _teacher = teacher;
            _course = course;
            _class = iClass;
        }

        public List<SubjectResponseDTO> GetAll()
        {
            return _subject.GetAllSubjects()
                .Result
                .ConvertAll(subj => new SubjectResponseDTO(subj));
        }

        public async Task<SubjectResponseDetailsDTO> GetByCodeAsync(string code)
        {
            try
            {
                Subject? subjectFound =  await _subject.GetSubjectDetailAsync(code);

                if (subjectFound == null)
                {
                    SubjectResponseDetailsDTO respNull = new()
                    {
                        Message = "We could not find this item in our database.",
                        Success = true
                    };

                    return respNull;
                }

                SubjectDetailsDTO subjectResponse = _mapper.Map<SubjectDetailsDTO>(subjectFound);
                subjectResponse.TeacherCode = subjectFound.Teacher.Code;
                subjectResponse.TeacherCode = subjectFound.Course.Code;

                SubjectResponseDetailsDTO response = new()
                {
                    Subject = subjectResponse,
                    Message = "Found successfully!",
                    Success = true
                };

                return response;
            }
            catch (Exception e)
            {
                SubjectResponseDetailsDTO response = new()
                {
                    Message = "We encountered an error trying to find the subject!",
                    Success = false,
                    Error = e.Message
                };

                return response;
            }
        }

        public async Task<SubjectResponseDetailsDTO> CreateAsync(SubjectInputDTO subject)
        {
            try
            {
                Teacher? teacherFound = await _teacher.GetByCodeAsync(subject.TeacherCode!);
                Course? courseFound = await _course.GetByCodeAsync(subject.CourseCode!);
                Class? classFound = await _class.GetByCodeAsync(subject.ClassCode);
                SubjectResponseDetailsDTO response = new();

                if (courseFound == null)
                {
                    response.Message = "*** We couldn't find any course in our database that has the given code.";
                    response.Success = false;
                }
                else if(teacherFound == null)
                {
                    response.Message = "*** We couldn't find any teacher in our database that has the given code.";
                    response.Success = false;
                }
                else
                {
                    Subject newSubject = _mapper.Map<Subject>(subject);
                    newSubject.CourseId = courseFound!.Id;
                    newSubject.TeacherId = teacherFound.Id;
                    newSubject.ClassId = classFound!.Id;

                    await _subject.CreateAsync(newSubject);

                    SubjectDetailsDTO subjectDetailsResponse = _mapper.Map<SubjectDetailsDTO>(subject);
                    response.Subject = subjectDetailsResponse;
                    response.Message = "*** Successfully registered subject";
                    response.Success = true;
                }

                return response;
            }
            catch (Exception e)
            {
                SubjectResponseDetailsDTO responseError = new()
                {
                    Message= "*** We encountered an error trying to register a new subject!",
                    Success = false,
                    Error = e.Message
                };
                return responseError;
            }
        }

        public async Task<BaseResponseDTO> DeleteAsync(string code)
        {
            try
            {
                Subject? subjectFound = await _subject.GetByCodeAsync(code);
                BaseResponseDTO response = new();

                if (subjectFound == null)
                {
                    response.Update(message: "*** We couldn't find the subject in our database!", success: false);
                }
                else
                {
                    await _subject.DeleteAsync(subjectFound);
                    response.Update(message: "*** Deleted successfully!", success: true);
                }

                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO response = new(message: "*** We encountered an error trying to DeleteAsync the subject!",
                    success: false,
                    error: e.Message);

                return response;
            }
        }

        public async Task<BaseResponseDTO> UpdateAsync(SubjectInputDTO subject, string code)
        {
            try
            {
                Subject? subjectFound = await _subject.GetByCodeAsync(code);
                BaseResponseDTO response = new();

                if (subjectFound == null)
                {
                    response.Update(message: "*** We couldn't find the subject in our database!", success: false);
                }
                else
                {
                    subjectFound = _mapper.Map<Subject>(subject);
                    await _subject.UpdateAsync(subjectFound);
                    response.Update(message: "*** Subject UpdateAsyncd successfully!", success: true);
                }
                
                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO response = new(message: "*** We encountered an error trying to UpdateAsync the subject!",
                    success: false, 
                    error: e.Message);

                return response;
            }
        }
    }
}
