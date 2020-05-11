import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { 
  GridModule, 
  //PDFModule,
  ExcelModule
} from '@progress/kendo-angular-grid';
import { BsDatepickerModule } from 'ngx-bootstrap';

import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { PurchasingRouterModule } from '../Routers/purchasing.router.module';
import { PurchaseRebateListComponent } from '../Components/purchase-rebate-list/purchase-rebate-list.component';
import { PurchaseRebateEditorComponent } from '../Components/purchase-rebate-editor/purchase-rebate-editor.component';
import { PurchaseInvoiceListComponent } from '../Components/purchase-invoice-list/purchase-invoice-list.component';
import { PurchaseInvoiceEditorComponent } from '../Components/purchase-invoice-editor/purchase-invoice-editor.component';
import { PurchaseProductComponent } from '../Components/purchase-product/purchase-product.component';
import { ProductModule } from '../../Products/Modules/product.module';
import { SettingModule } from '../../Setting/Modules/setting.module';
import { JournalEntriesModule } from '../../JournalEntries/Modules/journal-entries.module';

@NgModule({
  declarations: [
    PurchaseRebateListComponent,
    PurchaseRebateEditorComponent,
    PurchaseInvoiceListComponent,
    PurchaseInvoiceEditorComponent,
    PurchaseProductComponent
  ],
  imports: [
    SharedMainModule,
    PurchasingRouterModule,
    ReactiveFormsModule,
    ProductModule,
    SharedMainModule,
    FormsModule,
    DropDownsModule,
    GridModule,
    //PDFModule, 
    ExcelModule,
    BsDatepickerModule.forRoot(),
    SettingModule,
    JournalEntriesModule
  ],
  providers: []
})
export class PurchasingModule { }
