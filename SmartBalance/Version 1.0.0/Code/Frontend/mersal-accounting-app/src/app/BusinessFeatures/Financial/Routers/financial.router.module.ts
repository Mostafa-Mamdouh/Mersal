import { AddReceiptsComponent } from '../Components/movement-receipts/add-receipts/add-receipts.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PaymentMovementComponent } from '../Components/movement-payment/payments-movement/payments-movement.component';
import { ListComponent } from '../Components/movement-payment/list/list.component';
import { ListReceiptsComponent } from '../Components/movement-receipts/list/list.component';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { PermissionEnum } from '../../User/Models/permission-enum';
import { TestamentEditorComponent } from '../Components/testament/editor/editor.component';
import { TestamentListComponent } from '../Components/testament/list/list.component';
import { LiquidationComponent } from '../Components/Liquidation/liquidation.component'


const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/financial/addReceipts'
  },
  {
    path: 'financial-list', 
    data: { permissionCodes: [+PermissionEnum.movementsReceivedList] }, 
    canActivate: [AuthGuard], 
    component: ListReceiptsComponent
  },
  {
    path: 'financial-list/:pageIndex', 
    data: { permissionCodes: [+PermissionEnum.movementsReceivedList] }, 
    canActivate: [AuthGuard], 
    component: ListReceiptsComponent
  },
  {
    path: 'addReceipts', 
    data: { permissionCodes: [+PermissionEnum.addMovementsReceived] }, 
    canActivate: [AuthGuard], 
    component: AddReceiptsComponent
  },
  {
    path: 'edit/:editId', 
    data: { permissionCodes: [+PermissionEnum.editMovementsReceived] }, 
    canActivate: [AuthGuard], 
    component: AddReceiptsComponent
  },
  {
    path: 'detail/:detailId', 
    data: { permissionCodes: [+PermissionEnum.movementsReceivedList] }, 
    canActivate: [AuthGuard], 
    component: AddReceiptsComponent
  },

  {
    path: 'payment-list', 
    data: { permissionCodes: [+PermissionEnum.paymentsMovementsList] }, 
    canActivate: [AuthGuard], 
    component: ListComponent
  },
  {
    path: 'payment-list/:pageIndex', 
    data: { permissionCodes: [+PermissionEnum.paymentsMovementsList] }, 
    canActivate: [AuthGuard], 
    component: ListComponent
  },
  {
    path: 'payments-movement', 
    data: { permissionCodes: [+PermissionEnum.addPaymentsMovements] }, 
    canActivate: [AuthGuard], 
    component: PaymentMovementComponent
  },
  {
    path: 'payments-movement/edit/:editId', 
    data: { permissionCodes: [+PermissionEnum.editPaymentsMovements] }, 
    canActivate: [AuthGuard], 
    component: PaymentMovementComponent
  }, 
  {
    path: 'payments-movement/detail/:detailId', 
    data: { permissionCodes: [+PermissionEnum.editPaymentsMovements] }, 
    canActivate: [AuthGuard], 
    component: PaymentMovementComponent
  }, 
  {
    path: 'payments-movement/liquidation/:liquidationNumber', 
    data: { permissionCodes: [+PermissionEnum.addPaymentsMovements] }, 
    canActivate: [AuthGuard], 
    component: PaymentMovementComponent
  },
  { 
    path: 'testament/add', 
    data: { permissionCodes: [+PermissionEnum.addTestament] }, 
    canActivate: [AuthGuard], 
    component: TestamentEditorComponent
  },
  { 
    path: 'testament/edit/:editId', 
    data: { permissionCodes: [+PermissionEnum.editTestament] }, 
    canActivate: [AuthGuard], 
    component: TestamentEditorComponent
  },{ 
    path: 'testament/detail/:detailId', 
    data: { permissionCodes: [+PermissionEnum.testamentList] }, 
    canActivate: [AuthGuard], 
    component: TestamentEditorComponent
  },{ 
    path: 'testament/list', 
    data: { permissionCodes: [+PermissionEnum.testamentList] }, 
    canActivate: [AuthGuard], 
    component: TestamentListComponent
  },{ 
    path: 'testament/list/:pageIndex', 
    data: { permissionCodes: [+PermissionEnum.testamentList] }, 
    canActivate: [AuthGuard], 
    component: TestamentListComponent
  },{ 
    path: 'testament/liquidation', 
    data: { permissionCodes: [+PermissionEnum.testamentList] }, 
    canActivate: [AuthGuard], 
    component: LiquidationComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FinancialRoutingModule { }
