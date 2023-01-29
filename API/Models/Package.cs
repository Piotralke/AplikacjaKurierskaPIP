using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Package
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string number { get; set; }
        [Required]
        public int receiverId { get; set; }
        public User receiver { get; set; }
        [Required]
        public int receiverAddressId { get; set; }
        public Address receiverAddress { get; set; }
        [Required]
        public int senderId { get; set; }
        public User sender { get; set; }
        [Required]
        public int senderAddressId { get; set; }
        public Address senderAddress { get; set; }
        [Required]
        public float weight { get; set; }
        [Required]
        public float width { get; set; }
        [Required]
        public float depth { get; set; }
        [Required]
        public float heigth { get; set; }
        public string? description { get; set; }
        [Required]
        public bool isStandardShape { get; set; }
        public float? cODcost { get; set; }
        public Order? order { get; set; }
        public ICollection<Status> statuses { get; set; }

    }
}
