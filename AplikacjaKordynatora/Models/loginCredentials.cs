using AplikacjaKordynatora.Models;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace AplikacjaKordynatora.Models
{
    public class loginCredentials
    {
        
        public int id { get; set; }
        [Required(ErrorMessage = "Proszę podać adres e-mail"), EmailAddress]
        public string email { get; set; }
		[Required(ErrorMessage = "Proszę podać login")]
		public string login { get; set; }
		[Required(ErrorMessage = "Proszę podać haslo"), RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Hasło powinno zawierać małą, dużą litere, znak specjalny, cyfre i minimum 8 zanków")]
        public string password { get; set; }
        public User user { get; set; }
    }
}