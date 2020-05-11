import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { BsDatepickerModule } from 'ngx-bootstrap';

import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { BankingRouterModule } from '../Routers/banking.router.module';
import { ListComponent } from '../Components/list/list.component';
import { EditorComponent } from '../Components/editor/editor.component';
import { chequesComponent } from '../Components/cheques/cheques.component';
import { JournalEntriesModule } from '../../JournalEntries/Modules/journal-entries.module';
import { SettingModule } from '../../Setting/Modules/setting.module';
import { AddCostCenterComponent } from '../../Financial/Components/add-cost-center/add-cost-center.component';
import { FinancialModule } from '../../Financial/Modules/financial.module';

@NgModule({
  declarations: [
    ListComponent,
    EditorComponent,
    chequesComponent,
    
  ],
  imports: [
    SharedMainModule,
    BankingRouterModule,
    ReactiveFormsModule,
    FinancialModule,
    FormsModule,
    DropDownsModule,
    ExcelModule,
    GridModule,
    BsDatepickerModule.forRoot(),
    SettingModule,
    JournalEntriesModule
  ],
  providers: []
})
export class BankingModule { }
