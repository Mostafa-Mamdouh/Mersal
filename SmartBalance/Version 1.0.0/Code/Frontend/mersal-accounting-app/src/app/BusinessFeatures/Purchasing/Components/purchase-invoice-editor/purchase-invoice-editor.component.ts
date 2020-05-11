import { Component, Input, Output, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { PurchaseInvoice } from '../../Models/purchase-invoice.model';
import { PurchasingService } from '../../Services/Purchasing.service';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { CostCenters } from './../../../Financial/Models/receipts.model';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { PurchaseInvoiceCostCenter } from '../../Models/purchase-invoice-cost-center.model';
import { SettingService } from '../../../Setting/Services/setting.service';
import { BankService } from '../../../Bank/Services/bank.service';
import { GeneralSetting } from '../../../Setting/Models/general-setting.model';
import { Cheque } from '../../../../SharedFeatures/SharedMain/Models/cheque.mode';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';
import { OpeningBalance } from '../../Models/opening-balance.model';

declare var $: any;

@Component({
  selector: 'purchase-invoice-editor',
  styleUrls: ['./purchase-invoice-editor.component.scss'],
  templateUrl: './purchase-invoice-editor.component.html'
})
export class PurchaseInvoiceEditorComponent implements OnInit {
  products: any[];
  journalPreview: any;
  journalPreviewShow: boolean;
  openingBalances: OpeningBalance[];
  discountPercentages: any[];


  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private purchasingService: PurchasingService,
    private settingService: SettingService,
    private bankService: BankService,
    private location: Location,
    private errorService: ErrorService
  ) { }

  ngOnInit(): void {
    this.buildForm();
    this.addProduct();

    this.getVAT();
    this.geGeneralSetting();
    this.getPurchaseInvoiceTypes();
    this.getSafes();
    this.getBanks();
    this.getCostCenters();
    this.getVendorsLookup();
    this.getInventorysLookup();
    this.getDiscountPercentagesLookup();
    this.extractRouteParams();
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      code: [null],//, [Validators.required]],
      vendorInvoiceCode: [null],
      vendorId: [null, [Validators.required]],
      inventoryId: [null],
      date: [new Date(), [Validators.required]],
      hasCostCenter: [false, [Validators.required]],
      costCenterId: [null],
      purchaseInvoiceTypeId: [null, [Validators.required]],
      safeId: [null],
      openingBalanceId:[null],
      //visaBankId: [null],
      //visaNumber: [null],
      hasAdditionalExpenses: [false, [Validators.required]],
      additionalExpensesAmount: [0],
      hasDiscount: [false, [Validators.required]],
      discountAmount: [0],
      totalAmountBeforeTax: [null],//, [Validators.required]],
      totalAmountAfterTax: [null],
      taxAmount: [null],//, [Validators.required]],
      totalExpenses: [null],//, [Validators.required]],
      totalDiscount: [null],//, [Validators.required]],
      netAmount: [null],//, [Validators.required]],
      totalAmount: [null],

      fromBankId : [null, [Validators.required]],
      chequeNumber : [null, [Validators.required]],
      dueDate : [null, [Validators.required]],
      toBankId : [null],
      bankaccountchartId : [null],


      //FromBankId: [null],
      //ChequeNumber: [null],
      //Duedate: [new Date()],
      //ToBankId: [null],

      products: this.fb.array([])
    });



    this.editorForm.valueChanges.subscribe(res => {
      //;
      

      //   ;
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

      //     ;
      //     let hasCostCenter = this.isHasCostCenter();
      //     let costCenter = res.costCenterId;

      //     if (hasCostCenter && costCenter && costCenter.value) {
      //       this.itemModel.purchaseInvoiceCostCenters = [];
      //       let costCenterItem: PurchaseInvoiceCostCenter = new PurchaseInvoiceCostCenter();

      //       costCenterItem.costCenterId = costCenter.value;
      //       this.itemModel.purchaseInvoiceCostCenters.push(costCenterItem);
      //     }
      //   }
    });
  }

  createProduct(): FormGroup {
    return this.fb.group({
      brandId: [null, [Validators.required]],
      measurementUnitId: [null],
      productId: [null, [Validators.required]],
      quantity: [1, [Validators.required, Validators.min(1)]],
      price: [0, [Validators.required, Validators.min(1)]],
      total: [0, [Validators.required]],
      expenses: [0, [Validators.required]],
      discount: [0, [Validators.required]],
      totalDiscount: [0, [Validators.required]],
      netValue: [0, [Validators.required]],
      description: [null],

    });
  }

  getDiscountPercentagesLookup() {
    this.ReceiptsServ.getDiscountPercentagesLookup()
    .subscribe(res => {
      debugger;
      this.discountPercentages = res.collection;
      
    },
      (error) => {

      });
  }

  onProductListChanged(evnt: FormArray) {
    debugger
    evnt.value.forEach((element, index) => {
      (this.editorForm.get('products') as FormArray).removeAt(index);
    });
    (this.editorForm.get('products') as FormArray).removeAt(0);
    evnt.value.forEach(element => {
      this.addProduct();
    });
    (this.editorForm.get('products') as FormArray).patchValue(evnt.value);
    this.calcTotal();
  }

  VendorCahnged(value){
this.purchasingService.getOpeningBalancesByVendorId(value.id).subscribe(res => {
  console.log(res)
  var array = new Array<any>();
  res.collection.forEach(function (item) {
    array.push(item);
  });
  this.openingBalances = array;
},
  (error) => {
    this.notificationService.showOperationFailed();
  })

  }

  OpeningBalanceCahnged(value){
   var selectedOpeningBalance= this.openingBalances.filter(x => x.id === value.id)
    this.products=selectedOpeningBalance.map(p=>p.products)[0];
    this.editorForm.controls['inventoryId'].setValue(selectedOpeningBalance.map(i=>i.inventoryId)[0]);
    this.editorForm.controls['vendorInvoiceCode'].setValue(selectedOpeningBalance.map(i=>i.billNumber)[0]);
  }

  calcTotal(isChecked ?:any) {
    //
    this.totalAmount = 0;
    this.totalExpenses = 0;
    this.totalDiscount = 0;
    this.netValue = 0;


    this.itemModel = this.editorForm.value;
    this.itemModel.products.forEach(element => {
      this.totalAmount += element.total;
      this.totalExpenses += element.expenses;
      this.totalDiscount += element.discount + element.totalDiscount;
      this.netValue += element.netValue;
    });

    let hasAdditionalExpenses = this.isHasAdditionalExpenses();
    let hasDiscount = this.isHasDiscount();

    let additionalExpenses = this.itemModel.additionalExpensesAmount;
    let discountAmount = this.itemModel.discountAmount;
    if (hasAdditionalExpenses != true) additionalExpenses = 0;
    let totalValue=0;
  
    if (isChecked && isChecked!=undefined ) 
    {
      totalValue = (this.netValue + additionalExpenses) + discountAmount;
      this.itemModel.discountAmount=0;
      this.editorForm.controls['discountAmount'].setValue(this.itemModel.discountAmount);
    }
    else{
      totalValue = (this.netValue + additionalExpenses) - discountAmount;

    }
    
    
   


    if (this.totalAmount < 1) {
      totalValue = 0;
    }
    this.editorForm.get('totalAmountBeforeTax').setValue(this.totalAmount);
    let totalAmountAfterTax = +((this.totalAmount * this.vat).toFixed(3));
    //totalAmountAfterTax = totalAmountAfterTax.toFixed(3);

    // let totalAmountAfterTax = this.totalAmount + (this.totalAmount * this.vat);
    totalValue = totalAmountAfterTax;
    this.editorForm.get('taxAmount').setValue(totalAmountAfterTax);
    this.editorForm.get('totalAmountAfterTax').setValue(totalAmountAfterTax);
    this.editorForm.get('totalAmount').setValue(totalValue);
    //this.editorForm.get('totalAmount').setValue(this.totalAmount);
    let overallExpenses = this.totalExpenses + this.itemModel.additionalExpensesAmount;
    let overallDiscount = this.totalDiscount + this.itemModel.discountAmount;
    this.editorForm.get('totalExpenses').setValue(overallExpenses);
    this.editorForm.get('totalDiscount').setValue(overallDiscount);

    totalValue = +((this.totalAmount + totalValue + overallExpenses - overallDiscount).toFixed(3));
    this.editorForm.get('netAmount').setValue(totalValue);
    //this.editorForm.get('totalAmountBeforeTax').setValue(this.totalAmount);
    //this.editorForm.get('netAmount').setValue(totalValue - (totalValue * this.vat));

  }

  addProduct() {
    const products = this.editorForm.get('products') as FormArray;
    products.push(this.createProduct());
  }

  extractRouteParams(): void {
    //;
    let editId = +this.route.snapshot.params['editId'];
    let detailId = +this.route.snapshot.params['detailId'];

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
      this.purchasingService.getPurchaseInvoice(this.id)
        .subscribe(res => {
          //;
          debugger
          this.itemModel = res;
          this.products = this.itemModel.products;
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
    let url = [`/purchasing/purchase-invoice/list`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  getVAT() {
    this.settingService.getVAT()
      .subscribe(
        res => {
          // ;
          this.vat = res;
          this.editorForm.controls['taxAmount'].setValue(this.vat);
        }, () => {
          //this.PageLoading = false;
          this.notificationService.showOperationFailed();
        }
      );
  }

  geGeneralSetting() {
    this.settingService.getGeneralSetting()
      .subscribe(
        res => {
           ;
          this.generalSetting = res;

          if (!this.generalSetting.isInventoryRequired) {
            this.editorForm.controls['inventoryId'].clearValidators();
            this.editorForm.controls['inventoryId'].updateValueAndValidity();
          }
          else {
            this.editorForm.controls['inventoryId'].setValidators([Validators.required]);
            this.editorForm.controls['inventoryId'].updateValueAndValidity();
          }
        }, () => {
          //this.PageLoading = false;
          this.notificationService.showOperationFailed();
        }
      );
  }

  //lookups
  getCostCenters() {
    this.ReceiptsServ.getCostCentersLookups()
      .subscribe(
        res => {
          //this.PageLoading = false;
          // var array = new Array<any>();
          // res.forEach(function (item) {
          //   var record = new KendoDropDown();
          //   record.text = item.name;
          //   record.value = item.id;
          //   array.push(record);
          // });
          this.costCenter = res;
        }, () => {
          //this.PageLoading = false;
          this.notificationService.showOperationFailed();
        }
      );
  }

  getPurchaseInvoiceTypes() {
    this.purchasingService.getPurchaseInvoiceTypesLookups()
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
          this.notificationService.showOperationFailed();
        }
      );
  }

  getSafes() {
    this.purchasingService.getSafesLookups()
      .subscribe(
        res => {
          //this.PageLoading = false;

          // var array = new Array<any>();
          // res.collection.forEach(function (item) {
          //   var record = new KendoDropDown();
          //   record.text = item.name;
          //   record.value = item.id;
          //   array.push(record);
          // });
          this.safes = res.collection;
        }, () => {
          //this.PageLoading = false;
          this.notificationService.showOperationFailed();
        }
      );
  }

  getBanks() {
    this.bankService.getBanksLookups()
      .subscribe(
        res => {
          //this.PageLoading = false;
          // var array = new Array<any>();
          // res.collection.forEach(function (item) {
          //   var record = new KendoDropDown();
          //   record.text = item.name;
          //   record.value = item.id;
          //   array.push(record);
          // });
          this.banks = res.collection;
        }, () => {
          //this.PageLoading = false;
          this.notificationService.showOperationFailed();
        }
      );
  }

  journalValueChange(event){
    this.itemModel.journal = event;
  }
  journalApprove(event){
    ;
    //this.collectModelFromForm();
    this.itemModel.journal = event;
    this.ReceiptsServ.addPaymentMovments(this.itemModel)
      .subscribe(res => {
        ;
        this.PageLoading = false;
        $('#openPostlBTN').click();
        this.notificationService.showSuccessAlertForSavedDocument(this.itemModel.code);
        this.gotoList();
        //;
      }, (error) => {
        // ;
        console.error(JSON.stringify(error));
        this.PageLoading = false;

        this.errorService.handerErrors(error);
        // ;
      }, () => {
        this.PageLoading = false;

        // ;
      });
  }

  journalReject(event){
    $('#openPostlBTN').click();
    this.notificationService.showSuccessAlertForSavedDocument(this.itemModel.code);
    this.notificationService.showJournalcanceled();
    this.gotoList();
  }

  OneCostCenterCHekedToggle(evnt) {
    if (this.editorForm.controls['hasCostCenter'].value == true) {
      this.editorForm.controls['costCenterId'].setValidators([Validators.required]);
    }
    else {
      this.editorForm.controls['costCenterId'].setValidators(null);
    }
  }

  hasAdditionalExpensesCHekedToggle(evnt) {
    if (this.editorForm.controls['hasAdditionalExpenses'].value == true) {
      this.editorForm.controls['additionalExpensesAmount'].setValidators([Validators.required, Validators.pattern("^[0-9]+$")]);
    }
    else {
      this.editorForm.controls['additionalExpensesAmount'].setValidators(null);
    }

    this.calcTotal();
  }

  hasDiscountCHekedToggle(evnt) {

    debugger
    if (this.editorForm.controls['hasDiscount'].value == true) {
      this.editorForm.controls['discountAmount'].setValidators([Validators.required, Validators.pattern("^[0-9]+$")]);
    }
    else {
      this.editorForm.controls['discountAmount'].setValidators(null);
    }

    var isChecked=this.editorForm.controls['hasDiscount'].value

    this.calcTotal(isChecked);
  }

  onInvoiceTypeChange(evnt) {
    ;
    if (this.isCashType()) {
      this.editorForm.controls['safeId'].setValidators([Validators.required]);
      this.editorForm.controls['safeId'].updateValueAndValidity();     

      this.editorForm.controls['fromBankId'].clearValidators();
      this.editorForm.controls['fromBankId'].updateValueAndValidity();
      this.editorForm.controls['chequeNumber'].clearValidators();
      this.editorForm.controls['chequeNumber'].updateValueAndValidity();
      this.editorForm.controls['dueDate'].clearValidators();
      this.editorForm.controls['dueDate'].updateValueAndValidity();
      this.editorForm.controls['toBankId'].clearValidators();
      this.editorForm.controls['toBankId'].updateValueAndValidity();
      this.editorForm.controls['bankaccountchartId'].clearValidators();
      this.editorForm.controls['bankaccountchartId'].updateValueAndValidity();
      //this.editorForm.controls['visaBankId'].clearValidators();
      //this.editorForm.controls['visaBankId'].updateValueAndValidity();
      //this.editorForm.controls['visaNumber'].clearValidators();
      //this.editorForm.controls['visaNumber'].updateValueAndValidity();
    }
    else if (evnt == 4) {
      this.editorForm.controls['safeId'].clearValidators();
      this.editorForm.controls['safeId'].updateValueAndValidity();

      this.editorForm.controls['fromBankId'].clearValidators();
      this.editorForm.controls['fromBankId'].updateValueAndValidity();
      this.editorForm.controls['chequeNumber'].clearValidators();
      this.editorForm.controls['chequeNumber'].updateValueAndValidity();
      this.editorForm.controls['dueDate'].clearValidators();
      this.editorForm.controls['dueDate'].updateValueAndValidity();
      this.editorForm.controls['toBankId'].clearValidators();
      this.editorForm.controls['toBankId'].updateValueAndValidity();
      this.editorForm.controls['bankaccountchartId'].clearValidators();
      this.editorForm.controls['bankaccountchartId'].updateValueAndValidity();
      //this.editorForm.controls['visaBankId'].setValidators([Validators.required]);
      //this.editorForm.controls['visaBankId'].updateValueAndValidity();
      //this.editorForm.controls['visaNumber'].setValidators([Validators.required]);
      //this.editorForm.controls['visaNumber'].updateValueAndValidity();
    }
    else if (evnt == 7)
    {
      this.editorForm.controls['safeId'].clearValidators();
      this.editorForm.controls['safeId'].updateValueAndValidity();

      this.editorForm.controls['fromBankId'].setValidators([Validators.required]);
      this.editorForm.controls['fromBankId'].updateValueAndValidity();
      this.editorForm.controls['chequeNumber'].setValidators([Validators.required]);
      this.editorForm.controls['chequeNumber'].updateValueAndValidity();
      this.editorForm.controls['dueDate'].setValidators([Validators.required]);
      this.editorForm.controls['dueDate'].updateValueAndValidity();
      this.editorForm.controls['toBankId'].clearValidators();
      this.editorForm.controls['toBankId'].updateValueAndValidity();
      this.editorForm.controls['bankaccountchartId'].clearValidators();
      this.editorForm.controls['bankaccountchartId'].updateValueAndValidity();
      //this.editorForm.controls['visaBankId'].clearValidators();
      //this.editorForm.controls['visaBankId'].updateValueAndValidity();
      //this.editorForm.controls['visaNumber'].clearValidators();
      //this.editorForm.controls['visaNumber'].updateValueAndValidity();
    }
  }

  onChequeFormValueChanged(evnt) {
    ;
    let frm = this.editorForm;

    this.itemModel.fromBankId = evnt.fromBankId;
    this.itemModel.chequeNumber = evnt.chequeNumber;
    this.itemModel.dueDate = evnt.dueDate;
    this.itemModel.toBankId = evnt.toBankId;
    this.itemModel.toBankAccountChartId = evnt.bankaccountchartId;


    this.editorForm.controls['fromBankId'].setValue(evnt.fromBankId);
    this.editorForm.controls['chequeNumber'].setValue(evnt.chequeNumber);
    this.editorForm.controls['dueDate'].setValue(evnt.dueDate);
    this.editorForm.controls['toBankId'].setValue(evnt.toBankId);
    this.editorForm.controls['bankaccountchartId'].setValue(evnt.bankaccountchartId);

  }

  visaBankCahnged(evnt) {

  }
  fireChanged() {

  }
  getVendorsLookup() {
    //;
    this.ReceiptsServ.getVendorsLookup()
      .subscribe(res => {
        //;
        this.vendors = res;
        //this.PageLoading = false;

      },
        (error) => {
          //this.PageLoading = false;
          console.error(JSON.stringify(error));
          this.notificationService.showOperationFailed();
        }, () => {
        });
  }
  getInventorysLookup() {
    this.ReceiptsServ.getStoreLookup()
      .subscribe(res => {
        //;
        this.inventorys = res;
        //this.PageLoading = false;
      },
        (error) => {
          //this.PageLoading = false;
          console.error(JSON.stringify(error));
          this.notificationService.showOperationFailed();
        }, () => {
        });
  }
  isCashType() {
    let purchaseInvoiceTypeId = this.editorForm.controls['purchaseInvoiceTypeId'].value;
    if (purchaseInvoiceTypeId && purchaseInvoiceTypeId.value) {
      return (purchaseInvoiceTypeId.value == 1);
    }
    else {
      return (purchaseInvoiceTypeId == 1);
    }
  }
  isCreditType(): boolean {
    let purchaseInvoiceTypeId = this.editorForm.controls['purchaseInvoiceTypeId'].value;
    if (purchaseInvoiceTypeId && purchaseInvoiceTypeId.value) {
      //;
      return (purchaseInvoiceTypeId.value == 7);
    }
    else {
      //;
      return (purchaseInvoiceTypeId == 7);
    }
  }
  bindModelToForm(): void {
    ;
    if (this.itemModel) {
      this.editorForm.patchValue({
        code: this.itemModel.code,
        vendorInvoiceCode: this.itemModel.vendorInvoiceCode,
        vendorId: this.itemModel.vendorId,
        inventoryId: this.itemModel.inventoryId,
        date: new Date(this.itemModel.date),
        hasAdditionalExpenses: this.itemModel.hasAdditionalExpenses,
        additionalExpensesAmount: this.itemModel.additionalExpensesAmount,
        hasDiscount: this.itemModel.hasDiscount,
        discountAmount: this.itemModel.discountAmount,
        purchaseInvoiceTypeId: this.itemModel.purchaseInvoiceTypeId,
        safeId: this.itemModel.safeId,
        //visaBankId: this.itemModel.visaBankId,
        //visaNumber: this.itemModel.visaNumber,
        fromBankId: this.itemModel.fromBankId,
        chequeNumber: this.itemModel.chequeNumber,
        dueDate: this.itemModel.dueDate,
        toBankId: this.itemModel.toBankId, 
        bankaccountchartId: this.itemModel.toBankAccountChartId,
       
       
      });

      if (this.itemModel.purchaseInvoiceCostCenters &&
        this.itemModel.purchaseInvoiceCostCenters.length > 0) {
        this.editorForm.controls['hasCostCenter'].setValue(true);
        this.editorForm.controls['costCenterId'].setValue(this.itemModel.purchaseInvoiceCostCenters[0].costCenterId);
      }

      if (this.itemModel.purchaseInvoiceTypeId) {

      }

;
      this.cheque.fromBankId = this.itemModel.fromBankId;
      this.cheque.chequeNumber = this.itemModel.chequeNumber;
      this.cheque.dueDate = this.itemModel.dueDate;
      this.cheque.toBankId = this.itemModel.toBankId;
      this.cheque.bankaccountchartId = this.itemModel.toBankAccountChartId;

    }
  }
  collectModelFromForm(): void {
    ;
    this.itemModel.code = this.editorForm.controls["code"].value;
    this.itemModel.vendorInvoiceCode = this.editorForm.controls["vendorInvoiceCode"].value;
    this.itemModel.vendorId = this.editorForm.controls["vendorId"].value;
    this.itemModel.toBankAccountChartId = this.editorForm.controls["bankaccountchartId"].value;
    if (this.itemModel.vendorId.value) {
      this.itemModel.vendorId = this.itemModel.vendorId.value;
    }
    this.itemModel.inventoryId = this.editorForm.controls["inventoryId"].value;
    if (this.itemModel.inventoryId && 
      this.itemModel.inventoryId.value) {
      this.itemModel.inventoryId = this.itemModel.inventoryId.value;
    }
    this.itemModel.date = this.editorForm.controls["date"].value;
    this.itemModel.additionalExpensesAmount = this.editorForm.controls["additionalExpensesAmount"].value;
    this.itemModel.hasAdditionalExpenses = this.editorForm.controls["hasAdditionalExpenses"].value;
    this.itemModel.discountAmount = this.editorForm.controls["discountAmount"].value;
    this.itemModel.hasDiscount = this.editorForm.controls["hasDiscount"].value;
    //this.itemModel.visaBankId = this.editorForm.controls['visaBankId'].value;
    //this.itemModel.visaNumber = this.editorForm.controls['visaNumber'].value;

    this.itemModel.totalAmountBeforeTax = this.editorForm.controls["totalAmountBeforeTax"].value;
    this.itemModel.taxAmount = this.editorForm.controls["taxAmount"].value;
    this.itemModel.totalAmountAfterTax = this.editorForm.controls["totalAmountAfterTax"].value;
    this.itemModel.totalExpenses = this.editorForm.controls["totalExpenses"].value;
    this.itemModel.totalDiscount = this.editorForm.controls["totalDiscount"].value;
    this.itemModel.netAmount = this.editorForm.controls["netAmount"].value;



    this.itemModel.purchaseInvoiceTypeId = this.editorForm.controls['purchaseInvoiceTypeId'].value;
    if (this.itemModel.purchaseInvoiceTypeId.value) {
      this.itemModel.purchaseInvoiceTypeId = this.itemModel.purchaseInvoiceTypeId.value;
    }
    this.itemModel.safeId = this.editorForm.controls['safeId'].value;
    // if (this.itemModel.safeId.value) {
    //   this.itemModel.safeId = this.itemModel.safeId.value;
    // }
    //;
    let hasCostCenter = this.isHasCostCenter();
    let costCenter = this.getSelectedCostCenter();

    if (hasCostCenter && (costCenter.value || costCenter)) {
      this.itemModel.purchaseInvoiceCostCenters = [];
      let costCenterItem: PurchaseInvoiceCostCenter = new PurchaseInvoiceCostCenter();

      if (costCenter.value) {
        costCenterItem.costCenterId = costCenter.value;
      }
      else {
        costCenterItem.costCenterId = costCenter;
      }

      costCenterItem.amount = this.itemModel.netAmount;

      this.itemModel.purchaseInvoiceCostCenters.push(costCenterItem);
    }
    this.itemModel.products = this.editorForm.controls["products"].value;
    this.itemModel.products.forEach(element => {
      element.code = element.productId;
    });

    if (this.editorMode == EditorMode.edit) {
      this.itemModel.id = this.id;
    }
  }

  isHasCostCenter(): boolean {
    return this.editorForm.controls['hasCostCenter'].value;
  }

  getSelectedCostCenter(): any {
    return this.editorForm.controls['costCenterId'].value;
  }

  showCostCenterRequiredMessage() {
    this.translateService.get(['costCenter.required'])
      .subscribe(res => {
        this.notificationService.showError(res['costCenter.required']);
      });
  }

  isHasAdditionalExpenses(): boolean {
    return this.editorForm.controls['hasAdditionalExpenses'].value;
  }

  isHasDiscount(): boolean {
    return this.editorForm.controls['hasDiscount'].value;
  }

  // checkDate(): boolean {
  //   ;
  //   let selectedDate: any = this.editorForm.controls['date'].value;
  //   let now = new Date(Date.now());

  //   if (selectedDate > now) {
  //     this.notificationService.showTranslateHtmlError_h5('error.maxDateAlert');
  //     return false;
  //   }
  //   else {
  //     return true;
  //   }
  // }

  save(): void {
    debugger;
    if (this.canEdit()) {
      this.isProccessing = true;

      if (this.editorForm.valid) {
        //if(this.checkDate() == false) return;

        if (this.isHasCostCenter()) {
          let costCenter = this.getSelectedCostCenter();
          if (!costCenter) {
            this.showCostCenterRequiredMessage();
            this.isProccessing = false;
            return;
          }
        }
        if (!this.itemModel.products || this.itemModel.products.length < 1) {
          this.notificationService.showTranslateError('purchasing.rebate.productReq');
          this.isProccessing = false;
          return;
        }
        if (this.editorForm.controls['hasAdditionalExpenses'].value == true && this.editorForm.controls['additionalExpensesAmount'].value < 1) {
          this.notificationService.showTranslateError('purchasing.rebate.additionalExpensesReq');
          this.isProccessing = false;
          return;
        }
        if (this.editorForm.controls['hasDiscount'].value == true && this.editorForm.controls['discountAmount'].value < 1) {
          this.notificationService.showTranslateError('purchasing.rebate.discountReq');
          this.isProccessing = false;
          return;
        }

      }
      else {
        this.isProccessing = false;
        this.notificationService.showDataMissingError();
        return;
      }

      if (this.editorMode == EditorMode.add) {  
        this.collectModelFromForm();
        this.purchasingService.addPurchaseInvoice(this.itemModel)
          .subscribe(res => {
            this.itemModel = res;
              this.journalPreview = res.journal;
              this.journalPreviewShow  = true;
              $('#openPostlBTN').click();
          },
            (error) => {
              this.isProccessing = false;
              this.errorService.handerErrors(error);
            },
            () => {
              this.isProccessing = false;
              console.log(`addPurchaseInvoice completed.`);
            });
      }
      else if (this.editorMode == EditorMode.edit) {
        this.collectModelFromForm();
        this.purchasingService.updatePurchaseInvoice(this.itemModel)
          .subscribe(res => {
            this.notificationService.showOperationSuccessed();
            this.gotoList();
          },
            (error) => {
              this.isProccessing = false;
              this.errorService.handerErrors(error);
            },
            () => {
              ;
              this.isProccessing = false;
              console.log(`addPurchaseInvoice completed.`);
            });
      }
    }
  }


  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };
  PageLoading: boolean;
   editorForm: FormGroup;
   editorMode: EditorMode = EditorMode.add;
   editorModeEnum = EditorMode;
   id: any;
   isProccessing: boolean;
   vat: any;
   vendors: any[];
   inventorys: any[];
   purchaseInvoiceTypes: any[];
   safes: any[];
   banks: any[];
   itemModel: PurchaseInvoice = new PurchaseInvoice();
  SelectedCostCenter: number;
  costCenter: CostCenters[] = [];
  //
  totalAmount: number = 0;
  totalExpenses: number = 0;
  totalDiscount: number = 0;
  netValue: number = 0;
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
  generalSetting: GeneralSetting;
  cheque: Cheque = new Cheque();
}
