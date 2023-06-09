﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Response.TeachersDTO;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Mappings
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<TeacherInputDTO, Teacher>();
            CreateMap<ICollection<Teacher>, TeacherResponseDetailsDTO>();
            CreateMap<Teacher, Teacher>();
            CreateMap<TeacherInputDTO, Teacher>();

        }
    }
}
