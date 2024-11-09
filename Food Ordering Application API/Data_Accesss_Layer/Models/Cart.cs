 
using System.ComponentModel.DataAnnotations;

namespace Data_Accesss_Layer.Models
{
   
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public int CustomerId { get; set; }
        public User Customer { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
