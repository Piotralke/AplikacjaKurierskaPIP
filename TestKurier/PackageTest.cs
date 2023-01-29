using AplikacjaKordynatora.Models;
using System.Text.RegularExpressions;

namespace TestKurier
{
	[TestClass]
	public class PackageTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			Package package= new Package
			{
				id=0,
				number="123456789029-01-2023",
				receiverId=1,
				receiverAddressId=1,
				senderId=2,
				senderAddressId=2,
				weight=3.5f,
				width=20,
				depth=15.6f,
				heigth=22.7f,
				description="Testowa paczka",
				isStandardShape=true,
				cODcost=200
			};

			Assert.IsNotNull(package);
			var r = new Regex(@"^\d{12}-\d{2}-\d{4}$");
			Assert.IsTrue(r.IsMatch(package.number));
			Assert.IsTrue(package.weight > 0);
			Assert.IsTrue(package.width > 0);
			Assert.IsTrue(package.depth > 0);
			Assert.IsTrue(package.heigth > 0);
		}
	}
}