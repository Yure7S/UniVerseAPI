using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniVerseAPI.Application.DTOs.Response.BaseResponse;

namespace UniVerseAPI.Application.DTOs.Request.Common
{
    public class LoginResponseDTO : BaseResponseDTO
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Token { get; set; }

        public LoginResponseDTO()
        {
            
        }
    }
}
