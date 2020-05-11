import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ContactComponent } from '../Components/contact/contact.component';
import { AuthGuard } from 'src/app/BusinessFeatures/User/Services/auth-guard.service';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/contact/home'
  },
  {
    path: 'home', 
    data: {allowAll: true},
    canActivate: [AuthGuard], 
    component: ContactComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContactRoutingModule { }
