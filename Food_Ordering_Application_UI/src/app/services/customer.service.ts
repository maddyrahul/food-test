import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Menu } from '../models/Menu';
import { Observable } from 'rxjs/internal/Observable';
import { Review } from '../models/Review';
import { Restaurant } from '../models/Restaurant';
import { Order } from '../models/Order';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) {}
  private apiUrl='https://localhost:7090/api/Customer';

  getMenuByRestaurantId(restaurantId: number): Observable<Menu[]> {
    return this.http.get<Menu[]>(`${this.apiUrl}/viewMenu/${restaurantId}`);
  }

  // Browse restaurants
  browseRestaurants(search: string): Observable<Restaurant[]> {
    return this.http.get<Restaurant[]>(`${this.apiUrl}/browseRestaurants?search=${search}`);
  }

  // View menu for a specific restaurant
  viewMenu(restaurantId: number): Observable<Menu[]> {
    return this.http.get<Menu[]>(`${this.apiUrl}/viewMenu/${restaurantId}`);
  }

  // Service
addToCart(cartDto: { customerId: number; menuId: number; quantity: number }): Observable<any> {
  return this.http.post<any>(`${this.apiUrl}/addToCart`, cartDto);
}


  // Place an order
  placeOrder(customerId: number): Observable<string> {
    return this.http.post<string>(`${this.apiUrl}/placeOrder`, { customerId });
  }

  // Track an order
  trackOrder(orderId: number): Observable<Order> {
    return this.http.get<Order>(`${this.apiUrl}/trackOrder/${orderId}`);
  }

  // Get order history for a customer
  orderHistory(customerId: number): Observable<Order[]> {
    return this.http.get<Order[]>(`${this.apiUrl}/orderHistory/${customerId}`);
  }

  // Add a review to an order
  addReview(orderId: number, review: Review): Observable<string> {
    return this.http.post<string>(`${this.apiUrl}/${orderId}/AddReview`, review);
  }
}
