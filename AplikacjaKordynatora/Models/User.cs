
using System.Collections.Generic;

namespace AplikacjaKordynatora.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int role { get; set; } //0-koordynator,1-kurier,2-klient
        public int? defaultAddressId { get; set; }
        public Address defaultAddress { get; set; }
        public List<Package> senderPackages { get; set; }
        public List<Package> receiverPackages { get; set; }
        public List<Order> orders { get; set; }
    }
}
