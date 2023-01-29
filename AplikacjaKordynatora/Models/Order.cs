namespace AplikacjaKordynatora.Models
{
    public class Order
    {
        public int id { get; set; }
        public int? packageId { get; set; }
        public Package package { get; set; }
        public float? price { get; set; }
        public int? courierId { get; set; }
        public User courier { get; set; }  
    }
}
