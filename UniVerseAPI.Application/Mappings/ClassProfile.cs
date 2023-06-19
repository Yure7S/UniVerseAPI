using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Request.MasterInputsDTO;
using UniVerseAPI.Application.DTOs.Response.ClassDTO;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Mappings
{
    internal class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<Class, ClassResponseDTO>();
            CreateMap<Class, ClassDetailsDTO>();
            CreateMap<ClassInputDTO, ClassResponseDTO>();
            CreateMap<ClassInputDTO, Class>();

        }
    }
}
