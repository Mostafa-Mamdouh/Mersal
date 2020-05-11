import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { ListComponent } from '../Components/list/list.component';
import { EditorComponent } from '../Components/editor/editor.component';
import { MasterComponent } from '../Components/master/master.component';
import { GroupPermissionsComponent } from '../Components/group-permissions/group-permissions.component';
import { PermissionEnum } from '../../User/Models/permission-enum';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/group/list'
  },
  {
    path: 'list', data: { permissionCodes: [+PermissionEnum.groupList] }, canActivate: [AuthGuard], component: ListComponent
  },
  {
    path: 'list/:pageIndex', data: { permissionCodes: [+PermissionEnum.groupList] }, canActivate: [AuthGuard], component: ListComponent
  },
  {
    path: 'master', component: MasterComponent, children: [
      { path: '', pathMatch: 'full', redirectTo: '/group/master/add' },
      { path: 'add', data: { permissionCodes: [+PermissionEnum.addGroup] }, canActivate: [AuthGuard], component: EditorComponent },

    ]
  },
  {
    path: 'master/edit/:editGroupId', component: MasterComponent, children: [
      { path: '', pathMatch: 'full', redirectTo: '/group/master/add' },
      { path: 'edit/:editId', data: { permissionCodes: [+PermissionEnum.editGroup] }, canActivate: [AuthGuard], component: EditorComponent },

      { path: 'group-permissions/edit/:editGroupId', data: { permissionCodes: [+PermissionEnum.changeGroupPermisstions] }, canActivate: [AuthGuard], component: GroupPermissionsComponent },

    ]
  },

  {
    path: 'master/detail/:detailGroupId', component: MasterComponent, children: [
      { path: '', pathMatch: 'full', redirectTo: '/group/master/add' },
      {
        path: 'detail/:detailId',
        data: { permissionCodes: [+PermissionEnum.groupList] },
        canActivate: [AuthGuard],
        component: EditorComponent
      },
      {
        path: 'group-permissions/detail/:detailGroupId',
        data: {
          permissionCodes: [
            +PermissionEnum.groupList, 
            +PermissionEnum.changeGroupPermisstions
          ]
        },
        canActivate: [AuthGuard],
        component: GroupPermissionsComponent
      },
    ]
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GroupRouterModule { }
