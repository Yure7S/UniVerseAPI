using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Request.MasterEntitiesDTO;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Application.DTOs.Response.TeachersDTO;
using UniVerseAPI.Infra.Data.Context;
namespace UniVerseAPI.Application.IServices
{
    public interface ITeacherService
    {
        public List<TeacherResponseDTO> GetAllAsync();
        public Task<TeacherResponseDetailsDTO> Create(TeacherInputDTO teacher);
        public Task<TeacherResponseDetailsDTO> GetTeacherDetailAsync(string code);
        public Task<BaseResponseDTO> EnableOrDisableAsync(string code, bool status);
        public Task<BaseResponseDTO> UpdateAsync(TeacherInputDTO teacher, string code);
        public Task<BaseResponseDTO> DeleteAsync(string code);

    }
}
