import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { process, State } from '@progress/kendo-data-query';

import { PostSearch } from '../../Models/search.model';
//import {PurchasingService} from '../../Services/Purchasing.service';
//import { BankingService } from '../../Services/banking.service';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { GridDataResult, PageChangeEvent, GridComponent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
//import { FinancialService } from '../../../Financial/Services/financial.service';
import { AssetInventoryService } from '../../Services/asset-inventory.service';
import { PaginationOptions } from '../../../../SharedFeatures/SharedMain/Models/pagination-options.model';
import { PaginationService } from '../../../../SharedFeatures/SharedMain/Services/pagination.service';
import { LocationService } from '../../../Location/Services/location.service';
import { LocationLight } from 'src/app/BusinessFeatures/Location/Models/location.model';

@Component({
  selector: 'asset-inventory-list',
  styleUrls: ['./asset-inventory-list.component.scss'],
  templateUrl: './asset-inventory-list.component.html'
})
export class AssetInventoryListComponent implements OnInit {
  loadingtext: any;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private translateService: TranslateService,
    private notification: NotificationService,
    //private purchasingService: PurchasingService,
    //private bankingService: BankingService,
    //private ReceiptsServ: FinancialService,
    private locationService: LocationService,
    private assetInventoryService: AssetInventoryService,
    private paginationService: PaginationService
  ) { }

  ngOnInit(): void {
    this.translateService.get('shared.loading').subscribe(
      success => {
        debugger;
        this.loadingtext = success;
        console.log("translation now " + success);
      });
    this.pageSize = this.paginationService.getPaginationOptions().pageSize;
    this.pagenationSizeList = this.paginationService.getPaginationOptions().pagenationSizeList;
    this.pagenationSize = {value: this.pageSize};

    this.setLanguageSubscriber();
    this.getResourceKeys();
    //this.getBankLookup();
    //this.getJournalTypesLookup();
    this.getLocationsLookup();
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
  private locations: any[];
  searchForm: FormGroup;
  //searchModel: Search;
  language: any;
  itemIdToDelete: any;
  showAdvancedSearch: boolean = false;
  banks: any[] = [];// BranchLookup[] = [];
  journalTypes: any[] = [];
  list: any[] = [];
  ListLoading: boolean = false;

  public state: State = {
    // Initial filter descriptor
    filter: {
      logic: 'and',
      filters: []
    }
  };
  bankId: any;
  journalTypeId: any;
  public banksDropDownData: Array<KendoDropDown>;
  public journalTypesDropDownData: Array<KendoDropDown>;
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };

  postSearch: PostSearch = new PostSearch();
  //postSearch: any;
  filter: any;
  bank: number;
  journalType: number;
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

  bankChange(event) {
    //debugger;
    this.pageIndex = 0;
    //this.postSearch.bank = event.value;
    //this.bank = this.postSearch.bank;
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
          this.filter.splice( _i,1);      
        } else {
          this.postSearch.dateFrom = new Date(new Date().setMonth(new Date().getMonth() - 1)).toISOString().substring(0, 10);
          this.postSearch.dateTo = new Date(Date.now()).toISOString().substring(0, 10);
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
      //this.postSearch.bank = this.bank;
      //this.postSearch.journalType = this.journalType;
    }
    //debugger;
    this.postSearch.sort = this.state.sort;
    this.getList();
  }

  public pageChange(event: PageChangeEvent): void {

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

  // createAllFilter(): KendoDropDown {
  //   let record = new KendoDropDown();
  //   record.text = this.allKey;
  //   record.value = null;

  //   return record;
  // }

  // getBankLookup() {
  //   this.bankService.getBanksLookups()
  //     .subscribe(res => {
  //       var array = new Array<any>();

  //       array.push(this.createAllFilter());

  //       res.collection.forEach(function (item) {
  //         var record = new KendoDropDown();
  //         record.text = item.name;
  //         record.value = item.id;
  //         array.push(record);
          
  //       });
  //       this.banksDropDownData = array;
  //     },
  //       (error) => {
  //         this.notification.showOperationFailed();
  //       }
  //     );
  // }

 
  getLocationsLookup() {
    let location: LocationLight = new LocationLight();
    location.displyedName = this.loadingtext;
    let loodingArray = new Array();
    this.locationService.getLocationsLookups()
      .subscribe(res => {
        //this.PageLoading = false;
        debugger;
        this.locations = [{
            id: null,
            displyedName: this.allKey
        }];
        res.collection.forEach(x => {

          loodingArray.push(location)
          x.childLocations = loodingArray;
          this.locations.push(x);
          debugger;
        });
        //this.locations = res.collection;
        

      },
        (error) => {
          //this.PageLoading = false;

          this.notification.showOperationFailed();
        }, () => {
        });
  }

  locationvalueChange(event) {
    this.postSearch.locationId = event;
    this.pageIndex = 0;
    this.getList();
  }

  locationExpandOutPutEvent(event) {
    debugger;
    let location: LocationLight = new LocationLight();
    location.displyedName = this.loadingtext;
    let loodingArray = new Array();
    this.locationService.getLocationChildren(event.dataItem.id).subscribe(res => {


      res.forEach(x => {
        loodingArray.push(location)
        x.childLocations = loodingArray;
        debugger;
      });



      event.dataItem.childLocations = res;
      console.log(event.dataItem)
    });
    event.dataItem.childLocations.splice(0, 1);
  }

  getList() {
    this.postSearch.pageSize = this.pageSize;
    this.postSearch.pageIndex = this.pageIndex;
    this.ListLoading = true;

    //this.postSearch.bank = (this.bankId ? this.bankId.value : this.bankId);
    //debugger
    this.assetInventoryService.getassetInventorysByPost(this.postSearch)
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
    let url = [`/asset/asset-inventory-list/list`];
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