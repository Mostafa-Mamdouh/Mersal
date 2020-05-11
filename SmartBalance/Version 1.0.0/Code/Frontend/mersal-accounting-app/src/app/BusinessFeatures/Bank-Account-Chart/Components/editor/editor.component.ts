import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';
import { Observable, of } from 'rxjs';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { BankAccountChart, BankAccountChartLight, ModelStatus } from '../../Models/bank-account-chart.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service'
import { BankAccountChartService } from '../../Services/bank-account-chart.service';
import { BankService } from '../../../Bank/Services/bank.service';
import { Document } from '../../../Document/Models/document.model';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';
import { UserService } from '../../../User/Services/user.service';
import { PermissionEnum } from 'src/app/BusinessFeatures/User/Models/permission-enum';
import { CurrentUserService } from 'src/app/BusinessFeatures/User/Services/current-user.service';

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
    private bankAccountChartService: BankAccountChartService,
    private bankService: BankService,
    private location: Location,
    private errorService: ErrorService,
    private userService: UserService,
    private currentUserService: CurrentUserService,
  ) { }

  ngOnInit(): void {

    this.buildForm();
    this.getAccountChartLookups();
    this.getBankLookups();
    this.extractRouteParams();
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      accountId: [null],

      bankId: [null, [Validators.required]]
    });

    this.editorForm.valueChanges
      .subscribe(res => {
        //debugger;

      });
  }

  extractRouteParams(): void {
    debugger;
    let editId = +this.route.snapshot.params['id'];
    //let detailId = +this.route.snapshot.params['detailId'];
    this.id = editId;

    this.checkIsCurrentUserHassPermission(PermissionEnum.editBankAccountCharts)
    .subscribe(res => {
      debugger;
      if(res) {
        this.editorMode = EditorMode.edit
        this.id = editId;  
      }
      else {
        this.editorMode = EditorMode.detail;
        this.id = editId;  
      }
    });

    // if(this.checkIsCurrentUserHassPermission(PermissionEnum.editBankAccountCharts))
    // {
    //   debugger;
    //   this.editorMode = EditorMode.edit
    //   this.id = editId;
    // }
    // else if(this.checkIsCurrentUserHassPermission(PermissionEnum.bankAccountChartsList))
    // {
    //   debugger;
    //   this.editorMode = EditorMode.detail;
    //   this.id = editId;
    // }

    // else{
    //   this.currentUserService.logOut()
    //   this.notificationService.showAuthError();
    // }

    // if (editId) {
    //   this.editorMode = EditorMode.edit
    //   this.id = editId;
    // }
    // else if (detailId) {
    //   this.editorMode = EditorMode.detail;
    //   this.id = detailId;
    // }
    // else {
    //   this.editorMode = EditorMode.add;
    // }

    if (this.id) {
      // this.bankAccountChartService.getBankAccountChart(this.id)
      //   .subscribe(res => {
      //     debugger;
      //     //this.itemModel = res;
      //     //this.bindModelToForm();
      //   },
      //     (error) => {
      //       this.notificationService.showOperationFailed();
      //     })
    }
  }

  checkIsCurrentUserHassPermission(Permission: PermissionEnum): Observable<boolean> {
    //let result: boolean;
 return    this.userService.isCurrentUserHassPermission(Permission);
    // .subscribe(res => {
    //   debugger;
    //   return res
    // });
    //return result;
  }


  getAccountChartLookups() {
    this.ReceiptsServ.getAccountChartsLookup().subscribe(res => {
      this.accounts = res;
      if(this.id)
        this.bindModelToForm();
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
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  bindModelToForm(): void {
    debugger;
    if (this.itemModel) {
      this.editorForm.patchValue({
        bankId: this.id,

        //documentId: this.itemModel.documentId
      });
      this.bankValueChanged(this.id);
      console.log(this.itemModel);
    }
  }

  collectModelFromForm(): void {
    debugger;
    //this.itemModel.documentId = this.editorForm.controls["documentId"].value;
    this.itemModel.accountChartId = this.editorForm.controls["accountId"].value;
  }

  bankValueChanged(event) {
    this.bankAccountChartService.getBankAccountChart(event).subscribe(res => {
      debugger;
      this.bankAccountsList = new Array(); //this.documents.copyWithin(this.documentsList.length, 0);
      this.bankAccounts = new Array();
      for (let index = 0; index < res.length; index++) {
        debugger;
        let BDocument: BankAccountChartLight = new BankAccountChartLight();
        let back = this.accounts.find(x => x.id == res[index].accountChartId);
        BDocument.displyedName = back.displyedName;
        //BDocument.countReceipts = document.countReceipts;
        BDocument.accountChartId = back.accountChartId;
        this.bankAccountsList.push(BDocument);
        let bankAccount: BankAccountChartLight = new BankAccountChartLight();
        bankAccount.accountChartId = back.id;
        bankAccount.bankId = event;
        this.bankAccounts.push(bankAccount);

        //this.documentsList.splice(this.documentsList.findIndex(x => x.id == document.id), 1)
      }
      //this.bankDocuments = res
    });
  }  

  Add() {
    debugger;
    try {

      let accId = this.editorForm.controls["accountId"].value;
      let acc = this.bankAccounts.find(x => x.accountChartId == accId);
      let account = this.accounts.find(d => d.id == this.editorForm.controls["accountId"].value);
      if (acc == undefined) {
         let bank = this.banks.find(b => b.id == this.editorForm.controls["bankId"].value);
         let bd: BankAccountChartLight = new BankAccountChartLight();
         bd.displyedName = account.displyedName;
         bd.accountChartId = account.id;
         bd.bankId = bank.id
         bd.modelStatus = ModelStatus.Add;
         this.bankAccounts.push(bd);
         this.bankAccountsList.push(bd);
       }
      else if (acc.modelStatus == ModelStatus.Delete) {
        acc.modelStatus = ModelStatus.Add;
        this.bankAccountsList.push(acc);
      }
    } catch (error) {
      return;
    }
  }

  delete(accountChartId) {
    debugger;
    let index = this.bankAccountsList.findIndex(x => x.accountChartId == accountChartId);
    let accountChart = this.bankAccountsList[index];
    this.bankAccountsList.splice(index, 1);
    //this.bankAccounts.splice(index, 1);
    let bankAccount: BankAccountChartLight = this.bankAccounts.find(x => x.accountChartId == accountChartId);
    bankAccount.modelStatus = ModelStatus.Delete;
  }

  save(): void {
    debugger;
    if (this.canEdit()) {
      

      if (this.editorForm.valid) {
          debugger;
          //this.collectModelFromForm();
          if (this.bankAccounts.length > 0) {
            this.isProccessing = true;
            let BankAccounts: BankAccountChart[] = new Array();
            for (let index = 0; index < this.bankAccounts.length; index++) {
              BankAccounts[index] = new BankAccountChart();
              BankAccounts[index].accountChartId = this.bankAccounts[index].accountChartId
              BankAccounts[index].bankId = this.bankAccounts[index].bankId;
              BankAccounts[index].modelStatus = this.bankAccounts[index].modelStatus;

            }
            this.bankAccountChartService.updateBankAccountCharts(BankAccounts)
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
  private accounts: any[];
  private banks: any[];
  private isProccessing: boolean;
  private itemModel: BankAccountChart = new BankAccountChart();
  bankAccounts: BankAccountChartLight[] = new Array();
  bankAccountsList: any[] = new Array();
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
}