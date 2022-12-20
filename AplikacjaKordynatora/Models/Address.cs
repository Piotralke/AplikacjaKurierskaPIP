
using System.Collections.Generic;

namespace AplikacjaKordynatora.Models
{
    public class Address
    {
        public int id { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string houseNumber { get; set; }
        public string zipCode { get; set; }
        public List<Package> senderPackages { get; set; }
        public List<Package> receiverPackages { get; set; }
        public User user { get; set; }
    }
}
