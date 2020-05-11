
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedMainModule } from '../../../SharedFeatures/SharedMain/Modules/shared-main.module';
import { SalesBillsComponent } from '../Components/sales-bill/sales-bill.component';
import { BillSummaryComponent } from '../Components/summary/bill-summary.component';
import { SalesBillRoutingModule } from '../Routers/sales-bill.router.module';
import { ProductModule } from '../../Products/Modules/product.module';
import { BsDatepickerModule } from 'ngx-bootstrap';




@NgModule({
  declarations: [
    SalesBillsComponent,
    BillSummaryComponent
  ],
  imports: [
    CommonModule,
    SharedMainModule,
    SalesBillRoutingModule,
    ReactiveFormsModule,
    ProductModule,
    BsDatepickerModule.forRoot(),

  ],
  providers: []
})
export class SalesBillModule { }
