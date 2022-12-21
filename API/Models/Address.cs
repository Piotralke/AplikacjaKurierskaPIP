using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Address
    {
		[Key]
        public int id { get; set; }
        [Required]
        public string street { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string houseNumber { get; set; }
        [Required]
        public string zipCode { get; set; }
        public ICollection<Package>? senderPackages { get; set; }
        public ICollection<Package>? receiverPackages { get; set; }
        public User? user { get; set; }
    }
}
