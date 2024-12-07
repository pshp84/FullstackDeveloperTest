import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Store, StoreModule } from '@ngrx/store';
import { AppState, User } from '../../model/app-state.interface';
import {
  addUser,
  updateUser,
  deleteUser,
  selectUser,
  loadUsers,
} from '../../data/user.actions';
import { selectAllUsers } from '../../data/user.selectors';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { UserOrdersComponent } from '../user-orders/user-orders.component';
import { Observable } from 'rxjs';
import { userReducer } from '../../data/user.reducer';
import { UserService } from '../../service-management/user.service';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component'; // Import the confirmation dialog
import { UserDialogComponent } from './user-dialog/user-dialog.component';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatDialogModule,
  ],
  providers: [],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.scss',
})
export class UserListComponent implements OnInit {
  users$: Observable<User[]>;
  displayedColumns: string[] = ['id', 'name', 'actions'];
  nextNumber: number = 3;
  constructor(
    private store: Store<AppState>,
    private dialog: MatDialog,
    private userService: UserService
  ) {
    this.users$ = this.store.select(selectAllUsers);
  }

  ngOnInit(): void {
    // Fetch the users using the service and dispatch the loadUsers action
    this.userService.getUsers().subscribe((users) => {
      this.store.dispatch(loadUsers({ users: users })); // Dispatch action to store
    });
  }

  addUser(): void {
    const dialogRef = this.dialog.open(UserDialogComponent, {
      width: '400px',
      data: { isEdit: false, user: null },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.nextNumber = this.nextNumber + 1;
        const newUser = { id: this.nextNumber, ...result };
        this.store.dispatch(addUser({ user: newUser }));
      }
    });
  }

  updateUser(user: any): void {
    const dialogRef = this.dialog.open(UserDialogComponent, {
      width: '400px',
      data: { isEdit: true, user },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        debugger;
        this.store.dispatch(
          updateUser({ user: { id: user.id, changes: result } })
        );
      }
    });
  }

  deleteUser(userId: number): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent);

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        // If user confirms, dispatch delete action
        this.store.dispatch(deleteUser({ id: userId }));
      }
    });
  }

  viewOrders(userId: number): void {
    this.store.dispatch(selectUser({ userId }));
    this.dialog.open(UserOrdersComponent, {
      width: '500px',
      data: { userId },
    });
  }
}
