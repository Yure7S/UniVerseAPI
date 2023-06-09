﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace UniVerseAPI.Infra.Data.Context
{
    public partial class PeopleUpdateDTO : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string FullName { get; set; }
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(255)]
        public string Gender { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string Phone { get; set; }
    }


}