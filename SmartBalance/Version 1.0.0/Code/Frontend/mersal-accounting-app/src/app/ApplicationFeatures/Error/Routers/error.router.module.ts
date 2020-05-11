import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ErrorComponent } from '../Components/error/error.component';
import { PageNotFoundComponent } from '../Components/page-not-found/page-not-found.component';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/error/not-found'
  },
  {
    path: 'home/:id',
    data: { allowAll: true },
    component: ErrorComponent
  },
  {
    path: 'not-found',
    data: { allowAll: true },
    component: PageNotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ErrorRoutingModule { }
