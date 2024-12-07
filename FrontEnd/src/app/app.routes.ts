import { Routes } from '@angular/router';
import { UserListComponent } from './view/user-list/user-list.component';

export const routes: Routes = [
  
   {
    path: '',
    component: UserListComponent,
},

// Redirect empty path to '/example'
{path: '', pathMatch : 'full', redirectTo: 'user-list'},

];
