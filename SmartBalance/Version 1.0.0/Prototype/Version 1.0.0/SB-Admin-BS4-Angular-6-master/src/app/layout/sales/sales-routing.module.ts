import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SalesComponent } from './sales.component';
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


const routes: Routes = [
    {path: '', pathMatch: 'full', redirectTo: 'salesProduct'},
      {path: 'salesProduct', component: SalesProductComponent},
      {path: 'returnProduct', component: ReturnProductComponent},
      {path: 'purchasesProduct', component: PurchasesProductComponent},
      {path: 'returnPurchases', component: ReturnPurchasesComponent},
      {path: 'receipts', component: ReceiptsComponent},
      {path: 'payments', component: PaymentsComponent},
      {path: 'DailyRestrictions', component: DailyRestrictionsComponent},
      {path: 'store/Movement', component: StoreMovementComponent},
      {path: 'store/transfers', component: StoreTransferComponent},
      {path: 'store/balance', component: StoreBalanceComponent},
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class SalesRoutingModule {
}
