﻿using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string login { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public int role { get; set; } //0-koordynator,1-kurier,2-klient
    }
}
