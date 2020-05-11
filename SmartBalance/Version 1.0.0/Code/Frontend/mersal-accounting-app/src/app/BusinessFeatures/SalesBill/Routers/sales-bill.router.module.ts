import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BillSummaryComponent } from '../Components/summary/bill-summary.component';
import { SalesBillsComponent } from '../Components/sales-bill/sales-bill.component';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { PermissionEnum } from '../../User/Models/permission-enum';


const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/sales/sales-bill' },
  { path: 'sales-bill', canActivate: [AuthGuard], component: SalesBillsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SalesBillRoutingModule { }
