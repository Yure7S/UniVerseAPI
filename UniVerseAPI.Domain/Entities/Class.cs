﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UniVerseAPI.Models
{
    public partial class Class
    {
        public Class()
        {
            Subject = new HashSet<Subject>();
        }

        [Key]
        public Guid Id { get; private set; }

        [Required]
        [StringLength(255)]
        public string FullName { get; private set; }
        public int EnrolledStudents { get; private set; }
        public int Shift { get; private set; }

        [Required]
        [StringLength(255)]
        public string Room { get; private set; }

        [InverseProperty("Class")]
        public virtual ICollection<Subject> Subject { get; private set; }

        [Required]
        public DateTime LastUpdate { get; private set; }

        [Required]
        public DateTime RegistrationDate { get; private set; }

        public Class(Guid id, string fullName, int enrolledStudents, int shift, string room, ICollection<Subject> subject)
        {
            Id = id;
            FullName = fullName;
            EnrolledStudents = enrolledStudents;
            Shift = shift;
            Room = room;
            Subject = subject;
            LastUpdate = DateTime.Now;
            RegistrationDate = DateTime.Now;
        }

        public void Update(Guid id, string fullName, int enrolledStudents, int shift, string room, ICollection<Subject> subject)
        {
            Id = id;
            FullName = fullName;
            EnrolledStudents = enrolledStudents;
            Shift = shift;
            Room = room;
            Subject = subject;
            LastUpdate = DateTime.Now;
        }
    }


}