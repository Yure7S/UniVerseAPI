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
using UniVerseAPI.Domain.Enums;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.DTOs.Response.CoursesDTO
{
    public class CourseResponseDTO
    {
        public string? FullName { get; set; }
        public int? Seats { get; set; }
        public int? SpotsAvailable { get; set; }
        public string? ShortDescription { get; set; }
        public CourseCategory? Category { get; set; }
        public string? Code { get; set; }

        public CourseResponseDTO(Course course)
        {
            FullName = course.FullName;
            Seats = course.Seats;
            SpotsAvailable = course.SpotsAvailable;
            ShortDescription = course.ShortDescription;
            Category = course.Category;
            Code = course.Code;
        }
    }
}
