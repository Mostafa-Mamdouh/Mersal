import { StoreService } from './../../../Services/store.service';
import { KendoDropDown } from './../../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { PurchasingService } from './../../../../Purchasing/Services/Purchasing.service';
import { FinancialService } from './../../../../Financial/Services/financial.service';
import { EditorMode } from './../../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { Location } from '@angular/common';

import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ProductList } from '../../../../Products/Models/product-list.model';
import { CostCenters } from '../../../../Financial/Models/receipts.model';
import { NotificationService } from '../../../../../SharedFeatures/SharedMain/Services/notification.service';
import { StoreStartBalance, StoreProducts } from '../../../Models/opening-balance.model';
import { InventoryMovement } from '../../../Models/inventory-movement.model';
import { InventoryCostCenters } from '../../../Models/opening-balance.model';
import { ErrorService } from '../../../../../SharedFeatures/SharedMain/Services/error.service';
import { InventoryMovementTypeEnum } from '../../../Models/inventory-movement-type.enum';

declare var $: any;


@Component({
  selector: 'inventory-movement-editor',
  templateUrl: './inventory-movement-editor.component.html',
  styleUrls: ['./inventory-movement-editor.component.css']
})
export class InventoryMovementEditorComponent implements OnInit {
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };
  model: InventoryMovement;
  modelForm: FormGroup;
  bsDatePickerValue: Date = new Date();
  inventoryMovement: InventoryMovement = new InventoryMovement();
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
  outgoingTypeShow: boolean = false;

  ProductList: ProductList[];
  inventoryList: any[];
  costCenter: CostCenters[] = [];
  IsOneCostCenterChecked: boolean;
  CostCenterDropDown: any[];

  detailId: number;
  editId: number;
  movementTypeList: any[];
  outgoingTypeList: any[]
  canEditPrice:boolean;
  CostCenters: InventoryCostCenters[];
  journalPreview: any;
  journalPreviewShow: boolean;


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
    this.getMovementTypeLookup();
    this.addProduct();
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
      this.storeServ.getInventoryMovement(this.id).subscribe(res => {
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

        this.notification.showOperationFailed();
      }, () => {
      });
  }

  //validaton 
  onProductListChanged(evnt: FormArray) {
    debugger;
    evnt.value.forEach((element, index) => {
      (this.modelForm.get('products') as FormArray).removeAt(index);
    });
    (this.modelForm.get('products') as FormArray).removeAt(0);
    evnt.value.forEach(() => {
      this.addProduct();
    });
    (this.modelForm.get('products') as FormArray).patchValue(evnt.value);
    //console.log(this.modelForm.value);
  }
  //edit


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
        referenceNumber: this.model.referenceNumber,
        inventoryMovementTypeId: this.model.inventoryMovementTypeId,
        outgoingTypeId: this.model.outgoingTypeId,
      });
      if (this.model.inventoryMovementCostCenter &&
        this.model.inventoryMovementCostCenter.length > 0) {
        this.modelForm.controls['CostCentersCheck'].setValue(true);
        if (this.editorMode != EditorMode.add) {
          this.DetailsCostCenters = this.model.inventoryMovementCostCenter;
        }
        // if (this.editorMode == EditorMode.edit) {
        //   this.EditeCostCenters = this.model.inventoryMovementCostCenter;
        // }
        this.CostCenters = this.model.inventoryMovementCostCenter;
      }
      if (this.model.products && this.model.products.length > 0) {
        this.products = this.model.products;
      }
    }
  }

  journalValueChange(event){
    this.model.journal = event;
  }

  journalApprove(event){
    debugger;
    //this.collectModelFromForm();
    this.model.journal = event;
    this.storeServ.addInventoryMovement(this.model)
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
        this.inventoryMovement.inventoryMovementCostCenter = new Array();
      }
    });
  }

  onOneCostCenterChanged(id) {
    this.inventoryMovement.inventoryMovementCostCenter = new Array();
    this.inventoryMovement.inventoryMovementCostCenter.push({
      id: id.value,
      costCenterId: id.value,
      inventoryOpeningBalanceId: null
    })
    console.log("one cost center to Api " + JSON.stringify(this.inventoryMovement.inventoryMovementCostCenter))
  }

  movementTypeValueChange(event){
    if(event == 4){
      this.outgoingTypeShow = true;
      this.modelForm.controls["outgoingTypeId"].setValidators(Validators.required);
      this.modelForm.updateValueAndValidity();
    }
    else{
      this.outgoingTypeShow = false;
      this.modelForm.controls["outgoingTypeId"].clearValidators();
      this.modelForm.updateValueAndValidity();
      this.modelForm.controls["outgoingTypeId"].setValue(null);
    }
  }

  addCostCenters(costCentersList) {
    debugger
    this.IsOneCostCenterChecked = false;
    this.inventoryMovement.inventoryMovementCostCenter = new Array();
    this.inventoryMovement.inventoryMovementCostCenter = costCentersList;
    this.notification.showTranslateSuccess('costCenter.SucessCostCentersAdd');
  }


  //form
  addProduct() {
    debugger;
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
      referenceNumber: [null, [Validators.required, Validators.min(0)]],
      inventoryMovementTypeId: [null, [Validators.required]],
      CostCentersCheck: [],
      OneCostCenterCheck: [],
      OnCostCenterValue: [],
      outgoingTypeId: [],
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
    let url = [`/store/inventory/list`];
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

  getMovementTypeLookup() {
    this.storeServ.getMovementTypeList().subscribe(res => {
      debugger;
      this.movementTypeList = res.filter( x => x.parentInventoryMovementTypeId == null);
      this.outgoingTypeList = res.filter( x => x.parentInventoryMovementTypeId == 4)
      console.log(this.outgoingTypeList);
      // this.PageLoading = false;
    }, () => {
      //  this.PageLoading = false;
      this.notification.showOperationFailed();
    }, () => {
    });
  }

  //submit
  submit() {
    debugger
    this.validForm = true;
    if (!this.inventoryMovement || !this.inventoryMovement.inventoryMovementCostCenter || this.inventoryMovement.inventoryMovementCostCenter.length < 1) {
      this.modelForm.controls['CostCentersCheck'].setValue(false);
    }
    this.model = this.modelForm.value;
    if (this.inventoryMovement.inventoryMovementCostCenter) {
      this.model.inventoryMovementCostCenter = this.inventoryMovement.inventoryMovementCostCenter;
    } else {
      this.model.inventoryMovementCostCenter = this.CostCenters;
    }

    if (this.model.inventoryMovementCostCenter) {
      this.model.inventoryMovementCostCenter.forEach(item => {
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
          this.storeServ.updateInventoryMovement(this.model).subscribe(res => {
            this.PageLoading = false;
            this.notification.showSuccessAlertForSavedDocument(res.code);
            this.gotoList();
          }, 
          (error) => {
            console.error(JSON.stringify(error));
            this.PageLoading = false;
            this.errorService.handerErrors(error);
          }, () => {
            this.PageLoading = false;
          });
        } else {
          this.storeServ.addInventoryMovement(this.model).subscribe(res => {
            debugger;
            this.model = res;
            if(this.model.inventoryMovementTypeId == 4)
            {
              this.journalPreview = res.journal;
            this.journalPreviewShow = true;
            $('#openPostlBTN').click();
            }
            else{
            this.PageLoading = false;
            this.notification.showSuccessAlertForSavedDocument(res.code);
            this.gotoList();
            }
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
