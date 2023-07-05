using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Infra.Data.Context;
using Microsoft.Identity.Client;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;

namespace UniVerseAPI.Application.DTOs.Response.GradesDTO
{
    public class GradesResponseDTO : BaseResponseDTO
    {
        public string? Subject { get; set; }
        public decimal? FirstNote { get; set; }
        public decimal? SecondNote { get; set; }
        public bool? TookFinalExame { get; set; }
        public decimal? FinalExameGrade { get; set; }
        public bool Approved { get; set; }

        public GradesResponseDTO(Grades grades)
        {
            Subject = grades.Subject.FullName;
            FirstNote = grades?.FirstNote;
            SecondNote = grades?.SecondNote;
            TookFinalExame = grades?.TookFinalExame;
            FinalExameGrade = grades?.FinalExameGrade;
            Approved = grades!.Approved;
        }

        public GradesResponseDTO()
        {
        }
    }
}
