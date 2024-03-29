﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UniVerseAPI.Infra.Data.Context
{
    public partial class Grades : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
        public decimal? FirstNote { get; set; }
        public decimal? SecondNote { get; set; }
        public bool? TookFinalExame { get; set; }
        public decimal? FinalExameGrade { get; set; }
        public bool Approved { get; set; }

        [ForeignKey("SubjectId")]
        [InverseProperty("Grades")]
        public virtual Subject Subject { get; set; }

        [ForeignKey("StudentId")]
        [InverseProperty("Grades")]
        public virtual Student Student { get; set; }

        public Grades()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            LastUpdate = DateTime.Now;
        }
    }
}