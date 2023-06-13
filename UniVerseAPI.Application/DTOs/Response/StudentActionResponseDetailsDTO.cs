using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.DTOs.Response
{
    public class StudentActionResponseDetailsDTO
    {
        public string? Registration { get; set; }
        public PeopleResponseDTO? People { get; set; }
        public BaseResponseDTO? BaseResponse { get; set; }

        public StudentActionResponseDetailsDTO(string? registration = null, BaseResponseDTO? baseResponse = null, PeopleResponseDTO? people = null)
        {
            Registration = registration;
            People = people;
            BaseResponse = baseResponse;
        }
    }
}
