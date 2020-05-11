import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { BsDatepickerModule } from 'ngx-bootstrap';

import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { SafeRouterModule } from '../Routers/safe.router.module';
import { ListComponent } from '../Components/list/list.component';
import { EditorComponent } from '../Components/editor/editor.component';
import { MasterComponent } from '../Components/master/master.component';
import { SafeAccountChartsComponent } from '../Components/safe-accountCharts/safe-accountCharts.component';

@NgModule({
  declarations: [
    ListComponent,
    EditorComponent,
    MasterComponent,
    SafeAccountChartsComponent
  ],
  imports: [
    SharedMainModule,
    SafeRouterModule,
    ReactiveFormsModule,
    FormsModule,
    DropDownsModule,
    GridModule,
    ExcelModule,
    BsDatepickerModule.forRoot()
  ], 
  providers: []
})
export class SafeModule { }
