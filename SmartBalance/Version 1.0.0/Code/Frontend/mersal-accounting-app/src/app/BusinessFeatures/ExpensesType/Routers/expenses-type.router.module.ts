import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { ListComponent } from '../Components/list/list.component';
import { EditorComponent } from '../Components/editor/editor.component';
import { PermissionEnum } from '../../User/Models/permission-enum';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/expenses-type/list'
  },
  {
    path: 'list', 
    data: { permissionCodes: [+PermissionEnum.expenseTypeList] },
    canActivate: [AuthGuard], 
    component: ListComponent
  },
  {
    path: 'add', 
    data: { permissionCodes: [+PermissionEnum.addExpenseType] },
    canActivate: [AuthGuard], 
    component: EditorComponent
  },
  {
    path: 'edit/:editId', 
    data: { permissionCodes: [+PermissionEnum.editExpenseType] },
    canActivate: [AuthGuard], 
    component: EditorComponent
  },
  {
    path: 'detail/:detailId', 
    data: { permissionCodes: [+PermissionEnum.expenseTypeList] },
    canActivate: [AuthGuard], 
    component: EditorComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExpensesTypeRouterModule { }
