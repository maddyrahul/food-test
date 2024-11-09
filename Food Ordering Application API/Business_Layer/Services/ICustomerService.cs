using Data_Accesss_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public interface ICustomerService
    {
        // Browse and search restaurants
        Task<List<Restaurant>> BrowseRestaurantsAsync(string search);

        // View menu for a specific restaurant
        Task<List<Menu>> ViewMenuAsync(int restaurantId);

        // Add item to cart
        Task<string> AddToCartAsync(int customerId, int menuId, int quantity);

        // Place an order
        Task<string> PlaceOrderAsync(int customerId);

        // Track order status
        Task<object> TrackOrderAsync(int orderId);

        // View order history
        Task<List<object>> OrderHistoryAsync(int customerId);

        // Add review for a restaurant after an order
        Task<string> AddReviewAsync(int orderId, Review review);
    }
}
