//import { AddReceiptsComponent } from '../Components/movement-receipts/add-receipts/add-receipts.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ReceivedAssetEditorComponent } from '../Components/Received/editor/received-asset-editor.component';
import { ListReceivedAssetComponent } from '../Components/Received/list/received-asset-list.component';
import { ExpensesAssetEditorComponent } from '../Components/Expenses/editor/expenses-asset-editor.component';
import { ListExpensesAssetComponent } from '../Components/Expenses/list/expenses-asset-list.component';
import { DepreciationEditorComponent } from '../Components/Depreciation/editor/depreciation-editor.component';
//import { ListDepreciationComponent } from '../Components/Depreciation/list/depreciation-list.component';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { ExcludeEditorComponent } from '../Components/Exclude/exclude-editor.component';
import { AssetInventoryListComponent } from '../Components/asset-inventory-list/asset-inventory-list.component';
import { AssetInventoryEditorComponent } from '../Components/asset-inventory-editor/asset-inventory-editor.component';
import { PermissionEnum } from '../../User/Models/permission-enum';
import { AssetLocationEditorComponent } from '../Components/Location/editor/asset-location-editor.component';
import { AssetLocationListComponent } from '../Components/Location/list/asset-location-list.component';

const routes: Routes = [
  { 
    path: '', pathMatch: 'full', redirectTo: '/asset/receive-asset-list/list' 
  },
  { 
    path: 'receive-asset-list/list', 
    data: { permissionCodes: [+PermissionEnum.receivedFixedAssetsList] },
    canActivate: [AuthGuard],
    component: ListReceivedAssetComponent 
  },
  { 
    path: 'receive-asset-list/list/:pageIndex', 
    data: { permissionCodes: [+PermissionEnum.receivedFixedAssetsList] },
    canActivate: [AuthGuard],
    component: ListReceivedAssetComponent 
  },
  { 
    path: 'receive-asset-list/add', 
    data: { permissionCodes: [+PermissionEnum.addReceivedFixedAsset] },
    canActivate: [AuthGuard],
    component: ReceivedAssetEditorComponent },      
  { 
    path: 'receive-asset-list/edit/:editId',
    data: { permissionCodes: [+PermissionEnum.editReceivedFixedAsset] },
    canActivate: [AuthGuard], 
    component: ReceivedAssetEditorComponent },
  { 
    path: 'receive-asset-list/detail/:detailId',
    data: { permissionCodes: [+PermissionEnum.receivedFixedAssetsList] },
    canActivate: [AuthGuard], 
    component: ReceivedAssetEditorComponent 
  },

  { 
    path: 'expenses-asset-list/list',
    data: { permissionCodes: [+PermissionEnum.expensesFixedAssetList] },
    canActivate: [AuthGuard], 
    component: ListExpensesAssetComponent 
  },
  { 
    path: 'expenses-asset-list/list/:pageIndex',
    data: { permissionCodes: [+PermissionEnum.expensesFixedAssetList] },
    canActivate: [AuthGuard], 
    component: ListExpensesAssetComponent 
  },
  { 
    path: 'expenses-asset-list/add',
    data: { permissionCodes: [+PermissionEnum.addExpensesFixedAsset] },
    canActivate: [AuthGuard], 
    component: ExpensesAssetEditorComponent 
  },      
  { 
    path: 'expenses-asset-list/edit/:editId', 
    data: { permissionCodes: [+PermissionEnum.editExpensesFixedAsset] },
    canActivate: [AuthGuard],
    component: ExpensesAssetEditorComponent 
  },
  { 
    path: 'expenses-asset-list/detail/:detailId',
    data: { permissionCodes: [+PermissionEnum.expensesFixedAssetList] },
    canActivate: [AuthGuard], 
    component: ExpensesAssetEditorComponent 
  },

  //{ path: 'depreciation/list', component: ListDepreciationComponent },
  { 
    path: 'depreciation/add',
    data: { permissionCodes: [+PermissionEnum.addFixedAssetsDepreciation] },
    canActivate: [AuthGuard], 
    component: DepreciationEditorComponent 
  },      
  { 
    path: 'depreciation/edit/:editId',
    data: { permissionCodes: [+PermissionEnum.editFixedAssetsDepreciation] },
    canActivate: [AuthGuard], 
    component: DepreciationEditorComponent 
  },
  { 
    path: 'depreciation/detail/:detailId',
    data: { permissionCodes: [+PermissionEnum.fixedAssetsDepreciationList] },
    canActivate: [AuthGuard], 
    component: DepreciationEditorComponent 
  },

  { 
    path: 'exclude',
    data: { permissionCodes: [+PermissionEnum.addExcludedFixedAsset] },
    canActivate: [AuthGuard], 
    component: ExcludeEditorComponent 
  },
  //{ path: 'exclude/add', component: DepreciationEditorComponent },      
  //{ path: 'exclude/edit/:editId', component: DepreciationEditorComponent },
  //{ path: 'exclude/detail/:detailId', component: DepreciationEditorComponent },

  { 
    path: 'asset-inventory-list/list', 
    data: { permissionCodes: [+PermissionEnum.fixedAssetsInventoryList] },
    canActivate: [AuthGuard],
    component: AssetInventoryListComponent },
  { 
    path: 'asset-inventory-editor/add', 
    data: { permissionCodes: [+PermissionEnum.addFixedAssetsInventory] },
    canActivate: [AuthGuard],
    component: AssetInventoryEditorComponent 
  },      
  //{ path: 'asset-inventory-editor/edit/:editId', component: ExpensesAssetEditorComponent },
  { 
    path: 'asset-inventory-editor/detail/:detailId', 
    data: { permissionCodes: [+PermissionEnum.fixedAssetsInventoryList] },
    canActivate: [AuthGuard],
    component: AssetInventoryEditorComponent 
  },
  /**
   * asset-location
  */
  { 
    path: 'asset-location-list/list',
    data: { permissionCodes: [+PermissionEnum.assetLocationList] },
    canActivate: [AuthGuard], 
    component: AssetLocationListComponent 
  },
  { 
    path: 'asset-location-list/list/:pageIndex',
    data: { permissionCodes: [+PermissionEnum.assetLocationList] },
    canActivate: [AuthGuard], 
    component: AssetLocationListComponent 
  },
  // { 
  //   path: 'asset-location-list/add',
  //   data: { permissionCodes: [+PermissionEnum.addExpensesFixedAsset] },
  //   canActivate: [AuthGuard], 
  //   component: AssetLocationEditorComponent 
  // },      
  { 
    path: 'asset-location-list/edit/:editId', 
    data: { permissionCodes: [+PermissionEnum.editAssetLocation] },
    canActivate: [AuthGuard],
    component: AssetLocationEditorComponent 
  },
  { 
    path: 'asset-location-list/detail/:detailId',
    data: { permissionCodes: [+PermissionEnum.assetLocationList] },
    canActivate: [AuthGuard], 
    component: AssetLocationEditorComponent 
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FixedAssetsRoutingModule { }
