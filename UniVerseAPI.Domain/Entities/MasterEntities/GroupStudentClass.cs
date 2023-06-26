using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Domain.Entities.MasterEntities
{
    public class GroupStudentClass : BaseEntity
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        //[Required]
        //public Guid StudentId { get; set; }

        //[Required]
        //public Guid ClassId { get; set; }

        //[ForeignKey("StudentId")]
        //[InverseProperty("GroupStudentClass")]
        //public virtual Student? Student { get; set; }

        //[ForeignKey("ClassId")]
        //[InverseProperty("GroupStudentClass")]
        //public virtual Class? Class { get; set; }

        //public GroupStudentClass()
        //{
        //    Id = Guid.NewGuid();
        //    CreationDate = DateTime.Now;
        //    LastUpdate = DateTime.Now;
        //}
    }
}
