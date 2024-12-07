import { createSelector } from '@ngrx/store';
import { userAdapter } from './user.reducer';
import { AppState } from '../model/app-state.interface';

export const selectUserState = (state: AppState) => state.users;

const { selectEntities, selectAll } = userAdapter.getSelectors();

export const selectAllUsers = createSelector(selectUserState, selectAll);
export const selectUserEntities = createSelector(selectUserState, selectEntities);
export const selectSelectedUserId = createSelector(selectUserState, state => state.selectedUserId);
export const selectSelectedUser = createSelector(
  selectUserEntities,
  selectSelectedUserId,
  (entities, selectedUserId) => selectedUserId ? entities[selectedUserId] : null
);