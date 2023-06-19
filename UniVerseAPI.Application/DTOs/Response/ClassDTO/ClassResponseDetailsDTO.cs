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

namespace UniVerseAPI.Application.DTOs.Response.ClassDTO
{
    public class ClassResponseDetailsDTO : BaseResponseDTO
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ClassDetailsDTO? Class { get; set; }
    }
}
