using AplikacjaKordynatora.Models;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace AplikacjaKordynatora.Models
{
    public class loginCredentials
    {
        
        public int id { get; set; }
        [Required,EmailAddress]
        public string email { get; set; }
		[Required]
		public string login { get; set; }
		[Required]
		public string password { get; set; }
        public User user { get; set; }
    }
}