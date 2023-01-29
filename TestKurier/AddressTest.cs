using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AplikacjaKordynatora.Models;

namespace TestKurier
{
	[TestClass]
	public class AddressTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			Address address = new Address
			{
				id=0,
				street="Cwiartki",
				city="Wroclaw",
				houseNumber="3a/4",
				zipCode="50-110",
			};

			var r = new Regex(@"^[A-Z]{1}[a-z]*$");
			var r2 = new Regex(@"^[0-9]*[a-z]{1}/[0-9]*");
			var r3 = new Regex(@"^[0-9]{2}-[0-9]{3}$");
			Assert.IsTrue(r.IsMatch(address.city));
			Assert.IsTrue(r2.IsMatch(address.houseNumber));
			Assert.IsTrue(r3.IsMatch(address.zipCode));
			Assert.IsNotNull(address);
		}
	}
}
