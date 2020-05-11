import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  /*
   * apllication features pathes.
   */
  {path: '', pathMatch: 'full', redirectTo: '/home/dashboard'},
  //{path: '', pathMatch: 'full', redirectTo: '/financial/financial-list'},
  {path: 'home', loadChildren: 'src/app/ApplicationFeatures/Home/Modules/home.module#HomeModule'},
  {path: 'contact', loadChildren: 'src/app/ApplicationFeatures/Contact/Modules/contact.module#ContactModule'},
  {path: 'about', loadChildren: 'src/app/ApplicationFeatures/About/Modules/about.module#AboutModule'},
  {path: 'error', loadChildren: 'src/app/ApplicationFeatures/Error/Modules/error.module#ErrorModule'},
  /*
   * business features pathes. 
   */
  {path: 'user', loadChildren: 'src/app/BusinessFeatures/User/Modules/user.module#UserModule'},
  {path: 'store', loadChildren: 'src/app/BusinessFeatures/Store/Modules/store.module#StoreModule'},
  {path: 'product', loadChildren: 'src/app/BusinessFeatures/Products/Modules/product.module#ProductModule'},
  {path: 'sales', loadChildren: 'src/app/BusinessFeatures/SalesBill/Modules/sales-bill.module#SalesBillModule'},
  {path: 'financial', loadChildren: 'src/app/BusinessFeatures/Financial/Modules/financial.module#FinancialModule'},
  {path: 'journal', loadChildren: 'src/app/BusinessFeatures/JournalEntries/Modules/journal-entries.module#JournalEntriesModule'},
  {path: 'account-chart', loadChildren: 'src/app/BusinessFeatures/AccountsTree/Modules/account-chart.module#AccountChartModule'},
  {path: 'purchasing', loadChildren: 'src/app/BusinessFeatures/Purchasing/Modules/purchasing.module#PurchasingModule'},
  {path: 'banking', loadChildren: 'src/app/BusinessFeatures/Banking/Modules/banking.module#BankingModule'},
  {path: 'journal-posting', loadChildren: 'src/app/BusinessFeatures/JournalPosting/Modules/journal-posting.module#JournalPostingModule'},
  {path: 'setting', loadChildren: 'src/app/BusinessFeatures/Setting/Modules/setting.module#SettingModule'},
  {path: 'checks-under-collection', loadChildren: 'src/app/BusinessFeatures/ChecksUnderCollection/Modules/checks-under-collection.module#ChecksUnderCollectionModule'},
  {path: 'bank', loadChildren: 'src/app/BusinessFeatures/Bank/Modules/bank.module#BankModule'},
  {path: 'vendor', loadChildren: 'src/app/BusinessFeatures/Vendor/Modules/vendor.module#VendorModule'},
  {path: 'currency', loadChildren: 'src/app/BusinessFeatures/Currency/Modules/currency.module#CurrencyModule'},
  {path: 'cost-center', loadChildren: 'src/app/BusinessFeatures/CostCenter/Modules/cost-center.module#CostCenterModule'},
  {path: 'branch', loadChildren: 'src/app/BusinessFeatures/Branch/Modules/branch.module#BranchModule'},
  {path: 'brand', loadChildren: 'src/app/BusinessFeatures/Brand/Modules/brand.module#BrandModule'},
  {path: 'measurement-unit', loadChildren: 'src/app/BusinessFeatures/MeasurementUnit/Modules/measurement-unit.module#MeasurementUnitModule'},
  {path: 'safe', loadChildren: 'src/app/BusinessFeatures/Safe/Modules/safe.module#SafeModule'},
  {path: 'delegate', loadChildren: 'src/app/BusinessFeatures/Delegate/Modules/delegate.module#DelegateModule'},
  {path: 'donator', loadChildren: 'src/app/BusinessFeatures/Donator/Modules/donator.module#DonatorModule'},
  {path: 'asset', loadChildren: 'src/app/BusinessFeatures/FixedAsset/Modules/fixed-asset.module#FixedAssetModule'},
  {path: 'expenses-type', loadChildren: 'src/app/BusinessFeatures/ExpensesType/Modules/ExpensesType.module#ExpensesTypeModule'},
  {path: 'document', loadChildren: 'src/app/BusinessFeatures/Document/Modules/document.module#DocumentModule'},
  {path: 'account-document', loadChildren: 'src/app/BusinessFeatures/Account-Document/Modules/account-document.module#AccountDocumentModule'},
  {path: 'cost-center-type', loadChildren: 'src/app/BusinessFeatures/CostCenterType/Modules/cost-center-type.module#CostCenterTypeModule'},
  {path: 'closed-month', loadChildren: 'src/app/BusinessFeatures/ClosedMonth/Modules/closed-month.module#ClosedMonthModule'},
  {path: 'bank-account-chart', loadChildren: 'src/app/BusinessFeatures/Bank-Account-Chart/Modules/bank-account-chart.module#BankAccountChartModule'},
  {path: 'discount-percent', loadChildren: 'src/app/BusinessFeatures/Discount-Percent/Modules/discount-percent.module#DiscountPercentModule'},


  {path: 'permission', loadChildren: 'src/app/BusinessFeatures/Permission/Modules/permission.module#PermissionModule'},
  {path: 'role', loadChildren: 'src/app/BusinessFeatures/Role/Modules/role.module#RoleModule'},
  {path: 'menu-items', loadChildren: 'src/app/BusinessFeatures/MenuItem/Modules/menu-items.module#MenuItemsModule'},
  {path: 'group', loadChildren: 'src/app/BusinessFeatures/Group/Modules/group.module#GroupModule'},
  {path: 'location', loadChildren: 'src/app/BusinessFeatures/Location/Modules/location.module#LocationModule'},

  {path: 'reports', loadChildren: 'src/app/BusinessFeatures/Reports/Modules/reports.module#ReportsModule'},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
