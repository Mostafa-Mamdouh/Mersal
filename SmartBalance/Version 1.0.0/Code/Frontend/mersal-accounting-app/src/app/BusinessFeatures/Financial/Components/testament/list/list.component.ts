import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { process, State } from '@progress/kendo-data-query';
import { TestamentSearch } from '../../../Models/search.model';
// //import { CurrencyService } from '../../Services/Currency.service';
import { NotificationService } from '../../../../../SharedFeatures/SharedMain/Services/notification.service';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { GridDataResult, PageChangeEvent, GridComponent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { KendoDropDown } from '../../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
// //import { FinancialService } from '../../../Financial/Services/financial.service';
import { TestamentService } from '../../../Services/testament.service';
import { PaginationOptions } from '../../../../../SharedFeatures/SharedMain/Models/pagination-options.model';
import { PaginationService } from '../../../../../SharedFeatures/SharedMain/Services/pagination.service';

@Component({
  selector: 'testament-list',
  styleUrls: ['./list.component.scss'],
  templateUrl: './list.component.html'
})
export class TestamentListComponent implements OnInit {
  advancesTypes: any[];
  advancesTypeId: any;
  status: any[];
  closedKey: any;
  openKey: any;
  isClosed: boolean;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private translateService: TranslateService,
    private notification: NotificationService,
    //private purchasingService: PurchasingService,
    private testamentService: TestamentService,
    //private ReceiptsServ: FinancialService,
    private paginationService: PaginationService
  ) { }

  ngOnInit(): void {
    this.pageSize = this.paginationService.getPaginationOptions().pageSize;
    this.pagenationSizeList = this.paginationService.getPaginationOptions().pagenationSizeList;
    this.pagenationSize = {value: this.pageSize};

    this.setLanguageSubscriber();
    this.getResourceKeys();
    this.getAdvancesTypesLookups();
    //this.getBankLookup();
    //this.getJournalTypesLookup();
    this.getList();

    this.getStatusLookups();
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
//   public currencyDropDownData: Array<KendoDropDown>;
//   public journalTypesDropDownData: Array<KendoDropDown>;
//   public filterSettings: DropDownFilterSettings = {
//     caseSensitive: false,
//     operator: 'contains'
//   };

  postSearch: TestamentSearch = new TestamentSearch();
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

    this.translateService.get([
      'liquidation.status.closed'
  ]).subscribe(res => {
      debugger;
      if (res) {
          this.closedKey = res['liquidation.status.closed'];
      }
  });

  this.translateService.get([
      'liquidation.status.open'
  ]).subscribe(res => {
      debugger;
      if (res) {
          this.openKey = res['liquidation.status.open'];
      }
  });
  }

  statusValueChange(event) {
    this.postSearch.isClosed = event;
    this.isClosed = this.postSearch.isClosed;
    this.getList();
  }

//   bankChange(event) {
//     //debugger;
//     this.pageIndex = 0;
//     //this.postSearch.bank = event.value;
//     //this.bank = this.postSearch.bank;
//     this.getList();
//   }


  dataStateChange(state: DataStateChangeEvent): void {
    //debugger;
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
          //this.filter.splice( _i,1);      
        } else {
          this.postSearch.dateFrom = new Date(new Date().setMonth(new Date().getMonth() - 1)).toISOString().substring(0, 10);
          this.postSearch.dateTo = new Date().toISOString().substring(0, 10);
        }

        if (this.filter[_i].field == "date") {
          this.postSearch.dateFrom = this.filter[_i].value.toISOString().substring(0, 10);
          this.postSearch.dateTo = new Date().toISOString().substring(0, 10);
        }

        if (this.filter[_i].field == "code") {
          this.postSearch.code = this.filter[_i].value;
        }

        if (this.filter[_i].field == "advancesTypeName") {
          this.postSearch.advancesTypeId = this.filter[_i].value;
        }

        if (this.filter[_i].field == "totalValue") {
          this.postSearch.totalValueTo = this.filter[_i].value;
        }

        if (this.filter[_i].field == "description") {
          this.postSearch.description = this.filter[_i].value;
        }


        
      }
      this.postSearch.filters = this.filter;
      this.pageIndex = 0;
    } else {
      this.postSearch = new TestamentSearch();
      this.postSearch.advancesTypeId = this.advancesTypeId;
      //this.postSearch.bank = this.bank;
      //this.postSearch.journalType = this.journalType;
    }
    //debugger;
    this.postSearch.sort = this.state.sort;
    this.getList();
  }

  public pageChange(event: PageChangeEvent): void {
    this.pageIndex = (event.skip / this.pageSize);

    let url = [`/financial/testament/list/${this.pageIndex}`];
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

  getStatusLookups() {
    this.status = [];
    this.status.push({ text: this.allKey, value: null });

    this.status.push({ text: this.closedKey, value: true });


    this.status.push({ text: this.openKey, value: false });
}
  getAdvancesTypesLookups(){
    this.testamentService.getAdvancesTypesLookups().subscribe(res => {
      this.advancesTypes = [];
      this.advancesTypes.push(this.createAllFilter());
      res.collection.forEach(item => {
        let record = new KendoDropDown();
        record.text = item.name;
        record.value = item.id;
        this.advancesTypes.push(record);
      })
    })
  }
  advancesTypeValueChange(event){
    this.postSearch.advancesTypeId = event;
    this.advancesTypeId = this.postSearch.advancesTypeId;
    this.getList();
  }

//   getBankLookup() {
//     this.CurrencyService.getCurrencysLookups()
//       .subscribe(res => {
//         var array = new Array<any>();

//         array.push(this.createAllFilter());

//         res.collection.forEach(function (item) {
//           var record = new KendoDropDown();
//           record.text = item.name;
//           record.value = item.id;
//           array.push(record);
          
//         });
//         this.currencyDropDownData = array;
//       },
//         (error) => {
//           this.notification.showOperationFailed();
//         }
//       );
//   }

 

  getList() {
    this.postSearch.pageSize = this.pageSize;
    this.postSearch.pageIndex = this.pageIndex;
    this.ListLoading = true;

    //this.postSearch.bank = (this.bankId ? this.bankId.value : this.bankId);
    //debugger
    this.testamentService.getTestamentByPost(this.postSearch)
      .subscribe(res => {
        debugger;
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
    let url = [`/currency/list`];
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