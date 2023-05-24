using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVerseAPI.Application.DTOs.Response
{
    public class BaseResponse
    {
        public string? Message { get; set; }
        public bool Success { get; set; }

    }
}
