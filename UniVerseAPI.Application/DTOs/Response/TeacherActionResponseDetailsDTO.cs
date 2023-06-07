using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.DTOs.Response
{
    public class TeacherActionResponseDetailsDTO
    {
        public string? Code { get; set; }
        public PeopleResponseDTO? People { get; set; }
        public BaseResponseDTO? BaseResponse { get; set; }

        public TeacherActionResponseDetailsDTO(string? code = null, PeopleResponseDTO? people = null, BaseResponseDTO? baseResponse = null)
        {
            Code = code;
            BaseResponse = baseResponse;
            People = people;
        }

        public TeacherActionResponseDetailsDTO(string code, PeopleResponseDTO? people)
        {
            Code = code;
            People = people;
        }
    }
}
