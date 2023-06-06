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
    public class TeacherActionResponseDTO
    {
        public TeacherInputDTO? TeacherResponse { get; set; }
        public AddressResponseDTO? AddressResponse { get; set; }
        public PeopleResponseDTO? PeopleResponse { get; set; }

        public TeacherActionResponseDTO(TeacherInputDTO? teacherResponse, AddressResponseDTO? addressResponse, PeopleResponseDTO? peopleResponse)
        {
            TeacherResponse = teacherResponse;
            AddressResponse = addressResponse;
            PeopleResponse = peopleResponse;
        }
    }
}
