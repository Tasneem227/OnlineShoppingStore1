using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HospitalMS.ViewModel
{
    public class LoginUserViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
