﻿
using Data_Accesss_Layer.Models;
using Data_Accesss_Layer.Repositories;

namespace Business_Layer.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public Restaurant RegisterRestaurant(int ownerId, string name, string location, string cuisine)
        {
            var restaurant = new Restaurant
            {
                OwnerId = ownerId,
                Name = name,
                Location = location,
                Cuisine = cuisine
            };

            _restaurantRepository.AddRestaurant(restaurant);
            _restaurantRepository.SaveChanges();
            return restaurant;
        }

        public Menu AddMenuItem(int restaurantId, string name, decimal price)
        {
            var menuItem = new Menu
            {
                RestaurantId = restaurantId,
                Name = name,
                Price = price
            };

            _restaurantRepository.AddMenuItem(menuItem);
            _restaurantRepository.SaveChanges();
            return menuItem;
        }
        public Menu GetMenuItemById(int menuId)
        {
            return _restaurantRepository.GetMenuItemById(menuId);
        }
        public Menu EditMenuItem(int menuId, string name, decimal price)
        {
            var menuItem = _restaurantRepository.GetMenuItemById(menuId);
            if (menuItem == null)
                throw new KeyNotFoundException("Menu item not found.");

            menuItem.Name = name;
            menuItem.Price = price;

            _restaurantRepository.UpdateMenuItem(menuItem);
            _restaurantRepository.SaveChanges();
            return menuItem;
        }

        public void DeleteMenuItem(int menuId)
        {
            var menuItem = _restaurantRepository.GetMenuItemById(menuId);
            if (menuItem == null)
                throw new KeyNotFoundException("Menu item not found.");

            _restaurantRepository.DeleteMenuItem(menuItem);
            _restaurantRepository.SaveChanges();
        }

        public List<Review> ViewReviews(int restaurantId)
        {
            return _restaurantRepository.GetReviewsByRestaurantId(restaurantId);
        }

        public void RespondToReview(int reviewId, string response)
        {
            var review = _restaurantRepository.GetReviewById(reviewId);
            if (review == null)
                throw new KeyNotFoundException("Review not found.");

            
            review.Response = response;
            _restaurantRepository.SaveChanges();
        }
    }
}
