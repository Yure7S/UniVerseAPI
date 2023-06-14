using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Request.MasterEntitiesDTO;
using UniVerseAPI.Application.DTOs.Response.CoursesDTO;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Mappings
{
    internal class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDetailsDTO>();
            CreateMap<CourseInputDTO, CourseDetailsDTO>();
            CreateMap<CourseInputDTO, Course>();

        }
    }
}
