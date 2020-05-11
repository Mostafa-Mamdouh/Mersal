import { ProductModule } from '../../Products/Modules/product.module';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { AccountsTreeRoutingModule } from '../Routers/accounts-tree.router.module';
import { accountChartTreeComponent } from '../Components/account-chart-tree/account-chart-tree.component';
import { AccountsTreeService } from '../Services/accounts-tree.service';
import { TreeViewModule } from '@progress/kendo-angular-treeview';
import { AddAccountTreeComponent } from '../Components/add-account-chart/add-account-chart.component';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { AutoCompleteModule } from '@progress/kendo-angular-dropdowns';
import { MenusModule } from '@progress/kendo-angular-menu';
import { BsDatepickerModule } from 'ngx-bootstrap';
import { CommonModule } from '@angular/common';

import {WorkspaceLocalstorageComponent} from '../Components/workspace-split/workspace-split.component';

@NgModule({
  declarations: [
    accountChartTreeComponent,
    AddAccountTreeComponent,
    WorkspaceLocalstorageComponent
  ],
  imports: [
    CommonModule,
    SharedMainModule,
    AccountsTreeRoutingModule,
    ReactiveFormsModule,
    ProductModule,
    TreeViewModule,
    DropDownsModule,
    AutoCompleteModule,
    MenusModule,
    BsDatepickerModule.forRoot(),
    
  ],
  providers: [AccountsTreeService]
})
export class AccountChartModule { }
