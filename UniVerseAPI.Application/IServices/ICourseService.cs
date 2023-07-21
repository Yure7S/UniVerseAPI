using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Request.MasterEntitiesDTO;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Application.DTOs.Response.CoursesDTO;
using UniVerseAPI.Application.DTOs.Response.SubjectDTO;
using UniVerseAPI.Infra.Data.Context;
namespace UniVerseAPI.Application.IServices
{
    public interface ICourseService
    {
        public Task<CourseResponseDetailsDTO> GetByCodeAsync(string code);
        public List<CourseResponseDTO> GetAll();
        public Task<CourseResponseDetailsDTO> CreateAsync(CourseInputDTO course);
        public Task<BaseResponseDTO> UpdateAsync(CourseInputDTO course, string code);
        public Task<BaseResponseDTO> DeleteAsync(string code);
        public List<SubjectResponseDTO> AllSubjectsThisCourse(string code);

    }
}
