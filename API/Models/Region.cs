using System.ComponentModel.DataAnnotations;

namespace API.Models
{
	public class Region
	{
		[Key]
		public int Id { get; set; }
		public string? code { get; set; }
		public int? courierId { get; set; }
		public User? courier { get; set; }
		public ICollection<RegionPins>? regionPins { get; set; }
	}
}
