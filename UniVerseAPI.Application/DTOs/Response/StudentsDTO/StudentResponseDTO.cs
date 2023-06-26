using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.DTOs.Response.StudentsDTO
{
    public class StudentResponseDTO
    {
        public string? Registration { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }

        public StudentResponseDTO(Student student)
        {
            Registration = student.Registration;
            FullName = student.People.FullName;
            Email = student.People.Email;
        }

    }
}
