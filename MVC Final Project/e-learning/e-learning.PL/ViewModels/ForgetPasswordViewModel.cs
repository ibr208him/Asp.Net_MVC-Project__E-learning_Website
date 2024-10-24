using System.ComponentModel.DataAnnotations;

namespace e_learning.PL.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [MinLength(5)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
