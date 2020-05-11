import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { Testament } from '../../../Models/testament.model';
import { NotificationService } from '../../../../../SharedFeatures/SharedMain/Services/notification.service';
// import { FinancialService } from '../../../Financial/Services/financial.service';
import { TestamentService } from '../../../Services/testament.service';
import { SettingService } from '../../../../Setting/Services/setting.service';
import { FinancialService } from '../../../Services/financial.service';
import { CostCenterService } from 'src/app/BusinessFeatures/CostCenter/Services/cost-center.service';
import { BankService } from 'src/app/BusinessFeatures/Bank/Services/bank.service';
import { BankAccountChartService } from 'src/app/BusinessFeatures/Bank-Account-Chart/Services/bank-account-chart.service';
import { UserService } from '../../../../User/Services/user.service'
import { SafeService } from '../../../../Safe/Services/safe.service';
import { from } from 'rxjs';
import { ErrorService } from 'src/app/SharedFeatures/SharedMain/Services/error.service';
// import { ElementDef } from '@angular/core/src/view';
declare var $: any;

@Component({
  selector: 'testament-editor',
  styleUrls: ['./editor.component.scss'],
  templateUrl: './editor.component.html'
})
export class TestamentEditorComponent implements OnInit {
  vendors: any;
  PaymentDropDownData: any[];
  costCenterDropDown: any[];
  accountCharts: any[][] = new Array();
  banks: any[];
  journalPreview: any;
  journalPreviewShow: boolean;


  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    //     private ReceiptsServ: FinancialService,
    private testamentService: TestamentService,
    private SettingService: SettingService,
    private ReceiptsServ: FinancialService,
    private costCenterService: CostCenterService,
    private bankService: BankService,
    private BankAccountChart: BankAccountChartService,
    private userService: UserService,
    private safeService: SafeService,
    private errorService: ErrorService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.buildForm();
    //     this.getAccountChartsLookup();
    this.getAdvancesTypesLookups();
    this.getVendorsLookup();
    this.getCostCenters();
    this.getpaymentMethodsLookup();
    this.extractRouteParams();
    this.testamentService.generateNewCode().subscribe(ops => {
      this.editorForm.controls['code'].setValue(ops);
    })
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      code: [null, [Validators.required, Validators.pattern("([0-9]+\.)?[0-9]+")]],
      advancesTypeId: [null, [Validators.required]],
      vendorId: [null, []],
      date: [new Date(), [Validators.required]],
      totalValue: [null, [Validators.required, Validators.min(10), Validators.max(1000000)]],
      advances: this.fb.array([]),
      descriptionAr: [null, [Validators.required]],
      descriptionEn: [null]
    });

  }

  createAdvance(advance: any = undefined): FormGroup {
    return this.fb.group({
      liquidationNumber: [(advance)?advance.liquidationNumber : null, [Validators.required]],
      descriptionAr: [(advance)?advance.descriptionAr: null, [Validators.required]],
      descriptionEn: [(advance)?advance.descriptionEn : null,],
      amount: [(advance)?advance.amount : null, [Validators.required, Validators.min(1)]],
      costCenterId: [(advance)?advance.costCenterId : null, []],
      caseCode: [(advance)?advance.caseCode : null, []],
      paymentMethodId: [(advance)?advance.paymentMethodId : null, [Validators.required]],
      bankId: [(advance)?advance.bankId : null],
      accountChartId: [(advance)?advance.accountChartId : null, [Validators.required]]

    });
  }

  addAdvance(advance: any = undefined) {
    const advances = this.editorForm.get('advances') as FormArray;
    advances.push(this.createAdvance(advance));
  }

  

  deleteAdvance(item) {
    (this.editorForm.get('advances') as FormArray).removeAt(item);
    //this.calcTotal();
  }

  extractRouteParams(): void {
    debugger;
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
      this.testamentService.getTestament(this.id)
        .subscribe(res => {
          debugger;
          this.itemModel = res;
          this.bindModelToForm();
        },
          (error) => {
            this.notificationService.showOperationFailed();
          })
    }
  }

  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }

  gotoList() {
    let url = [`/financial/testament/list`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  getAdvancesTypesLookups(){
    this.testamentService.getAdvancesTypesLookups().subscribe(res => {
      this.advancesTypes = res.collection;
    })
  }

  getVendorsLookup() {
    this.ReceiptsServ.getVendorsLookup()
      .subscribe(res => {
        debugger;
        this.vendors = res;
        this.PageLoading = false;

      }, () => {
        this.PageLoading = false;

        this.notificationService.showOperationFailed();
      }, () => {
      });
  }

  getpaymentMethodsLookup() {
    this.ReceiptsServ.getReceivingMethodsLookup()
      .subscribe(res => {

        this.PaymentDropDownData = res;
        console.log(this.PaymentDropDownData);
      },
        error => {
          error;
          this.notificationService.showOperationFailed();
        }

      );
  }

  getCostCenters() {
    this.costCenterService.getEmployeesCostCentersLookup()
      .subscribe(
        res => {
          debugger;
          //this.PageLoading = false;         
          this.costCenterDropDown = res.collection;
          console.log(this.costCenterDropDown)
        },
        // this.Branches = res,
        error => {
          //this.PageLoading = false;         
          //this.notificationService.showOperationFailed();
        }

      );
  }

  paymentMethodValueChange(event, i){
    debugger;
    this.accountCharts[i] = [];
    switch(event)
    {
      case 1:{
        this.userService.getCurrentUserBranch().subscribe(res => {
          debugger;
          this.ReceiptsServ.getSafesByBranchId(res.id).subscribe(b => {
            debugger;
            this.safeService.getSafeAccountcharts(b.id).subscribe(a => {
              debugger;
              this.accountCharts[i] = a.list;
            })
          })
        })
        break;
      }
      case 4:{
        this.bankService.getBanksLookups().subscribe(res => {
          this.banks = res.collection;
        })
        break
      }
      case 7:{
        this.bankService.getBanksLookups().subscribe(res => {
          this.banks = res.collection;
        })
        break;
      }
      case 10:{
        this.bankService.getBanksLookups().subscribe(res => {
          this.banks = res.collection;
        })
        break;
      }
    }
  }


  bankValueChange(event, i){
    this.BankAccountChart.getAccountCharts(event).subscribe(res => {
      debugger;
      this.accountCharts[i] = res;
    })
  }

  bindModelToForm(): void {
         debugger;
    if (this.itemModel) {
      this.editorForm.patchValue({
        code: this.itemModel.code,
        advancesTypeId: this.itemModel.advancesTypeId,
        vendorId: this.itemModel.vendorId,
        date: this.itemModel.date,
        totalValue: this.itemModel.totalValue,
        descriptionAr: this.itemModel.descriptionAr,
        descriptionEn: this.itemModel.descriptionEn
       // ExchangeCurrency: this.itemModel.exchangeCurrencyId
      });

      for (var index = 0; index < this.itemModel.advances.length; index++) {
        //this.itemModel.advances[index].costCenterId = this.costCenterDropDown.find(x => x.id == this.itemModel.advances[index].costCenterId);
        this.paymentMethodValueChange(this.itemModel.advances[index].paymentMethodId, index)
        if(this.itemModel.advances[index].paymentMethodId != 1){
          this.bankValueChange(this.itemModel.advances[index].bankId, index)
        }
        this.addAdvance(this.itemModel.advances[index]);
        
      }
      console.log(this.itemModel);
    }
  }

  collectModelFromForm(): void {
         debugger;

    //     this.itemModel.isDebt = this.editorForm.controls["isDebt"].value;
    this.itemModel.code = this.editorForm.controls["code"].value;
    this.itemModel.advancesTypeId = this.editorForm.controls["advancesTypeId"].value;
    this.itemModel.vendorId = this.editorForm.controls["vendorId"].value;
    this.itemModel.date = this.editorForm.controls["date"].value;
    this.itemModel.totalValue = this.editorForm.controls["totalValue"].value;
    //this.itemModel.advances = this.editorForm.controls['advances'].value;
    this.itemModel.advances = new Array()
    let advances =  this.editorForm.get('advances').value;
    for (var index = 0; index < advances.length; index++) {
      let advance: any = advances[index];
      //  if(advance.paymentMethodId == 1)
      //  {
      //    advance.accountChartId = advance.accountChartId.value;
      //  }
       this.itemModel.advances.push(advance);
      
    }

    this.itemModel.descriptionAr = this.editorForm.controls["descriptionAr"].value;
    this.itemModel.descriptionEn = this.editorForm.controls["descriptionEn"].value;

  }

  journalValueChange(event) {
    this.itemModel.journal = event;
  }
  
  journalApprove(event) {
    debugger;
    //this.collectModelFromForm();
    this.itemModel.journal = event;
    this.testamentService.addTestament(this.itemModel)
      .subscribe(res => {
        debugger;
        this.PageLoading = false;
        $('#openPostlBTN').click();
        this.notificationService.showOperationSuccessed();
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

  journalReject(event) {
    $('#openPostlBTN').click();
    this.notificationService.showOperationSuccessed();
    this.notificationService.showJournalcanceled();
    this.gotoList();
  }

  save(): void {
    debugger;
    if (this.canEdit()) {
      this.isProccessing = true;

      if (this.editorForm.valid) {
        
        if (this.editorMode == EditorMode.add) {
          this.collectModelFromForm();

          let advances = this.itemModel.advances
          if (advances != null &&
            advances.length > 0) {
            let total: number = 0;
            advances.forEach(item => {
              total += item.amount;
            });
      
            if (total != this.editorForm.controls['totalValue'].value) {
              this.notificationService.showTranslateError('testament.error.sumAmountNotEqualTotalValue');
              this.isProccessing = false;
              return;
            }
          }else{
            this.notificationService.showTranslateError('testament.error.sumAmountNotEqualTotalValue');
            this.isProccessing = false;
            return;
          }

          this.testamentService.addTestament(this.itemModel)
            .subscribe(res => {
              this.itemModel = res;
              this.journalPreview = res.journal;
              this.journalPreviewShow = true;
              $('#openPostlBTN').click();
              this.PageLoading = false;
            },
              (error) => {
                this.errorService.handerErrors(error);
                this.isProccessing = false;
              },
              () => {
                console.log(`addCurrency completed.`);
              });
        }
        else if (this.editorMode == EditorMode.edit) {
          this.collectModelFromForm();
          this.testamentService.updateTestament(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();
              this.gotoList();
            },
              (error) => {
                this.isProccessing = false;
                this.notificationService.showOperationFailed();
              },
              () => {
                console.log(`updateCurrency completed.`);
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
  private isProccessing: boolean;
  advancesTypes: any[];
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
  //   private banks: any[];
  //   private toBanks: any[];
  //   private safes: any[];
  //   private journalTypes: any[];
  //   private accountCharts: any[];
  private itemModel: Testament = new Testament();
}

