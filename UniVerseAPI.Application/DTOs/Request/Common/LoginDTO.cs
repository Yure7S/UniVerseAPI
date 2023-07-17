using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVerseAPI.Application.DTOs.Request.Common
{
    public class LoginOrUserInputDTO
    {
        [Required(ErrorMessage = "*** Email is required")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "*** Password is required")]
        public string? Password { get; set; }
    }
}
