﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UniVerseAPI.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Assessment = new HashSet<Assessment>();
            ReportCard = new HashSet<ReportCard>();
        }

        [Key]
        public Guid Id { get; private set; }
        public Guid CourseId { get; private set; }
        public Guid TeacherId { get; private set; }
        public Guid? ClassId { get; private set; }
        public Guid PeriodId { get; private set; }

        [Required]
        [StringLength(255)]
        public string FullName { get; private set; }

        [Required]
        [StringLength(255)]
        public string Description { get; private set; }

        [Required]
        [StringLength(10)]
        [Unicode(false)]
        public string Code { get; private set; }

        [Column(TypeName = "date")]
        public DateTime Workload { get; private set; }

        [Required]
        [StringLength(255)]
        public string Instructor { get; private set; }


        [ForeignKey("ClassId")]
        [InverseProperty("Subject")]
        public virtual Class Class { get; private set; }

        [ForeignKey("CourseId")]
        [InverseProperty("Subject")]
        public virtual Course Course { get; private set; }

        [ForeignKey("PeriodId")]
        [InverseProperty("Subject")]
        public virtual Period Period { get; private set; }

        [ForeignKey("TeacherId")]
        [InverseProperty("Subject")]
        public virtual Teacher Teacher { get; private set; }

        [InverseProperty("Subject")]
        public virtual ICollection<Assessment> Assessment { get; private set; }

        [InverseProperty("Subject")]
        public virtual ICollection<ReportCard> ReportCard { get; private set; }

        [Required]
        public DateTime LastUpdate { get; private set; }

        [Required]
        public DateTime RegistrationDate { get; private set; }

        public Subject(Guid id, Guid courseId, Guid teacherId, Guid? classId, Guid periodId, string fullName, string description, string code, DateTime workload, string instructor, Class @class, Course course, Period period, Teacher teacher, ICollection<Assessment> assessment, ICollection<ReportCard> reportCard)
        {
            Id = id;
            CourseId = courseId;
            TeacherId = teacherId;
            ClassId = classId;
            PeriodId = periodId;
            FullName = fullName;
            Description = description;
            Code = code;
            Workload = workload;
            Instructor = instructor;
            Class = @class;
            Course = course;
            Period = period;
            Teacher = teacher;
            Assessment = assessment;
            ReportCard = reportCard;
            LastUpdate = DateTime.Now;
            RegistrationDate = DateTime.Now;
        }

        public void Update(Guid id, Guid courseId, Guid teacherId, Guid? classId, Guid periodId, string fullName, string description, string code, DateTime workload, string instructor, Class @class, Course course, Period period, Teacher teacher, ICollection<Assessment> assessment, ICollection<ReportCard> reportCard)
        {
            Id = id;
            CourseId = courseId;
            TeacherId = teacherId;
            ClassId = classId;
            PeriodId = periodId;
            FullName = fullName;
            Description = description;
            Code = code;
            Workload = workload;
            Instructor = instructor;
            Class = @class;
            Course = course;
            Period = period;
            Teacher = teacher;
            Assessment = assessment;
            ReportCard = reportCard;
            LastUpdate = DateTime.Now;
        }
    }
}