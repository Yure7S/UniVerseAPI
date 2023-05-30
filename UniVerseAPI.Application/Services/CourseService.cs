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
        public CourseService(ICourse iCourse)
        {
            _ICourse = iCourse;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _ICourse.GetAllAsync();
        }

        public async Task<CourseActionResponseDTO> GetByIdAsync(Guid id)
        {
            try
            {
                Course? courseFound =  await _ICourse.GetByIdAsync(id);
                if (courseFound == null)
                {
                    BaseResponseDTO baseRespNull = new(
                        message: "We could not find this item in our database.",
                        success: false);

                    CourseActionResponseDTO respNull = new(baseResponse: baseRespNull);
                    return respNull;
                }

                BaseResponseDTO baseResponse = new(
                        message: "Found successfully!",
                        success: true);

                CourseActionResponseDTO response = new(baseResponse: baseResponse, course: courseFound);
                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO baseResponse = new(message: "We encountered an error trying to find the course!", success: false, error: e.Message);
                CourseActionResponseDTO response = new(baseResponse: baseResponse);
                return response;
            }
        }

        public async Task<CourseActionResponseDTO> CreateAsync(CourseInputDTO course)
        {
            try
            {
                Course newCourse = new(
                        fullName: course.FullName,
                        description: course.Description,
                        startDate: course.StartDate,
                        endDate: course.EndDate,
                        instructor: course.Instructor,
                        seats: course.Seats,
                        spotsAvailable: course.SpotsAvailable,
                        price: course.Price,
                        category: course.Category,
                        code: course.Code);

                await _ICourse.CreateAsync(newCourse);

                BaseResponseDTO baseResponse = new(message: "*** Course Created successfully!", success: true);
                CourseActionResponseDTO response = new(course: newCourse, baseResponse: baseResponse);

                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO baseResponse = new(message: "*** We encountered an error trying to register a new course!", success: false, error: e.Message);
                CourseActionResponseDTO responseError = new(baseResponse: baseResponse);
                return responseError;
            }
        }

        public async Task<BaseResponseDTO> DeleteAsync(Guid id)
        {
            try
            {
                Course? courseFound = await _ICourse.GetByIdAsync(id);

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

        public async Task<BaseResponseDTO> UpdateAsync(CourseInputDTO course, Guid id)
        {
            try
            {
                Course? courseFound = await _ICourse.GetByIdAsync(id);
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
                        instructor: course.Instructor,
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
