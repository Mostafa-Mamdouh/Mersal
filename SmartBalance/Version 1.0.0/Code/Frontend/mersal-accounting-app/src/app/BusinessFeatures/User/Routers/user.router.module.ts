import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SampleListComponent } from '../Components/sample-list/sample-list.component';
import { SampleEditorComponent } from '../Components/sample-editor/sample-editor.component';
import { EditorComponent } from '../Components/editor/editor.component';
import { ListComponent } from '../Components/list/list.component';
import { MasterComponent } from '../Components/master/master.component';
import { UserPermissionsComponent } from '../Components/user-permissions/user-permissions.component';
import { UserRolesComponent } from '../Components/user-roles/user-roles.component';
import { UserMenuItemComponent } from '../Components/user-menuItem/user-menuItem.component';
import { UserGroupsComponent } from '../Components/user-groups/user-groups.component';
import { UserBranchsComponent } from '../Components/user-branchs/user-branchs.component';

import { LoginComponent } from '../Components/login/login.component';
import { AuthGuard } from '../Services/auth-guard.service';
import { PermissionEnum } from '../Models/permission-enum';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/user/list'
  },
  {
    path: 'list',
    data: { permissionCodes: [+PermissionEnum.userList] },
    canActivate: [AuthGuard],
    component: ListComponent
  },
  {
    path: 'list/:pageIndex',
    data: { permissionCodes: [+PermissionEnum.userList] },
    canActivate: [AuthGuard],
    component: ListComponent
  },
  {
    path: 'login',
    data: { allowAll: true },
    component: LoginComponent
  },
  {
    path: 'master', component: MasterComponent, children: [
      {
        path: '', pathMatch: 'full', redirectTo: '/user/master/add'
      },
      {
        path: 'add', 
        data: { permissionCodes: [+PermissionEnum.addUser] }, 
        canActivate: [AuthGuard], 
        component: EditorComponent
      },

    ]
  },
  {
    path: 'master/edit/:editUserId', component: MasterComponent, children: [
      {
        path: '', pathMatch: 'full', redirectTo: '/user/master/add'
      },
      {
        path: 'edit/:editId',
        data: { permissionCodes: [+PermissionEnum.editUser] },
        canActivate: [AuthGuard],
        component: EditorComponent
      },

      {
        path: 'user-permissions/edit/:editUserId',
        data: { permissionCodes: [+PermissionEnum.changeUserPermisstions] },
        canActivate: [AuthGuard],
        component: UserPermissionsComponent
      },
      {
        path: 'user-roles/edit/:editUserId',
        data: { permissionCodes: [+PermissionEnum.changeUserRoles] },
        canActivate: [AuthGuard],
        component: UserRolesComponent
      },
      {
        path: 'user-groups/edit/:editUserId',
        data: { permissionCodes: [+PermissionEnum.changeUserGroups] },
        canActivate: [AuthGuard],
        component: UserGroupsComponent
      },
      {
        path: 'user-menu-items/edit/:editUserId',
        data: { permissionCodes: [+PermissionEnum.changeUserMenus] },
        canActivate: [AuthGuard],
        component: UserMenuItemComponent
      },
       {
        path: 'user-branchs/edit/:editUserId',
        data: { permissionCodes: [+PermissionEnum.changeUserBranchs] },
        canActivate: [AuthGuard],
        component: UserBranchsComponent
      },
    ]
  },

  {
    path: 'master/detail/:detailUserId', component: MasterComponent, children: [
      {
        path: '', pathMatch: 'full', redirectTo: '/user/master/add'
      },
      {
        path: 'detail/:detailId',
        data: { permissionCodes: [+PermissionEnum.userList] },
        canActivate: [AuthGuard],
        component: EditorComponent
      },
      {
        path: 'user-permissions/detail/:detailUserId',
        data: {
          permissionCodes: [
            +PermissionEnum.userList,
            +PermissionEnum.changeUserPermisstions
          ]
        },
        canActivate: [AuthGuard],
        component: UserPermissionsComponent
      },
      {
        path: 'user-roles/detail/:detailUserId',
        data: {
          permissionCodes: [
            +PermissionEnum.userList,
            +PermissionEnum.changeUserRoles
          ]
        },
        canActivate: [AuthGuard],
        component: UserRolesComponent
      },
      {
        path: 'user-groups/detail/:detailUserId',
        data: {
          permissionCodes: [
            +PermissionEnum.userList,
            +PermissionEnum.changeUserGroups
          ]
        },
        canActivate: [AuthGuard],
        component: UserGroupsComponent
      },
      {
        path: 'user-menu-items/detail/:detailUserId',
        data: {
          permissionCodes: [
            +PermissionEnum.userList,
            +PermissionEnum.changeUserMenus
          ]
        },
        canActivate: [AuthGuard],
        component: UserMenuItemComponent
      },
      {
        path: 'user-branchs/detail/:detailUserId',
        data: {
          permissionCodes: [
            +PermissionEnum.userList,
            //+PermissionEnum.changeUserPermisstions
          ]
        },
        canActivate: [AuthGuard],
        component: UserBranchsComponent
      }
    ]
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
