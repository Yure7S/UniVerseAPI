using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVerseAPI.Application.DTOs.Request.MasterEntitiesDTO
{
    public class SubjectInputDTO
    {
        [Required]
        [StringLength(255)]
        public string? FullName { get; set; }

        [Required]
        [StringLength(255)]
        public string? Description { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string? Code { get; set; }

        public DateTime Workload { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5)]
        public string? ClassCode { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string? CourseCode { get; set; }

        [Required]
        public string? TeacherCode { get; set; }
    }
}
