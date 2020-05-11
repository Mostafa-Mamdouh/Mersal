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
  selector: 'financial-editor-editor',
  styleUrls: ['./financial-editor.component.scss'],
  templateUrl: './financial-editor.component.html'
})
export class FinancialEditorComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private settingService: SettingService,
    private location: Location
  ) { 

  }

  ngOnInit(): void {
    this.getAccountChartsLookup();
    this.buildForm();       
    this.extractRouteParams();   
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      showCasesThatMetRequiredAmount: [null, [Validators.required]],
      useChecksUnderCollection: [null, [Validators.required]],
      checksUnderCollectionAccountNumber: [null, [Validators.required]],
      vatAccountNumber: [null, [Validators.required]],  
      donationAccountNumber: [null, [Validators.required]],    
      donationReturnAccountNumber: [null, [Validators.required]],
      temporaryCovenantAccountNumber: [null, [Validators.required]] ,
      bankingPaymentsAccountNumber: [null, [Validators.required]] ,
      receiptPapersAccountNumber: [null, [Validators.required]] ,
      checksUnderReceiptPapersAccountNumber: [null, [Validators.required]] ,
      generalDonationsAccountNumber: [null, [Validators.required]] ,
    });   
  }

  extractRouteParams(): void {  
    this.PageLoading = true;     
      this.settingService.getFinancialSetting()
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
        showCasesThatMetRequiredAmount: this.itemModel.showCasesThatMetRequiredAmount,
        useChecksUnderCollection: this.itemModel.useChecksUnderCollection,
        vatAccountNumber: +this.itemModel.vatAccountNumber,
        checksUnderCollectionAccountNumber: +this.itemModel.checksUnderCollectionAccountNumber,
        donationAccountNumber: +this.itemModel.donationAccountNumber,     
        donationReturnAccountNumber: +this.itemModel.donationReturnAccountNumber,
        temporaryCovenantAccountNumber: +this.itemModel.temporaryCovenantAccountNumber,    
        bankingPaymentsAccountNumber: +this.itemModel.bankingPaymentsAccountNumber,    
        receiptPapersAccountNumber: +this.itemModel.receiptPapersAccountNumber, 
        checksUnderReceiptPapersAccountNumber: +this.itemModel.checksUnderReceiptPapersAccountNumber,    
        generalDonationsAccountNumber: +this.itemModel.generalDonationsAccountNumber,    


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

      this.settingService.updateFinancialSetting(this.itemModel)
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
  private itemModel: FinancialSetting = new FinancialSetting();
  private AccountCharts: any[];
  
}
