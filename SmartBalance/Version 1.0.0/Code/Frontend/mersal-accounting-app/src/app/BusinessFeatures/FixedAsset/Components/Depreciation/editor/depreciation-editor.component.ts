import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { process, State } from '@progress/kendo-data-query';

import { PostSearch } from '../../../Models/search.model';
import { NotificationService } from '../../../../../SharedFeatures/SharedMain/Services/notification.service';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { GridDataResult, PageChangeEvent, GridComponent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { KendoDropDown } from '../../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { FinancialService } from '../../../../Financial/Services/financial.service';
//import { ChecksUnderCollection} from '../../Models/checks-under-collection.model';
//import { SettingService } from '../../../Setting/Services/setting.service';
import { PaginationService } from '../../../../../SharedFeatures/SharedMain/Services/pagination.service'
import { DepreciationService } from '../../../Services/depreciation.service';
import { FixedAssetService } from '../../../Services/fixed-asset.service';
import { BrandService } from '../../../../Brand/Services/brand.service';
import { LocationService } from '../../../../Location/Services/location.service';
import { forEach } from '@angular/router/src/utils/collection';
import { elementDef } from '@angular/core/src/view';
import { BrandLight } from 'src/app/BusinessFeatures/Brand/Models/brand.model';
import { LocationLight } from 'src/app/BusinessFeatures/Location/Models/location.model';


@Component({
  selector: 'depreciation-collection-list',
  styleUrls: ['./depreciation-editor.component.scss'],
  templateUrl: './depreciation-editor.component.html'
})
export class DepreciationEditorComponent implements OnInit {
  loadingtext: any;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private translateService: TranslateService,
    private notificationService: NotificationService,
    private ReceiptsServ: FinancialService,
    private depreciationService: DepreciationService,
    private fixedAssetService: FixedAssetService,
    private brandService: BrandService,
    private locationService: LocationService,
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
    this.getAccountChartsLookup();
    this.getBrandsLookup();
    this.getLocationsLookup();
    this.getdepreciationRatesLookup();
    this.getList();
  }

  @ViewChild('exampleModal') exampleModal: ElementRef;
  @ViewChild('btnHidenModal') failedModal: ElementRef = ElementRef.prototype;

  //page
  pageSize;
  pageIndex: number = 0;
  total: number;
  skip = 0;
  gridView: GridDataResult;
  failedGridView: GridDataResult;
  data: any[];
  searchForm: FormGroup;
  //searchModel: Search;
  language: any;
  itemIdToDelete: any;
  showAdvancedSearch: boolean = false;
  list: any[] = [];
  ListLoading: boolean = false;
  private accountCharts: any[];
  private brands: any[] = [];
  private locations: any[];
  private depreciationRates: any[];

  public state: State = {
    // Initial filter descriptor
    filter: {
      logic: 'and',
      filters: []
    }
  };
  bankId: any;
  public BanksDropDownData: Array<KendoDropDown>;
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };

  postSearch: PostSearch = new PostSearch();
  filter: any;
  bank: number;
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

  isChecked: any[] = [];
  checkboxChange(e, id) {
    let item = { assetId: id };
    let pushItem: boolean = true;
    debugger;
    let existItemIndex = this.list.findIndex(x => x.assetId == id);
    if (existItemIndex >= 0) {
      let existItem = this.list[existItemIndex];
      if (e == true) {
        debugger;
        pushItem = true;
      }
      else if (e == false) {
        debugger;
        pushItem = false;
        this.list.splice(existItemIndex, 1);
      }
    }

    if (pushItem) {
      this.list.push(item);
    }

    //this.notification.showInfo(id + " " + JSON.stringify(event));
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
          //this.postSearch.dateFrom = x[0].value.toISOString().substring(0, 10);
          //this.postSearch.dateTo = x[1].value.toISOString().substring(0, 10);
          //this.filter.splice( _i,1);      
        } else {
          //this.postSearch.dateFrom = new Date(new Date().setMonth(new Date().getMonth() - 1)).toISOString().substring(0, 10);
          //this.postSearch.dateTo = new Date(Date.now()).toISOString().substring(0, 10);
        }

        // if (this.filter[_i].field == "code") {
        //     this.postSearch.code = this.filter[_i].value;
        // }

        // if (this.filter[_i].field == "date") {
        //     this.postSearch.dateFrom = this.filter[_i].value.toISOString().substring(0, 10);
        //     this.postSearch.dateTo = new Date(Date.now()).toISOString().substring(0, 10);
        // }

        // if (this.filter[_i].field == "amount") {
        //     this.postSearch.amount = this.filter[_i].value;
        // }
      }
      this.postSearch.filters = this.filter;
      this.pageIndex = 0;
    }
    else {
      this.postSearch = new PostSearch();
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

  createAllFilter(): KendoDropDown {
    let record = new KendoDropDown();
    record.text = this.allKey;
    record.value = null;

    return record;
  }

  getAccountChartsLookup() {
    this.ReceiptsServ.getAccountChartsLookup()
      .subscribe(res => {
        //this.PageLoading = false;

        //this.accountCharts = res;
        this.accountCharts = [{
          value: null,
          id: null,
          displyedName: this.allKey
        }];
        res.forEach(item => {
          this.accountCharts.push({
            value: item.id,
            id: item.id,
            displyedName: item.displyedName
          });
        });
      },
        (error) => {
          //this.PageLoading = false;

          this.notificationService.showOperationFailed();
        }, () => {
        });
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
          this.depreciationRates.push({
            id: item.id,
            displyedName: item.displyedName
          });
        });
      },
        (error) => {
          //this.PageLoading = false;

          this.notificationService.showOperationFailed();
        }, () => {
        });
  }

  brandChange(event) {
    debugger;
    this.pageIndex = 0;
    this.postSearch.brandId = event.id;
    this.getList();
  }

  locationChange(event) {
    debugger;
    this.pageIndex = 0;
    this.postSearch.locationId = event.id;
    this.getList();
  }

  accountChartChange(event) {
    debugger;
    this.pageIndex = 0;
    this.postSearch.accountChartId = event.id;
    this.getList();
  }

  depreciationRateChange(event) {
    debugger;
    this.pageIndex = 0;
    this.postSearch.depreciationRateId = event.id;
    this.getList();
  }

  getList() {
    this.postSearch.pageSize = this.pageSize;
    this.postSearch.pageIndex = this.pageIndex;
    this.ListLoading = true;
    this.gridView = { data: [], total: 0 };
    this.list = [];
    this.isChecked = [];

    //debugger
    this.depreciationService.getDepreciationsByPost(this.postSearch)
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
          this.notificationService.showOperationFailed();
          this.list = [];
        },
      );
  }

  save() {
    this.depreciationService.addDepreciationCollection(this.list)
      .subscribe(res => {
        debugger;
        this.list = [];
        this.selectAllModel = false;
        
        this.failedGridView = {
          data: res,
          total: res.length
        }
        //this.failedModal.click();
        //this.failedModal.nativeElement.click();
        console.info(res);
        document.getElementById("btnHidenModal").click();

        this.getList();
        //this.notificationService.showOperationSuccessed();

      },
        (error) => {
          debugger;
          //this.isChecked[id] = false;
          this.notificationService.showOperationFailed();
        },
        () => {

        });
  }

  setItemToDelete(id: any) {
    this.itemIdToDelete = id;
  }

  checkAll(event) {
    debugger;
    this.list = [];
    for (let index = 0; index < this.gridView.data.length; index++) {
      if (event) {
        this.gridView.data[index].checked = true;
        this.list.push({assetId: this.gridView.data[index].id});
      }
      else {
        this.gridView.data[index].checked = false;
        this.list.splice(index, 1);
      }
    }
  }
  
  gotoList() {
    let url = [`/asset/depreciation/add`];
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
  selectAllModel: boolean = false;
}