﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using UniVerseAPI.Domain.Enums;

namespace UniVerseAPI.Infra.Data.Context
{
    public partial class Roles
    {
        public Guid Id { get; private set; }
        public string RoleValue { get; set; }
        public string Description { get; set; }

        [InverseProperty("Roles")]
        public virtual ICollection<User> User { get; set; }

        public Roles()
        {
            Id = Guid.NewGuid();
        }
    }
}