import { ControlPanelComponent } from '../Components/control-panel/control-panel.component';
import { ReportsRoutingModule } from './../Routers/reports.router.module';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BsDatepickerModule } from 'ngx-bootstrap';
//import { PDFExportModule } from '@progress/kendo-angular-pdf-export';
import { DropDownsModule, AutoCompleteModule } from '@progress/kendo-angular-dropdowns';
import { GridModule } from '@progress/kendo-angular-grid';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { NgxPrintModule } from 'ngx-print';
import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { EditorComponent } from '../Components/editor/editor.component';
import { AccountsReportComponent } from '../Components/accounts-report/accounts-report.component';
import {SafeAccountReportComponent} from '../Components/safe-account-report/safe-account-report.component';
import {VendorAccountReportComponent} from '../Components/vendor-account-report/vendor-account-report.component';
import {BankAccountReportComponent} from '../Components/bank-account-report/bank-account-report.component';
import {CostCenterAccountReportComponent} from '../Components/cost-center-account-report/cost-center-account-report.component';
import {AccountBalanceComponent} from '../Components/account-balance/account-balance.component';
import {SafeBalanceReportComponent} from '../Components/safe-balance-report/safe-balance-report.component';
import {VendorBalanceReportComponent} from '../Components/vendor-balance-report/vendor-balance-report.component';
import {BankBalanceReportComponent} from '../Components/bank-balance-report/bank-balance-report.component';
import {CostCenterBalanceReportComponent} from '../Components/cost-center-balance-report/cost-center-balance-report.component';
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

@NgModule({
  declarations: [
    AccountsReportComponent,
    SafeAccountReportComponent,
    VendorAccountReportComponent,
    BankAccountReportComponent,
    CostCenterAccountReportComponent,
    EditorComponent,
    ControlPanelComponent,
    AccountBalanceComponent,
    SafeBalanceReportComponent,
    VendorBalanceReportComponent,
    BankBalanceReportComponent,
    CostCenterBalanceReportComponent,
    BalanceSheetReportComponent,

    FixedAssetDepreciationReportComponent,
    FixedAssetExcludedReportComponent,
    FixedAssetInventoryReportComponent,
    FixedAssetLocationReportComponent,
    FixedAssetLostReportComponent,
    FixedAssetMoveReportComponent,
    InventoryBalanceReportComponent,
    DonatorCasesHistoryReportComponent,
    DonationCasesBalanceReportComponent
  ],
  imports: [
    CommonModule,
    SharedMainModule,
    ReportsRoutingModule,
    ReactiveFormsModule,
    CommonModule,
    SharedMainModule,
    ReactiveFormsModule,
    FormsModule,
    BsDatepickerModule.forRoot(),
    //PDFExportModule,
    DropDownsModule,
    AutoCompleteModule,
    GridModule,
    InfiniteScrollModule,
    NgxPrintModule   
  ],
  providers: []
})
export class ReportsModule { }
