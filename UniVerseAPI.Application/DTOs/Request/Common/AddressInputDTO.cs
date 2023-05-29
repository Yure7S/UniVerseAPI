﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UniVerseAPI.Infra.Data.Context
{
    public partial class AddressInputDTO : BaseEntity
    {
        [Required]
        [Column("Address")]
        [StringLength(255)]
        public string AddressValue { get; private set; }
        public int Number { get; private set; }
        [Required]
        [StringLength(255)]
        public string Neighborhood { get; private set; }
        [Required]
        [StringLength(8)]
        [Unicode(false)]
        public string Cep { get; private set; }
    }
}