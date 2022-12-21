
using System.Collections.Generic;

namespace AplikacjaKordynatora.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int? loginCredentialsId { get; set; }
        public loginCredentials loginCredentials { get; set; }
        public int role { get; set; } //0-koordynator,1-kurier,2-klient
        public int? defaultAddressId { get; set; }
        public Address defaultAddress { get; set; }
        public List<Package> senderPackages { get; set; }
        public List<Package> receiverPackages { get; set; }
        public List<Order> orders { get; set; }
        public string phoneNumber { get; set; }
    }
}
