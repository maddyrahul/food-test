using Data_Accesss_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Accesss_Layer.Repositories
{
    public interface IAdminRepository
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<Restaurant> GetRestaurantByIdAsync(int restaurantId);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task SaveChangesAsync();

        Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
    }
}
