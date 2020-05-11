import { Component, Input, Output, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import {MovementTypeEnum} from '../../../JournalEntries/Models/movement-type-enum';
import {FinancialSetting} from '../../Models/financial-setting.model';
import {PostingSetting} from '../../Models/posting-setting.model';
import {VendorSetting} from '../../Models/vendor-setting.model';
import { SettingService } from '../../../Setting/Services/setting.service';


@Component({
  selector: 'vendor-editor-editor',
  styleUrls: ['./vendor-editor.component.scss'],
  templateUrl: './vendor-editor.component.html'
})
export class VendorEditorComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private settingService: SettingService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getAccountChartsLookup();
    this.buildForm();       
    this.extractRouteParams();   
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      cashPurchaseAccountNumber: [null, [Validators.required]],
      futurePurchaseAccountNumber: [null, [Validators.required]],
      purchaseDiscountAccountNumber: [null, [Validators.required]],
      purchaseExpensesAccountNumber: [null, [Validators.required]],
      purchaseTaxAccountNumber: [null, [Validators.required]],
      cashPurchasesRebateAccountNumber: [null, [Validators.required]],
      futurePurchaseRebateAccountNumber: [null, [Validators.required]],
      purchaseRebateDiscountAccountNumber: [null, [Validators.required]],
      purchaseRebateExpensesAccountNumber: [null, [Validators.required]],
      purchaseRebateTaxAccountNumber: [null, [Validators.required]]      
    });   
  }

  extractRouteParams(): void {   
    this.PageLoading = true;    
      this.settingService.getVendorSetting()
        .subscribe(res => {     
          this.PageLoading = false;        
          this.itemModel = res;
          this.bindModelToForm();
        },
          (error) => {
            this.PageLoading = false;   
            this.notificationService.showOperationFailed();
          },
          () => {

          });
  }

  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }
  gotoList() {
    this.location.back();

    // let url = [`/setting/control-panel`];
    // this.router.navigate(url);
  }
  
  bindModelToForm(): void {
    //debugger;
     if (this.itemModel) {
       this.editorForm.patchValue({
        cashPurchaseAccountNumber: +this.itemModel.cashPurchaseAccountNumber,
        futurePurchaseAccountNumber: +this.itemModel.futurePurchaseAccountNumber,
        purchaseDiscountAccountNumber: +this.itemModel.purchaseDiscountAccountNumber,
        purchaseExpensesAccountNumber: +this.itemModel.purchaseExpensesAccountNumber,
        purchaseTaxAccountNumber: +this.itemModel.purchaseTaxAccountNumber,
        cashPurchasesRebateAccountNumber: +this.itemModel.cashPurchasesRebateAccountNumber,
        futurePurchaseRebateAccountNumber: +this.itemModel.futurePurchaseRebateAccountNumber,
        purchaseRebateDiscountAccountNumber: +this.itemModel.purchaseRebateDiscountAccountNumber,
        purchaseRebateExpensesAccountNumber: +this.itemModel.purchaseRebateExpensesAccountNumber,
        purchaseRebateTaxAccountNumber: +this.itemModel.purchaseRebateTaxAccountNumber
       });
     }
  }

  getAccountChartsLookup() {
    this.ReceiptsServ.getAccountChartsLookup()
      .subscribe(res => {
        //this.PageLoading = false;

        this.AccountCharts = res;        
      }, () => {
        //this.PageLoading = false;

        this.notificationService.showOperationFailed();
      }, () => {
      });
  }

  save() {
    if (this.editorForm.valid) {
      this.itemModel = this.editorForm.value;

      this.settingService.updateVendorSetting(this.itemModel)
        .subscribe(res => {
          this.notificationService.showOperationSuccessed();
          this.gotoList();
        },
          (error) => {
            this.notificationService.showOperationFailed();
          },
          () => {

          });
    }
  }


  private editorForm: FormGroup;
  private editorMode: EditorMode = EditorMode.add;
  private editorModeEnum = EditorMode;
  private id: any;
  PageLoading: boolean = true;
  private isProccessing: boolean;
  private itemModel: VendorSetting = new VendorSetting();
  private AccountCharts: any[];
}
