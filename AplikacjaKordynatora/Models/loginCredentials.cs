using System.ComponentModel.DataAnnotations;

namespace AplikacjaKordynatora.Models
{
    public class loginCredentials
    {
        
        public int id { get; set; } 
        public string email { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public User user { get; set; }
    }
}
