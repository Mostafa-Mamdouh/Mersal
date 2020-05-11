import { StoreService } from './../../../Services/store.service';
import { KendoDropDown } from './../../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { FinancialService } from './../../../../Financial/Services/financial.service';
import { EditorMode } from './../../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { Location } from '@angular/common';

import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ProductList } from '../../../../Products/Models/product-list.model';
import { CostCenters } from '../../../../Financial/Models/receipts.model';
import { NotificationService } from '../../../../../SharedFeatures/SharedMain/Services/notification.service';
import { StoreProducts } from '../../../Models/opening-balance.model';
import { InventoryTransfer } from '../../../Models/inventory-transfer.model';
import { InventoryCostCenters } from '../../../Models/opening-balance.model';
import { ErrorService } from '../../../../../SharedFeatures/SharedMain/Services/error.service';

declare var $: any;


@Component({
  selector: 'inventory-transfers-editor',
  templateUrl: './inventory-transfers-editor.component.html',
  styleUrls: ['./inventory-transfers-editor.component.css']
})
export class InventoryTransfersEditorComponent implements OnInit {

  constructor(
    private ReceiptsServ: FinancialService,
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
    this.getCostCenters();
    this.getInventorysLookup();
    this.extractRouteParams();
  }

  buildForms(): void {
    this.modelForm = this.fb.group({
      id: [],
      code: [null],
      date: [new Date(), [Validators.required]],
      inventoryFromId: [null, [Validators.required]],
      inventoryToId: [null, [Validators.required]],
      descriptionAr: [null, [Validators.required]],
      descriptionEn: [null],
      CostCentersCheck: [],
      OneCostCenterCheck: [],
      OnCostCenterValue: [],
      products: this.fb.array([])
    });
  }

  extractRouteParams(): void {
    let editId = this.route.snapshot.params['editId'];
    let detailId = this.route.snapshot.params['detailId'];
    if (editId) {
      this.editorMode = EditorMode.edit
      this.editId = editId;
      this.id = editId;
    }
    else if (detailId) {
      this.editorMode = EditorMode.detail;
      this.detailId = detailId;
      this.id = detailId;
    }
    else {
      this.editorMode = EditorMode.add;
    }
    if (this.id) {
      this.PageLoading = true;
      this.storeServ.getInventoryTransfer(this.id).subscribe(res => {
        this.PageLoading = false;
        if (res != null) {
          this.buildForms();
          // debugger;
          this.model = res;
          //this.editorMode = EditorMode.detail;
          this.bindDetailModelToForm();
        }
      },
        () => {
          this.PageLoading = false;
          this.notification.showOperationFailed();
        })
    }
  }


  //validaton 
  onProductListChanged(evnt: FormArray) {
    // debugger;
    const list = this.modelForm.get('products') as FormArray;
    list.value.forEach((element, index) => {
      (this.modelForm.get('products') as FormArray).removeAt(0);
    });
    (this.modelForm.get('products') as FormArray).removeAt(0);
    evnt.value.forEach((element, index) => {
      if (element.id)
        this.addProduct();
    });
    (this.modelForm.get('products') as FormArray).patchValue(evnt.value);
    console.log((this.modelForm.get('products') as FormArray).value);
  }
  //edit

  bindDetailModelToForm(): void {
    // debugger
    if (this.model) {
      this.modelForm.patchValue({
        id: this.model.id,
        code: this.model.code,
        inventoryFromId: this.model.inventoryFromId,
        inventoryToId: this.model.inventoryToId,
        date: new Date(this.model.date),
        descriptionAr: this.model.descriptionAr,
        descriptionEn: this.model.descriptionEn,
      });
      if (this.model.inventoryTransferCostCenter &&
        this.model.inventoryTransferCostCenter.length > 0) {
        this.modelForm.controls['CostCentersCheck'].setValue(true);
        if (this.editorMode != EditorMode.add) {
          this.DetailsCostCenters = this.model.inventoryTransferCostCenter;
        }
        // if (this.editorMode == EditorMode.edit) {
        //   this.EditeCostCenters = this.model.inventoryTransferCostCenter;
        // }
        this.CostCenters = this.model.inventoryTransferCostCenter;
      }
      if (this.model.products && this.model.products.length > 0) {
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
        this.InventoryTransfer.inventoryTransferCostCenter = new Array();
      }
    });
  }

  onOneCostCenterChanged(id) {
    this.InventoryTransfer.inventoryTransferCostCenter = new Array();
    this.InventoryTransfer.inventoryTransferCostCenter.push({
      id: id.value,
      costCenterId: id.value,
      inventoryOpeningBalanceId: null
    });
    console.log("one cost center to Api " + JSON.stringify(this.InventoryTransfer.inventoryTransferCostCenter))
  }

  addCostCenters(costCentersList) {
    // debugger;
    this.IsOneCostCenterChecked = false;
    this.InventoryTransfer.inventoryTransferCostCenter = new Array();
    this.InventoryTransfer.inventoryTransferCostCenter = costCentersList;
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


  inventoryOpeningBalanceCostCenter: CostCenters[];

  createProduct(): FormGroup {
    return this.fb.group({
      id: [],
      brandId: [null, [Validators.required]],
      measurementUnitId: [null, [Validators.required]],
      quantity: [1, [Validators.required, Validators.min(1)]],
      price: [0, [Validators.required, Validators.min(1)]],
      total: [null, [Validators.required]],
      expenses: [0],
      discount: [0],
      totalDiscount: [0],
      netValue: [0],
    });
  }
  gotoList() {
    let url = [`/store/inventory-transfers/list`];
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
      this.inventoryListFrom = res;
      this.inventoryListTo = res;
      // this.PageLoading = false;
    }, () => {
      //  this.PageLoading = false;
      this.notification.showOperationFailed();
    }, () => {
    });
  }

  getProductByInventoryId(id) {
    debugger;
    this.inventoryListTo = this.inventoryListFrom;
    this.inventoryListTo = this.inventoryListTo.filter(x => x.id != id);
    this.storeServ.getProductByInventoryId(id).subscribe(res => {
      this.products = res;
      if (this.products.length == 0) {
        this.notification.showTranslateHtmlInfo_h5("error.inventoryDonotHaveProduct");
      }

    }, () => {
      //  this.PageLoading = false;
      this.notification.showOperationFailed();
    }, () => {
    });
  }

  validateSourceAndDestAreSame(): boolean {
    let result = false;

    let from = this.modelForm.controls['inventoryFromId'].value;
    let to = this.modelForm.controls['inventoryToId'].value;

    if (from && to && from == to) {
      result = true;
      this.notification.showTranslateHtmlError_h5('error.invalidSourceAndDestInventory');
    }

    return result;
  }

  //submit
  submit() {
    // debugger
    this.validForm = true;
    this.model = this.modelForm.value;
    if (this.InventoryTransfer.inventoryTransferCostCenter) {
      this.model.inventoryTransferCostCenter = this.InventoryTransfer.inventoryTransferCostCenter;
    } else {
      this.model.inventoryTransferCostCenter = this.CostCenters;
    }


    if (this.model.inventoryTransferCostCenter) {
      this.model.inventoryTransferCostCenter.forEach(item => {
        item.costCenterId = item.id;
      });
    }

    if (this.model.products.length < 1) {
      this.notification.showTranslateError('purchasing.rebate.productReq');
      this.validForm = false;
    }

    if (this.validForm) {
      if (this.modelForm.valid) {

        if (this.validateSourceAndDestAreSame() == true) {
          return;
        }

        this.PageLoading = true;
        if (this.model.id > 0) {
          this.storeServ.updateInventoryTransfer(this.model).subscribe(res => {
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
          this.storeServ.addInventoryTransfer(this.model).subscribe(res => {
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


  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };
  model: InventoryTransfer;
  modelForm: FormGroup;
  bsDatePickerValue: Date = new Date();
  InventoryTransfer: InventoryTransfer = new InventoryTransfer();
  products: StoreProducts[];
  DetailsCostCenters: any[];
  editorMode: EditorMode = EditorMode.add;
  editorModeEnum = EditorMode;
  id: any;
  SelectedCostCenter: number;
  totalCostCenters: number = 0;

  PageLoading: boolean = false;
  validForm: boolean = false;

  ProductList: ProductList[];
  inventoryList: any[];
  costCenter: CostCenters[] = [];
  IsOneCostCenterChecked: boolean;
  CostCenterDropDown: any[];
  inventoryListFrom: any[];
  inventoryListTo: any[];
  detailId: number;
  editId: number;
  EditeCostCenters: InventoryCostCenters[];
  CostCenters: InventoryCostCenters[];
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
  canEditPrice:boolean = false;
}
