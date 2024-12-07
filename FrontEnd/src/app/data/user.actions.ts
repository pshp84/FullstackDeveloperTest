import { createAction, props } from '@ngrx/store';
import { User } from '../model/app-state.interface';

export const addUser = createAction('[User] Add User', props<{ user: User }>());
export const updateUser = createAction('[User] Update User', props<{ user: { id: number, changes: Partial<User> } }>());
export const deleteUser = createAction('[User] Delete User', props<{ id: number }>());
export const loadUsers = createAction('[User] Load Users', props<{ users: User[] }>());
export const selectUser = createAction('[User] Select User', props<{ userId: number }>());