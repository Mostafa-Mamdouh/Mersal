import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { ListComponent } from '../Components/list/list.component';
import { EditorComponent } from '../Components/editor/editor.component';
import { MasterComponent } from '../Components/master/master.component';
import { SafeAccountChartsComponent } from '../Components/safe-accountCharts/safe-accountCharts.component'
import { PermissionEnum } from '../../User/Models/permission-enum';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/safe/list'
  },
  {
    path: 'list', 
    data: { permissionCodes: [+PermissionEnum.safeList] },
    canActivate: [AuthGuard], 
    component: ListComponent
  },
  {
    path: 'list/:pageIndex', 
    data: { permissionCodes: [+PermissionEnum.safeList] },
    canActivate: [AuthGuard], 
    component: ListComponent
  },
  {
    path: 'master',
    component: MasterComponent,
    children: [
      {
        path: '', pathMatch: 'full', redirectTo: '/user/master/add'
      },
      {
        path: 'add', 
        data: { permissionCodes: [+PermissionEnum.addSafe] },
        canActivate: [AuthGuard], 
        component: EditorComponent,
      }
    ]
  },
  {
    path: 'master/edit/:editId',
    component: MasterComponent,
    children: [
      {
        path: '', pathMatch: 'full', redirectTo: '/user/master/add'
      },
      {
        path: 'edit/:editId', 
    data: { permissionCodes: [+PermissionEnum.editSafe] },
    canActivate: [AuthGuard], 
    component: EditorComponent
      }
      ,{
        path: 'safe-accountCharts/edit/:editId',
        data: {
          permissionCodes: [
            +PermissionEnum.editSafeAccountCharts,
            +PermissionEnum.safeAccountChartsList
          ]
        },
        canActivate: [AuthGuard],
        component: SafeAccountChartsComponent
      }
    ]
  },
  {
  path: 'master/detail/:detailId',
  component: MasterComponent,
  children: [
    {
      path: '', pathMatch: 'full', redirectTo: '/user/master/add'
    },
    {
      path: 'detail/:detailId', 
    data: { permissionCodes: [+PermissionEnum.safeList] },
    canActivate: [AuthGuard], 
    component: EditorComponent
    },{
      path: 'safe-accountCharts/detail/:detailId',
      data: {
        permissionCodes: [
          +PermissionEnum.safeList,
          +PermissionEnum.safeAccountChartsList
        ]
      },
      canActivate: [AuthGuard],
      component: SafeAccountChartsComponent
    }
  ]
  }
]
  

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SafeRouterModule { }
