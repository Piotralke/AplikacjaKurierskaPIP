using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int idStatusName { get; set; }
        public statusNames StatusName { get; set; }
        [Required]
        public int idPackage { get; set; }
        public Package package { get; set; }
        [Required]
        public DateTime date { get; set; }
    }
}
