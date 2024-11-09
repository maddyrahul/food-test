﻿using System.ComponentModel.DataAnnotations;

namespace Data_Accesss_Layer.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Cuisine { get; set; }

        public bool IsActive { get; set; } = true;

        public int OwnerId { get; set; }
        public User Owner { get; set; }

        public List<Menu> Menus { get; set; }
        public List<Review> Reviews { get; set; }
    }

}
