using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.DTOs.Response
{
    public class CourseActionResponseDTO
    {
        public Course? Course { get; set; }
        public BaseResponseDTO? BaseResponse { get; set; }

        public CourseActionResponseDTO(BaseResponseDTO? baseResponse, Course? course = null)
        {
            Course = course;
            BaseResponse = baseResponse;
        }
    }
}
