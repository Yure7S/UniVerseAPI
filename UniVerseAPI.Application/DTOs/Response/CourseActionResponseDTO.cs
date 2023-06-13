﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class CourseActionResponseDTO
    {
        public string? FullName { get; set; }
        public string? Instructor { get; set; }
        public int? Seats { get; set; }
        public int? SpotsAvailable { get; set; }
        public string? Category { get; set; }
        public string? Code { get; set; }
        public BaseResponseDTO? BaseResponse { get; set; }

        public CourseActionResponseDTO(string? fullName, string? instructor, int? seats, int? spotsAvailable, string? category, string? code, BaseResponseDTO? baseResponse)
        {
            FullName = fullName;
            Instructor = instructor;
            Seats = seats;
            SpotsAvailable = spotsAvailable;
            Category = category;
            Code = code;
            BaseResponse = baseResponse;
        }
    }
}
