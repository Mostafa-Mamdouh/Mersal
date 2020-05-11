import { Component, Input, Output, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
//import { JournalTypeCodes } from '../../Models/journal-type-codes.enum';
//import { BankMovement } from '../../Models/bank-movement.model';
import { JournalPostingService } from '../../Services/journal-posting.service';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import {PostJournal} from '../../Models/post-journal.model';
import {MovementTypeEnum} from '../../../JournalEntries/Models/movement-type-enum';
//import { PurchasingService } from '../../../Purchasing/Services/Purchasing.service';
import { SettingService } from '../../../Setting/Services/setting.service';
import {PostingSetting} from '../../../Setting/Models/posting-setting.model';

@Component({
  selector: 'journal-posting-editor',
  styleUrls: ['./editor.component.scss'],
  templateUrl: './editor.component.html'
})
export class EditorComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private journalPostingService: JournalPostingService,
    private settingService: SettingService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.buildForm();
    this.getPostingSetting();
    this.extractRouteParams();   
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      id: [null],
      toDate: [new Date()],
      isAutomaticPosting: [false],
      isBulkPosting: [false],
      
      postReceiptsMovement: [null],
      postPaymentMovement: [null],
      postBankMovement: [null],
      postPurchaseInvoice: [null],
      postPurchaseRebate: [null],
      postStoreMovement: [null],
      postSalesInvoice: [null],
      postSalesRebate: [null],
      
      postedReceiptsMovementCount: [null],
      postedPaymentMovementCount: [null],
      postedBankMovementCount: [null],
      postedPurchaseInvoiceCount: [null],
      postedPurchaseRebateCount: [null],
      postedStoreMovementCount: [null],
      postedSalesInvoiceCount: [null],
      postedSalesRebateCount: [null],
    });   
  }

  extractRouteParams(): void {
    //debugger;   
    let detailId = +this.route.snapshot.params['detailId'];
   
    if (detailId) {
      this.editorMode = EditorMode.detail;
      this.id = detailId;
    }
    else {
      this.editorMode = EditorMode.add;
    }

    if (this.id) {
      this.journalPostingService.get(this.id)
        .subscribe(res => {
          //debugger;
          this.itemModel = res;
          this.bindModelToForm();
        },
          (error) => {
            this.notificationService.showOperationFailed();
          })
    }
  }

  getPostingSetting(): void {
    this.settingService.getPostingSetting()
    .subscribe(res => {
      //debugger;
      this.postingSetting = res;
    },
    (error) => {

    },
    () => {

    })
  }

  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }
  gotoList() {
    let url = [`/journal-posting/list`];
    this.router.navigate(url);
  }

  goToBack(){
    this.location.back();
  }
  
  bindModelToForm(): void {
    if (this.itemModel) {
      this.editorForm.patchValue({
        isAutomaticPosting: this.itemModel.isAutomaticPosting,
        toDate: this.itemModel.toDate,
       
      });
    }
  }
 

  PageLoading: boolean;
  private editorForm: FormGroup;
  private editorMode: EditorMode = EditorMode.add;
  private editorModeEnum = EditorMode;
  private id: any;
  private isProccessing: boolean;
  private itemModel: PostJournal = new PostJournal();
  postingSetting: PostingSetting = {
    isBulkPosting: false,
    isPostingAutomatic: true,
    allowPostingAccountCurrencyMisMatch: false
  };  
}
