// import { PostSearch } from './../../../Models/search.model';
// import { Component, OnInit } from '@angular/core';
// import { Router } from '@angular/router';
// import { TranslateService } from '@ngx-translate/core';
// import { process, State } from '@progress/kendo-data-query';
// import { NotificationService } from '../../../../../SharedFeatures/SharedMain/Services/notification.service';
// import { Validators, FormGroup, FormBuilder } from '@angular/forms';
// import { GridDataResult, PageChangeEvent, GridComponent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
// import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
// import { KendoDropDown } from '../../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
// import { PaginationOptions } from '../../../../../SharedFeatures/SharedMain/Models/pagination-options.model';
// import { PaginationService } from '../../../../../SharedFeatures/SharedMain/Services/pagination.service';
// import { FinancialService } from '../../../../Financial/Services/financial.service';
// import { ExpensesAssetService } from '../../../Services/expenses-fixed-asset.service';
// import {PurchaseInvoice} from '../../../../Purchasing/Models/purchase-invoice.model';
// import { PurchasingService } from '../../../../Purchasing/Services/Purchasing.service';
// import { LocationService } from '../../../../Location/Services/location.service';
// import { BrandService } from '../../../../Brand/Services/brand.service';
// import { ExpensesTypeService } from '../../../../ExpensesType/Services/expenses-type.service';

// @Component({
//   selector: 'app-list',
//   templateUrl: './depreciation-list.component.html',
//   styleUrls: ['./depreciation-list.component.css']
// })
// export class ListDepreciationComponent implements OnInit {

//   constructor(
//     private router: Router,
//     private fb: FormBuilder,
//     private notificationService: NotificationService,
//     private translateService: TranslateService,
//     private notification: NotificationService,

//     private paginationService: PaginationService
//   ) { }

//   ngOnInit(): void {
//     this.pageSize = this.paginationService.getPaginationOptions().pageSize;

//     this.setLanguageSubscriber();
//     this.getResourceKeys();
//     this.getList();
//   }

//   //page
//   pageSize;
//   pageIndex: number = 0;
//   total: number;
//   skip = 0;
//   gridView: GridDataResult;
//   data: any[];
//   searchForm: FormGroup;
//   //searchModel: Search;
//   language: any;
//   private accountCharts: any[];
//   private expensesTypes: any[];
//   list: any[] = [];
//   ListLoading: boolean = false;

//   public state: State = {
//     // Initial filter descriptor
//     filter: {
//       logic: 'and',
//       filters: []
//     }
//   };
//   bankId: any;
//   journalTypeId: any;
 
//   public filterSettings: DropDownFilterSettings = {
//     caseSensitive: false,
//     operator: 'contains'
//   };

//   postSearch: PostSearch = new PostSearch();
//   //postSearch: any;
//   filter: any;
//   bank: number;
//   journalType: number;
//   allKey: string;



//   getResourceKeys() {
//     this.translateService.get([
//       'shared.all'
//     ]).subscribe(res => {
//       if (res) {
//         this.allKey = res['shared.all'];
//       }
//     });
//   }


//   dataStateChange(state: DataStateChangeEvent): void {
//     debugger;
//     this.skip = state.skip;
//     this.pageIndex = (this.skip / this.pageSize);
//     this.state = state;
//     this.filter = this.state.filter.filters;
//     if (this.filter.length > 0) {
//       for (var _i = 0; _i < this.filter.length; _i++) {
//         if (this.filter[_i].filters) {
//           var x = this.filter[_i].filters;

//           //this.filter.splice( _i,1);      
//         } else {

//         }



//         // if (this.filter[_i].field == "expensesTypeName") {
//         //   this.postSearch.brandId = this.filter[_i].value;
//         // }

//         // if (this.filter[_i].field == "accountChartName") {
//         //   this.postSearch.accountChartId = this.filter[_i].value;
//         // }

//         // if (this.filter[_i].field == "amount") {
//         //   this.postSearch.amountTo = this.filter[_i].value;
//         // }
//       }
//       this.postSearch.filters = this.filter;
//       this.pageIndex = 0;
//     } 
//     else {
//       this.postSearch = new PostSearch();

//     }
// debugger;
//     this.postSearch.sort = this.state.sort;
//     this.getList();
//   }

//   public pageChange(event: PageChangeEvent): void {

//   }
//   setLanguageSubscriber(): void {
//     this.language = this.translateService.currentLang;
//     this.translateService.onLangChange.subscribe(val => {
//       this.language = val.lang;
//       this.getResourceKeys();
//     },
//       (error) => { },
//       () => { });
//   }


//   getList() {
//     this.postSearch.pageSize = this.pageSize;
//     this.postSearch.pageIndex = this.pageIndex;
//     this.ListLoading = true;

//     //this.postSearch.bank = (this.bankId ? this.bankId.value : this.bankId);
//     //debugger
//     // this.expensesAssetService.getExpenseAssesByPost(this.postSearch)
//     //   .subscribe(res => {
//     //     this.ListLoading = false;
//     //     this.gridView = {
//     //       data: res.collection,
//     //       total: res.totalCount
//     //     };
//     //     console.log(res)
//     //   },
//     //     (error) => {
//     //       // debugger;
//     //       this.ListLoading = false;
//     //       this.notification.showOperationFailed();
//     //       this.list = [];
//     //     },
//     //   );
//   }



// }
