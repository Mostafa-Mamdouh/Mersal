import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { process, State } from '@progress/kendo-data-query';

import { PostSearch } from '../../Models/search.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { Validators, FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { GridDataResult, PageChangeEvent, GridComponent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { FinancialService } from '../../../Financial/Services/financial.service';
//import { ChecksUnderCollection} from '../../Models/checks-under-collection.model';
//import { SettingService } from '../../../Setting/Services/setting.service';
import { PaginationService } from '../../../../SharedFeatures/SharedMain/Services/pagination.service'
import { ExcludeService } from '../../Services/exclude.service';
import { FixedAssetService } from '../../Services/fixed-asset.service';
import { BrandService } from '../../../Brand/Services/brand.service';
import { Exclude } from '../../Models/fixed-asset.model';
import { elementDef } from '@angular/core/src/view';
import { BrandLight } from 'src/app/BusinessFeatures/Brand/Models/brand.model';


@Component({
  selector: 'exclude-collection-list',
  styleUrls: ['./exclude-editor.component.scss'],
  templateUrl: './exclude-editor.component.html'
})
export class ExcludeEditorComponent implements OnInit {
  loadingtext: string;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private translateService: TranslateService,
    private notificationService: NotificationService,
    private ReceiptsServ: FinancialService,
    private excludeService: ExcludeService,
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

    this.skip = this.pageIndex * this.pageSize;  

    this.setLanguageSubscriber();
    this.getResourceKeys();
    this.getAccountChartsLookup();
    this.getBrandsLookup();
    this.getList();
    this.buildForm();
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
  saleForm: FormGroup;
  //searchModel: Search;
  language: any;
  itemIdToDelete: any;
  isSaleing: boolean = false;
  showAdvancedSearch: boolean = false;
  list: any[] = [];
  itemModel: Exclude[] = [];
  ListLoading: boolean = false;
  accountCharts: any[];
  private brands: any[] = [];

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

  buildForm(): void {
    this.saleForm = this.fb.group({
      accountChartId: [null, Validators.required],
      saleAssets: this.fb.array([])
    });

    //   debugger;
    //   if(this.editorMode == EditorMode.add) {
    //     this.itemModel.code = res.code;
    //     this.itemModel.vendorInvoiceCode = res.vendorInvoiceCode;
    //     this.itemModel.vendorId = res.vendorId;
    //     if (this.itemModel.vendorId.value) {
    //       this.itemModel.vendorId = this.itemModel.vendorId.value;
    //     }
    //     this.itemModel.inventoryId = res.inventoryId;
    //     if (this.itemModel.inventoryId.value) {
    //       this.itemModel.inventoryId = this.itemModel.inventoryId.value;
    //     }
    //     this.itemModel.date = res.date;
    //     this.itemModel.additionalExpensesAmount = res.additionalExpensesAmount;
    //     this.itemModel.hasAdditionalExpenses = res.hasAdditionalExpenses;
    //     this.itemModel.discountAmount = res.discountAmount;
    //     this.itemModel.hasDiscount = res.hasDiscount;

    //     debugger;
    //     let hasCostCenter = this.isHasCostCenter();
    //     let costCenter = res.costCenterId;

    //     if (hasCostCenter && costCenter && costCenter.value) {
    //       this.itemModel.purchaseInvoiceCostCenters = [];
    //       let costCenterItem: PurchaseInvoiceCostCenter = new PurchaseInvoiceCostCenter();

    //       costCenterItem.costCenterId = costCenter.value;
    //       this.itemModel.purchaseInvoiceCostCenters.push(costCenterItem);
    //     }
    //   }
  }
  createAsset(assetId, brandCode): FormGroup {
    debugger;
    return this.fb.group({
      assetId: [assetId],
      brandCode: [brandCode],
      salePrice: [null, [Validators.required, Validators.pattern("^[0-9]+$")]]
    });
  }

  addAsset(assetId, brandCode) {
    const assets = this.saleForm.get('saleAssets') as FormArray;
    assets.push(this.createAsset(assetId, brandCode));
  }

  deleteAsset(item) {
    (this.saleForm.get('saleAssets') as FormArray).removeAt(item);
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

  isChecked: any[] = [];
  checkboxChange(e: any, id: any, code: any) {
    let item = { assetId: id, brandCode: code };
    let pushItem: boolean = true;
    debugger;
    let existItemIndex = this.list.findIndex(x => x.assetId == id);
    if (existItemIndex >= 0) {
      let existItem = this.list[existItemIndex];
      if (e == true) {
        pushItem = false;
      }
      else if (e == false) {
        pushItem = false;
        this.list.splice(existItemIndex, 1);
        this.deleteAsset(existItemIndex);
      }
    }

    if (pushItem) {
      this.list.push(item);
      this.addAsset(item.assetId, item.brandCode);

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

        this.accountCharts = res;

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


  accountChartChange(event) {
    debugger;
    this.pageIndex = 0;
    this.postSearch.accountChartId = event.id;
    this.getList();
  }


  getList() {
    this.postSearch.pageSize = this.pageSize;
    this.postSearch.pageIndex = this.pageIndex;
    this.ListLoading = true;
    this.list = [];
    this.isChecked = [];
    this.selectAllModel = false;
    
    //debugger
    this.excludeService.getExcludesByPost(this.postSearch)
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



  saveSpeculation() {
    for (let index = 0; index < this.list.length; index++) {
      this.list[index].isSpeculation = true;

    }
    this.excludeService.addExcludeCollection(this.list)
      .subscribe(res => {
        debugger;
        this.list = [];

        this.failedGridView = {
          data: res,
          total: res.length
        }
        //this.failedModal.click();
        //this.failedModal.nativeElement.click();
        console.info(res);
        //document.getElementById("btnHidenModal").click();
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

  saveSale() {
    debugger;
    for (let index = 0; index < (this.saleForm.get('saleAssets') as FormArray).controls.length; index++) {
      this.itemModel[index] = new Exclude();
      let assetId = ((this.saleForm.get('saleAssets') as FormArray).controls[index] as FormGroup).controls["assetId"].value;
      this.itemModel[index].assetId = assetId;
      let amount = ((this.saleForm.get('saleAssets') as FormArray).controls[index] as FormGroup).controls["salePrice"].value;
      this.itemModel[index].amount = amount;
      this.itemModel[index].IsSaled = true;
      let accountChartId = this.saleForm.get('accountChartId').value.id;
      this.itemModel[index].accountChartId = accountChartId;
    }
    this.excludeService.addExcludeCollection(this.itemModel)
      .subscribe(res => {
        debugger;
        this.list = [];
        this.isChecked = [];
        this.selectAllModel = false;

        this.failedGridView = {
          data: res,
          total: res.length
        }
        //this.failedModal.click();
        //this.failedModal.nativeElement.click();
        console.info(res);
        //document.getElementById("btnHidenModal").click();
        this.getList();
        this.notificationService.showOperationSuccessed();

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
        //let item = { : id, brandCode: code };
        this.list.push({
          assetId: this.gridView.data[index].id,
          brandCode: this.gridView.data[index].brandCode
        });
        this.addAsset(this.gridView.data[index].id, this.gridView.data[index].brandCode);
      }
      else {
        this.gridView.data[index].checked = false;
        this.deleteAsset(index);
        //this.list.splice(index, 1);
      }
    }
  }

  showSaleForm() {
    this.isSaleing = true;
  }
 
  gotoList() {
    let url = [`/asset/exclude`];
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
  isProccessing: boolean;
}