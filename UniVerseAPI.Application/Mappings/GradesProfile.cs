using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Response.GradesDTO;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Mappings
{
    internal class GradesProfile : Profile
    {
        public GradesProfile()
        {

            CreateMap<GradeInputDTO, GradesResponseDTO>();
            CreateMap<GradeInputDTO, Grades>();
        }
    }
}
