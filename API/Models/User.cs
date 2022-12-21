using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string surname { get; set; }
        public int? loginCredentialsId { get; set; }
        public loginCredentials? loginCredentials { get; set; }
        [Required]
        public int role { get; set; } //0-koordynator,1-kurier,2-klient
        public int? defaultAddressId { get; set; }
        public Address? defaultAddress { get; set; }
        public ICollection<Package>? senderPackages {get; set;}
        public ICollection<Package>? receiverPackages {get; set;}
        public ICollection<Order>? orders { get; set;}
        public string phoneNumber { get; set; }
		public Region? region { get; set; }
	}
}
