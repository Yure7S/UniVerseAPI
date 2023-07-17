﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using UniVerseAPI.Domain.Enums;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace UniVerseAPI.Infra.Data.Context
{
    public partial class People : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cpf { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }

        [ForeignKey("AddressId")]
        [InverseProperty("People")]
        public virtual AddressEntity AddressEntity { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("People")]
        public virtual User User { get; set; }

        [InverseProperty("People")]
        public virtual ICollection<Student> Student { get; set; }

        [InverseProperty("People")]
        public virtual ICollection<Teacher> Teacher { get; set; }

        public People()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            LastUpdate = DateTime.Now;
        }
    }


}