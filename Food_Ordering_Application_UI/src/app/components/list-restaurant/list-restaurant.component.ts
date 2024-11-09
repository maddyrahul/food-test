import { Component, OnInit } from '@angular/core';
import { Restaurant } from '../../models/Restaurant';
import { Menu } from '../../models/Menu';
import { RestaurantService } from '../../services/restaurant.service';
import { Router } from '@angular/router';
import { CustomerService } from '../../services/customer.service';

@Component({
  selector: 'app-list-restaurant',
  templateUrl: './list-restaurant.component.html',
  styleUrl: './list-restaurant.component.css'
})
export class ListRestaurantComponent implements OnInit {
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

 
  viewMenu(restaurantId: number) {
    this.router.navigate(['/view-menu', restaurantId]);
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