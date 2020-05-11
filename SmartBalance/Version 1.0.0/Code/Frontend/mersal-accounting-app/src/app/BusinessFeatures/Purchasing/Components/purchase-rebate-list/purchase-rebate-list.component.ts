import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { process, State } from '@progress/kendo-data-query';

import { Search, PostSearch } from '../../Models/search.model';
import { PurchasingService } from '../../Services/Purchasing.service';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { GridDataResult, PageChangeEvent, GridComponent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { PaginationOptions } from '../../../../SharedFeatures/SharedMain/Models/pagination-options.model';
import { PaginationService } from '../../../../SharedFeatures/SharedMain/Services/pagination.service';

@Component({
  selector: 'purchase-rebate-list',
  styleUrls: ['./purchase-rebate-list.component.scss'],
  templateUrl: './purchase-rebate-list.component.html'
})
export class PurchaseRebateListComponent implements OnInit {
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private translateService: TranslateService,
    private notification: NotificationService,
    private purchasingService: PurchasingService,
    private ReceiptsServ: FinancialService,
    private paginationService: PaginationService
  ) { }

  ngOnInit(): void {
    this.pageSize = this.paginationService.getPaginationOptions().pageSize;
    this.pagenationSizeList = this.paginationService.getPaginationOptions().pagenationSizeList;
    this.pagenationSize = { value: this.pageSize };

    this.setLanguageSubscriber();
    this.getResourceKeys();
    this.getVendorLookup();
    this.getInventoryLookup();
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

  //page
  pageSize;
  pageIndex: number = 0;
  total: number;
  skip = 0;
  gridView: GridDataResult;
  data: any[];
  searchForm: FormGroup;
  searchModel: Search;
  language: any;
  itemIdToDelete: any;
  showAdvancedSearch: boolean = false;
  vendors: any[] = [];// BranchLookup[] = [];
  inventorys: any[] = [];
  list: any[] = [];
  ListLoading: boolean = false;

  public state: State = {
    // Initial filter descriptor
    filter: {
      logic: 'and',
      filters: []
    }
  };
  vendorId: any;
  inventoryId: any;
  public VendorsDropDownData: Array<KendoDropDown>;
  public InventorysDropDownData: Array<KendoDropDown>;
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };

  postSearch: PostSearch = new PostSearch();
  filter: any;
  vendor: number;
  inventory: number;
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

  vendorChange(event) {
    //debugger;
    this.pageIndex = 0;
    this.postSearch.vendor = event.value;
    this.vendor = this.postSearch.vendor;
    this.getList();
  }
  inventoryChange(event) {
    //debugger;
    this.pageIndex = 0;
    this.postSearch.inventory = event.value;
    this.inventory = this.postSearch.inventory;
    this.getList();
  }

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
          this.postSearch.dateTo = new Date(Date.now()).toISOString().substring(0, 10);
        }

        if (this.filter[_i].field == "id") {
          this.postSearch.id = this.filter[_i].value;
        }

        if (this.filter[_i].field == "date") {
          this.postSearch.dateFrom = this.filter[_i].value.toISOString().substring(0, 10);
          this.postSearch.dateTo = new Date(Date.now()).toISOString().substring(0, 10);
        }
      }
      this.postSearch.filters = this.filter;
      this.pageIndex = 0;
    } else {
      this.postSearch = new PostSearch();
      this.postSearch.vendor = this.vendor;
      this.postSearch.inventory = this.inventory;
    }
    //debugger;
    this.postSearch.sort = this.state.sort;
    this.getList();
  }

  public pageChange(event: PageChangeEvent): void {
    this.pageIndex = (event.skip / this.pageSize);

    let url = [`/purchase-rebate/list/${this.pageIndex}`];
    this.router.navigate(url)
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

  getVendorLookup() {
    this.ReceiptsServ.getVendorsLookup()
      .subscribe(res => {
        var array = new Array<any>();

        array.push(this.createAllFilter());

        res.forEach(function (item) {
          var record = new KendoDropDown();
          record.text = item.name;
          record.value = item.id;
          array.push(record);
        });
        this.VendorsDropDownData = array;
      },
        (error) => {
          this.notification.showOperationFailed();
        }
      );
  }

  getInventoryLookup() {
    this.ReceiptsServ.getStoreLookup()
      .subscribe(res => {
        var array = new Array<any>();

        array.push(this.createAllFilter());

        res.forEach(function (item) {
          var record = new KendoDropDown();
          record.text = item.name;
          record.value = item.id;
          array.push(record);
        });
        this.InventorysDropDownData = array;
      },
        (error) => {
          this.notification.showOperationFailed();
        }
      );
  }

  getList() {
    this.postSearch.pageSize = this.pageSize;
    this.postSearch.pageIndex = this.pageIndex;
    this.ListLoading = true;

    this.postSearch.vendor = (this.vendorId ? this.vendorId.value : this.vendorId);
    this.postSearch.inventory = (this.inventoryId ? this.inventoryId.value : this.inventoryId);
    //debugger
    this.purchasingService.getPurchaseRebatesByPost(this.postSearch)
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
    let url = [`/purchasing/purchase-rebate/list`];
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