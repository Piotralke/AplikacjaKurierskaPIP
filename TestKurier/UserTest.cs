using AplikacjaKordynatora.Models;
using System.Text.RegularExpressions;

namespace TestKurier
{
	[TestClass]
	public class UserTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			User user = new User
			{
				id=0,
				name="Jan",
				surname="Kowalski",
				loginCredentialsId=1,
				role=2,
				defaultAddressId=1,
				phoneNumber="123-123-123",
			};
			var r = new Regex(@"^[0-9]{3}-[0-9]{3}-[0-9]{3}$");
			Assert.IsTrue(r.IsMatch(user.phoneNumber));
			Assert.IsNotNull(user);
			Assert.IsNotNull(user.name);
			Assert.IsNotNull(user.surname);
		}
	}
}