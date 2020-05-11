import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { BsDatepickerModule } from 'ngx-bootstrap';

import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { CurrencyRouterModule } from '../Routers/currency.router.module';
import { CurrencyExchangeListComponent } from '../Components/currency-exchange-list/currency-exchange-list.component';
import { CurrencyExchangeEditorComponent } from '../Components/currency-exchange-editor/currency-exchange-editor.component';
import { CurrencyListComponent } from '../Components/currency-list/currency-list.component';
import { CurrencyEditorComponent } from '../Components/currency-editor/currency-editor.component';
 
@NgModule({
  declarations: [
    CurrencyExchangeListComponent,
    CurrencyExchangeEditorComponent,
    CurrencyListComponent,
    CurrencyEditorComponent
  ],
  imports: [
    SharedMainModule,
    CurrencyRouterModule,
    ReactiveFormsModule,
    FormsModule,
    ExcelModule,
    DropDownsModule,
    GridModule,
    BsDatepickerModule.forRoot()
  ],
  providers: []
})
export class CurrencyModule { }
