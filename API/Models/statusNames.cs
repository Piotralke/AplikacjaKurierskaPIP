using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class statusNames
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public ICollection<Status> status { get; set; }
    }
}
