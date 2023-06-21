using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Request.MasterEntitiesDTO;
using UniVerseAPI.Application.DTOs.Request.MasterInputsDTO;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Application.DTOs.Response.ClassDTO;
using UniVerseAPI.Application.DTOs.Response.CoursesDTO;
using UniVerseAPI.Application.DTOs.Response.StudentsDTO;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.IServices
{
    public interface IClassService
    {
        public Task<ClassResponseDetailsDTO> GetByCodeAsync(int code);
        public List<ClassResponseDTO> GetAllAsync();
        public Task<ClassResponseDetailsDTO> CreateAsync(ClassInputDTO classDTO);
        public Task<BaseResponseDTO> UpdateAsync(ClassInputDTO classDTO, Guid id);
        public Task<BaseResponseDTO> DeleteAsync(Guid id);

    }
}
