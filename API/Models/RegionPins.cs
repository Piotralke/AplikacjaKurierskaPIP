using System.ComponentModel.DataAnnotations;

namespace API.Models
{
	public class RegionPins
	{
		[Key]
		public int id { get; set; }
		public float x { get; set; } 
		public float y { get; set; }
		public int? regionId { get; set; }
		public Region? region { get; set; }
	}
}
