﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using UniVerseAPI.Domain;

namespace UniVerseAPI.Infra.Data.Context
{
    public partial class Student : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? ReportCardId { get; set; }
        public Guid PeopleId { get; set; }
        public Guid? CourseId { get; set; }
        public string Registration { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        [ForeignKey("CourseId")]
        [InverseProperty("Student")]
        public virtual Course Course { get; set; }

        [ForeignKey("PeopleId")]
        [InverseProperty("Student")]
        public virtual People People { get; set; }

        [InverseProperty("Students")]
        public virtual ICollection<Class> Classes { get; set; }

        [InverseProperty("Student")]
        public virtual ICollection<Grades> Grades { get; }

        public Student()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            LastUpdate = DateTime.Now;
        }
    }
}


