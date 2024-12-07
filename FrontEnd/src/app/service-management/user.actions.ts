import { createAction, props } from '@ngrx/store';
import { User } from '../model/app-state.interface';


export const loadUsersSuccess = createAction(
  '[Users API] Load Users Success',
  props<{ users: User[] }>()
);

export const addUser = createAction(
  '[Users Page] Add User',
  props<{ user: User }>()
);

export const updateUser = createAction(
  '[Users Page] Update User',
  props<{ user: User }>()
);

export const deleteUser = createAction(
  '[Users Page] Delete User',
  props<{ id: number }>()
);

export const selectUser = createAction(
  '[Users Page] Select User',
  props<{ userId: number }>()
);