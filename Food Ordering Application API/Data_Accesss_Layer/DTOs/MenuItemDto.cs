using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Accesss_Layer.DTOs
{
    public class MenuItemDto
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

}
