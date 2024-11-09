using Data_Accesss_Layer.Data;
using Data_Accesss_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace Business_Layer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Restaurant>> BrowseRestaurantsAsync(string search)
        {
            var restaurants = _context.Restaurants.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                restaurants = restaurants.Where(r => r.Name.Contains(search));
            }
            return await restaurants.ToListAsync();
        }

        public async Task<List<Menu>> ViewMenuAsync(int restaurantId)
        {
            return await _context.Menus.Where(m => m.RestaurantId == restaurantId).ToListAsync();
        }

        public async Task<string> AddToCartAsync(int customerId, int menuId, int quantity)
        {
            var cartItem = new Cart
            {
                CustomerId = customerId,
                MenuId = menuId,
                Quantity = quantity
            };

            _context.Carts.Add(cartItem);
            await _context.SaveChangesAsync();

            return "Item added to cart.";
        }

        public async Task<string> PlaceOrderAsync(int customerId)
        {
            var cartItems = await _context.Carts
                .Include(c => c.Menu)
                .ThenInclude(m => m.Restaurant)
                .Where(c => c.CustomerId == customerId)
                .ToListAsync();

            if (!cartItems.Any())
                return "Cart is empty.";

            if (cartItems.Any(c => c.Menu == null || c.Menu.Restaurant == null))
                return "Some cart items have missing menu or restaurant data.";

            var order = new Order
            {
                CustomerId = customerId,
                RestaurantId = cartItems.First().Menu.Restaurant.RestaurantId,
                OrderDate = DateTime.Now,
                Status = "Placed",
                TotalAmount = cartItems.Sum(c => c.Quantity * c.Menu.Price),
                DisputeResolution = "No"
            };

            _context.Orders.Add(order);
            _context.Carts.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            return "Order placed successfully.";
        }

        public async Task<object> TrackOrderAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) return null;

            return new { order.OrderDate, order.Status, order.TotalAmount };
        }

        public async Task<List<object>> OrderHistoryAsync(int customerId)
        {
            return await _context.Orders
                .Where(o => o.CustomerId == customerId)
                .Select(o => new { o.OrderDate, o.Status, o.TotalAmount })
                .ToListAsync<object>();
        }

        public async Task<string> AddReviewAsync(int orderId, Review review)
        {
            var order = await _context.Orders
                .Include(o => o.Restaurant)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null)
                return "Order not found or not authorized.";

            var existingReview = await _context.Reviews
                .FirstOrDefaultAsync(r => r.CustomerId == order.CustomerId && r.RestaurantId == order.RestaurantId);

            if (existingReview != null)
                return "Review already exists for this order.";

            review.CustomerId = order.CustomerId;
            review.RestaurantId = order.RestaurantId;
            review.Response = "";
            review.DatePosted = DateTime.UtcNow;

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return "Review added successfully.";
        }
    }
}
