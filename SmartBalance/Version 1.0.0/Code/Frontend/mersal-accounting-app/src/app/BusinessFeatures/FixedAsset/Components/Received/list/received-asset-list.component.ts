import { PostSearch } from './../../../Models/search.model';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { process, State } from '@progress/kendo-data-query';
import { NotificationService } from '../../../../../SharedFeatures/SharedMain/Services/notification.service';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { GridDataResult, PageChangeEvent, GridComponent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { KendoDropDown } from '../../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { PaginationOptions } from '../../../../../SharedFeatures/SharedMain/Models/pagination-options.model';
import { PaginationService } from '../../../../../SharedFeatures/SharedMain/Services/pagination.service';
import { FinancialService } from '../../../../Financial/Services/financial.service';
import { FixedAssetService } from '../../../Services/fixed-asset.service';
import {PurchaseInvoice} from '../../../../Purchasing/Models/purchase-invoice.model';
import { PurchasingService } from '../../../../Purchasing/Services/Purchasing.service';
import { LocationService } from '../../../../Location/Services/location.service';
import { BrandService } from '../../../../Brand/Services/brand.service';
import { BrandLight } from 'src/app/BusinessFeatures/Brand/Models/brand.model';
import { LocationLight } from 'src/app/BusinessFeatures/Location/Models/location.model';

@Component({
  selector: 'app-list',
  templateUrl: './received-asset-list.component.html',
  styleUrls: ['./received-asset-list.component.css']
})
export class ListReceivedAssetComponent implements OnInit {
  loadingtext: string;
  brandRequired: boolean;
  locationRequired: boolean;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private notification: NotificationService,
    private ReceiptsServ: FinancialService,
    private purchasingService: PurchasingService,
    private locationService: LocationService,
    private fixedAssetService: FixedAssetService,
    private brandService: BrandService,
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
    this.getBrandsLookup();
    this.getAccountChartsLookup();
    this.getPurchaseInvoicesLookup();
    this.getLocationsLookup();
    this.getdepreciationRatesLookup();
    this.getdepreciationTypeLookups();
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
  //searchModel: Search;
  language: any;
  private brands: any[];
  private locations: any[];
  private depreciationRates: any[];
  private depreciationTypes: any[];
  private accountCharts: any[];
  private PurchaseInvoices: any[];
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

  // brandChange(event) {
  //   debugger;
  //   this.pageIndex = 0;
  //   this.postSearch.brandId = event.id;
  //   this.getList();
  // }

  locationChange(event) {
    debugger;
    this.pageIndex = 0;
    this.postSearch.locationId = event.id;
    this.getList();
  }

  depreciationRateChange(event) {
    debugger;
    this.pageIndex = 0;
    this.postSearch.depreciationRateId = event.id;
    this.getList();
  }

  depreciationTypeChange(event) {
    debugger;
    this.pageIndex = 0;
    this.postSearch.depreciationTypeId = event.id;
    this.getList();
  }

  accountChartChange(event) {
    debugger;
    this.pageIndex = 0;
    this.postSearch.accountChartId = event.id;
    this.getList();
  }

  purchaseInvoiceChange(event) {
    debugger;
    this.pageIndex = 0;
    this.postSearch.PurchaseInvoiceId = event.id;
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

          //this.filter.splice( _i,1);      
        } else {

        }



        if (this.filter[_i].field == "brandName") {
          this.postSearch.brandId = this.filter[_i].value;
        }

        if (this.filter[_i].field == "locationName") {
          this.postSearch.locationId = this.filter[_i].value;
        }

        if (this.filter[_i].field == "depreciationRateName") {
          this.postSearch.depreciationRateId = this.filter[_i].value;
        }

        if (this.filter[_i].field == "depreciationTypeName") {
          this.postSearch.depreciationTypeId = this.filter[_i].value;
        }

        if (this.filter[_i].field == "accountChartName") {
          this.postSearch.accountChartId = this.filter[_i].value;
        }

        if (this.filter[_i].field == "PurchaseInvoiceCode") {
          this.postSearch.PurchaseInvoiceId = this.filter[_i].value;
        }

        if (this.filter[_i].field == "depreciationValue") {
          this.postSearch.depreciationValueTo = this.filter[_i].value;
        }
      }
      this.postSearch.filters = this.filter;
      this.pageIndex = 0;
    } 
    else {
      this.postSearch = new PostSearch();

    }
debugger;
    this.postSearch.sort = this.state.sort;
    this.getList();
  }

  public pageChange(event: PageChangeEvent): void {
    this.pageIndex = (event.skip / this.pageSize);

    let url = [`/asset/receive-asset-list/list/${this.pageIndex}`];
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

  getBrandsLookup() {
    debugger;
   let brand: BrandLight = new BrandLight();
    brand.displyedName = this.loadingtext;
    let loodingArray = new Array();
    loodingArray.push(loodingArray); 
    
    this.brandService.getBrandsLookups()
      .subscribe(res => {
        //this.PageLoading = false;
        this.brands = [{
          id: null,
          displyedName: this.allKey
        }];
        res.collection.forEach(x =>{
          this.brands.push(x);
        })
        res.collection.forEach(x => {
          x.childBrands = loodingArray;
        });
        //this.brands = res.collection;
        console.info(this.brands);
      },
        (error) => {
          //this.PageLoading = false;

          this.notificationService.showOperationFailed();
        }, () => {
        });
  }

  brandvalueChange($event) {
    debugger;
    this.pageIndex = 0;
    this.postSearch.brandId = $event;
    this.brandRequired = false;
    this.getList();


    //let p = this.PurchaseInvoices.find(x => x.products.find(v => v.BrandId == $event))
    // this.editorForm.patchValue({
    //   amount: [null],
    //   quantity: [null]
    // });
  }

  brandExpand(event) {
    debugger;
    let brand: BrandLight = new BrandLight();
    brand.displyedName = this.loadingtext;
    let loodingArray = new Array();
    loodingArray.push(loodingArray);
    this.brandService.getBrandChildren(event.dataItem.id).subscribe(res => {
      res.forEach(x => {
        x.childBrands = loodingArray;
      });
      event.dataItem.childBrands = res;
    });
  }


  getAccountChartsLookup() {
    this.ReceiptsServ.getAccountChartsLookup()
      .subscribe(res => {
        //this.PageLoading = false;

        this.accountCharts = res;

      },
        (error) => {
          //this.PageLoading = false;

          this.notificationService.showOperationFailed();
        }, () => {
        });
  }

  getPurchaseInvoicesLookup() {
    debugger;
    this.purchasingService.getAllPurchaseInvoices()
      .subscribe(res => {
        debugger;
        //this.PageLoading = false;
        this.PurchaseInvoices = res.collection;
        console.info(res);

      },
        (error) => {
          //this.PageLoading = false;
          debugger;
          this.notificationService.showOperationFailed();
        }, () => {
          debugger;
        });
  }

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

          this.notificationService.showOperationFailed();
        }, () => {
        });
  }

  locationvalueChange(event) {
    this.postSearch.locationId = event;
    this.locationRequired = false;
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

  getdepreciationRatesLookup() {
    this.fixedAssetService.getdepreciationRatesLookups()
      .subscribe(res => {
        //this.PageLoading = false;

        //this.depreciationRates = res.collection;
        this.depreciationRates = [{
          id: null,
          displyedName: this.allKey
        }];
        res.collection.forEach(item => {
          this.depreciationRates.push(item);
        });
      },
        (error) => {
          //this.PageLoading = false;

          this.notificationService.showOperationFailed();
        }, () => {
        });
  }

  getdepreciationTypeLookups() {
    this.fixedAssetService.getdepreciationTypeLookups()
      .subscribe(res => {
        //this.PageLoading = false;

        //this.depreciationTypes = res.collection;
        this.depreciationTypes = [{
          id: null,
          displyedName: this.allKey
        }];
        res.collection.forEach(item => {
          this.depreciationTypes.push(item);
        });
      },
        (error) => {
          //this.PageLoading = false;

          this.notificationService.showOperationFailed();
        }, () => {
        });
  }


 

  getList() {
    this.postSearch.pageSize = this.pageSize;
    this.postSearch.pageIndex = this.pageIndex;
    this.ListLoading = true;

    //this.postSearch.bank = (this.bankId ? this.bankId.value : this.bankId);
    //debugger
    this.fixedAssetService.getFixedAssetsByPost(this.postSearch)
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
 
  gotoList() {
    let url = [`/asset/receive-asset-list/list`];
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
