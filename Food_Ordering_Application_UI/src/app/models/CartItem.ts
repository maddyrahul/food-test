import { Menu } from "./Menu";

export interface CartItem {
    cartId: number;
    customerId: number;
    menuId: number;
    menu:Menu;
    quantity: number;
  }