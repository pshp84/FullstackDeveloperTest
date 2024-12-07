// mock-data.ts
import { User, Order } from '../model/app-state.interface';

export const USERS: User[] = [
  { id: 1, name: 'John Doe' },
  { id: 2, name: 'Jane Smith' },
  { id: 3, name: 'Emily Johnson' },
];

export const ORDERS: Order[] = [
  { id: 101, userId: 1, total: 150.5 },
  { id: 102, userId: 1, total: 200.0 },
  { id: 103, userId: 2, total: 99.99 },
  { id: 104, userId: 3, total: 250.75 },
];