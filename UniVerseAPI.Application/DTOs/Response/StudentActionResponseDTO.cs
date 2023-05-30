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
    public class StudentActionResponseDTO
    {
        public StudentInputDTO? StudentInput { get; set; }
        public Student? Student { get; set; }
        public BaseResponseDTO? BaseResponse { get; set; }

        public StudentActionResponseDTO(BaseResponseDTO? baseResponse, StudentInputDTO? studentInput = null, Student? student = null)
        {
            StudentInput = studentInput;
            Student = student;
            BaseResponse = baseResponse;
        }
    }
}
