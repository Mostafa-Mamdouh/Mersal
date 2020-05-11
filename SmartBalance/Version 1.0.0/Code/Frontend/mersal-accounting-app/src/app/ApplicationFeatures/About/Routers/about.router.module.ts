import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AboutComponent } from '../Components/about/about.component';
import { AuthGuard } from 'src/app/BusinessFeatures/User/Services/auth-guard.service';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/about/home'
  },
  {
    path: 'home',
    data: { allowAll: true },
    canActivate: [AuthGuard],
    component: AboutComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AboutRoutingModule { }
