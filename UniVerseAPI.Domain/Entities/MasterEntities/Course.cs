﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace UniVerseAPI.Infra.Data.Context
{
    public partial class Course : BaseEntity
    {

        [Key]
        public Guid Id { get; private set; }
        [Required]
        [StringLength(255)]
        public string FullName { get; private set; }
        [Required]
        [StringLength(255)]
        public string Description { get; private set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; private set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; private set; }
        public int Seats { get; private set; }
        public int SpotsAvailable { get; private set; }
        public int Price { get; private set; }
        [Required]
        [StringLength(255)]
        public string Category { get; private set; }
        [Required]
        [StringLength(10, MinimumLength = 10)]
        [Unicode(true)]
        public string Code { get; private set; }


        [InverseProperty("Course")]
        public virtual ICollection<Student> Student { get; set; }

        [InverseProperty("Course")]
        public virtual ICollection<Subject> Subject { get; set; }

    }
}