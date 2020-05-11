import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {LoaderComponent} from '../Components/loader/loader.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/loader/loader-page' },
  { path: 'loader-page', component: LoaderComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoaderRoutingModule { }
