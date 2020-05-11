import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { accountChartTreeComponent } from '../Components/account-chart-tree/account-chart-tree.component';
import { PermissionEnum } from '../../User/Models/permission-enum';

import { WorkspaceLocalstorageComponent } from '../Components/workspace-split/workspace-split.component';


const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/account-chart/account-chart-tree'
  },
  {
    path: 'account-chart-tree', 
    data: { 
      permissionCodes: [
        +PermissionEnum.viewAccountChart, 
        +PermissionEnum.addAccountChart
      ] 
    },
    canActivate: [AuthGuard], 
    component: accountChartTreeComponent
  },
  // {
  //   path: 'split',     
  //   canActivate: [AuthGuard], 
  //   component: WorkspaceLocalstorageComponent
  // },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountsTreeRoutingModule { }
