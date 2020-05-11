import { StoreService } from './../../../Services/store.service';
import { KendoDropDown } from './../../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { PurchasingService } from './../../../../Purchasing/Services/Purchasing.service';
import { FinancialService } from './../../../../Financial/Services/financial.service';
import { EditorMode } from './../../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { Location } from '@angular/common'

import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ProductList } from '../../../../Products/Models/product-list.model';
import { CostCenters } from '../../../../Financial/Models/receipts.model';
import { NotificationService } from '../../../../../SharedFeatures/SharedMain/Services/notification.service';
import { StoreStartBalance, StoreProducts } from '../../../Models/opening-balance.model';
import { ErrorService } from '../../../../../SharedFeatures/SharedMain/Services/error.service';

declare var $: any;

@Component({
  selector: 'opening-balance-editor',
  templateUrl: './opening-balance-editor.component.html',
  styleUrls: ['./opening-balance-editor.component.css']
})
export class OpeningBalanceEditorComponent implements OnInit {
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };
  model: StoreStartBalance;
  modelForm: FormGroup;
  bsDatePickerValue: Date = new Date();
  storeStartBalance: StoreStartBalance = new StoreStartBalance();
  products: StoreProducts[];
  DetailsCostCenters: any[];
  EditeCostCenters: any[];
  editorMode: EditorMode = EditorMode.add;
  editorModeEnum = EditorMode;
  id: any;
  SelectedCostCenter: number;
  totalCostCenters: number = 0;

  PageLoading: boolean = false;
  validForm: boolean = false;
  canEditPrice: boolean;

  ProductList: ProductList[];
  inventoryList: any[];
  costCenter: CostCenters[] = [];
  IsOneCostCenterChecked: boolean;
  CostCenterDropDown: any[];

  detailId: number;
  editId: number;
  CostCenters: any;
  productsCount : number=0 ; 


  constructor(
    private ReceiptsServ: FinancialService,
    private serv: PurchasingService,
    private storeServ: StoreService,
    public router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private notification: NotificationService,
    private location: Location,
    private errorService: ErrorService
    ) {

  }

  ngOnInit() {
    this.buildForms();
    this.getVendorsLookup();
    this.getCostCenters();
    this.getInventorysLookup();
    this.extractRouteParams();
  }

  extractRouteParams(): void {
    let editId = this.route.snapshot.params['editId'];
    let detailId = this.route.snapshot.params['detailId'];
    //debugger;
    if (editId) {
      this.editorMode = EditorMode.edit
      this.editId = editId;
      this.id = editId;
      this.canEditPrice = true;
    }
    else if (detailId) {
      this.editorMode = EditorMode.detail;
      this.detailId = detailId;
      this.id = detailId;
      this.canEditPrice = false;
    }
    else {
      this.editorMode = EditorMode.add;
      this.canEditPrice = true;
    }
    if (this.id) {
      this.PageLoading = true;
      this.storeServ.getOpeningBalance(this.id).subscribe(res => {
        this.PageLoading = false;
        if (res != null) {
          this.buildForms();
          debugger;
          this.model = res;
          // this.editorMode = EditorMode.detail;
          this.bindDetailModelToForm();
        }
      },
        () => {
          this.PageLoading = false;
          this.notification.showOperationFailed();
        })
    }
  }

  getVendorsLookup() {
    this.ReceiptsServ.getVendorsLookup()
      .subscribe(res => {
        //debugger;
        this.vendors = res;
        this.PageLoading = false;

      }, () => {
        this.PageLoading = false;

        this.notification.showOperationFailedToLoadVendors();
      }, () => {
      });
  }

  //validaton 
  onProductListChanged(evnt: FormArray) {
    //debugger;
    evnt.value.forEach((element, index) => {
      (this.modelForm.get('products') as FormArray).removeAt(index);
    });
    (this.modelForm.get('products') as FormArray).removeAt(0);
    evnt.value.forEach(() => {
      this.addProduct();
    });
    (this.modelForm.get('products') as FormArray).patchValue(evnt.value);
    console.log(this.modelForm.value);
  }
  //edit
  bindModelToForm(): void {
    //debugger
    // if (this.purchInvoice) {
    //   this.buildForms();
    //   this.modelForm.patchValue({
    //     code: this.purchInvoice.code,
    //     vendorInvoiceCode: this.purchInvoice.vendorInvoiceCode,
    //     vendorId: this.purchInvoice.vendorId,
    //     inventoryId: this.purchInvoice.inventoryId,
    //     date: new Date(this.purchInvoice.date),
    //     hasAdditionalExpenses: this.purchInvoice.hasAdditionalExpenses,
    //     additionalExpensesAmount: this.purchInvoice.additionalExpensesAmount,
    //     hasDiscount: this.purchInvoice.hasDiscount,
    //     discountAmount: this.purchInvoice.discountAmount,
    //     purchaseInvoiceTypeId: this.purchInvoice.purchaseInvoiceTypeId,
    //     safeId: this.purchInvoice.safeId,
    //     taxAmount: this.purchInvoice.taxAmount
    //   });

    //   if (this.purchInvoice.purchaseInvoiceCostCenters &&
    //     this.purchInvoice.purchaseInvoiceCostCenters.length > 0) {
    //     this.modelForm.controls['hasCostCenter'].setValue(true);
    //     this.modelForm.controls['costCenterId'].setValue(this.purchInvoice.purchaseInvoiceCostCenters[0].costCenterId);
    //   }
    //   if (this.purchInvoice.products && this.purchInvoice.products.length > 0) {
    //     this.products = this.purchInvoice.products;
    //   }

    //   if (this.purchInvoice.purchaseInvoiceTypeId) {

    //   }
    // }
  }

  bindDetailModelToForm(): void {
    //  debugger
    if (this.model) {
      this.modelForm.patchValue({
        id: this.model.id,
        code: this.model.code,
        inventoryId: parseInt(this.model.inventoryId, 10),
        vendorId: this.model.vendorId,
        billNumber: this.model.billNumber,
        date: new Date(this.model.date),
        descriptionAr: this.model.descriptionAr,
        descriptionEn: this.model.descriptionEn,
      });
      if (this.model.inventoryOpeningBalanceCostCenter &&
        this.model.inventoryOpeningBalanceCostCenter.length > 0) {
        this.modelForm.controls['CostCentersCheck'].setValue(true);
        if (this.editorMode != EditorMode.add) {
          this.DetailsCostCenters = this.model.inventoryOpeningBalanceCostCenter;
        }
        // if( this.editorMode == EditorMode.edit){
        //   this.EditeCostCenters=this.model.inventoryOpeningBalanceCostCenter;
        // }  
        this.CostCenters = this.model.inventoryOpeningBalanceCostCenter;
      }

      if (this.model.products && this.model.products.length > 0) {
        this.productsCount= this.model.products.length
       this.products = this.model.products;
      }
    }
  }

  //cost cente
  CostCentersCHekedToggle() {
    this.modelForm.controls['CostCentersCheck'].valueChanges.subscribe(value => {
      if (value == true) {
        this.modelForm.controls['OneCostCenterCheck'].setValue(false);
        this.IsOneCostCenterChecked = false;
        $('#openCostCentersModalBTN').click();
        $('#openCostCentersModalBTN').html("Heloo");
      }
      else {
        this.storeStartBalance.inventoryOpeningBalanceCostCenter = new Array();
      }
    });
  }

  onOneCostCenterChanged(id) {
    this.storeStartBalance.inventoryOpeningBalanceCostCenter = new Array();
    this.storeStartBalance.inventoryOpeningBalanceCostCenter.push({
      id: id.value,
      costCenterId: id.value,
      inventoryOpeningBalanceId: null
    });
    console.log("one cost center to Api " + JSON.stringify(this.storeStartBalance.inventoryOpeningBalanceCostCenter))
  }

  addCostCenters(costCentersList) {
    this.IsOneCostCenterChecked = false;
    this.storeStartBalance.inventoryOpeningBalanceCostCenter = new Array();
    this.storeStartBalance.inventoryOpeningBalanceCostCenter = costCentersList;
    this.notification.showTranslateSuccess('costCenter.SucessCostCentersAdd');
  }

  //form
  addProduct() {
    const products = this.modelForm.get('products') as FormArray;
    products.push(this.createProduct());
  }
  deleteProduct(item) {
    (this.modelForm.get('products') as FormArray).removeAt(item);
  }

  buildForms(): void {
    this.modelForm = this.fb.group({
      id: [],
      code: [null],//, [Validators.required]],
      date: [new Date(), [Validators.required]],
      inventoryId: [null, [Validators.required]],
      vendorId: [null, [Validators.required]],
      billNumber: [null, [Validators.required]],
      descriptionAr: [null, [Validators.required]],
      descriptionEn: [null],
      CostCentersCheck: [],
      OneCostCenterCheck: [],
      OnCostCenterValue: [],
      products: this.fb.array([])
    });
  }
  inventoryOpeningBalanceCostCenter: CostCenters[];

  createProduct(): FormGroup {
    return this.fb.group({
      id: [],
      brandId: [null, [Validators.required]],
      measurementUnitId: [null, [Validators.required]],
      quantity: [1, [Validators.required, Validators.min(1)]],
      price: [null, [Validators.min(1)]],
      total: [null],
      expenses: [0],
      discount: [0],
      totalDiscount: [0],
      netValue: [0],
    });
  }
  gotoList() {
    let url = [`/store/opening-balance/list`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  //lookups
  getCostCenters() {
    this.ReceiptsServ.getCostCentersLookups()
      .subscribe(
        res => {
          this.PageLoading = false;
          var array = new Array<any>();
          res.forEach(function (item) {
            var record = new KendoDropDown();
            record.text = item.displyedName;
            record.value = item.id;
            array.push(record);
          });
          this.CostCenterDropDown = array;
        },
        // this.Branches = res,
        error => {
          this.PageLoading = false;

          error;
          this.notification.showOperationFailed();
        }

      );
  }

  OneCostCenterCHekedToggle(val) {
    this.IsOneCostCenterChecked = val.checked;
    this.modelForm.controls['CostCentersCheck'].setValue(false);
  }

  getInventorysLookup() {
    this.ReceiptsServ.getStoreLookup().subscribe(res => {
      //debugger;
      this.inventoryList = res;
      // this.PageLoading = false;
    }, () => {
      //  this.PageLoading = false;
      this.notification.showOperationFailed();
    }, () => {
    });
  }

  //submit
  submit() {
    // debugger   
    this.validForm = true;
    if (!this.storeStartBalance || !this.storeStartBalance.inventoryOpeningBalanceCostCenter || this.storeStartBalance.inventoryOpeningBalanceCostCenter.length < 1) {
      this.modelForm.controls['CostCentersCheck'].setValue(false);
    }
    this.model = this.modelForm.value;
    if (this.storeStartBalance.inventoryOpeningBalanceCostCenter) {
      this.model.inventoryOpeningBalanceCostCenter = this.storeStartBalance.inventoryOpeningBalanceCostCenter;
    } else {
      this.model.inventoryOpeningBalanceCostCenter = this.CostCenters;
    }

    if (this.model.inventoryOpeningBalanceCostCenter) {
      this.model.inventoryOpeningBalanceCostCenter.forEach(item => {
        item.costCenterId = item.id;
      });
    }

    if (this.model.products.length < 1) {
      this.notification.showTranslateError('purchasing.rebate.productReq');
      this.validForm = false;
    }

    if (this.validForm) {
      if (this.modelForm.valid) {
        this.PageLoading = true;
        debugger;
        if (this.model.id > 0) {
          this.storeServ.updateOpeningBalance(this.model).subscribe(res => {
            this.PageLoading = false;
            this.notification.showSuccessAlertForSavedDocument(res.code);
            this.gotoList();
          }, (error) => {
            console.error(JSON.stringify(error));
            this.PageLoading = false;
            this.errorService.handerErrors(error);
          }, () => {
            this.PageLoading = false;
          });
        } else {
          this.storeServ.addOpeningBalance(this.model).subscribe(res => {
            this.PageLoading = false;
            this.notification.showSuccessAlertForSavedDocument(res.code);
            this.gotoList();
          }, (error) => {
            console.error(JSON.stringify(error));
            this.PageLoading = false;
            this.errorService.handerErrors(error);
          }, () => {
            this.PageLoading = false;
          });
        }
      }
      else {
        const modelFormFormKeys = Object.keys(this.modelForm.controls);
        modelFormFormKeys.forEach((control) => {
          console.log(control);
          ;
        });
        this.modelForm.setErrors({ 'invalid': true, 'valid': false });
        this.notification.showTranslateError('financial.formNotificationError');
      }
    }
    else {
      this.validForm = false;
      this.notification.showTranslateError('financial.formNotificationError');
    }
  }


  vendors: any[];
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
}
