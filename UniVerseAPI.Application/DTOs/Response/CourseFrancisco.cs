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
    public class CourseFrancisco
    {
        public string? FullName { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Instructor { get; set; }
        public int? Seats { get; set; }
        public int? SpotsAvailable { get; set; }
        public int? Price { get; set; }
        public string? Category { get; private set; }
        public string? Code { get; private set; }
    }
}
