import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { createReducer, on } from '@ngrx/store';
import { addUser, updateUser, deleteUser, loadUsers, selectUser } from './user.actions';
import { User } from '../model/app-state.interface';


export const userAdapter = createEntityAdapter<User>();

export interface UserState extends EntityState<User> {
  selectedUserId: number | null;
}

const initialState: UserState = userAdapter.getInitialState({
  selectedUserId: null,
});

export const userReducer = createReducer(
  initialState,
  on(addUser, (state, { user }) => userAdapter.upsertOne(user, state)),
  on(updateUser, (state, { user }) => userAdapter.updateOne(user, state)),
  on(deleteUser, (state, { id }) => userAdapter.removeOne(id, state)),
  on(loadUsers, (state, { users }) => userAdapter.setAll(users, state)),
  on(selectUser, (state, { userId }) => ({ ...state, selectedUserId: userId }))
);