 
using System.ComponentModel.DataAnnotations;
 
namespace Data_Accesss_Layer.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }
        public User Customer { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        public string Status { get; set; }

        public decimal TotalAmount { get; set; }

        public string? DisputeResolution { get; set; } // For admin dispute handling
    }
}
