﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Domain.Enums;

namespace UniVerseAPI.Application.DTOs.Request.MasterEntitiesDTO
{
    public class CourseInputDTO
    {
        [Required]
        [StringLength(255)]
        public string? FullName { get; set; }
        [Required]
        [StringLength(255)]
        public string? ShortDescription { get; set; }
        [Required]
        [StringLength(2000)]
        public string? Description { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        [Required]
        public int Seats { get; set; }
        public int SpotsAvailable { get; set; }
        public int Price { get; set; }
        [Required]
        public CourseCategory Category { get; set; }

    }
}
