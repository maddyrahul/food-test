using Business_Layer.Services;
using Data_Accesss_Layer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        /* private readonly ApplicationDbContext _context;

         public AdminController(ApplicationDbContext context)
         {
             _context = context;
         }

         // Manage user account access levels
         [HttpPost("manageUserAccount")]
         public IActionResult ManageUserAccount(int userId, bool isActive)
         {
             var user = _context.Users.Find(userId);
             if (user == null) return NotFound("User not found.");

             user.IsActive = isActive;
             _context.SaveChanges();

             return Ok("User account status updated.");
         }

         // Manage restaurants
         [HttpPost("manageRestaurant")]
         public IActionResult ManageRestaurant(int restaurantId, bool isActive)
         {
             var restaurant = _context.Restaurants.Find(restaurantId);
             if (restaurant == null) return NotFound("Restaurant not found.");

             restaurant.IsActive = isActive;
             _context.SaveChanges();

             return Ok("Restaurant status updated.");
         }

         // Resolve disputes
         [HttpPost("resolveDispute")]
         public IActionResult ResolveDispute(int orderId, string resolution)
         {
             var order = _context.Orders.Find(orderId);
             if (order == null) return NotFound("Order not found.");

             order.DisputeResolution = resolution;
             order.Status = "Resolved";
             _context.SaveChanges();

             return Ok("Dispute resolved successfully.");
         }*/
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // Manage user account access levels
        [HttpPost("manageUserAccount")]
        public async Task<IActionResult> ManageUserAccount(int userId, bool isActive)
        {
            if (userId <= 0) return BadRequest("Invalid user ID.");

            try
            {
                var result = await _adminService.ManageUserAccountAsync(userId, isActive);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while managing user account.");
            }
        }

        // Manage restaurants
        [HttpPost("manageRestaurant")]
        public async Task<IActionResult> ManageRestaurant(int restaurantId, bool isActive)
        {
            if (restaurantId <= 0) return BadRequest("Invalid restaurant ID.");

            try
            {
                var result = await _adminService.ManageRestaurantAsync(restaurantId, isActive);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while managing the restaurant.");
            }
        }

        // Resolve disputes
        [HttpPost("resolveDispute")]
        public async Task<IActionResult> ResolveDispute(int orderId, string resolution)
        {
            if (orderId <= 0) return BadRequest("Invalid order ID.");
            if (string.IsNullOrWhiteSpace(resolution)) return BadRequest("Resolution must not be empty.");

            try
            {
                var result = await _adminService.ResolveDisputeAsync(orderId, resolution);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while resolving the dispute.");
            }
        }


        [HttpGet("getAllRestaurants")]
        public async Task<IActionResult> GetAllRestaurants()
        {
            try
            {
                var restaurants = await _adminService.GetAllRestaurantsAsync();
                return Ok(restaurants);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving restaurant details.");
            }
        }
    }
}
