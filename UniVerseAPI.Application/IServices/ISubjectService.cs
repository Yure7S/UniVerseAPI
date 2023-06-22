using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Request.MasterEntitiesDTO;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Application.DTOs.Response.SubjectDTO;
using UniVerseAPI.Infra.Data.Context;
namespace UniVerseAPI.Application.IServices
{
    public interface ISubjectService
    {
        public Task<SubjectResponseDetailsDTO> GetByCodeAsync(string code);
        public List<SubjectResponseDTO> GetAllAsync();
        public Task<SubjectResponseDetailsDTO> CreateAsync(SubjectInputDTO subject);
        public Task<BaseResponseDTO> UpdateAsync(SubjectInputDTO subject, string code);
        public Task<BaseResponseDTO> DeleteAsync(string code);

    }
}
