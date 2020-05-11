import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { ListComponent } from '../Components/list/list.component';
import { PermissionEnum } from '../../User/Models/permission-enum';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/checks-under-collection/list'
  },
  {
    path: 'list', 
    data: { permissionCodes: [+PermissionEnum.controlChecksUnderCollection] },
    canActivate: [AuthGuard], 
    component: ListComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ChecksUnderCollectionRouterModule { }
