import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { ListComponent } from '../Components/list/list.component';
import { EditorComponent } from '../Components/editor/editor.component';
import { MasterComponent } from '../Components/master/master.component';
import { UserMenuItemComponent } from '../Components/user-menuItem/user-menuItem.component';
import { PermissionEnum } from '../../User/Models/permission-enum';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/menu-items/list'
  },
  {
    path: 'list',
    data: { permissionCodes: [+PermissionEnum.menuItemList] },
    canActivate: [AuthGuard],
    component: ListComponent
  },
  {
    path: 'list/:pageIndex',
    data: { permissionCodes: [+PermissionEnum.menuItemList] },
    canActivate: [AuthGuard],
    component: ListComponent
  },

  {
    path: 'master', component: MasterComponent, children: [
      { path: '', pathMatch: 'full', redirectTo: '/menu-items/master/add' },
      { path: 'add', data: { permissionCodes: [+PermissionEnum.addMenuItem] }, canActivate: [AuthGuard], component: EditorComponent },

    ]
  },

  {
    path: 'master/edit/:editUserId', component: MasterComponent, children: [
      { path: '', pathMatch: 'full', redirectTo: '/menu-items/master/add' },
      { path: 'edit/:editId', data: { permissionCodes: [+PermissionEnum.editMenuItem] }, canActivate: [AuthGuard], component: EditorComponent },

      { path: 'user-menu-item/edit/:editUserId', data: { permissionCodes: [+PermissionEnum.changeUserMenus] }, canActivate: [AuthGuard], component: UserMenuItemComponent },

    ]
  },

  {
    path: 'master/detail/:detailUserId', component: MasterComponent, children: [
      { path: '', pathMatch: 'full', redirectTo: '/menu-items/master/add' },
      { path: 'detail/:detailId', data: { permissionCodes: [+PermissionEnum.menuItemList] }, canActivate: [AuthGuard], component: EditorComponent },
      {
        path: 'user-menu-item/detail/:detailUserId',
        data: {
          permissionCodes: [
            +PermissionEnum.menuItemList,
            +PermissionEnum.changeUserMenus
          ]
        },
        canActivate: [AuthGuard],
        component: UserMenuItemComponent
      },
    ]
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MenuItemsRouterModule { }
