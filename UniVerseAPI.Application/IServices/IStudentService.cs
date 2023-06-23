using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Request.MasterEntitiesDTO;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Application.DTOs.Response.StudentsDTO;
using UniVerseAPI.Application.DTOs.Response.SubjectDTO;
using UniVerseAPI.Domain.Entities.MasterEntities;
using UniVerseAPI.Infra.Data.Context;
namespace UniVerseAPI.Application.IServices
{
    public interface IStudentService
    {
        public List<StudentResponseDTO> GetAllAsync();
        public Task<StudentResponseDetailsDTO> GetByRegistrationAsync(string registration);
        public Task<StudentResponseDetailsDTO> CreateAsync(StudentInputDTO student);
        public Task<BaseResponseDTO> UpdateAsync(StudentUpdateDTO student, string registration);
        public Task<BaseResponseDTO> DeleteAsync(string registration);
        public Task<BaseResponseDTO> AddStudentInClass(GroupStudentClassInputDTO gscInput);
        public Task<List<SubjectResponseDTO>> GetSubjectsDone(string registration);

    }
}
