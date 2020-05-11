import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddProductComponent } from '../Components/add-product/add-product.component';
import { AuthGuard } from '../../User/Services/auth-guard.service';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/product/add-product' },
  { path: 'add-product', canActivate: [AuthGuard], component: AddProductComponent },

];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductRoutingModule { }
