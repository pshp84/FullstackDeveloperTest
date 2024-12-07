import { AfterViewInit, Component, Inject } from '@angular/core';
import { selectSelectedUser } from '../../data/user.selectors';
import { AppState, Order, User } from '../../model/app-state.interface';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { Observable } from 'rxjs';
import { ORDERS } from '../../service-management/mock-data';

@Component({
  selector: 'app-user-orders',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatDialogModule,
  ],
  templateUrl: './user-orders.component.html',
  styleUrl: './user-orders.component.scss',
})
export class UserOrdersComponent implements AfterViewInit {
  selectedUser$ = this.store.select(selectSelectedUser);
  orders: Order[] = [];
  totalOrderAmount: number = 0;
  displayedColumns: string[] = ['id', 'total']; // Columns for the table
  constructor(
    private store: Store<AppState>,
    private dialogRef: MatDialogRef<UserOrdersComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngAfterViewInit(): void {
    this.orders = ORDERS.filter((order) => order.userId === this.data.userId);

    // Calculate the total amount of orders for this user
    this.totalOrderAmount = this.orders.reduce(
      (total, order) => total + order.total,
      0
    );
  }

  filterOrdersForUser(userId: number): void {
    // Filter orders from mock data based on selected user
    this.orders = ORDERS.filter((order) => order.userId === userId);

    // Calculate the total amount of orders for this user
    this.totalOrderAmount = this.orders.reduce(
      (total, order) => total + order.total,
      0
    );
  }

  closeDialog(): void {
    this.dialogRef.close();
  }
}
