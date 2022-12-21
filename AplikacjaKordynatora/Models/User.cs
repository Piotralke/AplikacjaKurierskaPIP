
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace AplikacjaKordynatora.Models
{
    public class User
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Proszę podać imie")]
        public string name { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwisko")]
        public string surname { get; set; }
        public int? loginCredentialsId { get; set; }
        public loginCredentials loginCredentials { get; set; }
        public int role { get; set; } //0-koordynator,1-kurier,2-klient
        public int defaultAddressId { get; set; }
        public Address defaultAddress { get; set; }
        public List<Package> senderPackages { get; set; }
        public List<Package> receiverPackages { get; set; }
        public List<Order> orders { get; set; }
		[Required(ErrorMessage = "Proszę podać numer telefonu"), RegularExpression("^[0-9]{3}-[0-9]{3}-[0-9]{3}$", ErrorMessage = "Poprawny format numeru telefonu to 'xxx-xxx-xxx'")]
		public string phoneNumber { get; set; }
        public Region region { get; set; }
    }
}
