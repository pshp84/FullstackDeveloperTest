// user.service.ts
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { User, Order } from '../model/app-state.interface';
import { USERS, ORDERS } from './mock-data';

@Injectable({ providedIn: 'root' })
export class UserService {
  getUsers(): Observable<User[]> {
    return of(USERS);
  }

  getOrdersByUserId(userId: number): Observable<Order[]> {
    const userOrders = ORDERS.filter(order => order.userId === userId);
    return of(userOrders);
  }
}