using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Deliverable_2_WireFrames.ViewModels
{
    public class ComaprePasswordVM
    {
        [Required(ErrorMessage = "Please Enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm your password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string confirmPassword { get; set; }



    }
}