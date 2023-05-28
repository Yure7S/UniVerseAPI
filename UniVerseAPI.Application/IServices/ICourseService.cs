﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs;
using UniVerseAPI.Application.DTOs.Request;
using UniVerseAPI.Application.DTOs.Response;
using UniVerseAPI.Infra.Data.Context;
namespace UniVerseAPI.Application.IServices
{
    public interface ICourseService
    {
        public Task<CourseActionResponseDTO> GetById(Guid id);
        public Task<List<Course>> GetAll();
        public Task<CourseActionResponseDTO> Create(CourseInputDTO course);
        public Task<BaseResponseDTO> Update(CourseInputDTO course, Guid id);
        public Task<BaseResponseDTO> Delete(Guid id);
    }
}
