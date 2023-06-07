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
    public interface ITeacherService
    {
        public List<TeacherActionResponseDTO> GetAllAsync();
        public TeacherActionResponseDetailsDTO CreateAsync(TeacherInputDTO teacher);
        public Task<TeacherActionResponseDetailsDTO> GetTeacherDetailAsync(Guid id);
        public Task<BaseResponseDTO> EnableOrDisable(Guid id, bool status);
        public Task<BaseResponseDTO> UpdateAsync(TeacherInputDTO teacher, Guid id);
        public Task<BaseResponseDTO> DeleteAsync(Guid id);

    }
}
