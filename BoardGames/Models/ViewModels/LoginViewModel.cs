using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BoardGames.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        [UIHint("Password")]
        [PasswordPropertyText]
        public string Password { get; set; } = null!;
        public string ReturnUrl { get; set; } = "/";
    }
}
