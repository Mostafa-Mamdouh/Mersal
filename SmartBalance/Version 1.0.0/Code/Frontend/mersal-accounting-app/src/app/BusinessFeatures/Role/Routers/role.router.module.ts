import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { ListComponent } from '../Components/list/list.component';
import { EditorComponent } from '../Components/editor/editor.component';
import { MasterComponent } from '../Components/master/master.component';
import { RolePermissionsComponent } from '../Components/role-permissions/role-permissions.component';
import { PermissionEnum } from '../../User/Models/permission-enum';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/role/list'
  },
  {
    path: 'list',
    data: { permissionCodes: [+PermissionEnum.roleList] },
    canActivate: [AuthGuard],
    component: ListComponent
  },
  {
    path: 'list/:pageIndex',
    data: { permissionCodes: [+PermissionEnum.roleList] },
    canActivate: [AuthGuard],
    component: ListComponent
  },
  {
    path: 'master', component: MasterComponent, children: [
      {
        path: '', pathMatch: 'full', redirectTo: '/role/master/add'
      },
      {
        path: 'add', 
        data: { permissionCodes: [+PermissionEnum.addRole] }, 
        canActivate: [AuthGuard], 
        component: EditorComponent
      },

    ]
  },
  {
    path: 'master/edit/:editRoleId', component: MasterComponent, children: [
      {
        path: '', pathMatch: 'full', redirectTo: '/role/master/add'
      },
      {
        path: 'edit/:editId',
        data: { permissionCodes: [+PermissionEnum.editRole] },
        canActivate: [AuthGuard],
        component: EditorComponent
      },

      {
        path: 'role-permissions/edit/:editRoleId',
        data: { permissionCodes: [+PermissionEnum.changeRolePermisstions] },
        canActivate: [AuthGuard],
        component: RolePermissionsComponent
      },

    ]
  },

  {
    path: 'master/detail/:detailRoleId', component: MasterComponent, children: [
      {
        path: '', pathMatch: 'full', redirectTo: '/role/master/add'
      },
      {
        path: 'detail/:detailId',
        data: { permissionCodes: [+PermissionEnum.roleList] },
        canActivate: [AuthGuard],
        component: EditorComponent
      },
      {
        path: 'role-permissions/detail/:detailRoleId',
        data: {
          permissionCodes: [
            +PermissionEnum.roleList,
            +PermissionEnum.changeRolePermisstions
          ]
        },
        canActivate: [AuthGuard], component: RolePermissionsComponent
      },
    ]
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoleRouterModule { }
