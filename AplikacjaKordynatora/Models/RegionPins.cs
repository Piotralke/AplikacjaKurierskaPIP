using System.ComponentModel.DataAnnotations;

namespace AplikacjaKordynatora.Models
{
	public class RegionPins
	{
		public int id { get; set; }
		public float x { get; set; }
		public float y { get; set; }
		public int? regionId { get; set; }
		public Region region { get; set; }
	}
}