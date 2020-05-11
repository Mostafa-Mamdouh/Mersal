import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { BsDatepickerModule } from 'ngx-bootstrap';

import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { MenuItemsRouterModule } from '../Routers/menu-items.router.module';
import { ListComponent } from '../Components/list/list.component';
import { EditorComponent } from '../Components/editor/editor.component';
import { MasterComponent } from '../Components/master/master.component';
import { UserMenuItemComponent } from '../Components/user-menuItem/user-menuItem.component';

@NgModule({
  declarations: [
    ListComponent,
    EditorComponent,
    MasterComponent,
    UserMenuItemComponent
  ],
  imports: [
    SharedMainModule,
    MenuItemsRouterModule,
    ReactiveFormsModule,
    FormsModule,
    DropDownsModule,
    GridModule,
    ExcelModule,
    BsDatepickerModule.forRoot()
  ], 
  providers: []
})
export class MenuItemsModule { }
