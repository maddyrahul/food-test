using Data_Accesss_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public interface IAdminService
    {
        Task<string> ManageUserAccountAsync(int userId, bool isActive);
        Task<string> ManageRestaurantAsync(int restaurantId, bool isActive);
        Task<string> ResolveDisputeAsync(int orderId, string resolution);

        Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
    }
}
