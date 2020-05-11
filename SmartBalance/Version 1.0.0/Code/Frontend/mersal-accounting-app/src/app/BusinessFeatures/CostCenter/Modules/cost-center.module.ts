import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { BsDatepickerModule } from 'ngx-bootstrap';

import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { CostCenterRouterModule } from '../Routers/cost-center.router.module';
import { ListComponent } from '../Components/list/list.component';
import { EditorComponent } from '../Components/editor/editor.component';

@NgModule({
    declarations: [
        ListComponent,
        EditorComponent
    ],
    imports: [
        SharedMainModule,
        CostCenterRouterModule,
        ReactiveFormsModule,
        FormsModule,
        ExcelModule,
        DropDownsModule,
        GridModule,
        BsDatepickerModule.forRoot()
    ],
    providers: []
})
export class CostCenterModule {}