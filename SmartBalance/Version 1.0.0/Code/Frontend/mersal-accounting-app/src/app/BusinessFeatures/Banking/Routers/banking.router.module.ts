import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { ListComponent } from '../Components/list/list.component';
import { EditorComponent } from '../Components/editor/editor.component';
import { PermissionEnum } from '../../User/Models/permission-enum';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/banking/bank-movement/list'
  },
  {
    path: 'bank-movement/list', 
    data: { permissionCodes: [+PermissionEnum.bankMovementsList] },
    canActivate: [AuthGuard], 
    component: ListComponent
  },
  {
    path: 'bank-movement/list/:pageIndex', 
    data: { permissionCodes: [+PermissionEnum.bankMovementsList] },
    canActivate: [AuthGuard], 
    component: ListComponent
  },
  {
    path: 'bank-movement/add', 
    data: { permissionCodes: [+PermissionEnum.addBankMovement] },
    canActivate: [AuthGuard],
    component: EditorComponent
  },
  {
    path: 'bank-movement/edit/:editId', 
    data: { permissionCodes: [+PermissionEnum.editBankMovement] },
    canActivate: [AuthGuard], 
    component: EditorComponent
  },
  {
    path: 'bank-movement/detail/:detailId', 
    data: { permissionCodes: [+PermissionEnum.bankMovementsList] },
    canActivate: [AuthGuard], 
    component: EditorComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BankingRouterModule { }
