using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Request;
using UniVerseAPI.Application.DTOs.Response;
using UniVerseAPI.Infra.Data.Context;
namespace UniVerseAPI.Application.IServices
{
    public interface ICourseService
    {
        public Task<CourseActionResponseDTO> GetById(Guid id);
        public Task<List<Course>> GetAll();
        public Task<CourseActionResponseDTO> Create(CourseRegisterDTO course);
        public Task<Course> Update(Guid id);
        public Task<Course> Delete(Guid id);
    }
}
