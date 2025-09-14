
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Review
    {

        [Key]
        public int ReviewId { get; set; }

        public int UserId { get; set; }
        public int OrderId {  get; set; }   
        public string ReviewText { get; set; }
        public DateTime CreationDate { get; set; }  
        public int Rate {  get; set; }


        public User User { get; set; }

        public Order Order { get; set; }
    }
}
