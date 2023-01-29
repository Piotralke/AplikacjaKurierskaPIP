using System;

namespace AplikacjaKordynatora.Models
{
    public class Status
    {
        public int id { get; set; }
        public int idStatusName { get; set; }
        public statusNames statusName { get; set; }
        public int idPackage { get; set; }
        public Package package { get; set; }
        public DateTime date { get; set; }
    }
}
