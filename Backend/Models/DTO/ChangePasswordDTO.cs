using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class ChangePasswordDTO
    {
        //[Required(ErrorMessage = "User Name is required")]
        //public string? Username { get; set; }

        [Required(ErrorMessage = "Current Password is required")]
        public string? CurrentPassword { get; set; }

        [Required(ErrorMessage = "Current Password is required")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Current Password is required")]
        [Compare("NewPassword")]
        public string? ConfirmNewPassword { get; set; }
    }
}
