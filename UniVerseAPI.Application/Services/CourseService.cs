using AutoMapper;
using Azure;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Request.MasterEntitiesDTO;
using UniVerseAPI.Application.DTOs.Response;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
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

        public async Task<List<Course>> GetAllAsync()
        {
            return await _ICourse.GetAllAsync();
        }

        public async Task<CourseActionResponseDetailsDTO> GetByCodeAsync(string code)
        {
            try
            {
                Course? courseFound =  await _ICourse.GetByCodeAsync(code);

                if (courseFound == null)
                {
                    CourseActionResponseDetailsDTO respNull = new()
                    {
                        Message = "We could not find this item in our database.",
                        Success = true
                    };

                    return respNull;
                }

                CourseFrancisco newCourse = _mapper.Map<CourseFrancisco>(courseFound);
                CourseActionResponseDetailsDTO response = new()
                {
                    Course = newCourse,
                    Message = "Found successfully!",
                    Success = true
                };

                return response;
            }
            catch (Exception e)
            {
                CourseActionResponseDetailsDTO response = new()
                {
                    Message = "We encountered an error trying to find the course!",
                    Success = false,
                    Error = e.Message
                };

                return response;
            }
        }

        public async Task<CourseActionResponseDetailsDTO> CreateAsync(CourseInputDTO course)
        {
            try
            {
                Course newCourse = _mapper.Map<Course>(course);

                CourseFrancisco courseResponse = _mapper.Map<CourseFrancisco>(course);

                CourseActionResponseDetailsDTO courseGeneralResponse = new()
                {
                    Course = courseResponse, 
                    Message = "Ok",
                    Success = true
                };

                await _ICourse.CreateAsync(newCourse);

                return courseGeneralResponse;
            }
            catch (Exception e)
            {
                CourseActionResponseDetailsDTO responseError = new()
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

                if (courseFound == null)
                {
                    BaseResponseDTO respNull = new(message: "*** We couldn't find the course in our database!",
                    success: false);
                    return respNull;
                }

                courseFound.DeleteAsync(true);
                await _ICourse.UpdateAsync(courseFound);
                BaseResponseDTO response = new(message: "*** Deleted successfully!",
                success: true);
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
                if (courseFound == null)
                {
                    BaseResponseDTO respNull = new(message: "*** We couldn't find the course in our database!",
                    success: false);
                    return respNull;
                }

                courseFound.UpdateAsync(
                        fullName: course.FullName,
                        description: course.Description,
                        startDate: course.StartDate,
                        endDate: course.EndDate,
                        seats: course.Seats,
                        spotsAvailable: course.SpotsAvailable,
                        price: course.Price,
                        category: course.Category,
                        code: course.Code);

                await _ICourse.UpdateAsync(courseFound);

                BaseResponseDTO response = new(message: "*** Course UpdateAsyncd successfully!",
                success: true);
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
