using System;

namespace AplikacjaKordynatora.Models
{
    public class Status
    {
        public int Id { get; set; }
        public int idStatusName { get; set; }
        public statusNames StatusName { get; set; }
        public int idPackage { get; set; }
        public Package package { get; set; }
        public DateTime date { get; set; }
    }
}
