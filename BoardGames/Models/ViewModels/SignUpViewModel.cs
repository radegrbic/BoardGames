using DomainCore;
using System.ComponentModel.DataAnnotations;

namespace BoardGames.Models.ViewModels
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Email moet ingevuld worden.")]
        [Display(Name = "Uw email:")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Voornaam moet ingevuld worden.")]
        [Display(Name = "Uw voornaam:")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "Achternaam moet ingevuld worden.")]
        [Display(Name = "Uw achternaam:")]
        public string SecondName { get; set; } = null!;
        [Required(ErrorMessage = "Geef jouw geslacht aan")]
        [Display(Name = "Uw geslacht:")]
        public Sex Sex { get; set; }
        [Required(ErrorMessage = "Stad moet ingevuld worden.")]
        [Display(Name = "Uw stad:")]
        public string City { get; set; } = null!;
        [Required(ErrorMessage = "Straat moet ingevuld worden.")]
        [Display(Name = "Uw straat:")]
        public string Street { get; set; } = null!;
        [Required(ErrorMessage = "Huisnummer moet ingevuld worden.")]
        [Display(Name = "Uw huisnummer:")]
        public int HouseNumber { get; set; }
        [Required(ErrorMessage = "Geboortedatum moet ingevuld worden.")]
        [Display(Name = "Uw geboortedatum:")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Wachtwoord moet ingevuld worden.")]
        [Display(Name = "Uw wachtwoord:")]
        [RegularExpression(
            "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Een wachtwoord moet de volgende tekens bevatten: een kleine letter, een grote letter, " +
                           "een cijfer, een speciaal teken(#?!@$%^&*-) en moet minimaal 8 karakters lang zijn")]
        public string Password { get; set; } = null!;
    }
}
