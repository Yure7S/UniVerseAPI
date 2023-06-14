using AutoMapper;
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
using UniVerseAPI.Application.DTOs.Response.CoursesDTO;
using UniVerseAPI.Application.IServices;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourse _ICourse;
        private readonly IMapper _mapper;

        public CourseService(ICourse iCourse, IMapper mapper)
        {
            _ICourse = iCourse;
            _mapper = mapper;
        }

        public List<CourseResponseDTO> GetAllAsync()
        {
            return _ICourse.GetAllAsync()
                .Result
                .ConvertAll(crs => new CourseResponseDTO(crs));
        }

        public async Task<CourseResponseDetailsDTO> GetByCodeAsync(string code)
        {
            try
            {
                Course? courseFound =  await _ICourse.GetByCodeAsync(code);

                if (courseFound == null)
                {
                    CourseResponseDetailsDTO respNull = new()
                    {
                        Message = "We could not find this item in our database.",
                        Success = true
                    };

                    return respNull;
                }

                CourseDetailsDTO newCourse = _mapper.Map<CourseDetailsDTO>(courseFound);
                CourseResponseDetailsDTO response = new()
                {
                    Course = newCourse,
                    Message = "Found successfully!",
                    Success = true
                };

                return response;
            }
            catch (Exception e)
            {
                CourseResponseDetailsDTO response = new()
                {
                    Message = "We encountered an error trying to find the course!",
                    Success = false,
                    Error = e.Message
                };

                return response;
            }
        }

        public async Task<CourseResponseDetailsDTO> CreateAsync(CourseInputDTO course)
        {
            try
            {
                Course newCourse = _mapper.Map<Course>(course);

                CourseDetailsDTO courseDetailsResponse = _mapper.Map<CourseDetailsDTO>(newCourse);

                CourseResponseDetailsDTO response = new()
                {
                    Course = courseDetailsResponse,
                    Message = "*** Successfully registered course",
                    Success = true
                };
                await _ICourse.CreateAsync(newCourse);

                return response;
            }
            catch (Exception e)
            {
                CourseResponseDetailsDTO responseError = new()
                {
                    Message= "*** We encountered an error trying to register a new course!",
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
                Course? courseFound = await _ICourse.GetByCodeAsync(code);
                BaseResponseDTO response = new();

                if (courseFound == null)
                {
                    response.Update(message: "*** We couldn't find the course in our database!", success: false);
                }
                else
                {
                    courseFound!.DeleteAsync(true);
                    await _ICourse.UpdateAsync(courseFound);
                    response.Update(message: "*** Deleted successfully!", success: true);
                }

                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO response = new(message: "*** We encountered an error trying to DeleteAsync the course!",
                    success: false,
                    error: e.Message);

                return response;
            }
        }

        public async Task<BaseResponseDTO> UpdateAsync(CourseInputDTO course, string code)
        {
            try
            {
                Course? courseFound = await _ICourse.GetByCodeAsync(code);
                BaseResponseDTO response = new();

                if (courseFound == null)
                {
                    response.Update(message: "*** We couldn't find the course in our database!", success: false);
                }
                else
                {
                    courseFound = _mapper.Map<Course>(course);
                    await _ICourse.UpdateAsync(courseFound);
                    response.Update(message: "*** Course UpdateAsyncd successfully!", success: true);
                }
                
                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO response = new(message: "*** We encountered an error trying to UpdateAsync the course!",
                    success: false, 
                    error: e.Message);

                return response;
            }
        }
    }
}
