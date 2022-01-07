using System.ComponentModel.DataAnnotations;

namespace TeamFinderDAL.Models.ViewModels
{
    public class AccountLoginViewModel
    {
        [Required] public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}