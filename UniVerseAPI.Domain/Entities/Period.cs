﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UniVerseAPI.Models
{
    public partial class Period
    {
        public Period()
        {
            ReportCard = new HashSet<ReportCard>();
            Subject = new HashSet<Subject>();
        }

        [Key]
        public Guid Id { get; private set; }
        [Required]
        [StringLength(255)]
        public string FullName { get; private set; }
        public int EnrolledStudents { get; private set; }
        [Required]
        [StringLength(255)]
        public string Room { get; private set; }

        [InverseProperty("Period")]
        public virtual ICollection<ReportCard> ReportCard { get; private set; }
        [InverseProperty("Period")]
        public virtual ICollection<Subject> Subject { get; private set; }

        [Required]
        public DateTime LastUpdate { get; private set; }

        [Required]
        public DateTime RegistrationDate { get; private set; }

        public Period(Guid id, string fullName, int enrolledStudents, string room, ICollection<ReportCard> reportCard, ICollection<Subject> subject)
        {
            Id = id;
            FullName = fullName;
            EnrolledStudents = enrolledStudents;
            Room = room;
            ReportCard = reportCard;
            Subject = subject;
            LastUpdate = DateTime.Now;
            RegistrationDate = DateTime.Now;
        }

        public void Update(Guid id, string fullName, int enrolledStudents, string room, ICollection<ReportCard> reportCard, ICollection<Subject> subject)
        {
            Id = id;
            FullName = fullName;
            EnrolledStudents = enrolledStudents;
            Room = room;
            ReportCard = reportCard;
            Subject = subject;
            LastUpdate = DateTime.Now;
        }
    }
}