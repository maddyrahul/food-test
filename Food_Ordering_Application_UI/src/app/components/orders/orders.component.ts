import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../services/order.service';
import { Order } from '../../models/Order';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.css'
})
export class OrdersComponent implements OnInit {
  orders: Order[] = [];
  customerId: number = 1; // Assuming you have the customer ID stored somehow

  constructor(private orderService: OrderService) {}

  ngOnInit(): void {
    this.loadOrderHistory();
  }

  // Load order history for the customer
  loadOrderHistory() {
    this.orderService.getOrderHistory(this.customerId).subscribe({
      next: (orders) => {
        this.orders = orders;
      },
      error: (err) => console.error("Error loading order history:", err)
    });
  }
}
