using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UniVerseAPI.Application.DTOs.Response.BaseResponse
{
    public class BaseResponseDTO
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool Success { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Error { get; set; }

        public BaseResponseDTO() { }    

        public BaseResponseDTO(string? message, bool success, string? error = "")
        {
            Message = message;
            Success = success;
            Error = error;
        }

        public void Update(string? message, bool success, string? error = "")
        {
            Message = message;
            Success = success;
            Error = error;
        }
    }
}
