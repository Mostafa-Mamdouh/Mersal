import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { EditorMode } from '../../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { FixedAsset } from '../../../Models/fixed-asset.model';
import { NotificationService } from '../../../../../SharedFeatures/SharedMain/Services/notification.service';
import { PurchasingService } from '../../../../Purchasing/Services/Purchasing.service';
import { FinancialService } from '../../../../Financial/Services/financial.service';
import { FixedAssetService } from '../../../Services/fixed-asset.service';
import { PurchaseInvoice } from '../../../../Purchasing/Models/purchase-invoice.model';
import { LocationService } from '../../../../Location/Services/location.service';
import { LocationLight } from '../../../../Location/Models/location.model';
import { BrandService } from '../../../../Brand/Services/brand.service';
import { VendorService } from '../../../../Vendor/Services/vendor.service';
import { LocationModel } from '../../../../Location/Models/location.model';
import { Location } from '@angular/common';
import { ErrorService } from '../../../../../SharedFeatures/SharedMain/Services/error.service';
import { BrandLight } from '../../../../Brand/Models/brand.model';
import { CostCenterService } from '../../../../CostCenter/Services/cost-center.service';
import { EffiencyRaise } from 'src/app/SharedFeatures/SharedMain/Models/effiency-raise.model';

@Component({
  selector: 'received-asset-editor',
  styleUrls: ['./received-asset-editor.component.scss'],
  templateUrl: './received-asset-editor.component.html'
})
export class ReceivedAssetEditorComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private purchasingService: PurchasingService,
    private locationService: LocationService,
    private fixedAssetService: FixedAssetService,
    private brandService: BrandService,
    private vendorService: VendorService,
    private location: Location,
    private costCenterService: CostCenterService,
    private errorService: ErrorService
  ) { }

  ngOnInit(): void {
    this.translateService.get('shared.loading').subscribe(
      success => {
        debugger;
        this.loadingtext = success;
        console.log("translation now " + success);
      });
    this.buildForm();
    this.getCostCenters();
    this.getAccountChartsLookup();
    this.getPurchaseInvoicesLookup();
    this.getdepreciationRatesLookup();
    this.getdepreciationTypeLookups();
    this.getBrandsLookup();
    this.getvendorServicesLookup();
    this.extractRouteParams();
    this.getLocationsLookup();
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      ///brand: [null, [Validators.required]],
      //locationId: [null, [Validators.required]],
      accountChartId: [null, [Validators.required]],
      depreciationValue: [null, [Validators.required, Validators.min(1)]],
      depreciationRate: [null, [Validators.required]],
      depreciationType: [null, [Validators.required]],
      startDepreciationDate: [new Date(), Validators.required],
      PurchaseInvoice: [null],
      descriptionAr: [null],
      descriptionEn: [null],
      serial: [null],
      model: [null],
      color: [null],
      size: [null],
      status: [null],
      costCenterId: [null],
      Properties: [null],
      date: [new Date()],
      vendor: [null],
      amount: [null, Validators.required],
      quantity: [null, Validators.required]
    });

    this.editorForm.valueChanges
      .subscribe(res => {
        //debugger;
      });
  }

  extractRouteParams(): void {
    //debugger;
    let editId = +this.route.snapshot.params['editId'];
    let detailId = +this.route.snapshot.params['detailId'];

    if (editId) {
      this.editorMode = EditorMode.edit
      this.invoiceDetail = true;
      this.id = editId;
    }
    else if (detailId) {
      this.editorMode = EditorMode.detail;
      this.invoiceDetail = true;
      this.id = detailId;
    }
    else {
      this.editorMode = EditorMode.add;
    }

    if (this.id) {
      this.fixedAssetService.getFixedAsset(this.id)
        .subscribe(res => {
          debugger;
          this.itemModel = res;
          this.bindModelToForm();
        },
          (error) => {
            this.notificationService.showOperationFailed();
          })
    }
  }

  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }
  gotoList() {
    let url = [`/asset/receive-asset-list/list`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  onOneCostCenterChanged(id) {

  }

  //lookups

  getCostCenters() {
    this.costCenterService.getCostCentersLookups()
      .subscribe(
        res => {
          debugger;
          //this.PageLoading = false;         
          this.costCenterDropDown = res.collection;
        },
        // this.Branches = res,
        error => {
          //this.PageLoading = false;         
          //this.notificationService.showOperationFailed();
        }

      );
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

    this.purchasingService.getAllPurchaseInvoices()
      .subscribe(res => {
        debugger;
        //this.PageLoading = false;
        this.PurchaseInvoices = res.collection;
        // for (let index = 0; index < this.PurchaseInvoices.length; index++) {
        //   this.brands.push(this.PurchaseInvoices[index].brands);

        // }

        console.info(res);
        console.info(this.brands);

      },
        (error) => {
          //this.PageLoading = false;
          debugger;
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
        res.collection.forEach(x => {

          loodingArray.push(location)
          x.childLocations = loodingArray;
          debugger;
        });
        this.locations = res.collection;

      },
        (error) => {
          //this.PageLoading = false;

          this.notificationService.showOperationFailed();
        }, () => {
        });
  }

  getdepreciationRatesLookup() {
    this.fixedAssetService.getdepreciationRatesLookups()
      .subscribe(res => {
        //this.PageLoading = false;

        this.depreciationRates = res.collection;

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

        this.depreciationTypes = res.collection;

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
        res.collection.forEach(x => {
          x.childBrands = loodingArray;
        });
        this.brands = res.collection;
        console.info(this.brands);
      },
        (error) => {
          //this.PageLoading = false;

          this.notificationService.showOperationFailed();
        }, () => {
        });
  }

  getvendorServicesLookup() {
    debugger;
    this.vendorService.getVendorsLookups()
      .subscribe(res => {
        //this.PageLoading = false;

        this.vendors = res.collection;
        console.info(res);

      },
        (error) => {
          //this.PageLoading = false;

          this.notificationService.showOperationFailed();
        }, () => {
        });
  }

  brandvalueChange($event) {
    debugger;
    this.itemModel.brandId = $event;
    this.brandRequired = false;
    let brand = this.brands.find(b => b.id == $event);
    let invoice = this.PurchaseInvoices.find(g => g.id == this.editorForm.controls['PurchaseInvoice'].value);
    if (invoice) {
      let prod = invoice.products.find(n => n.brandId == $event);

      //this.editorForm.controls['brand'].setValue(this.itemModel.brandId);

      this.editorForm.controls['quantity'].setValue(prod.quantity);
      this.editorForm.controls['amount'].setValue(prod.price);
    }


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

  locationvalueChange(event) {
    this.itemModel.locationId = event;
    this.locationRequired = false;
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
  PurchaseInvoicevalueChange($event) {
    debugger;
    if ($event) {
      this.invoiceDetail = true;
      //this.editorForm.controls['brand'].setValue(null);
      this.itemModel.brandId = undefined;
      let PurchaseInvoice = this.PurchaseInvoices.find(p => p.id == $event);
      this.brands = PurchaseInvoice.brands;
      this.editorForm.patchValue({
        date: new Date(PurchaseInvoice.date),
        vendor: PurchaseInvoice.vendorId,
        quantity: null,
        amount: null
      });
    }
    else {
      this.invoiceDetail = false;
      this.getBrandsLookup();
      this.editorForm.patchValue({
        date: new Date(),
        vendor: null,
        quantity: null,
        amount: null
      });
    }
  }
  addNewEffiencyRaise(effiencyRaise){
    this.itemModel.raiseAmount=effiencyRaise.raiseAmount;
    this.itemModel.raiseDate=effiencyRaise.raiseDate;
    this.notificationService.showEffiencyRaiseSuccessed();
    
  }
  addNewlocation(location) {
    debugger;
    this.newLocation = location;
    this.itemModel.location = location;
    this.isNewlocation = true;
    //this.editorForm.controls['locationId'].setValue(null);
    //this.editorForm.controls['locationId'].clearValidators();
    //this.editorForm.controls['locationId'].updateValueAndValidity();
    this.locationRequired = false;
    this.notificationService.showOperationSuccessed();

    console.log("location insider obj " + this.itemModel.location);
    console.log("location insider obj " + this.isNewlocation);
  }

  cancelNewlocation() {
    this.isNewlocation = false;
    this.newLocation = null;
    this.itemModel.location = null;
    this.locationRequired = true;
    //this.editorForm.controls['locationId'].setValidators([Validators.required]);
    //this.editorForm.controls['locationId'].updateValueAndValidity();

  }

  bindModelToForm(): void {
    debugger;
    if (this.itemModel) {
      this.editorForm.patchValue({
        //brand: this.itemModel.brandId,
        //code: this.itemModel.id,
        //locationId: this.itemModel.locationId,
        // isDebt: this.itemModel.isDebt,

        depreciationValue: this.itemModel.depreciationValue,
        depreciationRate: this.itemModel.depreciationRateId,
        depreciationType: this.itemModel.depreciationTypeId,
        startDepreciationDate: new Date(this.itemModel.startDepreciationDate),
        PurchaseInvoice: this.itemModel.purchaseInvoiceId,
        Properties: this.itemModel.properties,
        descriptionAr: this.itemModel.descriptionAr,
        descriptionEn: this.itemModel.descriptionEn,
        serial: this.itemModel.serial,
        model: this.itemModel.model,
        color: this.itemModel.color,
        size: this.itemModel.size,
        status: this.itemModel.status,
        //costCenterId: this.itemModel.costCenterId,
        nameAr: this.itemModel.nameAr,
        nameEn: this.itemModel.nameEn,
        accountChartId: this.itemModel.accountChartId,
        date: new Date(this.itemModel.date),
        vendor: this.itemModel.vendor,
        amount: this.itemModel.amount,
        quantity: this.itemModel.quantity

      });

      debugger;
      if (this.itemModel.costCenterId && this.costCenterDropDown) {
        let costCenter = this.costCenterDropDown.find(x => x.id == this.itemModel.costCenterId);
        this.editorForm.controls['costCenterId'].setValue(costCenter);
      }
      console.log(this.itemModel);
    }
  }
  collectModelFromForm(): void {
    debugger;
    //this.itemModel.brandId = this.editorForm.controls["brand"].value;
    //this.itemModel.locationId = this.editorForm.controls["locationId"].value;
    //this.itemModel.isDebt = this.editorForm.controls["isDebt"].value;
    this.itemModel.purchaseInvoiceId = this.editorForm.controls["PurchaseInvoice"].value;
    this.itemModel.properties = this.editorForm.controls["Properties"].value;
    this.itemModel.descriptionAr = this.editorForm.controls["descriptionAr"].value;
    this.itemModel.descriptionEn = this.editorForm.controls["descriptionEn"].value;
    this.itemModel.serial = this.editorForm.controls["serial"].value;
    this.itemModel.model = this.editorForm.controls["model"].value;
    this.itemModel.color = this.editorForm.controls["color"].value;
    this.itemModel.size = this.editorForm.controls["size"].value;
    this.itemModel.status = this.editorForm.controls["status"].value;
    if (this.editorForm.controls['costCenterId'].value) {
      this.itemModel.costCenterId = this.editorForm.controls['costCenterId'].value.id;
    }
    this.itemModel.accountChartId = this.editorForm.controls["accountChartId"].value;
    this.itemModel.depreciationRateId = this.editorForm.controls["depreciationRate"].value;
    this.itemModel.depreciationTypeId = this.editorForm.controls["depreciationType"].value;
    this.itemModel.depreciationValue = this.editorForm.controls["depreciationValue"].value;
    this.itemModel.startDepreciationDate = this.editorForm.controls["startDepreciationDate"].value;
    this.itemModel.purchaseInvoiceId = this.editorForm.controls["PurchaseInvoice"].value;


    this.itemModel.date = this.editorForm.controls["date"].value;
    this.itemModel.vendor = this.editorForm.controls["vendor"].value;
    this.itemModel.amount = this.editorForm.controls["amount"].value;
    this.itemModel.quantity = this.editorForm.controls["quantity"].value;


    this.itemModel.accountChartId = this.editorForm.controls["accountChartId"].value;
    if (this.itemModel.accountChartId && this.itemModel.accountChartId.value) {
      this.itemModel.accountChartId = this.itemModel.accountChartId.value;
    }
  }

  save(): void {
    debugger;
    if (this.canEdit()) {
      this.isProccessing = true;

      if (this.editorForm.valid) {
        if (this.editorMode == EditorMode.add) {
          this.collectModelFromForm();
          if (this.itemModel.brandId == undefined) {
            this.brandRequired = true;
            this.notificationService.showDataMissingError();
            this.isProccessing = false;
          }
          else if (this.itemModel.locationId == undefined && !this.isNewlocation) {
            this.locationRequired = true;
            this.notificationService.showDataMissingError();
            this.isProccessing = false;
          }
          else {
            this.isProccessing = true;
            debugger;
            this.fixedAssetService.addFixedAsset(this.itemModel)
              .subscribe(res => {
                this.notificationService.showOperationSuccessed();
                this.isProccessing = false;
                this.gotoList();
              },
                (error) => {
                  //debugger;
                  this.isProccessing = false;
                  this.errorService.handerErrors(error);
                },
                () => {
                  console.log(`addBank completed.`);
                });
          }
        }
        else if (this.editorMode == EditorMode.edit) {
          this.collectModelFromForm();
          this.fixedAssetService.updateFixedAsset(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();
              this.gotoList();
            },
              (error) => {
                //debugger;
                this.isProccessing = false;
                this.errorService.handerErrors(error);
              },
              () => {
                console.log(`updateBank completed.`);
              });
        }
      }
      else {
        this.isProccessing = false;
        this.notificationService.showDataMissingError();
      }
    }
  }
  effiencyRaiseModel : EffiencyRaise;
  PageLoading: boolean;
  private editorForm: FormGroup;
  private editorMode: EditorMode = EditorMode.add;
  private editorModeEnum = EditorMode;
  private id: any;
  private isProccessing: boolean;
  private invoiceDetail: boolean = false;
  private brands: any[] = [];
  private locations: any[];
  
  private depreciationRates: any[];
  private depreciationTypes: any[];
  private accountCharts: any[];
  private PurchaseInvoices: PurchaseInvoice[];
  private vendors: any[];
  private newLocation: LocationModel;
  private isNewlocation: boolean;
  private itemModel: FixedAsset = new FixedAsset();
  costCenterDropDown: any[];
  locationRequired: boolean = false;
  brandRequired: boolean = false;
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
  loadingtext: string;
}

