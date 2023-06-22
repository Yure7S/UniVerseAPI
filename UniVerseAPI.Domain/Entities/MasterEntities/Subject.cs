﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UniVerseAPI.Infra.Data.Context
{
    public partial class Subject : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid ClassId { get; set; }
        public Guid? PeriodId { get; set; }

        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [Unicode(true)]
        public string Code { get; set; }

        [Column(TypeName = "date")]
        public DateTime Workload { get; set; }

        [ForeignKey("ClassId")]
        [InverseProperty("Subject")]
        public virtual Class Class { get; set; }
        [ForeignKey("CourseId")]
        [InverseProperty("Subject")]
        public virtual Course Course { get; set; }
        [ForeignKey("PeriodId")]
        [InverseProperty("Subject")]
        public virtual Period Period { get; set; }
        [ForeignKey("TeacherId")]
        [InverseProperty("Subject")]
        public virtual Teacher Teacher { get; set; }
        [InverseProperty("Subject")]
        public virtual ICollection<Assessment> Assessment { get; set; }
        [InverseProperty("Subject")]
        public virtual ICollection<ReportCard> ReportCard { get; set; }
    }
}