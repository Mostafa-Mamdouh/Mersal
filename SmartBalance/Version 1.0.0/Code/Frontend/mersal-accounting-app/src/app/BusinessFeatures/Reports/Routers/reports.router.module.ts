import { ControlPanelComponent } from '../Components/control-panel/control-panel.component';

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { AccountsReportComponent } from '../Components/accounts-report/accounts-report.component';
import { SafeAccountReportComponent } from '../Components/safe-account-report/safe-account-report.component';
import { VendorAccountReportComponent } from '../Components/vendor-account-report/vendor-account-report.component';
import { BankAccountReportComponent } from '../Components/bank-account-report/bank-account-report.component';
import { CostCenterAccountReportComponent } from '../Components/cost-center-account-report/cost-center-account-report.component';
import { AccountBalanceComponent } from '../Components/account-balance/account-balance.component';
import { SafeBalanceReportComponent } from '../Components/safe-balance-report/safe-balance-report.component';
import { VendorBalanceReportComponent } from '../Components/vendor-balance-report/vendor-balance-report.component';
import { BankBalanceReportComponent } from '../Components/bank-balance-report/bank-balance-report.component';
import { CostCenterBalanceReportComponent } from '../Components/cost-center-balance-report/cost-center-balance-report.component';
import { BalanceSheetReportComponent } from '../Components/balance-sheet-report/balance-sheet-report.component';
import { FixedAssetDepreciationReportComponent } from '../Components/fixed-asset-depreciation-report/fixed-asset-depreciation-report.component';
import { FixedAssetExcludedReportComponent } from '../Components/fixed-asset-excluded-report/fixed-asset-excluded-report.component';
import { FixedAssetInventoryReportComponent } from '../Components/fixed-asset-inventory-report/fixed-asset-inventory-report.component';
import { FixedAssetLocationReportComponent } from '../Components/fixed-asset-location-report/fixed-asset-location-report.component';
import { FixedAssetLostReportComponent } from '../Components/fixed-asset-lost-report/fixed-asset-lost-report.component';
import { FixedAssetMoveReportComponent } from '../Components/fixed-asset-move-report/fixed-asset-move-report.component';
import { InventoryBalanceReportComponent } from '../Components/inventory-balance-report/inventory-balance-report.component';
import { DonatorCasesHistoryReportComponent } from '../Components/donator-cases-history-report/donator-cases-history-report.component';
import { DonationCasesBalanceReportComponent } from '../Components/donation-cases-balance-report/donation-cases-balance-report.component';
import { PermissionEnum } from '../../User/Models/permission-enum';

const routes: Routes = [
  //canActivate: [AuthGuard],
  { path: '', pathMatch: 'full', redirectTo: '/reports/control-panel' },
  {
    path: 'control-panel',
    data: { allowAll: true },
    canActivate: [AuthGuard],
    component: ControlPanelComponent
  },
  // account-Report
  {
    path: 'account-Report',
    data: { permissionCodes: [+PermissionEnum.accountReport] },
    canActivate: [AuthGuard],
    component: AccountsReportComponent
  },
  {
    path: 'safe-account-report',
    data: { permissionCodes: [+PermissionEnum.safeAccountReport] },
    canActivate: [AuthGuard],
    component: SafeAccountReportComponent
  },
  {
    path: 'vendor-account-report',
    data: { permissionCodes: [+PermissionEnum.vendorAccountReport] },
    canActivate: [AuthGuard],
    component: VendorAccountReportComponent
  },
  {
    path: 'bank-account-report',
    data: { permissionCodes: [+PermissionEnum.bankAccountReport] },
    canActivate: [AuthGuard],
    component: BankAccountReportComponent
  },
  {
    path: 'cost-center-account-report',
    data: { permissionCodes: [+PermissionEnum.costCenterAccountReport] },
    canActivate: [AuthGuard],
    component: CostCenterAccountReportComponent
  },
  {
    path: 'balance-sheet-report',
    data: { permissionCodes: [+PermissionEnum.balanceReviewReport] },
    canActivate: [AuthGuard],
    component: BalanceSheetReportComponent
  },
  // account-balance
  {
    path: 'account-balance',
    data: { permissionCodes: [+PermissionEnum.accountBalanceReport] },
    canActivate: [AuthGuard],
    component: AccountBalanceComponent
  },
  {
    path: 'safe-balance-report',
    data: { permissionCodes: [+PermissionEnum.safeBalanceReport] },
    canActivate: [AuthGuard],
    component: SafeBalanceReportComponent
  },
  {
    path: 'vendor-balance-report',
    data: { permissionCodes: [+PermissionEnum.vendorBalanceReport] },
    canActivate: [AuthGuard],
    component: VendorBalanceReportComponent
  },
  {
    path: 'bank-balance-report',
    data: { permissionCodes: [+PermissionEnum.bankBalanceReport] },
    canActivate: [AuthGuard],
    component: BankBalanceReportComponent
  },
  {
    path: 'cost-center-balance-report',
    data: { permissionCodes: [+PermissionEnum.costCenterBalanceReport] },
    canActivate: [AuthGuard],
    component: CostCenterBalanceReportComponent
  },
  // fixed-asset
  {
    path: 'fixed-asset-depreciation-report',
    data: { permissionCodes: [+PermissionEnum.fixedAssetsDepreciationReport] },
    canActivate: [AuthGuard],
    component: FixedAssetDepreciationReportComponent
  },
  {
    path: 'fixed-asset-excluded-report',
    data: { permissionCodes: [+PermissionEnum.excludedFixedAssetsReport] },
    canActivate: [AuthGuard],
    component: FixedAssetExcludedReportComponent
  },
  {
    path: 'fixed-asset-inventory-report',
    data: { permissionCodes: [+PermissionEnum.fixedAssetsInventoryReport] },
    canActivate: [AuthGuard],
    component: FixedAssetInventoryReportComponent
  },
  {
    path: 'fixed-asset-location-report',
    data: { permissionCodes: [+PermissionEnum.fixedAssetsLocationReport] },
    canActivate: [AuthGuard],
    component: FixedAssetLocationReportComponent
  },
  {
    path: 'fixed-asset-lost-report',
    data: { permissionCodes: [+PermissionEnum.fixedAssetsLostReport] },
    canActivate: [AuthGuard],
    component: FixedAssetLostReportComponent
  },
  {
    path: 'fixed-asset-move-report',
    data: { permissionCodes: [+PermissionEnum.fixedAssetsMovementsReport] },
    canActivate: [AuthGuard],
    component: FixedAssetMoveReportComponent
  },
  // inventory
  {
    path: 'inventory-balance-report',
    data: { permissionCodes: [+PermissionEnum.stockBalancesReport] },
    canActivate: [AuthGuard],
    component: InventoryBalanceReportComponent
  },
   // donation
   {
    path: 'donator-cases-history-report',
    data: { permissionCodes: [+PermissionEnum.donatorCasesHistoryReport] },
    canActivate: [AuthGuard],
    component: DonatorCasesHistoryReportComponent
  },
  {
    path: 'donation-cases-balance-report',
    data: { permissionCodes: [+PermissionEnum.donationCasesBalanceReport] },
    canActivate: [AuthGuard],
    component: DonationCasesBalanceReportComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReportsRoutingModule { }
