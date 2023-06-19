using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Request.MasterInputsDTO;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Application.DTOs.Response.ClassDTO;
using UniVerseAPI.Application.DTOs.Response.CoursesDTO;
using UniVerseAPI.Application.DTOs.Response.StudentsDTO;
using UniVerseAPI.Application.IServices;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Services
{
    public class ClassService : IClassService
    {

        private readonly IClass _class;
        private readonly IMapper _mapper;
        public ClassService(IClass classInjection, IMapper mapper) 
        { 
            _class = classInjection;
            _mapper = mapper;
        }

        public async Task<ClassResponseDetailsDTO> CreateAsync(ClassInputDTO classDTO)
        {

            try
            {
                Class newClass = _mapper.Map<Class>(classDTO);

                ClassDetailsDTO classDetailsResponse = _mapper.Map<ClassDetailsDTO>(newClass);

                ClassResponseDetailsDTO response = new()
                {
                    Class = classDetailsResponse,
                    Message = "*** Successfully registered class",
                    Success = true
                };
                await _class.CreateAsync(newClass);

                return response;
            }
            catch (Exception e)
            {
                ClassResponseDetailsDTO responseError = new()
                {
                    Message = "*** We encountered an error trying to register a new class!",
                    Success = false,
                    Error = e.Message
                };
                return responseError;
            }
        }

        public async Task<BaseResponseDTO> DeleteAsync(Guid id)
        {
            try
            {
                Class? classFound = await _class.GetByIdAsync(id);
                BaseResponseDTO response = new();

                if (classFound == null)
                {
                    response.Update(message: "*** We couldn't find the class in our database!", success: false);
                }
                else
                {
                    classFound!.DeleteAsync(true);
                    await _class.UpdateAsync(classFound);
                    response.Update(message: "*** Deleted successfully!", success: true);
                }

                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO response = new(message: "*** We encountered an error trying to DeleteAsync the class!",
                    success: false,
                    error: e.Message);

                return response;
            }
        }

        public List<ClassResponseDTO> GetAllAsync()
        {
            return _class.GetAllAsync()
                .Result
                .ConvertAll(cls => _mapper.Map<ClassResponseDTO>(cls));
        } 

        public async Task<ClassResponseDetailsDTO> GetByIdAsync(Guid id)
        {
            try
            {
                Class? classFound = await _class.GetByIdAsync(id);

                if (classFound == null)
                {
                    ClassResponseDetailsDTO respNull = new()
                    {
                        Message = "We could not find this item in our database.",
                        Success = true
                    };

                    return respNull;
                }

                ClassDetailsDTO newCourse = _mapper.Map<ClassDetailsDTO>(classFound);
                ClassResponseDetailsDTO response = new()
                {
                    Class = newCourse,
                    Message = "Found successfully!",
                    Success = true
                };

                return response;
            }
            catch (Exception e)
            {
                ClassResponseDetailsDTO response = new()
                {
                    Message = "We encountered an error trying to find the class!",
                    Success = false,
                    Error = e.Message
                };

                return response;
            }
        }

        public async Task<BaseResponseDTO> UpdateAsync(ClassInputDTO classDTO, Guid id)
        {
            try
            {
                Class? classFound = await _class.GetByIdAsync(id);
                BaseResponseDTO response = new();

                if (classFound  == null)
                {
                    response.Update(message: "*** We couldn't find the class in our database!", success: false);
                }
                else
                {
                    classFound = _mapper.Map<Class>(classDTO);
                    await _class.UpdateAsync(classFound);
                    response.Update(message: "*** Class UpdateAsyncd successfully!", success: true);
                }

                return response;
            }
            catch (Exception e)
            {
                BaseResponseDTO response = new(message: "*** We encountered an error trying to UpdateAsync the class!",
                    success: false,
                    error: e.Message);

                return response;
            }
        }
    }
}
