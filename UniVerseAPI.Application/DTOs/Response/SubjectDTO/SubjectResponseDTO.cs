using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.DTOs.Response.SubjectDTO
{
    public class SubjectResponseDTO
    {
        public string? FullName { get; set; }
        public string? Code { get; set; }
        public string? Course { get; set; }

        public SubjectResponseDTO(Subject subject)
        {
            FullName = subject.FullName;
            Code = subject.Code;
            Course = subject.Course.FullName;
        }
    }
}
