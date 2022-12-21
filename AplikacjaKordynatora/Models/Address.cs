
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AplikacjaKordynatora.Models
{
    public class Address
    {
        public int id { get; set; }
		[Required]
		public string street { get; set; }
		[Required]
		public string city { get; set; }
		[Required]
		public string houseNumber { get; set; }
		[Required]
		public string zipCode { get; set; }
        public List<Package> senderPackages { get; set; }
        public List<Package> receiverPackages { get; set; }
        public User user { get; set; }
    }
}
