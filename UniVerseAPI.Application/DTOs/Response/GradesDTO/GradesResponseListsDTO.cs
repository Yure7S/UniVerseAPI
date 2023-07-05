using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Infra.Data.Context;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;
using System.Text.Json.Serialization;

namespace UniVerseAPI.Application.DTOs.Response.GradesDTO
{
    public class GradesResponseListsDTO : BaseResponseDTO
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<GradesResponseDTO>? Grade { get; set; }
    }
}
