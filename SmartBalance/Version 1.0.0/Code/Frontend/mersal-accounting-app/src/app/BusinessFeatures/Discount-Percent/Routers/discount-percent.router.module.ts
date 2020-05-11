import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { ListComponent } from '../Components/list/list.component';
import { EditorComponent } from '../Components/editor/editor.component';
import { PermissionEnum } from '../../User/Models/permission-enum';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/discount-percent/list'
  },
  {
    path: 'list', 
    data: { permissionCodes: [+PermissionEnum.discountPercentageList] },
    canActivate: [AuthGuard], 
    component: ListComponent
  },
  {
    path: 'add', 
    data: { permissionCodes: [+PermissionEnum.addDiscountPercentage] },
    canActivate: [AuthGuard], 
    component: EditorComponent
  },
  {
    path: 'edit/:editId', 
    data: { permissionCodes: [+PermissionEnum.editDiscountPercentage] },
    canActivate: [AuthGuard], 
    component: EditorComponent
  },
  {
    path: 'detail/:detailId', 
    data: { permissionCodes: [+PermissionEnum.discountPercentageList] },
    canActivate: [AuthGuard], 
    component: EditorComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DiscountPercentRouterModule { }
