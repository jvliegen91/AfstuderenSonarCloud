using System.ComponentModel.DataAnnotations;

namespace Afstuderen2020.Models
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Het veld '{0}' is niet ingevuld, dit veld is verplicht.")]
        [Display(Name ="Gebruikersnaam")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Het veld '{0}' is niet ingevuld, dit veld is verplicht.")]
        [Display(Name ="Wachtwoord")]
        public string Password { get; set; }
        public string LoginErrorMessage { get; set; }
    }
}
