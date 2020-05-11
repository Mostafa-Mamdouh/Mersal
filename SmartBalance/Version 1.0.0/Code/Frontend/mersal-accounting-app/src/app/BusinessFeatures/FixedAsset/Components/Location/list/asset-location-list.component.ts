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
import { FixedAssetService } from '../../../Services/fixed-asset.service';
import { LocationService } from '../../../../Location/Services/location.service';
import { AssetLocationService } from '../../../Services/asset-location.service';
import { PostSearch } from './../../../Models/search.model';
import { BrandLight } from 'src/app/BusinessFeatures/Brand/Models/brand.model';
import { BrandService } from 'src/app/BusinessFeatures/Brand/Services/brand.service';
import { LocationLight } from 'src/app/BusinessFeatures/Location/Models/location.model';

@Component({
  selector: 'asset-location-list',
  templateUrl: './asset-location-list.component.html',
  styleUrls: ['./asset-location-list.component.css']
})
export class AssetLocationListComponent implements OnInit {
  loadingtext: any;
  brands: any[];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private notification: NotificationService,
    private locationService: LocationService,
    private fixedAssetService: FixedAssetService,
    private paginationService: PaginationService,
    private assetLocationService: AssetLocationService,
    private brandService: BrandService,
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
    this.pagenationSize = { value: this.pageSize };

    this.setLanguageSubscriber();
    this.getResourceKeys();
    this.getFixedAssetsLookups();
    this.getBrandsLookup();
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


  getResourceKeys() {
    this.translateService.get([
      'shared.all'
    ]).subscribe(res => {
      if (res) {
        this.allKey = res['shared.all'];
      }
    });
  }

  brandvalueChange($event) {
    debugger;
    this.pageIndex = 0;
    this.postSearch.assetId = $event;
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

        if (this.filter[_i].field == "asset") {
          this.postSearch.brandId = this.filter[_i].value;
        }

        if (this.filter[_i].field == "location") {
          this.postSearch.locationId = this.filter[_i].value;
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

    let url = [`/asset/asset-location-list/list/${this.pageIndex}`];
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

  getFixedAssetsLookups() {
    let brand: BrandLight = new BrandLight();
    brand.displyedName = this.loadingtext;
    let loodingArray = new Array();
    loodingArray.push(loodingArray);
    this.fixedAssetService.getFixedAssetsLookups()
      .subscribe(res => {
        //this.PageLoading = false;       
        this.assets = [{
          id: null,
          brandName: this.allKey
        }];
        res.collection.forEach(item => {
          this.assets.push(item);
        });
        res.collection.forEach(x => {
          x.childBrands = loodingArray;
        });
        console.log(res);
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


  getList() {
    this.postSearch.pageSize = this.pageSize;
    this.postSearch.pageIndex = this.pageIndex;
    this.ListLoading = true;

    //debugger
    this.assetLocationService.getassetLocationsByPost(this.postSearch)
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

  gotoList() {
    let url = [`/asset/asset-location-list/list`];
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
  language: any;  
  private locations: any[];
  assets: any[];
  list: any[] = [];
  ListLoading: boolean = false;

  public state: State = {
    // Initial filter descriptor
    filter: {
      logic: 'and',
      filters: []
    }
  };
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };

  postSearch: PostSearch = new PostSearch();
  filter: any; 
  allKey: string;
  pagenationSize: any;
  pagenationSizeList: any[];
}
