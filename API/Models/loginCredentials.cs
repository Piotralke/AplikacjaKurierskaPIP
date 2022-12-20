using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class loginCredentials
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string login { get; set; }
        [Required]
        public string password { get; set; }
        public User user { get; set; }
    }
}