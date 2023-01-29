using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaKordynatora.Models
{
	public class Report
	{
		public int id { get; set; }
		public string numPackage { get; set; }
		public DateTime date { get; set; }
		public string desc { get; set; }
	}
}

