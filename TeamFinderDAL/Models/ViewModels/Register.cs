using System.ComponentModel.DataAnnotations;

namespace TeamFinderDAL.Models.ViewModels
{
    public class AccountRegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        public string DisplayUsername { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}