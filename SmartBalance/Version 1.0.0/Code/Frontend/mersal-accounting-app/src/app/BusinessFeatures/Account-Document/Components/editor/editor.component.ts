import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { AccountDocument, AccountDocumentLight, ModelStatus } from '../../Models/account-document.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service'
import { AccountDocumentService } from '../../Services/account-document.service';
import { DocumentService } from '../../../Document/Services/document.service';
import { Document } from '../../../Document/Models/document.model';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';
import { BankAccountChartService } from '../../../Bank-Account-Chart/Services/bank-account-chart.service';
import { BankService } from '../../../Bank/Services/bank.service';

@Component({
  selector: 'account-document',
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
    private accountDocumentService: AccountDocumentService,
    private documentService: DocumentService,
    private location: Location,
    private errorService: ErrorService,
    private bankAccountChartService: BankAccountChartService,
    private bankService: BankService
  ) { }

  ngOnInit(): void {
    this.buildForm();
    this.getBankLookups();
    //this.getAccountChartLookups();
    this.getDocumentLookups();
    this.extractRouteParams();
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      accountId: [null, [Validators.required]],
      bankId: [null, [Validators.required]],

      documentId: [null]
    });

    this.editorForm.valueChanges
      .subscribe(res => {
        //debugger;

      });
  }

  extractRouteParams(): void {
    //debugger;
    let editId = +this.route.snapshot.params['editId'];
    let detailId = +this.route.snapshot.params['detailId'];

    let bankId = +this.route.snapshot.params['bankId'];
    this.editorForm.controls["bankId"].setValue(bankId);
    this.bankValueChanged(bankId);

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
      this.accountDocumentService.getAccountDocument(this.id)
        .subscribe(res => {
          debugger;
          //this.itemModel = res;
          this.bindModelToForm();
        },
          (error) => {
            this.notificationService.showOperationFailed();
          })
    }
  }


  getAccountChartLookups() {
    this.ReceiptsServ.getAccountChartsLookup().subscribe(res => {
      this.accounts = res;
      console.log(res);
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

  getBankLookups() {
    this.bankService.getBanksLookups()
      .subscribe(res => {
        debugger;
        this.banks = res.collection;
        //this.documentsList = this.documents.copyWithin(this.documents.length, 0);
        console.log(res);
      });
  }

  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }

  gotoList() {
    let url = [`/bank/list`];
    //let url = [`/account-document/list`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  bindModelToForm(): void {
    debugger;
    if (this.itemModel) {
      this.editorForm.patchValue({
        accountId: this.id,

        documentId: this.itemModel.documentId
      });
      this.accountValueChanged(this.id);
      console.log(this.itemModel);
    }
  }

  collectModelFromForm(): void {
    debugger;
    this.itemModel.documentId = this.editorForm.controls["documentId"].value;
    this.itemModel.accountChartId = this.editorForm.controls["accountId"].value;
  }

  accountValueChanged(event) {
    this.accountDocumentService.getAccountDocument(event).subscribe(res => {
      debugger;
      this.documentsList = new Array(); //this.documents.copyWithin(this.documentsList.length, 0);
      this.accountDocuments = new Array();
      for (let index = 0; index < res.length; index++) {
        debugger;
        let BDocument: AccountDocumentLight = new AccountDocumentLight();
        let document = this.documents.find(x => x.id == res[index].documentId);
        BDocument.documentNumber = document.documentNumber;
        BDocument.countReceipts = document.countReceipts;
        BDocument.documentId = document.id;
        this.documentsList.push(BDocument);
        let accountDocument: AccountDocumentLight = new AccountDocumentLight();
        accountDocument.accountChartId = event;
        accountDocument.documentId = document.id;
        this.accountDocuments.push(accountDocument);

        //this.documentsList.splice(this.documentsList.findIndex(x => x.id == document.id), 1)
      }
      //this.bankDocuments = res
    });
  }  

  bankValueChanged(event) {
    this.bankAccountChartService.getAccountCharts(event).subscribe(res => {
      debugger;
      
      this.accounts = res;
       
      //this.bankDocuments = res
    });
  } 

  Add() {
    debugger;
    try {

      let docId = this.editorForm.controls["documentId"].value;
      let doc = this.accountDocuments.find(x => x.documentId == docId);
      let document = this.documents.find(d => d.id == this.editorForm.controls["documentId"].value);
      if (doc == undefined) {
        let account = this.accounts.find(b => b.id == this.editorForm.controls["accountId"].value);
        let bd: AccountDocumentLight = new AccountDocumentLight();
        bd.displyedName = account.displyedName;
        bd.accountChartId = account.id
        bd.documentNumber = document.documentNumber;
        bd.documentId = document.id;
        bd.countReceipts = document.countReceipts;
        bd.modelStatus = ModelStatus.Add;
        this.accountDocuments.push(bd);
        this.documentsList.push(bd);
      }
      else if (doc.modelStatus == ModelStatus.Delete) {
        doc.modelStatus = ModelStatus.Add;
        this.documentsList.push(doc);
      }
    } catch (error) {
      return;
    }
  }

  delete(documentId) {
    debugger;
    let index = this.documentsList.findIndex(x => x.documentId == documentId);
    let document = this.documentsList[index];
    this.documentsList.splice(index, 1);
    //this.accountDocuments.splice(index, 1);
    let accountDocument: AccountDocumentLight = this.accountDocuments.find(x => x.documentId == documentId);
    accountDocument.modelStatus = ModelStatus.Delete;
  }

  save(): void {
    debugger;
    if (this.canEdit()) {

      if (this.editorForm.valid) {

          debugger;
          //this.collectModelFromForm();
          if (this.accountDocuments.length > 0) {
            this.isProccessing = true;
            let AccountDocuments: AccountDocument[] = new Array();
            for (let index = 0; index < this.accountDocuments.length; index++) {
              AccountDocuments[index] = new AccountDocument();
              AccountDocuments[index].accountChartId = this.accountDocuments[index].accountChartId
              AccountDocuments[index].documentId = this.accountDocuments[index].documentId;
              AccountDocuments[index].modelStatus = this.accountDocuments[index].modelStatus;

            }
            this.accountDocumentService.updateAccountDocuments(AccountDocuments)
              .subscribe(res => {
                this.notificationService.showOperationSuccessed();
                this.gotoList();
              },
                (error) => {
                  this.isProccessing = false;
                  this.errorService.handerErrors(error);
                },
                () => {
                  console.log(`update Document completed.`);
                });
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
   editorMode: EditorMode = EditorMode.add;
   editorModeEnum = EditorMode;
  private id: any;
  private banks: any[];
  private accounts: any[];
  private documents: any[];
  private isProccessing: boolean;
  private itemModel: AccountDocument = new AccountDocument();
  accountDocuments: AccountDocumentLight[] = new Array();
  documentsList: any[];
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
}