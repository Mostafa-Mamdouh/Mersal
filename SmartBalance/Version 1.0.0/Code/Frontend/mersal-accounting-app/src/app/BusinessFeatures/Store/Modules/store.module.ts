import { FinancialModule } from './../../Financial/Modules/financial.module';
import { BsDatepickerModule } from 'ngx-bootstrap';
import { ProductModule } from './../../Products/Modules/product.module';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { StoreRoutingModule } from '../Routers/store.router.module';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { OpeningBalanceEditorComponent } from '../Components/opening-balance/opening-balance-editor/opening-balance-editor.component';
import { OpeningBalanceListComponent } from '../Components/opening-balance/opening-balance-list/opening-balance-list.component';
import { StoreProductComponent } from '../Components/store-product/store-product.component';
import { StoreCostCenterComponent } from '../Components/store-cost-center/store-cost-center.component';
import { InventoryTransfersListComponent } from '../Components/inventory-transfers/inventory-transfers-list/inventory-transfers-list.component';
import { InventoryTransfersEditorComponent } from '../Components/inventory-transfers/inventory-transfers-editor/inventory-transfers-editor.component';
import { InventoryMovementListComponent } from '../Components/inventory-movement/inventory-movement-list/inventory-movement-list.component';
import { InventoryMovementEditorComponent } from '../Components/inventory-movement/inventory-movement-editor/inventory-movement-editor.component';
import { InventoryEditorComponent } from '../Components/inventory/editor/editor.component';
import { InventoryListComponent } from '../Components/inventory/list/list.component';
import { JournalEntriesModule } from '../../JournalEntries/Modules/journal-entries.module';
// import {StartBalanceComponent } from '../Components/start-balance/start-balance.component';
import { from } from 'rxjs';



@NgModule({
  declarations: [
    OpeningBalanceEditorComponent,
    OpeningBalanceListComponent,
    StoreProductComponent,
    StoreCostCenterComponent,
    InventoryTransfersListComponent,
    InventoryTransfersEditorComponent,
    InventoryMovementListComponent,
    InventoryMovementEditorComponent,
    InventoryEditorComponent,
    InventoryListComponent
    // StartBalanceComponent
  ],
  imports: [
    CommonModule,
    SharedMainModule,
    StoreRoutingModule,
    ReactiveFormsModule,
    ProductModule,
    ReactiveFormsModule,
    ProductModule,
    FinancialModule,
    FormsModule,
    DropDownsModule,
    GridModule, 
    ExcelModule,
    JournalEntriesModule,
    BsDatepickerModule.forRoot()
  ],
  providers: []
})
export class StoreModule { }
