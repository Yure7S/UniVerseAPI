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
    public interface IStudentService
    {
        public Task<List<Student>> GetAllAsync();
        public Task<StudentActionResponseDTO> GetByIdAsync(Guid id);
        public Task<ICollection<Student>> GetStudentDetailsAsync(Guid id);
        public Task<StudentActionResponseDTO> CreateAsync(StudentInputDTO student);
        public Task<BaseResponseDTO> UpdateAsync(StudentInputDTO student, Guid id);
        public Task<BaseResponseDTO> DeleteAsync(Guid id);

    }
}
