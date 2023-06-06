using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVerseAPI.Application.DTOs.Response.BaseResponse
{
    public class BaseResponseDTO
    {
        public string? Message { get; set; }
        public bool Success { get; set; }
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
