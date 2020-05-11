import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { BsDatepickerModule } from 'ngx-bootstrap';
//import {CommonModule} from '@angular/common';

import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { FixedAssetsRoutingModule } from '../Routers/fixed-asset.router.module';
import { ReceivedAssetEditorComponent } from '../Components/Received/editor/received-asset-editor.component';
import { ListReceivedAssetComponent } from '../Components/Received/list/received-asset-list.component';
import { ExpensesAssetEditorComponent } from '../Components/Expenses/editor/expenses-asset-editor.component';
import { ListExpensesAssetComponent } from '../Components/Expenses/list/expenses-asset-list.component';
import { DepreciationEditorComponent } from '../Components/Depreciation/editor/depreciation-editor.component';
//import { ListDepreciationComponent } from '../Components/Depreciation/list/depreciation-list.component';
import { ExcludeEditorComponent } from '../Components/Exclude/exclude-editor.component';
import { AssetSaleComponent } from '../Components/asset-sale/asset-sale.component';
import { AddLocationComponent } from '../../Location/Components/add-location/add-location.component';
import { AssetInventoryListComponent } from '../Components/asset-inventory-list/asset-inventory-list.component';
import { AssetInventoryEditorComponent } from '../Components/asset-inventory-editor/asset-inventory-editor.component';
import { AssetLocationEditorComponent } from '../Components/Location/editor/asset-location-editor.component';
import { AssetLocationListComponent } from '../Components/Location/list/asset-location-list.component';

@NgModule({
  declarations: [
    ReceivedAssetEditorComponent,
    ListReceivedAssetComponent,
    ExpensesAssetEditorComponent,
    ListExpensesAssetComponent,
    DepreciationEditorComponent,
    //ListDepreciationComponent.
    ExcludeEditorComponent,
    AssetSaleComponent,
    AddLocationComponent,
    AssetInventoryListComponent,
    AssetInventoryEditorComponent,
    AssetLocationEditorComponent,
    AssetLocationListComponent
  ],
  imports: [
    SharedMainModule,
    //CommonModule,
    FixedAssetsRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    ExcelModule,
    DropDownsModule,
    GridModule,
    BsDatepickerModule.forRoot()
  ],
  providers: []
})
export class FixedAssetModule { }
