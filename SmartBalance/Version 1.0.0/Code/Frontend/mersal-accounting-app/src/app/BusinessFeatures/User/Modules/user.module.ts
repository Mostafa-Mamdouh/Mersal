//import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { BsDatepickerModule } from 'ngx-bootstrap';

import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { UserRoutingModule } from '../Routers/user.router.module';
import { SampleListComponent } from '../Components/sample-list/sample-list.component';
import { SampleEditorComponent } from '../Components/sample-editor/sample-editor.component';
import { LoginComponent } from '../Components/login/login.component';
import { EditorComponent } from '../Components/editor/editor.component';
import { ListComponent } from '../Components/list/list.component';
import { MasterComponent } from '../Components/master/master.component';
import { UserPermissionsComponent } from '../Components/user-permissions/user-permissions.component';
import { UserRolesComponent } from '../Components/user-roles/user-roles.component';
import { UserMenuItemComponent } from '../Components/user-menuItem/user-menuItem.component';
import { UserGroupsComponent } from '../Components/user-groups/user-groups.component';
import { UserBranchsComponent } from '../Components/user-branchs/user-branchs.component';
 
@NgModule({
  declarations: [
    SampleListComponent,
    SampleEditorComponent,   
    LoginComponent,
    EditorComponent,
    ListComponent,
    MasterComponent,
    UserPermissionsComponent,
    UserRolesComponent,
    UserMenuItemComponent,
    UserGroupsComponent,
    UserBranchsComponent
  ],
  imports: [
    //CommonModule,
    DropDownsModule,
    GridModule,
    ExcelModule,
    BsDatepickerModule.forRoot(),
    
    SharedMainModule,
    UserRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: []
})
export class UserModule { }
