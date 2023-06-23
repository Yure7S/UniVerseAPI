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

namespace UniVerseAPI.Application.DTOs.Response.SubjectDTO
{
    public class SubjectDetailsDTO
    {
        public string? FullName { get; set; }

        public string? Description { get; set; }

        public string? Code { get; set; }

        public DateTime Workload { get; set; }

        public string? CourseCode { get; set; }

        public int ClassCode { get; set; }

        public string? TeacherCode { get; set; }
    }
}
