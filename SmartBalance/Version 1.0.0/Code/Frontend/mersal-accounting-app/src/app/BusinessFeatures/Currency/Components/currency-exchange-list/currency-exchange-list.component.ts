import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { process, State } from '@progress/kendo-data-query';

import { PostSearch } from '../../Models/search.model';
// import {PurchasingService} from '../../Services/Purchasing.service';
import { CurrencyRateService } from '../../Services/currency-rate.service.';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { GridDataResult, PageChangeEvent, GridComponent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
// //import { FinancialService } from '../../../Financial/Services/financial.service';
import { CurrencyService } from '../../../Currency/Services/currency.service';
import { PaginationOptions } from '../../../../SharedFeatures/SharedMain/Models/pagination-options.model';
import { PaginationService } from '../../../../SharedFeatures/SharedMain/Services/pagination.service';

@Component({
  selector: 'currency-exchange-list',
  styleUrls: ['./currency-exchange-list.component.scss'],
  templateUrl: './currency-exchange-list.component.html'
})
export class CurrencyExchangeListComponent implements OnInit {

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private translateService: TranslateService,
    private notification: NotificationService,
    //private purchasingService: PurchasingService,
    //private bankingService: BankingService,
    //private ReceiptsServ: FinancialService,
    private currencyrateService: CurrencyRateService,
    private paginationService: PaginationService,
    private currencyService: CurrencyService
  ) { }

  ngOnInit(): void {
    this.pageSize = this.paginationService.getPaginationOptions().pageSize;
    this.pagenationSizeList = this.paginationService.getPaginationOptions().pagenationSizeList;
    this.pagenationSize = {value: this.pageSize};

    this.skip = this.pageIndex * this.pageSize;  

    this.setLanguageSubscriber();
    this.getResourceKeys();
    this.getCurrencyLookup();
    //this.getJournalTypesLookup();
    this.getList();
    this.extractRouteParams();
  }

  extractRouteParams() {
    let pageIndex = +this.route.snapshot.params['pageIndex'];

    this.pageIndex = 0;
    if (pageIndex) {
      this.pageIndex = pageIndex;
      this.skip = this.pageIndex * this.pageSize;  
    }
  }

//   //page
  pageSize;
  pageIndex: number = 0;
//   total: number;
  skip = 0;
  gridView: GridDataResult;
//   data: any[];
//   searchForm: FormGroup;
//   //searchModel: Search;
  language: any;
  itemIdToDelete: any;
//   showAdvancedSearch: boolean = false;
//   banks: any[] = [];// BranchLookup[] = [];
//   journalTypes: any[] = [];
  list: any[] = [];
  ListLoading: boolean = false;

  public state: State = {
    // Initial filter descriptor
    filter: {
      logic: 'and',
      filters: []
    }
  };
//   bankId: any;
//   journalTypeId: any;
  public currencyDropDownData: Array<KendoDropDown>;
//   public journalTypesDropDownData: Array<KendoDropDown>;
//   public filterSettings: DropDownFilterSettings = {
//     caseSensitive: false,
//     operator: 'contains'
//   };

  postSearch: PostSearch = new PostSearch();
//   //postSearch: any;
  filter: any;
//   bank: number;
//   journalType: number;
  allKey: string;



  getResourceKeys() {
    this.translateService.get([
      'shared.all'
    ]).subscribe(res => {
      if (res) {
        this.allKey = res['shared.all'];
      }
    });
  }

  currencyChange(event) {
    debugger;
    this.pageIndex = 0;
    this.postSearch.currency = event.value;
    //this.bank = this.postSearch.bank;
    this.getList();
  }
  exchangeCurrencyChange(event) {
    debugger;
    this.pageIndex = 0;
    this.postSearch.ExchangeCurrency = event.value;
    //this.bank = this.postSearch.bank;
    this.getList();
  }

  dataStateChange(state: DataStateChangeEvent): void {
    debugger;
    this.skip = state.skip;
    this.pageIndex = (this.skip / this.pageSize);
    this.state = state;
    this.filter = this.state.filter.filters;
    if (this.filter.length > 0) {
      for (var _i = 0; _i < this.filter.length; _i++) {
        if (this.filter[_i].filters) {
          var x = this.filter[_i].filters;
          this.postSearch.dateFrom = x[0].value.toISOString().substring(0, 10);
          this.postSearch.dateTo = x[1].value.toISOString().substring(0, 10);
          this.filter.splice( _i,1);      
        } else {
          this.postSearch.dateFrom = new Date(new Date().setMonth(new Date().getMonth() - 1)).toISOString().substring(0, 10);
          this.postSearch.dateTo = new Date(Date.now()).toISOString().substring(0, 10);
        }

        if (this.filter[_i].field == "currency") {
          this.postSearch.currency = this.filter[_i].value;
        }

        if (this.filter[_i].field == "price") {
          this.postSearch.priceTo = this.filter[_i].value;
        }

        if (this.filter[_i].field == "date") {
          this.postSearch.dateFrom = this.filter[_i].value.toISOString().substring(0, 10);
          this.postSearch.dateTo = new Date(Date.now()).toISOString().substring(0, 10);
        }

        if (this.filter[_i].field == "ExchangeCurrency") {
          this.postSearch.ExchangeCurrency = this.filter[_i].value;
        }
      }
      this.postSearch.filters = this.filter;
      this.pageIndex = 0;
    } else {
      this.postSearch = new PostSearch();
      //this.postSearch.bank = this.bank;
      //this.postSearch.journalType = this.journalType;
    }
    //debugger;
    this.postSearch.sort = this.state.sort;
    this.getList();
  }

  public pageChange(event: PageChangeEvent): void {
    this.pageIndex = (event.skip / this.pageSize);

    let url = [`/currency/exchange/list/${this.pageIndex}`];
    this.router.navigate(url);
  }
  setLanguageSubscriber(): void {
    this.language = this.translateService.currentLang;
    this.translateService.onLangChange.subscribe(val => {
      this.language = val.lang;
      this.getResourceKeys();
    },
      (error) => { },
      () => { });
  }

  createAllFilter(): KendoDropDown {
    let record = new KendoDropDown();
    record.text = this.allKey;
    record.value = null;

    return record;
  }

  getCurrencyLookup() {
    debugger;

    this.currencyService.getCurrencysLookups()
      .subscribe(res => {
        var array = new Array<any>();

        array.push(this.createAllFilter());

        res.collection.forEach(function (item) {
          var record = new KendoDropDown();
          record.text = item.name;
          record.value = item.id;
          array.push(record);
          
        });
        this.currencyDropDownData = array;
        console.info(res);
      },
        (error) => {
          this.notification.showOperationFailed();
          console.error(JSON.stringify(error));
        }
      );
  }

 

  getList() {
    this.postSearch.pageSize = this.pageSize;
    this.postSearch.pageIndex = this.pageIndex;
    this.ListLoading = true;

    //this.postSearch.bank = (this.bankId ? this.bankId.value : this.bankId);
    debugger;
    this.currencyrateService.getCurrencyByPost(this.postSearch)
      .subscribe(res => {
        this.ListLoading = false;
        this.gridView = {
          data: res.collection,
          total: res.totalCount
        };
        console.log(res)
      },
        (error) => {
          // debugger;
          this.ListLoading = false;
          this.notification.showOperationFailed();
          this.list = [];
        },
      );
  }


  setItemToDelete(id: any) {
    this.itemIdToDelete = id;
  }
 
  gotoList() {
    let url = [`/currency/exchange/list`];
    this.router.navigate(url);
  }

  pagenationSizeChange(event: any) {
    debugger;
    this.paginationService.setPaginationOptions(this.pagenationSize.value);
    if (this.pageIndex == 0) {
      this.pageSize = this.pagenationSize.value;
      this.pageIndex = 0;
      this.skip = 0;
      this.getList();
    }
    else {
      this.gotoList();
    }
  }


  pagenationSize: any;
  pagenationSizeList: any[];
}