using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using UniVerseAPI.Domain.Interface;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.DTOs.Response.TeachersDTO
{
    public class TeacherResponseDTO
    {
        public string? FullName { get; set; }
        public string? Code { get; set; }
        public string? Email { get; set; }

        public TeacherResponseDTO(Teacher teacher)
        {
            FullName = teacher.People.FullName;
            Code = teacher.Code;
            Email = teacher.People.Email;
        }
    }
}
