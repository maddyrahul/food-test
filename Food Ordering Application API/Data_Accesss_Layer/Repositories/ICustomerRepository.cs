using Data_Accesss_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Accesss_Layer.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Restaurant>> BrowseRestaurantsAsync(string search);
        Task<List<Menu>> ViewMenuAsync(int restaurantId);
        Task<Cart> AddToCartAsync(Cart cartItem);
        Task<List<Cart>> GetCartItemsAsync(int customerId);
        Task<Order> PlaceOrderAsync(Order order, List<Cart> cartItems);
        Task<Order> TrackOrderAsync(int orderId);
        Task<List<Order>> OrderHistoryAsync(int customerId);
        Task<Review> AddReviewAsync(Review review);
    }
}
