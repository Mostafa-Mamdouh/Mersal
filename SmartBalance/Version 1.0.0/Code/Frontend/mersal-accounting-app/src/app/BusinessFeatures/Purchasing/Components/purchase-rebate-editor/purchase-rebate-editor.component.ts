import { PurchaseInvoice } from './../../Models/purchase-invoice.model';
import { PurchasingService } from './../../Services/Purchasing.service';
import { FinancialService } from './../../../Financial/Services/financial.service';
import { SourceType } from './../../../Financial/Models/source-type.enum';
import { CostCenters } from './../../../Financial/Models/receipts.model';
import { KendoDropDown } from './../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { ProductList } from '../../../Products/Models/product-list.model';
import { PurchaseRebate } from '../../Models/purchase-rebate.model';
import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { SettingService } from '../../../Setting/Services/setting.service';
import { Location } from '@angular/common';
import { DOCUMENT } from '@angular/platform-browser';
import { GeneralSetting } from '../../../Setting/Models/general-setting.model';
import { Cheque } from '../../../../SharedFeatures/SharedMain/Models/cheque.mode';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';

declare var $: any;

@Component({
  selector: 'purchase-rebate-editor',
  styleUrls: ['./purchase-rebate-editor.component.scss'],
  templateUrl: './purchase-rebate-editor.component.html'
})
export class PurchaseRebateEditorComponent implements OnInit {
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };
  model: PurchaseRebate;
  modelForm: FormGroup;
  bsDatePickerValue: Date = new Date();
  sourceType: typeof SourceType = SourceType;
  Vendors: any[];
  AccountCharts: any[];
  donators: any[];
  safes: any[];
  products: any[];
  editorMode: EditorMode = EditorMode.add;
  editorModeEnum = EditorMode;
  id: any;
  isProccessing: boolean;
  purchaseInvoiceTypes: any[];
  validForm: boolean = true;
  SelectedCostCenter: number;
  //selectedSourceType = 0;
  PageLoading: boolean = false;
  ProductList: ProductList[];
  inventoryList: any[];
  costCenter: CostCenters[] = [];
  //calc
  totalAmount: number = 0;
  totalExpenses: number = 0;
  totalDiscount: number = 0;
  taxAmount: number = 0;

  netValue: number = 0;
  purchaseInvoice: any[];
  purchInvoice: PurchaseInvoice;
  private vat: any;
  isEdit: number;

  cheque: Cheque = new Cheque();
  journalPreviewShow: boolean;
  journalPreview: any;

  constructor(
    private ReceiptsServ: FinancialService,
    private serv: PurchasingService,
    public router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private translateService: TranslateService,
    private notification: NotificationService,
    private settingService: SettingService,
    private location: Location,
    private errorService: ErrorService,
    @Inject(DOCUMENT) private document: any,
  ) {

  }

  ngOnInit() {
    // this.selectedSourceType = 1;  
    this.getPurchaseInvoiceLookup();
    this.buildForms();
    this.addProduct();

    this.getVAT();
    this.geGeneralSetting();
    this.getVendorsLookup();
    this.getٍSafeLookup();
    this.getCostCenters();
    this.getInventorysLookup();
    this.getPurchaseInvoiceTypes();
    this.extractRouteParams();
  }

  buildForms(): void {
    this.modelForm = this.fb.group({
      code: [null],//, [Validators.required]],
      date: [new Date(), [Validators.required]],
      vendorId: [null, [Validators.required]],
      inventoryId: [null],
      // invoiceType: [1, [Validators.required]],
      purchaseInvoiceTypeId: [null, [Validators.required]],
      safeId: [],
      hasCostCenter: [false, [Validators.required]],
      costCenterId: [],
      totalAmount: [0, [Validators.required]],
      taxAmount: [null],//, [Validators.required]],
      totalExpenses: [0, [Validators.required]],
      totalDiscount: [0, [Validators.required]],
      netAmount: [0, [Validators.required]],

      fromBankId : [null],
      chequeNumber : [null],
      dueDate : [null],
      toBankId : [null],

      purchaseRebateProducts: this.fb.array([])
    });

    // this.modelForm.valueChanges.subscribe(res => {
    // });
  }

  extractRouteParams(): void {
    let editId = this.route.snapshot.params['editId'];
    let detailId = this.route.snapshot.params['detailId'];
    if (editId) {
      this.editorMode = EditorMode.edit
      this.id = editId;
    }
    else if (detailId) {
      this.editorMode = EditorMode.detail;
      this.id = detailId;
    }
    else {
      this.editorMode = EditorMode.add;
    }
    if (this.id) {
      this.PageLoading = true;
      this.serv.getPurchaseRebates(this.id)
        .subscribe(res => {
          debugger;
          this.PageLoading = false;
          if (res != null) {
            this.buildForms();
            this.model = res;
            this.editorMode = EditorMode.detail;
            this.bindDetailModelToForm();
          }
        },
          (error) => {
            this.PageLoading = false;
            this.notification.showOperationFailed();
          })
    }
    this.modelForm.valueChanges.subscribe(x => {
      this.calcTotal();
    },
      (error) => { });
  }

  removeControlSelection(elementName: string) {
    debugger;
    if (elementName == 'code') {
      //this.products = [];

      if (this.products.length > 0) {
        this.products.forEach(item => {
          this.deleteProduct(item);
        });
      }

      this.products = [];
      this.buildForms();

      let purchaseRebateProducts = this.modelForm.get('purchaseRebateProducts') as FormArray;


      document.location.reload();

      //   let xx =(this.modelForm.get('purchaseRebateProducts') as FormArray);
      //  (this.modelForm.get('purchaseRebateProducts') as FormArray) = this.fb.group({
      //   brandId: [null, [Validators.required]],
      //   productId: [null, [Validators.required]],
      //   quantity: [1, [Validators.required, Validators.min(0)]],
      //   price: [0, [Validators.required, Validators.min(0)]],
      //   total: [0, [Validators.required]],
      //   expenses: [0],
      //   discount: [0],
      //   totalDiscount: [0],
      //   netValue: [0],
      //   measurementUnitId: [null, [Validators.required]],
      //   purchaseInvoiceId: [null]
      // });
    }
  }

  getVAT() {
    this.settingService.getVAT()
      .subscribe(
        res => {
          // debugger;
          this.vat = res;
          this.modelForm.controls['taxAmount'].setValue(this.vat);
        }, () => {
          //this.PageLoading = false;
          this.notification.showOperationFailed();
        }
      );
  }

  geGeneralSetting() {
    this.settingService.getGeneralSetting()
      .subscribe(
        res => {
          // debugger;
          this.generalSetting = res;

          if (!this.generalSetting.isInventoryRequired) {
            this.modelForm.controls['inventoryId'].clearValidators();
            this.modelForm.controls['inventoryId'].updateValueAndValidity();
          }
          else {
            this.modelForm.controls['inventoryId'].setValidators([Validators.required]);
            this.modelForm.controls['inventoryId'].updateValueAndValidity();
          }
        }, () => {
          //this.PageLoading = false;
          this.notification.showOperationFailed();
        }
      );
  }

  // checkDate(): boolean {
  //   debugger;
  //   let selectedDate: any = this.modelForm.controls['date'].value;
  //   let now = new Date(Date.now());

  //   if (selectedDate > now) {
  //     this.notification.showTranslateHtmlError_h5('error.maxDateAlert');
  //     return false;
  //   }
  //   else {
  //     return true;
  //   }
  // }

  //validaton 
  isCashType() {
    let purchaseInvoiceTypeId = this.modelForm.controls['purchaseInvoiceTypeId'].value;
    if (purchaseInvoiceTypeId && purchaseInvoiceTypeId.value) {
      return (purchaseInvoiceTypeId.value == 1);
    }
    else {
      return (purchaseInvoiceTypeId == 1);
    }
  }

  onPurchaseInvoiceTypeChanged(event){
    debugger;
    let test = this.modelForm;
    switch (event) {
      case 1:
        {
          this.modelForm.controls["safeId"].setValidators([Validators.required]);
          this.modelForm.controls["safeId"].updateValueAndValidity();

          this.modelForm.controls['fromBankId'].clearValidators();
          this.modelForm.controls['fromBankId'].updateValueAndValidity();
          this.modelForm.controls['chequeNumber'].clearValidators();
          this.modelForm.controls['chequeNumber'].updateValueAndValidity();
          this.modelForm.controls['dueDate'].clearValidators();
          this.modelForm.controls['dueDate'].updateValueAndValidity();

          break;
        }

      case 4:
        {
          this.modelForm.controls["safeId"].clearValidators();
          this.modelForm.controls["safeId"].updateValueAndValidity();

          this.modelForm.controls['fromBankId'].clearValidators();
          this.modelForm.controls['fromBankId'].updateValueAndValidity();
          this.modelForm.controls['chequeNumber'].clearValidators();
          this.modelForm.controls['chequeNumber'].updateValueAndValidity();
          this.modelForm.controls['dueDate'].clearValidators();
          this.modelForm.controls['dueDate'].updateValueAndValidity();

          break;
        }

      case 7:
        {
          this.modelForm.controls["safeId"].clearValidators();
          this.modelForm.controls["safeId"].updateValueAndValidity();

          this.modelForm.controls['fromBankId'].setValidators([Validators.required]);
          this.modelForm.controls['fromBankId'].updateValueAndValidity();
          this.modelForm.controls['chequeNumber'].setValidators([Validators.required]);
          this.modelForm.controls['chequeNumber'].updateValueAndValidity();
          this.modelForm.controls['dueDate'].setValidators([Validators.required]);
          this.modelForm.controls['dueDate'].updateValueAndValidity();

          break;
        }

      default:
        break;
    }

  }

  journalValueChange(event){
    this.model.journal = event;
  }

  journalApprove(event){
    debugger;
    //this.collectModelFromForm();
    this.model.journal = event;
    this.ReceiptsServ.addPaymentMovments(this.model)
      .subscribe(res => {
        debugger;
        this.PageLoading = false;
        $('#openPostlBTN').click();
        this.notification.showSuccessAlertForSavedDocument(this.model.code);
        this.gotoList();
        //debugger;
      }, (error) => {
        // debugger;
        console.error(JSON.stringify(error));
        this.PageLoading = false;

        this.errorService.handerErrors(error);
        // debugger;
      }, () => {
        this.PageLoading = false;

        // debugger;
      });
  }
  
  journalReject(event){
    $('#openPostlBTN').click();
    this.notification.showSuccessAlertForSavedDocument(this.model.code);
    this.notification.showJournalcanceled();
    this.gotoList();
  }

  onProductListChanged(evnt: FormArray) {
    debugger;
    evnt.value.forEach((element, index) => {
      (this.modelForm.get('purchaseRebateProducts') as FormArray).removeAt(index);
    });
    (this.modelForm.get('purchaseRebateProducts') as FormArray).removeAt(0);
    evnt.value.forEach(element => {
      debugger;
      this.addProduct();
    });

    (this.modelForm.get('purchaseRebateProducts') as FormArray).patchValue(evnt.value);
    //(this.modelForm.get('purchaseRebateProducts') as FormArray).patchValue(null);

    console.log(this.modelForm.value);
    this.calcTotal();
  }

  onChequeFormValueChanged(evnt) {
    debugger;
    let test = this.modelForm;

    this.cheque.fromBankId = evnt.fromBankId;
    this.cheque.chequeNumber = evnt.chequeNumber;
    this.cheque.dueDate = evnt.dueDate;
    this.cheque.toBankId = evnt.toBankId;

    this.modelForm.controls['fromBankId'].setValue(evnt.fromBankId);
    this.modelForm.controls['chequeNumber'].setValue(evnt.chequeNumber);
    this.modelForm.controls['dueDate'].setValue(evnt.dueDate);
    this.modelForm.controls['toBankId'].setValue(evnt.toBankId);
  }


  //edit
  purchaseInvoiceChange(event) {
    debugger;
    if(event)
    {
    if (event > 0) {
      this.PageLoading = true;
      this.serv.getPurchaseInvoice(event)
        .subscribe(res => {
          // debugger
          if (res != null) {
            this.purchInvoice = res;
            this.editorMode = EditorMode.edit;
            // this.buildForms();
            this.bindModelToForm();
            this.modelForm.controls['code'].setValue(event);
            this.PageLoading = false;
          }
        },
          (error) => {
            this.PageLoading = false;
            this.notification.showOperationFailed();
          })
    }
  }
  else
  {
    this.removeControlSelection("code");
    //this.addProduct();
  }
  }

  bindModelToForm(): void {
    //debugger
    if (this.purchInvoice) {
      this.buildForms();
      this.modelForm.patchValue({
        code: this.purchInvoice.code,
        vendorInvoiceCode: this.purchInvoice.vendorInvoiceCode,
        vendorId: this.purchInvoice.vendorId,
        inventoryId: this.purchInvoice.inventoryId,
        date: new Date(this.purchInvoice.date),
        hasAdditionalExpenses: this.purchInvoice.hasAdditionalExpenses,
        additionalExpensesAmount: this.purchInvoice.additionalExpensesAmount,
        hasDiscount: this.purchInvoice.hasDiscount,
        discountAmount: this.purchInvoice.discountAmount,
        purchaseInvoiceTypeId: this.purchInvoice.purchaseInvoiceTypeId,
        safeId: this.purchInvoice.safeId,
        totalAmount: this.purchInvoice.totalAmountBeforeTax,
        taxAmount: this.purchInvoice.taxAmount,


        totalExpenses: this.purchInvoice.totalExpenses,
        totalDiscount: this.purchInvoice.totalDiscount,
        netAmount: this.purchInvoice.netAmount,
      });

      if (this.purchInvoice.purchaseInvoiceCostCenters &&
        this.purchInvoice.purchaseInvoiceCostCenters.length > 0) {
        this.modelForm.controls['hasCostCenter'].setValue(true);
        this.modelForm.controls['costCenterId'].setValue(this.purchInvoice.purchaseInvoiceCostCenters[0].costCenterId);
      }
      if (this.purchInvoice.products && this.purchInvoice.products.length > 0) {
        // this.purchInvoice.products.forEach(element => {
        //   this.addProduct();
        // });
        // (this.modelForm.get('purchaseRebateProducts') as FormArray).patchValue(this.purchInvoice.products);
        this.products = this.purchInvoice.products;
        this.isEdit = 1;
      }

      if (this.purchInvoice.purchaseInvoiceTypeId) {
        if(this.purchInvoice.purchaseInvoiceTypeId == 7)
        {
          this.cheque.fromBankId = this.purchInvoice.fromBankId;
          this.cheque.chequeNumber = this.purchInvoice.chequeNumber;
          this.cheque.dueDate = this.purchInvoice.dueDate;
          this.cheque.toBankId = this.purchInvoice.toBankId;
        }

      }

      this.calcTotal();
    }
  }

  bindDetailModelToForm(): void {
    //debugger
    if (this.model) {
      this.modelForm.patchValue({
        code: Number(this.model.code),
        vendorId: this.model.vendorId,
        inventoryId: this.model.inventoryId,
        date: new Date(this.model.date),
        purchaseInvoiceTypeId: this.model.purchaseInvoiceTypeId,
        safeId: this.model.safeId,
        totalAmount: this.model.totalAmount,
        totalExpenses: this.model.totalExpenses,
        totalDiscount: this.model.totalDiscount,
        netAmount: this.model.safeId,
        taxAmount: this.model.taxAmount,
      });
      if (this.model.purchaseRebateCostCenters &&
        this.model.purchaseRebateCostCenters.length > 0) {
        this.modelForm.controls['hasCostCenter'].setValue(true);
        this.modelForm.controls['costCenterId'].setValue(this.model.purchaseRebateCostCenters[0].costCenterId);
      }
      if (this.model.purchaseRebateProducts && this.model.purchaseRebateProducts.length > 0) {
        // this.model.purchaseRebateProducts.forEach(element => {
        //   this.addProduct();
        // });
        // (this.modelForm.get('purchaseRebateProducts') as FormArray).patchValue(this.model.purchaseRebateProducts);
        this.isEdit = null;
        this.products = this.model.purchaseRebateProducts;
      }

      if (this.model.purchaseInvoiceTypeId) {
        if(this.model.purchaseInvoiceTypeId == 7)
        {        
          this.cheque.fromBankId = this.model.fromBankId;
          this.cheque.chequeNumber = this.model.chequeNumber;
          this.cheque.dueDate = this.model.dueDate;
          this.cheque.toBankId = this.model.toBankId;
        }
      }


    }
  }


  calcTotal() {
    //debugger
    this.totalAmount = 0;
    this.totalExpenses = 0;
    this.totalDiscount = 0;
    this.netValue = 0;
    this.taxAmount = 0;

    this.model = this.modelForm.value;
    this.model.purchaseRebateProducts.forEach(element => {
      this.totalAmount += element.total;
      this.totalExpenses += element.expenses;
      this.totalDiscount += element.discount + element.totalDiscount;
      this.netValue += element.netValue;
    });

    let taxAmountValue = +((this.totalAmount * this.vat).toFixed(3));
    if (taxAmountValue != this.taxAmount) {
      this.netValue = +((this.totalAmount + taxAmountValue + this.totalExpenses - this.totalDiscount).toFixed(3));

      if (this.modelForm) {
        this.modelForm.controls['totalAmount'].setValue(this.totalAmount);
        this.modelForm.controls['taxAmount'].setValue(taxAmountValue);
        this.modelForm.controls['totalExpenses'].setValue(this.totalExpenses);
        this.modelForm.controls['totalDiscount'].setValue(this.totalDiscount);
        this.modelForm.controls['netAmount'].setValue(this.netValue);
      }
    }
  }


  //form
  addProduct() {
    const purchaseRebateProducts = this.modelForm.get('purchaseRebateProducts') as FormArray;
    purchaseRebateProducts.push(this.createProduct());
  }
  deleteProduct(item) {
    (this.modelForm.get('purchaseRebateProducts') as FormArray).removeAt(item);
    this.calcTotal();
  }


  createProduct(): FormGroup {
    return this.fb.group({
      brandId: [null, [Validators.required]],
      productId: [null, [Validators.required]],
      quantity: [1, [Validators.required, Validators.min(1)]],
      price: [0, [Validators.required, Validators.min(1)]],
      total: [0, [Validators.required]],
      expenses: [0],
      discount: [0],
      totalDiscount: [0],
      netValue: [0],
      measurementUnitId: [null, [Validators.required]],
      purchaseInvoiceId: [null]
    });
  }

  gotoList() {
    let url = [`/purchasing/purchase-rebate/list`];
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
          //this.PageLoading = false;
          var array = new Array<any>();
          res.forEach(function (item) {
            var record = new KendoDropDown();
            record.text = item.name;
            record.value = item.id;
            array.push(record);
          });
          this.costCenter = res;
        }, () => {
          //this.PageLoading = false;
          this.notification.showOperationFailed();
        }
      );
  }

  getٍSafeLookup() {
    //safes
    this.ReceiptsServ.getSafesLookup().subscribe(res => {
      this.safes = res;
      // this.PageLoading = false;
    },
      (error) => {
        // this.PageLoading = false;
        //this.notification.showOperationFailed();
      }, () => {
      });
  }

  getPurchaseInvoiceLookup() {
    //debugger;
    this.serv.getPurchaselookup().subscribe(res => {
      //debugger;
      this.purchaseInvoice = res;
      //this.PageLoading = false;
    },
      (error) => {
        //debugger;
        console.error(JSON.stringify(error));
        // this.PageLoading = false;
        //this.notification.showOperationFailed();
      }, () => {
        //debugger;
      });
  }

  OneCostCenterCHekedToggle(val) {
    this.modelForm.controls['costCenterId'].setValue(false);
  }

  getVendorsLookup() {
    this.ReceiptsServ.getVendorsLookup()
      .subscribe(res => {
        this.Vendors = res;
        // this.PageLoading = false;
      }, () => {
        //this.PageLoading = false;
        this.notification.showOperationFailed();
      }, () => {
      });
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

  getPurchaseInvoiceTypes() {
    this.serv.getPurchaseInvoiceTypesLookups()
      .subscribe(
        res => {
          //this.PageLoading = false;
          var array = new Array<any>();
          res.collection.forEach(function (item) {
            var record = new KendoDropDown();
            record.text = item.name;
            record.value = item.id;
            array.push(record);
          });
          this.purchaseInvoiceTypes = res.collection;
        }, () => {
          //this.PageLoading = false;
          this.notification.showOperationFailed();
        }
      );
  }


  //submit
  submit() {
    debugger
    this.validForm = true;
    this.model = this.modelForm.value;
    if (this.model.purchaseRebateProducts.length < 1) {
      this.notification.showTranslateError('purchasing.rebate.productReq');
      this.validForm = false;
    }
    if (this.model.purchaseInvoiceTypeId == 1 && this.model.safeId == null) {
      this.notification.showTranslateError('purchasing.rebate.safeReq');
      this.validForm = false;
    }
    if (this.model.hasCostCenter) {
      if (!(this.model.costCenterId > 0)) {
        this.notification.showTranslateError('purchasing.rebate.costCenteReq');
        this.validForm = false;
        return;
      } else {
        this.model.purchaseRebateCostCenters = [];
        this.model.purchaseRebateCostCenters.push({
          costCenterId: this.model.costCenterId,
          amount: this.model.netAmount
        })
      }
    }
    if (this.validForm) {
      if (this.modelForm.valid) {
        //if(this.checkDate() == false) return;

        this.PageLoading = true;
        debugger;

        this.model.fromBankId = this.cheque.fromBankId;
        this.model.chequeNumber = this.cheque.chequeNumber;
        this.model.dueDate = this.cheque.dueDate;
        this.model.toBankId = this.cheque.toBankId;

        this.serv.addPurchaseRebates(this.model).subscribe(res => {
          this.model = res;
              this.journalPreview = res.journal;
              this.journalPreviewShow = true;
              $('#openPostlBTN').click();;
        }, (error) => {
          console.error(JSON.stringify(error));
          this.PageLoading = false;
          this.errorService.handerErrors(error);
        }, () => {
          this.PageLoading = false;
        });
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
      //this.notification.showDataMissingError();
    }
  }

  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
  generalSetting: GeneralSetting;
}