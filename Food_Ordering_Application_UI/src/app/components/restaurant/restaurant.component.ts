import { Component } from '@angular/core';
import { Restaurant } from '../../models/Restaurant';
import { Menu } from '../../models/Menu';
import { RestaurantService } from '../../services/restaurant.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrl: './restaurant.component.css'
})
export class RestaurantComponent {
  restaurant: Restaurant = {} as Restaurant;
  errorMessage: string = '';
  ownerId:number= 2;
  constructor(private restaurantService: RestaurantService, private router: Router) {}

  registerRestaurant() {


    const restaurantDto = {
      ownerId: this.ownerId,
      name: this.restaurant.name,
      location: this.restaurant.location,
      cuisine:this.restaurant.cuisine
    };
  
    this.restaurantService.registerRestaurant(restaurantDto)
      .subscribe({
        next: () => {
          alert("Restaurant registered successfully!");
          this.router.navigate(['/all-restaurants']);
        },
        error: (err) => this.errorMessage = err.message
      });
  }
}
