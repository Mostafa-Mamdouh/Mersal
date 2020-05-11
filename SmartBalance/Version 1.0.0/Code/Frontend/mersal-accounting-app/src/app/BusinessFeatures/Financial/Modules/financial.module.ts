import { mobileComponent } from './../../../SharedFeatures/SharedMain/Components/mobile/mobile.component';
import { addressComponent } from './../../../SharedFeatures/SharedMain/Components/address/address.component';
import { PaymentMovementComponent } from '../Components/movement-payment/payments-movement/payments-movement.component';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { SelectCasesComponent } from '../Components/select-cases/select-cases.component';
import { BsDatepickerModule } from 'ngx-bootstrap';
import { FinancialRoutingModule } from '../Routers/financial.router.module';
import { PaymentMethodsComponent } from '../Components/payment-methods/payment-methods.component';
import { ProductModule } from '../../Products/Modules/product.module';
import { AddDonerComponent } from '../Components/Donator/add-donator.component';
import { AddCostCenterComponent } from '../../Financial/Components/add-cost-center/add-cost-center.component';
import { ListComponent } from '../Components/movement-payment/list/list.component';
import { AddReceiptsComponent } from '../Components/movement-receipts/add-receipts/add-receipts.component';
import { ListReceiptsComponent } from '../Components/movement-receipts/list/list.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { ViewPaymentComponent } from '../Components/movement-payment/view-payments/view-payments.component';
import { ViewReceiptsComponent } from '../Components/movement-receipts/view-receipts/view-receipts.component';
import { AuthGuard } from '../../User/Services/auth-guard.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { AutoCompleteModule } from '@progress/kendo-angular-dropdowns';
import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { SearchComponent } from '../Components/search/search.component';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { receiptinvoice } from '../Components/receipt-invoice/receipt-invoice.component';
import { PDFExportModule } from '@progress/kendo-angular-pdf-export';
import {NgxPrintModule} from 'ngx-print';
import { emailComponent } from '../../../SharedFeatures/SharedMain/Components/email/email.component';
import { SettingModule } from '../../Setting/Modules/setting.module';
import { JournalEntriesModule } from '../../JournalEntries/Modules/journal-entries.module';
import { TestamentEditorComponent } from '../Components/testament/editor/editor.component';
import { TestamentListComponent } from '../Components/testament/list/list.component';
import { LiquidationComponent } from '../Components/Liquidation/liquidation.component'

@NgModule({
  declarations: [
    AddReceiptsComponent,
    SelectCasesComponent,
    PaymentMethodsComponent,
    AddDonerComponent,
    AddCostCenterComponent,
    PaymentMovementComponent,
    ListComponent,
    ListReceiptsComponent,
    ViewPaymentComponent,
    ViewReceiptsComponent,
    SearchComponent,
    receiptinvoice,
    emailComponent,
    addressComponent,
    mobileComponent,
    TestamentEditorComponent,
    TestamentListComponent,
    LiquidationComponent
  ],
  imports: [
    CommonModule,
    SharedMainModule,
    ReactiveFormsModule,
    FinancialRoutingModule,
    FormsModule,
    BsDatepickerModule.forRoot(),
    ProductModule,
    ExcelModule,
    NgxPaginationModule,
    PDFExportModule,
     DropDownsModule,
    AutoCompleteModule,
    GridModule,
    InfiniteScrollModule,
    NgxPrintModule,
    SettingModule,
    JournalEntriesModule
  ],
  exports: [AddCostCenterComponent],
  providers: [AuthGuard]
})
export class FinancialModule { }
