using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Status
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int idStatusName { get; set; }
        public statusNames statusName { get; set; }
        [Required]
        public int idPackage { get; set; }
        public Package package { get; set; }
        [Required]
        public DateTime date { get; set; }
    }
}
