﻿using Azure;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs;
using UniVerseAPI.Application.DTOs.Request;
using UniVerseAPI.Application.DTOs.Response;
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

        public async Task<List<Course>> GetAll()
        {
            return await _ICourse.GetAll();
        }

        public async Task<CourseActionResponseDTO> GetById(Guid id)
        {
            try
            {
                Course? courseFound =  await _ICourse.GetById(id);
                if (courseFound == null)
                {
                    BaseResponseDTO baseResponse = new(
                        message: "We could not find this item in our database.",
                        success: false);

                    CourseActionResponseDTO response = new(baseResponse: baseResponse);
                    return response;
                }
                else
                {
                    BaseResponseDTO baseResponse = new(
                        message: "Found successfully!",
                        success: true);

                    CourseActionResponseDTO response = new(baseResponse: baseResponse, course: courseFound);
                    return response;
                }
            }
            catch (Exception e)
            {
                BaseResponseDTO baseResponse = new(message: "We encountered an error trying to find the course!", success: false, error: e.Message);
                CourseActionResponseDTO response = new(baseResponse: baseResponse);
                return response;
            }
        }

        public async Task<CourseActionResponseDTO> Create(CourseInputDTO course)
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
                        category: course.Category);

                await _ICourse.Create(newCourse);

                BaseResponseDTO baseResponse = new(message: "*** Course created successfully!", success: true);
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

        public async Task<BaseResponseDTO> Delete(Guid id)
        {
            try
            {
                Course? courseFound = await _ICourse.GetById(id);

                if (courseFound == null)
                {
                    BaseResponseDTO resp = new(message: "*** We couldn't find the course in our database!",
                    success: false);
                    return resp;
                }
                else
                {
                    await _ICourse.Delete(courseFound);
                    BaseResponseDTO response = new(message: "*** Deleted successfully!",
                    success: true);
                    return response;
                }
            }
            catch (Exception e)
            {
                BaseResponseDTO response = new(message: "*** We encountered an error trying to delete the course!",
                    success: false,
                    error: e.Message);

                return response;
            }
        }

        // Totamente errado
        public async Task<BaseResponseDTO> Update(CourseInputDTO course, Guid id)
        {
            try
            {
                Course? courseFound = await _ICourse.GetById(id);
                if (courseFound == null)
                {
                    BaseResponseDTO respNull = new(message: "*** We couldn't find the course in our database!",
                    success: false);
                    return respNull;
                }

                courseFound.Update(
                        fullName: course.FullName,
                        description: course.Description,
                        startDate: course.StartDate,
                        endDate: course.EndDate,
                        instructor: course.Instructor,
                        seats: course.Seats,
                        spotsAvailable: course.SpotsAvailable,
                        price: course.Price,
                        category: course.Category);

                await _ICourse.Update(courseFound);

                BaseResponseDTO response = new(message: "*** Course updated successfully!",
                success: true);
                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO response = new(message: "*** We encountered an error trying to update the course!",
                    success: false, 
                    error: e.Message);

                return response;
            }
        }
    }
}
