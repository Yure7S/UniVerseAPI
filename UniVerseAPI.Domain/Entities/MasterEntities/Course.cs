﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using UniVerseAPI.Domain.Enums;

namespace UniVerseAPI.Infra.Data.Context
{
    public partial class Course : BaseEntity
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int Seats { get; private set; }
        public int SpotsAvailable { get; private set; }
        public int Price { get; private set; }
        public CourseCategory Category { get; private set; }
        public string Code { get; private set; }

        [InverseProperty("Course")]
        public virtual ICollection<Student> Student { get; set; }

        [InverseProperty("Course")]
        public virtual ICollection<Subject> Subject { get; set; }
    }
}