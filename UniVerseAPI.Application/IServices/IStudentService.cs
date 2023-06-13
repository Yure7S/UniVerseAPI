using Microsoft.Extensions.Primitives;
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
        public List<StudentActionResponseDTO> GetAllAsync();
        public Task<StudentActionResponseDetailsDTO> GetByRegistrationAsync(string registration);
        public Task<StudentActionResponseDetailsDTO> CreateAsync(StudentInputDTO student);
        public Task<BaseResponseDTO> UpdateAsync(StudentInputDTO student, string registration);
        public Task<BaseResponseDTO> DeleteAsync(string registration);

    }
}
