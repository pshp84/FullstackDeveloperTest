import { EntityState } from "@ngrx/entity";

export interface AppState {
  users: UserState;
  orders: OrderState;
}

export interface UserState extends EntityState<User> {
  selectedUserId: number | null;
}

export interface OrderState {
  entities: { [id: number]: Order };
}

export interface User {
  id: number;
  name: string;
}

export interface Order {
  id: number;
  userId: number;
  total: number;
}