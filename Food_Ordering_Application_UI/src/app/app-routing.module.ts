import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RestaurantComponent } from './components/restaurant/restaurant.component';
import { AllRestaurantsComponent } from './components/all-restaurants/all-restaurants.component';
import { AddMenuComponent } from './components/add-menu/add-menu.component';
import { EditMenuComponent } from './components/edit-menu/edit-menu.component';
import { ViewMenuComponent } from './components/view-menu/view-menu.component';
import { ListRestaurantComponent } from './components/list-restaurant/list-restaurant.component';
import { CartComponent } from './components/cart/cart.component';
import { OrdersComponent } from './components/orders/orders.component';
import { LoginComponent } from './components/login/login.component';
import { UsersComponent } from './components/users/users.component';

const routes: Routes = [
  { path: 'register-restaurant', component: RestaurantComponent },
  { path: 'all-restaurants', component: AllRestaurantsComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'edit-menu/:menuId', component: EditMenuComponent },
  { path: 'add-menu/:restaurantId', component: AddMenuComponent },
  { path: 'view-menu/:restaurantId',component:ViewMenuComponent},
  { path: 'list-restaurant',component:ListRestaurantComponent},
  { path: 'login',component:LoginComponent},
  { path: 'users',component:UsersComponent},
  { path: 'cart',component:CartComponent},
  { path: '', redirectTo: '/all-restaurants', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
