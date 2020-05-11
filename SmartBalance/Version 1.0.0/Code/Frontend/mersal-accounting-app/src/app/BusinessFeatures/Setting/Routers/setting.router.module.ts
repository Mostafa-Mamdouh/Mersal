import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { ControlPanelComponent } from '../Components/control-panel/control-panel.component';
import { FinancialEditorComponent } from '../Components/financial-editor/financial-editor.component';
import { PostingEditorComponent } from '../Components/posting-editor/posting-editor.component';
import { VatEditorComponent } from '../Components/vat-editor/vat-editor.component';
import { VendorEditorComponent } from '../Components/vendor-editor/vendor-editor.component';
import { SystemCurrencyEditorComponent } from '../Components/system-currency-editor/system-currency-editor.component';
import { GeneralSettingEditorComponent } from '../Components/general-setting-editor/general-setting-editor.component';
import { AccountChartSettingeEditorComponent } from '../Components/account-chart-setting-editor/account-chart-setting-editor.component';
import { FixedAssetAccountSettingEditorComponent } from '../Components/fixed-asset-account/fixed-asset-account.component';
import { PermissionEnum } from '../../User/Models/permission-enum';
import { TestamentAndAdvancesEditorComponent } from '../Components/testament-and-advances-editor/testament-and-advances-editor.component';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/setting/control-panel'
  },
  {
    path: 'control-panel', 
    data: {allowAll: true},
    canActivate: [AuthGuard], 
    component: ControlPanelComponent
  },
  {
    path: 'financial-editor', 
    data: { permissionCodes: [+PermissionEnum.financialMovementSettings] },
    canActivate: [AuthGuard], 
    component: FinancialEditorComponent
  },
  {
    path: 'posting-editor', 
    data: { permissionCodes: [+PermissionEnum.postingJournalSettings] },
    canActivate: [AuthGuard], 
    component: PostingEditorComponent
  },
  {
    path: 'vat-editor', 
    data: { permissionCodes: [+PermissionEnum.vatSettings] },
    canActivate: [AuthGuard], 
    component: VatEditorComponent
  },
  {
    path: 'vendor-editor', 
    data: { permissionCodes: [+PermissionEnum.vendorSystemSettings] },
    canActivate: [AuthGuard], 
    component: VendorEditorComponent
  },
  {
    path: 'system-currency-editor', 
    data: { permissionCodes: [+PermissionEnum.systemCurrencySettings] },
    canActivate: [AuthGuard], 
    component: SystemCurrencyEditorComponent
  },
  {
    path: 'general-setting-editor', 
    data: { permissionCodes: [+PermissionEnum.generalSettings] },
    canActivate: [AuthGuard], 
    component: GeneralSettingEditorComponent
  },

  {
    path: 'account-chart-setting-editor', 
    data: { permissionCodes: [+PermissionEnum.accountChartSetting] },
    canActivate: [AuthGuard],     
    component: AccountChartSettingeEditorComponent
  },
  {
    path: 'fixed-asset-account-chart-setting-editor',
    data: { permissionCodes: [+PermissionEnum.accountChartSetting] },
    canActivate: [AuthGuard],
    component: FixedAssetAccountSettingEditorComponent
  },
  {
    path: 'testament-and-advances-setting-editor',
    data: { permissionCodes: [+PermissionEnum.testamentAndAdvancesSettings] },
    canActivate: [AuthGuard],
    component: TestamentAndAdvancesEditorComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingRouterModule { }
