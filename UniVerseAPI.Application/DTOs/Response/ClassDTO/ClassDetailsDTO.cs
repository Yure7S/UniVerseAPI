﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.DTOs.Response.ClassDTO
{
    public class ClassDetailsDTO
    {
        public ClassDetailsDTO()
        {
        }

        public string? FullName { get; set; }
        public string? Code { get; set; }
        public int EnrolledStudents { get; set; }
        public string? Shift { get; set; }
        public string? Room { get; set; }
    }
}
