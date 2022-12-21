
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AplikacjaKordynatora.Models
{
    public class Address
    {
        public int id { get; set; }
		[Required(ErrorMessage = "Proszę podać ulice")]
		public string street { get; set; }
		[Required(ErrorMessage = "Proszę podać miasto"), RegularExpression("^[A-Z]{1}[a-z]*$", ErrorMessage = "Niepoprawna nazwa miasta, spróbuj użyć formatu 'Xxxx..'")]
		public string city { get; set; }
		[Required(ErrorMessage = "Proszę podać numer domu")]
		public string houseNumber { get; set; }
		[Required(ErrorMessage = "Proszę podać kod pocztowy"), RegularExpression("^[0-9]{2}-[0-9]{3}$", ErrorMessage = "Poprawny format kodu to 'xx-xxx'")]
		public string zipCode { get; set; }
        public List<Package> senderPackages { get; set; }
        public List<Package> receiverPackages { get; set; }
        public User user { get; set; }
    }
}
