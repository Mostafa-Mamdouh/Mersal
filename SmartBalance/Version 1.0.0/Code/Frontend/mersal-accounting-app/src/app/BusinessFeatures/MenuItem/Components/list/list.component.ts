import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { process, State } from '@progress/kendo-data-query';

import { PostSearch } from '../../Models/search.model';
import { MenuItemsService } from '../../Services/menu-items.service';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { GridDataResult, PageChangeEvent, GridComponent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { PaginationOptions } from '../../../../SharedFeatures/SharedMain/Models/pagination-options.model';
import { PaginationService } from '../../../../SharedFeatures/SharedMain/Services/pagination.service';

@Component({
  selector: 'menu-items-list',
  styleUrls: ['./list.component.scss'],
  templateUrl: './list.component.html'
})
export class ListComponent implements OnInit {

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private translateService: TranslateService,
    private notification: NotificationService,
    private menuItemsService: MenuItemsService,
    private ReceiptsServ: FinancialService,
    private paginationService: PaginationService
  ) { }

  ngOnInit(): void {
    this.pageSize = this.paginationService.getPaginationOptions().pageSize;
    this.pagenationSizeList = this.paginationService.getPaginationOptions().pagenationSizeList;
    this.pagenationSize = {value: this.pageSize};
    
    this.setLanguageSubscriber();
    this.getResourceKeys();
    this.getMenuItemLookup();
    //this.getJournalTypesLookup();
    this.getHasParentDropDownData();
    this.getIsActiveDropDownData();
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

   
  gotoList() {
    let url = [`/menu-items/list`];
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

  //page
  pageSize;
  pageIndex: number = 0;
  total: number;
  skip = 0;
  gridView: GridDataResult;
  data: any[];
  searchForm: FormGroup;
  //searchModel: Search;
  language: any;
  itemIdToDelete: any;
  showAdvancedSearch: boolean = false;
  menuItems: any[] = [];// BranchLookup[] = [];
  //journalTypes: any[] = [];
  list: any[] = [];
  ListLoading: boolean = false;

  public state: State = {
    // Initial filter descriptor
    filter: {
      logic: 'and',
      filters: []
    }
  };
  //vendorId: any;
  //journalTypeId: any;
  //public banksDropDownData: Array<KendoDropDown>;
  //public journalTypesDropDownData: Array<KendoDropDown>;
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };

  postSearch: PostSearch = new PostSearch();
  filter: any;
  parentMenuItemId: number;
  //journalType: number;
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

  getMenuItemLookup() {
    this.menuItemsService.getMenuItemsLookups()
    .subscribe(res => {
      debugger;
      this.menuItems = [];
      this.menuItems.push({id: null, disabledName: this.allKey});

      res.collection.forEach(item => {
        this.menuItems.push({id: item.id, disabledName: item.displyedName});
      });
    },
    (error) => {

    },
    () => {

    });
  }

  getHasParentDropDownData() {
    if(this.language == "en") {
      this.HasParentDropDownData = [
        {text: "All", value: null},
        {text: "Yes", value: true},
        {text: "No", value: false},      
      ];
    }
    else {
      this.HasParentDropDownData = [
        {text: "الكل", value: null},
        {text: "نعم", value: true},
        {text: "لا", value: false},      
      ];
    }
  }

  getIsActiveDropDownData() {
    if(this.language == "en") {
      this.IsActiveDropDownData = [
        {text: "All", value: null},
        {text: "Yes", value: true},
        {text: "No", value: false},      
      ];
    }
    else {
      this.IsActiveDropDownData = [
        {text: "الكل", value: null},
        {text: "نعم", value: true},
        {text: "لا", value: false},      
      ];
    }
  }
 
  hasParentChange(event: any) {
    debugger;
    if(event) {
      this.postSearch.hasParent = event.value;
      this.getList();
    }
  }
  isActiveChange(event: any) {
    debugger;
    if(event) {
      this.postSearch.isActive = event.value;
      this.getList();
    }
  }

  parentMenuItemIdChange(event) {
    //debugger;
    this.pageIndex = 0;
    this.postSearch.parentMenuItemId = event.id;
    this.parentMenuItemId = this.postSearch.parentMenuItemId;
    this.getList();
  }
//   journalTypeChange(event) {
//     //debugger;
//     this.pageIndex = 0;
//     this.postSearch.journalType = event.value;
//     this.journalType = this.postSearch.journalType;
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
          // this.postSearch.dateFrom = x[0].value.toISOString().substring(0, 10);
          // this.postSearch.dateTo = x[1].value.toISOString().substring(0, 10);
          //this.filter.splice( _i,1);      
        } else {
          // this.postSearch.dateFrom = new Date(new Date().setMonth(new Date().getMonth() - 1)).toISOString().substring(0, 10);
          // this.postSearch.dateTo = new Date(Date.now()).toISOString().substring(0, 10);
        }

        if (this.filter[_i].field == "code") {
          this.postSearch.code = this.filter[_i].value;
        }

        if (this.filter[_i].field == "name") {
          this.postSearch.name = this.filter[_i].value;
        }

        if (this.filter[_i].field == "isActive") {
          this.postSearch.isActive = this.filter[_i].value;
        }

        if (this.filter[_i].field == "itemOrder") {
          this.postSearch.itemOrder = this.filter[_i].value;
        }

        if (this.filter[_i].field == "url") {
          this.postSearch.url = this.filter[_i].value;
        }
      }
      this.postSearch.filters = this.filter;
      this.pageIndex = 0;
    } else {
      this.postSearch = new PostSearch();
    //   this.postSearch.bank = this.bank;
    //   this.postSearch.journalType = this.journalType;
    }
    //debugger;
    this.postSearch.sort = this.state.sort;
    this.getList();
  }

  public pageChange(event: PageChangeEvent): void {
    this.pageIndex = (event.skip / this.pageSize);

    let url = [`/menu-items/list/${this.pageIndex}`];
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

//   getBankLookup() {
//     this.bankService.getBanksLookups()
//       .subscribe(res => {
//         var array = new Array<any>();

//         array.push(this.createAllFilter());

//         res.collection.forEach(function (item) {
//           var record = new KendoDropDown();
//           record.text = item.name;
//           record.value = item.id;
//           array.push(record);
//         });
//         this.banksDropDownData = array;
//       },
//         (error) => {
//           this.notification.showOperationFailed();
//         }
//       );
//   }

//   getJournalTypesLookup() {
//     this.bankingService.getJournalTypes()
//       .subscribe(res => {
//         var array = new Array<any>();

//         array.push(this.createAllFilter());

//         res.collection.forEach(function (item) {
//           var record = new KendoDropDown();
//           record.text = item.name;
//           record.value = item.id;
//           array.push(record);
//         });
//         this.journalTypesDropDownData = array;
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
    //this.postSearch.journalType = (this.journalTypeId ? this.journalTypeId.value : this.journalTypeId);
    //debugger
    this.menuItemsService.getMenuItemsByPost(this.postSearch)
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



  HasParentDropDownData: any[];
  IsActiveDropDownData: any[];
  pagenationSize: any;
  pagenationSizeList: any[];   
}