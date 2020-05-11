import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { DropDownFilterSettings, ValueTemplateDirective } from '@progress/kendo-angular-dropdowns';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormArray, FormArrayName, MinLengthValidator } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { JournalPostingService } from '../../Services/journal-posting.service';
import { PostJournal } from '../../Models/post-journal.model';
import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { SettingService } from '../../../Setting/Services/setting.service';
import { PostingSetting } from '../../../Setting/Models/posting-setting.model';
import { MovementTypeEnum } from '../../../JournalEntries/Models/movement-type-enum';

@Component({
  selector: 'post-journal',
  templateUrl: './post-journal.component.html',
  styleUrls: ['./post-journal.component.scss']
})
export class PostJournalComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private journalPostingService: JournalPostingService,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private settingService: SettingService
  ) {

  }

  ngOnInit() {
    this.setLanguageSubscriber();
    this.buildForm();
    this.getPostingSetting();
  }

  setLanguageSubscriber(): void {
    this.language = this.translateService.currentLang;
    this.translateService.onLangChange.subscribe(val => {

      this.language = val.lang;
    },
      (error) => {

      },
      () => {

      });
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

  submit(): void {
    if (this.editorForm.valid) {

    }
    else {
      this.notificationService.showDataMissingError();
    }
  }
  buildForm(): void {
    this.editorForm = this.fb.group({
      selectAll: [false],
      postReceiptsMovement: [false, [Validators.required]],
      postPaymentMovement: [false, [Validators.required]],
      postBankMovement: [false, [Validators.required]],
      postPurchaseInvoice: [false, [Validators.required]],
      postPurchaseRebate: [false, [Validators.required]],
      postStoreMovement: [false, [Validators.required]],
      postSalesInvoice: [false, [Validators.required]],
      postSalesRebate: [false, [Validators.required]],
      toDate: [new Date()]
    });
  }

  selectAllChanged() {
    let val = this.editorForm.controls['selectAll'].value;
    val = !val;

    this.editorForm.controls['postReceiptsMovement'].setValue(val);
    this.editorForm.controls['postPaymentMovement'].setValue(val);
    this.editorForm.controls['postBankMovement'].setValue(val);
    this.editorForm.controls['postPurchaseInvoice'].setValue(val);
    this.editorForm.controls['postPurchaseRebate'].setValue(val);
    this.editorForm.controls['postStoreMovement'].setValue(val);
    this.editorForm.controls['postSalesInvoice'].setValue(val);
    this.editorForm.controls['postSalesRebate'].setValue(val);
  }

  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }

  isAnySelected(): boolean {
    let result = false;

    if (this.editorForm.controls['postReceiptsMovement'].value) return true;
    if (this.editorForm.controls['postPaymentMovement'].value) return true;
    if (this.editorForm.controls['postBankMovement'].value) return true;
    if (this.editorForm.controls['postPurchaseInvoice'].value) return true;
    if (this.editorForm.controls['postPurchaseRebate'].value) return true;
    if (this.editorForm.controls['postStoreMovement'].value) return true;
    if (this.editorForm.controls['postSalesInvoice'].value) return true;
    if (this.editorForm.controls['postSalesRebate'].value) return true;

    return result;
  }

  gotoList() {
    let url = [`/journal-posting/list`];
    this.router.navigate(url);
  }
  gotoJournalPreviewList() {
    let types: string = "";
    let formValue = this.editorForm.value;

    // ReceiptsMovement = 1,
    // PaymentMovement = 2,
    // BankMovement = 3,
    // PurchaseInvoice = 4,
    // PurchaseRebate = 5,
    // StoreMovement = 6,
    // SalesInvoice = 7,
    // SalesRebate = 8

    types += `/${(formValue.postReceiptsMovement)}`;
    types += `/${(formValue.postPaymentMovement)}`;
    types += `/${(formValue.postBankMovement)}`;
    types += `/${(formValue.postPurchaseInvoice)}`;
    types += `/${(formValue.postPurchaseRebate)}`;
    types += `/${(formValue.postStoreMovement)}`;
    types += `/${(formValue.postSalesInvoice)}`;
    types += `/${(formValue.postSalesRebate)}`;



    let url = [`/journal/preview-list${types}`];
    this.router.navigate(url);
  }

  bindModelToForm(): void {
    if (this.itemModel) {
      this.editorForm.patchValue({
        postReceiptsMovement: this.itemModel.postReceiptsMovement,
        postPaymentMovement: this.itemModel.postPaymentMovement,
        postBankMovement: this.itemModel.postBankMovement,
        postPurchaseInvoice: this.itemModel.postPurchaseInvoice,
        postPurchaseRebate: this.itemModel.postPurchaseRebate,
        postStoreMovement: this.itemModel.postStoreMovement,
        postSalesInvoice: this.itemModel.postSalesInvoice,
        postSalesRebate: this.itemModel.postSalesRebate,
        toDate: this.itemModel.toDate
      });
    }
  }
  collectModelFromForm(): void {
    //debugger;
    this.itemModel = this.editorForm.value;
  }

  save() {
    if (this.editorForm.valid) {
      if(this.isAnySelected() == false) {
        this.notificationService.showDataMissingError();
        return;
      }


      this.isProccessing = true;
      this.collectModelFromForm();
      debugger;
      this.journalPostingService.postJournal(this.itemModel)
        .subscribe(res => {
          debugger;
          this.notificationService.showOperationSuccessed();
          this.isProccessing = false;
          this.gotoJournalPreviewList();
          //this.gotoList();
        },
          (error) => {
            this.notificationService.showOperationFailed();
            this.isProccessing = false;
          },
          () => {

          });
    }
    else {
      this.notificationService.showDataMissingError();
    }
  }

  PageLoading: boolean;
  language: any;
  editorForm: FormGroup;
  editorFormErrors: any;
  private editorMode: EditorMode = EditorMode.add;
  private isProccessing: boolean;
  private itemModel: PostJournal = new PostJournal();
  maxDate: Date = new Date();
  postingSetting: PostingSetting = {
    isBulkPosting: false,
    isPostingAutomatic: true,
    allowPostingAccountCurrencyMisMatch: false
  };
}
