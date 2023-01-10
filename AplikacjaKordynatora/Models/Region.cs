﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AplikacjaKordynatora.Models
{
	public class Region
	{
		[JsonProperty("Id")]
		public int Id { get; set; }
		public string code { get; set; }
		public int? courierId { get; set; }
		public User courier { get; set; }
		public List<RegionPins> regionPins { get; set; }
	}
}
