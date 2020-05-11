
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SalesRoutingModule } from './sales-routing.module';
import { BsDatepickerModule } from 'ngx-bootstrap';
import { PageHeaderModule } from './../../shared';
import { SalesComponent } from './sales.component';
import { TranslateModule } from '@ngx-translate/core';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SalesProductComponent } from './components/sales-product/sales-product.component';
import { ReturnProductComponent } from './components/return-sales-product/return-sales-product.component';
import { ReceiptsComponent } from './components/receipts/receipts.component';
import { PaymentsComponent } from './components/payments/payments.component';
import { StoreMovementComponent } from './components/store-movement/store-movement.component';
import { StoreTransferComponent } from './components/store-transfer/store-transfer.component';
import { StoreBalanceComponent } from './components/store-balance/store-balance.component';
import { DailyRestrictionsComponent } from './components/daily-restrictions/daily-restrictions.component';
import { PurchasesProductComponent } from './components/purchases-product/purchases-product.component';
import { ReturnPurchasesComponent } from './components/return-purchases-product/return-purchases-product.component';
import { AddProductComponent } from './components/add-product/add-product.component';
import { PurchasesAddProductComponent } from './components/purchases-add-product/purchases-add-product.component';

@NgModule({
    imports: [
        CommonModule,
        SalesRoutingModule,
        PageHeaderModule,
        TranslateModule,
        NgbDropdownModule,
        BsDatepickerModule.forRoot(),
        FormsModule,
        ReactiveFormsModule
    ],
    declarations: [
        SalesComponent,
        SalesProductComponent,
        ReturnProductComponent,
        ReceiptsComponent,
        PaymentsComponent,
        StoreMovementComponent,
        StoreTransferComponent,
        StoreBalanceComponent,
        DailyRestrictionsComponent,
        PurchasesProductComponent,
        ReturnPurchasesComponent,
        AddProductComponent,
        PurchasesAddProductComponent
    ]
})

export class SalesModule {}
