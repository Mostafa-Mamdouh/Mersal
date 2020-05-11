import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { ModelStatus } from '../../../Account-Document/Models/account-document.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service'
//import { AccountDocumentService } from '../../Services/account-document.service';
import { DocumentService } from '../../../Document/Services/document.service';
//import { Document } from '../../../Document/Models/document.model';
import { AccountChart } from '../../Models/account-chart.model';
import { SettingService } from '../../Services/setting.service'
import { GridDataResult } from '@progress/kendo-angular-grid';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';

@Component({
  selector: 'fixed-asset-account',
  styleUrls: ['./fixed-asset-account.component.scss'],
  templateUrl: './fixed-asset-account.component.html'
})

export class FixedAssetAccountSettingEditorComponent implements OnInit {
  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private settingService: SettingService,
    private documentService: DocumentService,
    private location: Location,
    private errorService: ErrorService
  ) { }

  ngOnInit(): void {
    this.buildForm();
    this.getAccountChartLookups();
    //this.getDocumentLookups();
    //this.extractRouteParams();
    this.settingService.getFixedAssetAccountSetting().subscribe(res => {
      debugger;
      if (res.length > 0) {
        this.assetAccounts = new Array();
        this.accountsList = new Array();
        for (let index = 0; index < res.length; index++) {
          this.accountsList[index] = res[index].accountChartViewModel
          this.assetAccounts[index] = res[index];
        }
      }

    },
      (error) => {
        this.notificationService.showOperationFailed();
      }
    );
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      accountId: [null],

      // documentId: [null]
    });

    // this.editorForm.valueChanges
    //   .subscribe(res => {
    //     //debugger;

    //   });
  }

  extractRouteParams(): void {
    //debugger;
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
      // this.accountDocumentService.getAccountDocument(this.id)
      //   .subscribe(res => {
      //     debugger;
      //     //this.itemModel = res;
      //     this.bindModelToForm();
      //   },
      //     (error) => {
      //       this.notificationService.showOperationFailed();
      //     })
    }
  }


  getAccountChartLookups() {
    this.ReceiptsServ.getAccountChartsLookup().subscribe(res => {
      this.accounts = res;
      //console.log(res);
    });
  }


  getDocumentLookups() {
    this.documentService.getDocumentsLookups()
      .subscribe(res => {
        debugger;
        this.documents = res.collection;
        //this.documentsList = this.documents.copyWithin(this.documents.length, 0);
        console.log(res);
      });
  }

  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }

  gotoList() {
    let url = [`/setting/control-panel`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  bindModelToForm(): void {
    debugger;
    // if (this.itemModel) {
    //   // this.editorForm.patchValue({
    //   //   accountId: this.id,

    //   //   documentId: this.itemModel.documentId
    //   // });
    //   //this.accountValueChanged(this.id);
    //   console.log(this.itemModel);
    // }
  }

  collectModelFromForm(): void {
    debugger;
    //this.itemModel.documentId = this.editorForm.controls["documentId"].value;
    //this.itemModel.accountChartId = this.editorForm.controls["accountId"].value;
  }

  // accountValueChanged(event) {
  //   this.accountDocumentService.getAccountDocument(event).subscribe(res => {
  //     debugger;
  //     this.documentsList = new Array(); //this.documents.copyWithin(this.documentsList.length, 0);
  //     this.accountDocuments = new Array();
  //     for (let index = 0; index < res.length; index++) {
  //       debugger;
  //       let BDocument: AccountChart = new AccountChart();
  //       let document = this.documents.find(x => x.id == res[index].documentId);
  //       BDocument.documentNumber = document.documentNumber;
  //       BDocument.countReceipts = document.countReceipts;
  //       BDocument.documentId = document.id;
  //       this.documentsList.push(BDocument);
  //       let accountDocument: AccountDocumentLight = new AccountDocumentLight();
  //       accountDocument.accountChartId = event;
  //       accountDocument.documentId = document.id;
  //       this.accountDocuments.push(accountDocument);

  //       //this.documentsList.splice(this.documentsList.findIndex(x => x.id == document.id), 1)
  //     }
  //this.bankDocuments = res
  //});
  //}

  Add() {
    debugger;
    try {

      let accId = this.editorForm.controls["accountId"].value;
      if (accId) {
        let acc = this.assetAccounts.find(x => x.id == accId);
        if (acc == undefined) {
          acc = this.accounts.find(x => x.id == accId);
          let bd: AccountChart = new AccountChart();
          bd.displyedName = acc.displyedName;
          bd.id = acc.id
          bd.modelStatus = ModelStatus.Add;
          this.accountsList.push(bd);
          this.assetAccounts.push(bd);
        }
        else if (acc.modelStatus == ModelStatus.Delete) {
          acc.modelStatus = ModelStatus.Add;
          this.accountsList.push(acc);
        }
      }
    } catch (error) {
      return;
    }

  }

  delete(accountId) {
    debugger;
    let index = this.accountsList.findIndex(x => x.id == accountId);
    let account = this.accountsList[index];
    this.accountsList.splice(index, 1);
    //this.accountDocuments.splice(index, 1);
    let assetAccount: any = this.assetAccounts.find(x => x.id == accountId);
    assetAccount.modelStatus = ModelStatus.Delete;
  }

  save(): void {
    debugger;
    if (this.canEdit()) {
      this.isProccessing = true;

      if (this.editorForm.valid) {
        if (this.editorMode == EditorMode.add) {
          //this.collectModelFromForm();
          debugger;
          if (this.assetAccounts.length > 0) {
            let AccountCharts: AccountChart[] = new Array();
            for (let index = 0; index < this.assetAccounts.length; index++) {
              AccountCharts[index] = new AccountChart();
              AccountCharts[index].id = this.assetAccounts[index].id
              AccountCharts[index].displyedName = this.assetAccounts[index].displyedName;
              AccountCharts[index].modelStatus = this.assetAccounts[index].modelStatus;

            }
            this.settingService.updateFixedAssetAccountSetting(AccountCharts)
              .subscribe(res => {
                this.notificationService.showOperationSuccessed();
                this.gotoList();
                this.isProccessing = false;
              },
                (error) => {
                  this.isProccessing = false;
                  this.errorService.handerErrors(error);
                },
                () => {
                  console.log(`add Document completed.`);
                });
          }
          else {

          }
        }
        else if (this.editorMode == EditorMode.edit) {
          debugger;
          //this.collectModelFromForm();
          //   if (this.accountDocuments.length > 0) {
          //     //let AccountDocuments: AccountDocument[] = new Array();
          //     for (let index = 0; index < this.accountDocuments.length; index++) {
          //       // AccountDocuments[index] = new AccountDocument();
          //       // AccountDocuments[index].accountChartId = this.accountDocuments[index].accountChartId
          //       // AccountDocuments[index].documentId = this.accountDocuments[index].documentId;
          //       // AccountDocuments[index].modelStatus = this.accountDocuments[index].modelStatus;

          //     }
          //   //   this.accountDocumentService.updateAccountDocuments(AccountDocuments)
          //   //     .subscribe(res => {
          //   //       this.notificationService.showOperationSuccessed();
          //   //       this.gotoList();
          //   //     },
          //   //       (error) => {
          //   //         this.isProccessing = false;
          //   //          this.errorService.handerErrors(error);
          //   //       },
          //   //       () => {
          //   //         console.log(`update Document completed.`);
          //   //       });
          //   // }
        }
      }
      else {
        this.isProccessing = false;
        this.notificationService.showDataMissingError();
      }
    }
  }

  PageLoading: boolean;
  private editorForm: FormGroup;
  private editorMode: EditorMode = EditorMode.add;
  private editorModeEnum = EditorMode;
  private id: any;
  private accounts: any[] = new Array();
  private documents: any[];
  private isProccessing: boolean;
  //private itemModel: AccountDocument = new AccountDocument();
  //accountDocuments: AccountDocumentLight[] = new Array();
  private accountsList: any[] = new Array();
  private assetAccounts: any[] = new Array();
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
}