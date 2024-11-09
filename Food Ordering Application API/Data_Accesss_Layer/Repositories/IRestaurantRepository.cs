using Data_Accesss_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Accesss_Layer.Repositories
{
    public interface IRestaurantRepository
    {
        Restaurant AddRestaurant(Restaurant restaurant);
        Menu AddMenuItem(Menu menuItem);
        Menu GetMenuItemById(int menuId);
        void UpdateMenuItem(Menu menuItem);
        void DeleteMenuItem(Menu menuItem);
        List<Review> GetReviewsByRestaurantId(int restaurantId);
        Review GetReviewById(int reviewId);
        void SaveChanges();
    }
}
