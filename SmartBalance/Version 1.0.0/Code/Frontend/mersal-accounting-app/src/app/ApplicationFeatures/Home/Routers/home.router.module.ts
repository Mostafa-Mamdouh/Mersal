import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from '../Components/home/home.component';
import { DashboardComponent } from '../Components/dashboard/dashboard.component';
import { AuthGuard } from 'src/app/BusinessFeatures/User/Services/auth-guard.service';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/home/home'
  },
  {
    path: 'home',
    data: { allowAll: true },
    canActivate: [AuthGuard], 
    component: HomeComponent
  },
  {
    path: 'dashboard',
    data: { allowAll: true },
    canActivate: [AuthGuard], 
    component: DashboardComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
