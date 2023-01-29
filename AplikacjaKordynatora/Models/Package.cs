using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AplikacjaKordynatora.Models
{
    public class Package
    {
        public int id { get; set; }
        public string number { get; set; }
        public int receiverId { get; set; }
        public User receiver { get; set; }
        public int receiverAddressId { get; set; }
        public Address receiverAddress { get; set; }
        public int senderId { get; set; }
        public User sender { get; set; }
        public int senderAddressId { get; set; }
        public Address senderAddress { get; set; }
        public float weight { get; set; }
        public float width { get; set; }
        public float depth { get; set; }
        public float heigth { get; set; }
        public string description { get; set; }
        public bool isStandardShape { get; set; }
        public float cODcost { get; set; }
        public Order order { get; set; }
        public List<Status> statuses { get; set; }
    }
}
