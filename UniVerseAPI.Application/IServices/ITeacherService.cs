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
        public Task<List<Teacher>> GetAllAsync();
        public Task<TeacherActionResponseDTO> GetByIdAsync(Guid id);
        public Task<ICollection<Teacher>> GetTeacherDetailsAsync(Guid id);
        public Task<TeacherActionResponseDTO> CreateAsync(TeacherInputDTO teacher);
        public Task<BaseResponseDTO> UpdateAsync(TeacherInputDTO teacher, Guid id);
        public Task<BaseResponseDTO> DeleteAsync(Guid id);

    }
}
