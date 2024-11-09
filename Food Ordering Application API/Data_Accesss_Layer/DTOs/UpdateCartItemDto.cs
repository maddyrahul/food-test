using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Accesss_Layer.DTOs
{
    public class UpdateCartItemDto
    {
        public int CartId { get; set; }
        public int Quantity { get; set; }
    }
}
