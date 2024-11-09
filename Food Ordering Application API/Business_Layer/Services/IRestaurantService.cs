
using Data_Accesss_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public interface IRestaurantService
    {
        Restaurant RegisterRestaurant(int ownerId, string name, string location, string cuisine);
        Menu AddMenuItem(int restaurantId, string name, decimal price);

        Menu GetMenuItemById(int menuId);
        Menu EditMenuItem(int menuId, string name, decimal price);
        void DeleteMenuItem(int menuId);
        List<Review> ViewReviews(int restaurantId);
        void RespondToReview(int reviewId, string response);
    }
}
