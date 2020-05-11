import { KendoDropDown } from './../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { DropDownFilterSettings, ValueTemplateDirective } from '@progress/kendo-angular-dropdowns';
import { FinancialService } from './../../../Financial/Services/financial.service';
import { Component, OnInit, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormArray, FormArrayName, MinLengthValidator } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';
import { EventEmitter } from '@angular/core';

import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { JournalEntriesService } from '../../Services/journal-entries.service';
import { AddJournal } from '../../Models/add-journal.model';
import { IfStmt } from '@angular/compiler';
import { PostingStatus } from '../../../JournalPosting/Models/posting-status.enum';
import { MovementTypeEnum } from '../../Models/movement-type-enum';
import { UserService } from '../../../User/Services/user.service';
import { PermissionEnum } from 'src/app/BusinessFeatures/User/Models/permission-enum';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';
import { SettingService } from '../../../Setting/Services/setting.service';
declare var $: any;

@Component({
  selector: 'journal-entries-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.css']
})
export class EditorComponent implements OnInit {
  addJournal: FormGroup;
  @Input() journalPreview: any;
  @Output() journalValueChange: EventEmitter<any> = new EventEmitter();
  @Output() journalApprove: EventEmitter<any> = new EventEmitter();
  @Output() journalReject: EventEmitter<any> = new EventEmitter()
  @Input() isInventory: boolean = false;
  journal: AddJournal;
  PageLoading = true;
  AccountCharts: any[];
  CostCenters: any[];
  totalDebtorValue: number = 0;
  totalCreditorValue: number = 0;
  CostCenterDropDown = new Array();
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private serv: JournalEntriesService,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private location: Location,
    private userService: UserService,
    private errorService: ErrorService,
    private settingService: SettingService
  ) {
  }

  ngOnInit() {
    debugger;
    this.setLanguageSubscriber();
    this.checkIsCurrentUserHassPermission();
    this.getHasPermissionToChangePostedAccounts();
    this.buildForm();
    //this.addJournalDetails();
    this.getAccountChartsLookup();
    this.getCostCenters();
    this.extractRouteParams();
    console.log(this.postingStatus);
    console.log(this.journalPreview);
  }

  extractRouteParams() {
    let editId = this.route.snapshot.params['editId'];
    let detailId = this.route.snapshot.params['detailId'];

    if (editId) {
      this.mode = 'edit';
      this.id = editId;
      this
    }
    else if (detailId) {
      this.mode = 'detail';
      this.id = detailId;
      debugger;
      if(!this.hasPermissionToChangePostedAccounts == false)
      {
      this.addJournal.disable();
      }
    }
    else {
      this.mode = 'add';
      this.addJournalDetails();
    }
    debugger;
    if (this.id) {
      this.getItem();
    } else if (this.postingStatus == PostingStatus.needAprove) {
      this.getItem();
    }

    this.addJournal.valueChanges.subscribe(x => {
      if (this.postingStatus == PostingStatus.needAprove) {
        this.journal = this.addJournal.value;
        this.calcTotal();
      }
    },
      (error) => {
        ;

      });
  }

  checkIsCurrentUserHassPermission(): void {
    this.userService.isCurrentUserHassPermission(PermissionEnum.approveOrRejectJournalEntriesUnderReview)
      .subscribe(res => {
        debugger;
        this.canApproveOrRejectJournalEntriesUnderReview = res;
      })
  }

  getHasPermissionToChangePostedAccounts(): void {
    this.serv.getHasPermissionToChangePostedAccounts()
      .subscribe(res => {
        debugger;
        this.hasPermissionToChangePostedAccounts = res;
      },
        (error) => {

        })
  }

  canChangePostedAccounts(): boolean {
    //debugger;
    return (this.postingStatus == this.postingStatusEnum.needAprove &&
      this.hasPermissionToChangePostedAccounts);
  }

  debtorValueChange(event, index) {
    debugger;
    if ((this.addJournal.get('journalDetails') as FormArray).value[index]['debtorValue'] > 0) {
      (this.addJournal.get('journalDetails') as FormArray).controls[index]['controls']['isCreditor'].setValue(false);
    } else {
      (this.addJournal.get('journalDetails') as FormArray).controls[index]['controls']['isCreditor'].setValue(null);
    }
  }

  creditorValueChange(event, index) {
    debugger;
    if ((this.addJournal.get('journalDetails') as FormArray).value[index]['creditorValue'] > 0) {
      (this.addJournal.get('journalDetails') as FormArray).controls[index]['controls']['isCreditor'].setValue(true);
    } else {
      (this.addJournal.get('journalDetails') as FormArray).controls[index]['controls']['isCreditor'].setValue(null);
    }
  }

  accountIdChanged(event, i) {
    debugger;
    let id = event.id;// (this.addJournal.get('journalDetails') as FormArray).value;

    let fullCode = null;
    let account = this.AccountCharts.find(x => x.id == id);
    if (account) {
      fullCode = account.fullCode;
    }
    (this.addJournal.get('journalDetails') as FormArray).controls[i]['controls']['accountId'].setValue(id);

    (this.addJournal.get('journalDetails') as FormArray).controls[i]['controls']['accountFullCode'].setValue(fullCode);
  }

  accountFullCodeChange(event, index) {
    //debugger;
    let fullCode = (this.addJournal.get('journalDetails') as FormArray).controls[index]['controls']['accountFullCode'].value;
    let account = this.AccountCharts.find(x => x.fullCode == fullCode);

    if (account) {
      let accountId = (this.addJournal.get('journalDetails') as FormArray).controls[index]['controls']['accountId'].value;

      if (account.id != accountId) {
        (this.addJournal.get('journalDetails') as FormArray).controls[index]['controls']['accountId'].setValue(account.id);
      }
    }
    else {
      let invalidAccountCodeKey = 'journalEntries.error.invalidAccountCode';
      this.translateService.get([invalidAccountCodeKey])
        .subscribe(res => {
          if (res) {
            this.notificationService.showError(res[invalidAccountCodeKey]);
          }
        });
    }
  }

  calcTotal() {
    this.totalDebtorValue = 0;
    this.totalCreditorValue = 0;
    this.journal.journalDetails.forEach(element => {
      this.totalDebtorValue += element.debtorValue;
      this.totalCreditorValue += element.creditorValue;
    });
  }

  reverseConstraint() {
    debugger;
    if (this.item.isReversed || this.item.reversedFromId) {
      let key = 'journalEntries.canNotReversed';
      this.translateService.get([key])
        .subscribe(res => {
          this.notificationService.showError(res[key]);
        });
    }

    this.mode = 'add';
    var prefix;
    let prefixAr: string = "عكس القيد";
    let prefixEn: string = "Reverse Restriction";

    // this.translateService.get('movements.reverseConstraint').subscribe(val => {
    //    prefix=val;
    // });
    //this.addJournal.controls['isReversed'].setValue(true);
    this.addJournal.controls['reversedFromId'].setValue(this.item.id);

    this.addJournal.controls['descriptionAr'].setValue(prefixAr + ' ' + this.addJournal.controls['descriptionAr'].value);
    this.addJournal.controls['descriptionEn'].setValue(prefixEn + ' ' +
      this.addJournal.controls['descriptionEn'].value != null ?
      this.addJournal.controls['descriptionEn'].value : ' ');

    (this.addJournal.get('journalDetails') as FormArray).controls.forEach(element => {
      let descriptionAR = element['controls']['descriptionAr'].value != null ? element['controls']['descriptionAr'].value : ' ';
      element['controls']['descriptionAr'].setValue(prefixAr + ' ' + descriptionAR);
      let descriptionEn = element['controls']['descriptionEn'].value != null ? element['controls']['descriptionEn'].value : ' ';
      element['controls']['descriptionEn'].setValue(prefixEn + ' ' + descriptionEn);
      //reverse value
      element['controls']['isCreditor'].setValue(!(element['controls']['isCreditor'].value));
      let amount
      if (element['controls']['isCreditor'].value) {
        amount = element['controls']['debtorValue'].value;
        element['controls']['creditorValue'].setValue(amount);
        element['controls']['debtorValue'].setValue(null);
      } else {
        amount = element['controls']['creditorValue'].value;
        element['controls']['creditorValue'].setValue(null);
        element['controls']['debtorValue'].setValue(amount);
      }
    });
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

  goToLinkedJuornal(id: any) {
    this.id = id;
    this.buildForm();
    this.getItem()
    let url = [`/journal/detail/${id}`];
    this.router.navigate(url);
  }

  getAccountChartsLookup() {
    this.ReceiptsServ.getAccountChartsLookup()
      .subscribe(res => {
        debugger;
        this.PageLoading = false;

        this.AccountCharts = res;
      }, () => {
        this.PageLoading = false;

        this.notificationService.showOperationFailed();
      }, () => {
      });

      if(this.isInventory){
      this.settingService.getFixedAssetAccountSetting().subscribe(res =>{
        this.fixedAssetAccount = new Array();
        res.forEach(item => {
          this.fixedAssetAccount.push(item.accountChartViewModel);
        })
      })
    }
  }

  getCostCenters() {
    this.ReceiptsServ.getCostCentersLookups()
      .subscribe(
        res => {
          this.PageLoading = false;
          this.CostCenters = res;
        },
        error => {
          this.PageLoading = false;
          error;
          this.notificationService.showOperationFailed();
        }

      );
  }

  getItem() {
    debugger;
    if (this.journalPreview == undefined) {
      this.serv.get(this.id)
        .subscribe(res => {
          debugger;
          this.item = res;
          this.postingStatus = res.postingStatus;
          this.movementTypeEnum = res.movementType;

          this.item.journalDetails.forEach((journalDetail, x) => {
            if (journalDetail.isCreditor) {
              journalDetail.creditorValue = journalDetail.amount;
            } else {
              journalDetail.debtorValue = journalDetail.amount;
            }
          });
          this.fillForm();
        },
          (error) => {

          },
          () => {

          });
    } else {
      this.journal = this.journalPreview;
      this.postingStatus = this.journalPreview.postingStatus;
      this.movementTypeEnum = this.journalPreview.movementType;

      this.journalPreview.journalDetails.forEach((journalDetail, x) => {
        debugger;
        if (journalDetail.isCreditor) {
          journalDetail.creditorValue = journalDetail.amount;
        } else {
          journalDetail.debtorValue = journalDetail.amount;
        }
      });
      this.fillForm();
    }

  }

  fillForm() {
    if (this.journalPreview == undefined) {
      this.item.journalDetails.forEach((journalDetail, x) => {
        const detail = this.addJournal.get('journalDetails') as FormArray;
        detail.push(this.createJournalDetails());
      });
      this.addJournal.patchValue(this.item);
      this.addJournal.controls['date'].setValue(this.item.date);
      this.addJournal.controls['descriptionEn'].setValue(this.item.descriptionEn);
      this.addJournal.controls['descriptionAr'].setValue(this.item.descriptionAr);
      this.addJournal.controls['documentNumber'].setValue(this.item.documentNumber);
      this.addJournal.controls['isAutomaticPosting'].setValue(this.item.isAutomaticPosting);
      this.addJournal.controls['isBulkPosting'].setValue(this.item.isBulkPosting);

      this.addJournal.controls['isReversed'].setValue(this.item.isReversed);
      this.addJournal.controls['reversedFromId'].setValue(this.item.reversedFromId);
      this.addJournal.controls['reversedToId'].setValue(this.item.reversedToId);
    }
    else {
      const detail = this.addJournal.get('journalDetails') as FormArray;
      detail.removeAt(0);
      this.journalPreview.journalDetails.forEach((journalDetail, x) => {
        debugger;
        detail.push(this.createJournalPreviewDetails(journalDetail));
      });
      this.addJournal.patchValue(this.journalPreview);
      this.addJournal.controls['date'].setValue(this.journalPreview.date);
      this.addJournal.controls['descriptionEn'].setValue(this.journalPreview.descriptionEn);
      this.addJournal.controls['descriptionAr'].setValue(this.journalPreview.descriptionAr);
      this.addJournal.controls['documentNumber'].setValue(this.journalPreview.documentNumber);
      this.addJournal.controls['isAutomaticPosting'].setValue(this.journalPreview.isAutomaticPosting);
      this.addJournal.controls['isBulkPosting'].setValue(this.journalPreview.isBulkPosting);

      this.addJournal.controls['isReversed'].setValue(this.journalPreview.isReversed);
      this.addJournal.controls['reversedFromId'].setValue(this.journalPreview.reversedFromId);
      this.addJournal.controls['reversedToId'].setValue(this.journalPreview.reversedToId);

      this.calcTotal();
    }
  }

  addJournalDetails() {
    const journalDetails = this.addJournal.get('journalDetails') as FormArray;

    journalDetails.push(this.createJournalDetails());
  }

  deletejournalDetails(item) {
    (this.addJournal.get('journalDetails') as FormArray).removeAt(item);
  }

  // checkDate(): boolean {
  //   debugger;
  //   let selectedDate: any = this.addJournal.controls['date'].value;
  //   let now = new Date(Date.now());

  //   if (selectedDate > now) {
  //     this.notificationService.showTranslateHtmlError_h5('error.maxDateAlert');
  //     return false;
  //   }
  //   else {
  //     return true;
  //   }
  // }

  submit(): void {
    debugger;
    this.addJournal.enable();

    if (this.addJournal.valid) {
      //if(this.checkDate() == false) return;

      if (this.mode == 'add') {
        this.journal = this.addJournal.value;

        if (this.totalCreditorValue != this.totalDebtorValue) {
          this.notificationService.showTranslateError('journalEntries.balance');
          return;
        }
debugger
        this.journal.journalDetails.forEach(element => {
          if (element.accountId == null || (element.debtorValue == null && element.creditorValue == null)) {
            this.notificationService.showTranslateError('journalEntries.valueRequired');
            return;
          }
        });

        if (this.totalCreditorValue < 1) {
          this.notificationService.showTranslateError('journalEntries.valueRequired');
          return;
        }
        else {
          if (this.postingStatus != PostingStatus.needAprove) {
            this.serv.add(this.journal)
              .subscribe(res => {
                this.notificationService.showSuccessAlertForSavedDocument(res.documentNumber);
                this.gotoList();
              },
                (error) => {
                  this.errorService.handerErrors(error);
                },
                () => { });
          }
        }
      }
      else if (this.mode == 'edit' || this.hasPermissionToChangePostedAccounts) {
debugger;
        this.journal = this.addJournal.value;
        this.journal.id = this.id;

        this.serv.update(this.journal)
          .subscribe(res => {
            this.notificationService.showSuccessAlertForSavedDocument(res.documentNumber);
            this.gotoList();
          },
            (error) => {
              this.notificationService.showOperationFailed();
            },
            () => { });
      }
      else {
        this.gotoList()
      }
    }
    else {
      this.notificationService.showDataMissingError();
    }
  }

  buildForm(): void {
    this.addJournal = this.fb.group({
      descriptionEn: [null],
      descriptionAr: [null, [Validators.required]],
      documentNumber: [null],
      date: [new Date(), [Validators.required]],
      isAutomaticPosting: [false],
      isBulkPosting: [false],
      isReversed: [false],
      reversedFromId: [null],
      reversedToId: [null],
      journalDetails: this.fb.array([

      ])

    });
    this.addJournal.valueChanges.subscribe(res => {
      debugger;
      //this.journalPreview = res;
      this.totalCreditorValue = 0;
      this.totalDebtorValue = 0;
      res.journalDetails.forEach(element => {
        this.totalDebtorValue += element.debtorValue;
        this.totalCreditorValue += element.creditorValue;
      });

      this.journalValueChange.emit(res);
    });
  }

  createJournalPreviewDetails(journalDetails: any): FormGroup {
    return this.fb.group({
      descriptionEn: [journalDetails.descriptionEN],
      descriptionAr: [journalDetails.descriptionAR],
      accountId: [journalDetails.accountChartId, [Validators.required]],
      costCenterId: [journalDetails.costCenterId],
      isCreditor: [journalDetails.isCreditor],
      debtorValue: [journalDetails.debtorValue, [Validators.min(0)]],
      creditorValue: [journalDetails.creditorValue, [Validators.min(0)]],
      accountFullCode: [null],
      objectType: [null],
      objectId: [null],
    });
  }

  // createJournalDetails(): FormGroup {
  //   return this.fb.group({
  //     descriptionEn: [null],
  //     descriptionAr: [null],
  //     accountId: [null, [Validators.required]],
  //     costCenterId: [null],
  //     isCreditor: [null],
  //     debtorValue: [null, [Validators.min(0)]],
  //     creditorValue: [null, [Validators.min(0)]],
  //     accountFullCode: [null],
  //     objectType: [null],
  //     objectId: [null],
  //   });
  // }

  createJournalDetails(): FormGroup {
    return this.fb.group({
      descriptionEn: [null],
      descriptionAr: [null],
      accountId: [null, [Validators.required]],
      costCenterId: [null],
      isCreditor: [null],
      debtorValue: [null, [Validators.min(0)]],
      creditorValue: [null, [Validators.min(0)]],
      accountFullCode: [null],
      objectType: [null],
      objectId: [null],
    });
  }

  approve() {
    debugger;
    if(this.journalPreview == undefined)
    {
    if (!this.canApproveOrRejectJournalEntriesUnderReview) {
      this.notificationService.showTranslateHtmlError_h5('error.auth');
      return;
    }

    if (this.canChangePostedAccounts()) {
      this.journal = this.addJournal.value;

      for (let i = 0; i < this.journal.journalDetails.length; i++) {
        let newTrans = this.journal.journalDetails[i];
        let oldTrans = this.item.journalDetails[i];

        if (oldTrans.accountId != newTrans.accountId) {
          oldTrans.accountId = newTrans.accountId;
        }
      }
      //return
    }

    this.serv.approveItem(this.item)
      .subscribe(res => {
        this.notificationService.showOperationSuccessed();
        this.gotoList();
      },
        (error) => {
          this.notificationService.showOperationFailed();
        },
        () => { });
      }else{
        if (this.totalCreditorValue != this.totalDebtorValue) {
          this.notificationService.showTranslateError('journalEntries.balance');
          return;
        }
        this.journalPreview = this.addJournal.value;
        this.journalPreview.postingStatus = PostingStatus.approved;
        
        this.journalApprove.emit(this.journalPreview);
      }
  }

  reject() {
    if(this.journalPreview == undefined){
    if (!this.canApproveOrRejectJournalEntriesUnderReview) {
      this.notificationService.showTranslateHtmlError_h5('error.auth');
      return;
    }

    let model = {
      collection: [this.item.docId]
    };

    this.serv.reject(model)
      .subscribe(res => {
        this.notificationService.showOperationSuccessed();
        this.gotoList();
      },
        (error) => {
          this.notificationService.showOperationFailed();
        },
        () => { });
      }else{
        this.journalReject.emit(null);
        
      }
  }

  gotoList() {
    let url = [`/journal/list`];
    if (this.postingStatus == PostingStatus.needAprove) {
      url = [`/journal/preview-list`];
    }
    this.router.navigate(url);
  }


  language: any;
  editorForm: FormGroup;
  editorFormErrors: any;
  mode: any = 'add';
  id: any;
  item: any;
  @Input() postingStatus: PostingStatus;
  postingStatusEnum = PostingStatus;
  movementTypeEnum: MovementTypeEnum;
  movementTypeEnumType = MovementTypeEnum;
  hasPermissionToChangePostedAccounts: boolean = false;
  canApproveOrRejectJournalEntriesUnderReview: boolean = false;
  fixedAssetAccount: any[];
}
