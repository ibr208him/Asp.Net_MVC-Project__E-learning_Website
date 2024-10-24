using System.ComponentModel.DataAnnotations;

namespace e_learning.PL.ViewModels
{
    public class LoginViewModel
    {
 

        [Required(ErrorMessage = "Email is required")]
        [MinLength(5)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }=false;

    }
}
