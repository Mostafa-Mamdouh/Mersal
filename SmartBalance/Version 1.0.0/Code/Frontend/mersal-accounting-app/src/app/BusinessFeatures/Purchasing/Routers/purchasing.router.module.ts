import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PurchaseRebateListComponent } from '../Components/purchase-rebate-list/purchase-rebate-list.component';
import { PurchaseRebateEditorComponent } from '../Components/purchase-rebate-editor/purchase-rebate-editor.component';
import { PurchaseInvoiceListComponent } from '../Components/purchase-invoice-list/purchase-invoice-list.component';
import { PurchaseInvoiceEditorComponent } from '../Components/purchase-invoice-editor/purchase-invoice-editor.component';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { PermissionEnum } from '../../User/Models/permission-enum';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/purchasing/purchase-invoice/list'
  },
  /*
   * purchase-invoice
   */
  {
    path: 'purchase-invoice/list/:pageIndex', 
    data: { permissionCodes: [+PermissionEnum.purchaseInvoicesList] },
    canActivate: [AuthGuard], 
    component: PurchaseInvoiceListComponent
  },
  {
    path: 'purchase-invoice/list', 
    data: { permissionCodes: [+PermissionEnum.purchaseInvoicesList] },
    canActivate: [AuthGuard], 
    component: PurchaseInvoiceListComponent
  },
  {
    path: 'purchase-invoice/add', 
    data: { permissionCodes: [+PermissionEnum.addPurchaseInvoice] },
    canActivate: [AuthGuard], 
    component: PurchaseInvoiceEditorComponent
  },
  {
    path: 'purchase-invoice/edit/:editId', 
    data: { permissionCodes: [+PermissionEnum.editPurchaseInvoice] },
    canActivate: [AuthGuard], 
    component: PurchaseInvoiceEditorComponent
  },
  {
    path: 'purchase-invoice/detail/:detailId', 
    data: { permissionCodes: [+PermissionEnum.purchaseInvoicesList] },
    canActivate: [AuthGuard], 
    component: PurchaseInvoiceEditorComponent
  },
  /*
   * purchase-rebate
   */
  {
    path: 'purchase-rebate/list', 
    data: { permissionCodes: [+PermissionEnum.purchaseRebateList] },    
    canActivate: [AuthGuard], 
    component: PurchaseRebateListComponent
  },
  {
    path: 'purchase-rebate/list/:pageIndex', 
    data: { permissionCodes: [+PermissionEnum.purchaseRebateList] },
    canActivate: [AuthGuard], 
    component: PurchaseRebateListComponent
  },
  {
    path: 'purchase-rebate/add', 
    data: { permissionCodes: [+PermissionEnum.addPurchaseRebate] },
    canActivate: [AuthGuard], 
    component: PurchaseRebateEditorComponent
  },
  {
    path: 'purchase-rebate/edit/:editId', 
    data: { permissionCodes: [+PermissionEnum.editPurchaseRebate] },
    canActivate: [AuthGuard], 
    component: PurchaseRebateEditorComponent
  },
  {
    path: 'purchase-rebate/detail/:detailId', 
    data: { permissionCodes: [+PermissionEnum.purchaseRebateList] },
    canActivate: [AuthGuard], 
    component: PurchaseRebateEditorComponent
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PurchasingRouterModule { }
