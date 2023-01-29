using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
	public class Report
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }
		[Required]
		public string numPackage { get; set; }
		public DateTime date { get; set; }
		public string desc { get; set; }
	}
}
