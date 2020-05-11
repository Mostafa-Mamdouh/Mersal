import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { OpeningBalanceListComponent } from '../Components/opening-balance/opening-balance-list/opening-balance-list.component';
import { OpeningBalanceEditorComponent } from '../Components/opening-balance/opening-balance-editor/opening-balance-editor.component';
import { InventoryTransfersListComponent } from '../Components/inventory-transfers/inventory-transfers-list/inventory-transfers-list.component';
import { InventoryTransfersEditorComponent } from '../Components/inventory-transfers/inventory-transfers-editor/inventory-transfers-editor.component';
import { InventoryMovementListComponent } from '../Components/inventory-movement/inventory-movement-list/inventory-movement-list.component';
import { InventoryMovementEditorComponent } from '../Components/inventory-movement/inventory-movement-editor/inventory-movement-editor.component';
import { InventoryEditorComponent } from '../Components/inventory/editor/editor.component';
import { InventoryListComponent } from '../Components/inventory/list/list.component';
import { PermissionEnum } from '../../User/Models/permission-enum';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/store/opening-balance/list'
  },

  {
    path: 'opening-balance/list', 
    data: { permissionCodes: [+PermissionEnum.openingBalanceList] },
    canActivate: [AuthGuard], 
    component: OpeningBalanceListComponent
  },
  {
    path: 'opening-balance/list/:pageIndex', 
    data: { permissionCodes: [+PermissionEnum.openingBalanceList] },
    canActivate: [AuthGuard], 
    component: OpeningBalanceListComponent
  },
  {
    path: 'opening-balance/add', 
    data: { permissionCodes: [+PermissionEnum.addOpeningBalance] },
    canActivate: [AuthGuard], 
    component: OpeningBalanceEditorComponent
  },
  {
    path: 'opening-balance/edit/:editId', 
    data: { permissionCodes: [+PermissionEnum.editOpeningBalance] },
    canActivate: [AuthGuard], 
    component: OpeningBalanceEditorComponent
  },
  {
    path: 'opening-balance/detail/:detailId', 
    data: { permissionCodes: [+PermissionEnum.openingBalanceList] },
    canActivate: [AuthGuard], 
    component: OpeningBalanceEditorComponent
  },

  {
    path: 'inventory/list', 
    data: { permissionCodes: [+PermissionEnum.inventoryMovementList] },
    canActivate: [AuthGuard], 
    component: InventoryMovementListComponent
  },
  {
    path: 'inventory/list/:pageIndex', 
    data: { permissionCodes: [+PermissionEnum.inventoryMovementList] },
    canActivate: [AuthGuard], 
    component: InventoryMovementListComponent
  },
  {
    path: 'inventory/add', 
    data: { permissionCodes: [+PermissionEnum.addInventoryMovement] },
    canActivate: [AuthGuard], 
    component: InventoryMovementEditorComponent
  },
  {
    path: 'inventory/edit/:editId', 
    data: { permissionCodes: [+PermissionEnum.editInventoryMovement] },
    canActivate: [AuthGuard], 
    component: InventoryMovementEditorComponent
  },
  {
    path: 'inventory/detail/:detailId', 
    data: { permissionCodes: [+PermissionEnum.inventoryMovementList] },
    canActivate: [AuthGuard], 
    component: InventoryMovementEditorComponent
  },

  {
    path: 'inventory-transfers/list', 
    data: { permissionCodes: [+PermissionEnum.inventoryTransfersList] },
    canActivate: [AuthGuard], 
    component: InventoryTransfersListComponent
  },
  {
    path: 'inventory-transfers/list/:pageIndex', 
    data: { permissionCodes: [+PermissionEnum.inventoryTransfersList] },
    canActivate: [AuthGuard], 
    component: InventoryTransfersListComponent
  },
  {
    path: 'inventory-transfers/add', 
    data: { permissionCodes: [+PermissionEnum.addInventoryTransfers] },
    canActivate: [AuthGuard], 
    component: InventoryTransfersEditorComponent
  },
  {
    path: 'inventory-transfers/edit/:editId', 
    data: { permissionCodes: [+PermissionEnum.editInventoryTransfers] },
    canActivate: [AuthGuard], 
    component: InventoryTransfersEditorComponent
  },
  {
    path: 'inventory-transfers/detail/:detailId', 
    data: { permissionCodes: [+PermissionEnum.inventoryTransfersList] },
    canActivate: [AuthGuard], 
    component: InventoryTransfersEditorComponent
  },

  {
    path: 'inventory-editor/list', 
    data: { permissionCodes: [+PermissionEnum.storesList] },
    canActivate: [AuthGuard], 
    component: InventoryListComponent
  },
  {
    path: 'inventory-editor/list/:pageIndex', 
    data: { permissionCodes: [+PermissionEnum.storesList] },
    canActivate: [AuthGuard], 
    component: InventoryListComponent
  },
  {
    path: 'inventory-editor/add', 
    data: { permissionCodes: [+PermissionEnum.addStore] },
    canActivate: [AuthGuard], 
    component: InventoryEditorComponent
  },
  {
    path: 'inventory-editor/edit/:editId', 
    data: { permissionCodes: [+PermissionEnum.editStore] },
    canActivate: [AuthGuard], 
    component: InventoryEditorComponent
  },
  {
    path: 'inventory-editor/detail/:detailId', 
    data: { permissionCodes: [+PermissionEnum.storesList] },
    canActivate: [AuthGuard], 
    component: InventoryEditorComponent
  },
]
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StoreRoutingModule { }
