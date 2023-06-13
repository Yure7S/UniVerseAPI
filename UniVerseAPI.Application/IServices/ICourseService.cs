using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Request.MasterEntitiesDTO;
using UniVerseAPI.Application.DTOs.Response;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Infra.Data.Context;
namespace UniVerseAPI.Application.IServices
{
    public interface ICourseService
    {
        public Task<CourseActionResponseDTO> GetByCodeAsync(string code);
        public Task<List<Course>> GetAllAsync();
        public Task<CourseActionResponseDTO> CreateAsync(CourseInputDTO course);
        public Task<BaseResponseDTO> UpdateAsync(CourseInputDTO course, string code);
        public Task<BaseResponseDTO> DeleteAsync(string code);
    }
}
