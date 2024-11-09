import { Component, OnInit } from '@angular/core';
import { Restaurant } from '../../models/Restaurant';
import { RestaurantService } from '../../services/restaurant.service';
import { Router } from '@angular/router';
import { CustomerService } from '../../services/customer.service';
import { Menu } from '../../models/Menu';

@Component({
  selector: 'app-all-restaurants',
  templateUrl: './all-restaurants.component.html',
  styleUrl: './all-restaurants.component.css'
})
export class AllRestaurantsComponent implements OnInit {
  restaurants: Restaurant[] = [];
  menuItems: Menu[] = [];
  selectedRestaurantId: number | null = null;
  errorMessage: string = '';

  constructor(private restaurantService: RestaurantService, private router: Router, private customerService:CustomerService) {}

  ngOnInit(): void {
    this.loadRestaurants();
  }

  loadRestaurants() {
    this.restaurantService.getAllRestaurants().subscribe({
      next: (res) => this.restaurants = res,
      error: (err) => this.errorMessage = err.message
    });
  }

  addMenu(restaurantId: number) {
    this.router.navigate(['/add-menu', restaurantId]);
  }
  viewMenu(restaurantId: number) {
    // Set the selected restaurant ID to display menu for that restaurant
    this.selectedRestaurantId = restaurantId;

    // Fetch menu items for the selected restaurant
    this.customerService.getMenuByRestaurantId(restaurantId).subscribe({
      next: (res) => this.menuItems = res,
      error: (err) => this.errorMessage = "Error loading menu: " + err.message
    });
  }


   // Edit Menu Item
   editMenu(menuId: number) {
    
    this.router.navigate(['/edit-menu', menuId]);
    }
  

  // Delete Menu Item
  deleteMenu(menuId: number) {
    const confirmDelete = confirm("Are you sure you want to delete this menu item?");
    if (confirmDelete) {
      this.restaurantService.deleteMenuItem(menuId).subscribe({
        next: () => {
          alert('Menu item deleted successfully!');
          this.loadRestaurants(); // Call this after successful deletion
        },
        error: (err) => {
          alert("Error deleting menu item: " + err.message);
        }
      });
    }
  }
}