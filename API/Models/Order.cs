using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int? packageId { get; set; }
        public Package? package { get; set; }
        public float? price { get; set; }
        public int? courierId { get; set; }
        public User? courier { get; set; }  
    }
}
