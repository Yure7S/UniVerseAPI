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

namespace UniVerseAPI.Application.DTOs.Response
{
    public class StudentActionResponseDTO
    {
        public string? Registration { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }

        public StudentActionResponseDTO(string? registration = null, string? fullName = null, string? email = null)
        {
            Registration = registration;
            FullName = fullName;
            Email = email;
        }

        public StudentActionResponseDTO(Student student)
        {
            Registration = student.Registration;
            FullName = student.People.FullName;
            Email = student.People.Email;
        }
    }
}
