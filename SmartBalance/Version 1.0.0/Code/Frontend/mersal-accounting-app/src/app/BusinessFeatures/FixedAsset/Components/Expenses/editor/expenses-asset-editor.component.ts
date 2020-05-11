import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { EditorMode } from '../../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { FixedAsset, ExpenseAsset } from '../../../Models/fixed-asset.model';
import { NotificationService } from '../../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../../Financial/Services/financial.service';
import { FixedAssetService } from '../../../Services/fixed-asset.service';
import { ExpensesTypeService } from '../../../../ExpensesType/Services/expenses-type.service';
import { ExpensesAssetService } from '../../../Services/expenses-fixed-asset.service';
import { Location } from '@angular/common';
import { ErrorService } from '../../../../../SharedFeatures/SharedMain/Services/error.service';

@Component({
  selector: 'expenses-asset-editor',
  styleUrls: ['./expenses-asset-editor.component.scss'],
  templateUrl: './expenses-asset-editor.component.html'
})
export class ExpensesAssetEditorComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private fixedAssetService: FixedAssetService,
    private expensesTypeService: ExpensesTypeService,
    private expensesAssetService: ExpensesAssetService,
    private location: Location,
    private errorService: ErrorService
  ) { }

  ngOnInit(): void {
    this.buildForm();
    this.getAccountChartsLookup();
    this.getAssetsLookup();
    this.getExpensesTypesLookup();
    this.extractRouteParams();
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      asset: [null, [Validators.required]],
      expensesType: [null, [Validators.required]],
      accountChartId: [null, [Validators.required]],
      amount: [null, [Validators.required, Validators.pattern("([0-9]+\.)?[0-9]+")]],

      descriptionAr: [null],
      descriptionEn: [null],
      
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

    if (editId) {
      this.editorMode = EditorMode.edit
      this.invoiceDetail = true;
      this.id = editId;
    }
    else if (detailId) {
      this.editorMode = EditorMode.detail;
      this.invoiceDetail = true;
      this.id = detailId;
    }
    else {
      this.editorMode = EditorMode.add;
    }

    if (this.id) {
      this.expensesAssetService.getExpenseAsse(this.id)
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
    let url = [`/asset/expenses-asset-list/list`];
    this.router.navigate(url);
  }

  goToBack(){
    this.location.back();
  }

  //lookups

  getAccountChartsLookup() {
    this.ReceiptsServ.getAccountChartsLookup()
      .subscribe(res => {
        //this.PageLoading = false;

        this.accountCharts = res;

      },
        (error) => {
          //this.PageLoading = false;

          this.notificationService.showOperationFailed();
        }, () => {
        });
  }


  getExpensesTypesLookup() {
    this.expensesTypeService.getExpensesTypesLookups()
      .subscribe(res => {
        //this.PageLoading = false;

        this.expensesTypes = res.collection;

      },
        (error) => {
          //this.PageLoading = false;

          this.notificationService.showOperationFailed();
        }, () => {
        });
  }



  getAssetsLookup() {
    debugger;
    this.fixedAssetService.getFixedAssetsLookups()
      .subscribe(res => {
        //this.PageLoading = false;

        this.assets = res.collection;
        console.info(this.assets);
      },
        (error) => {
          //this.PageLoading = false;

          this.notificationService.showOperationFailed();
        }, () => {
        });
  }



  bindModelToForm(): void {
    debugger;
    if (this.itemModel) {
      this.editorForm.patchValue({
        asset: this.itemModel.assetId,
        //code: this.itemModel.id,
        expensesType: this.itemModel.expensesTypeId,
       // isDebt: this.itemModel.isDebt,

       amount: this.itemModel.amount,

        descriptionAr: this.itemModel.descriptionAr,
        descriptionEn: this.itemModel.descriptionEn,

        accountChartId: this.itemModel.accountChartId,

      });
      console.log(this.itemModel);
    }
  }

  collectModelFromForm(): void {
    debugger;
    this.itemModel.assetId = this.editorForm.controls["asset"].value;
    this.itemModel.expensesTypeId = this.editorForm.controls["expensesType"].value;

    //this.itemModel.isDebt = this.editorForm.controls["isDebt"].value;
    this.itemModel.amount = this.editorForm.controls["amount"].value;
    this.itemModel.descriptionAr = this.editorForm.controls["descriptionAr"].value;
    this.itemModel.descriptionEn = this.editorForm.controls["descriptionEn"].value;
    this.itemModel.accountChartId = this.editorForm.controls["accountChartId"].value;

    

    this.itemModel.accountChartId = this.editorForm.controls["accountChartId"].value;
    if (this.itemModel.accountChartId && this.itemModel.accountChartId.value) {
      this.itemModel.accountChartId = this.itemModel.accountChartId.value;
    }
  }

  save(): void {
    //debugger;
    if (this.canEdit()) {
      this.isProccessing = true;

      if (this.editorForm.valid) {
        if (this.editorMode == EditorMode.add) {
          this.collectModelFromForm();
          this.expensesAssetService.addExpenseAsse(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();
              this.gotoList();
            },
              (error) => {
                //debugger;
                this.isProccessing = false;
                this.errorService.handerErrors(error);       
              },
              () => {
                console.log(`add Expense Asse completed.`);
              });
        }
        else if (this.editorMode == EditorMode.edit) {
          this.collectModelFromForm();
          this.expensesAssetService.updateExpenseAsset(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();
              this.gotoList();
            },
              (error) => {
                //debugger;
                this.isProccessing = false;
                this.errorService.handerErrors(error);          
              },
              () => {
                console.log(`update Expense Asse completed.`);
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
  private editorMode: EditorMode = EditorMode.add;
  private editorModeEnum = EditorMode;
  private id: any;
  private isProccessing: boolean;
  private invoiceDetail: boolean = false;
  private assets: any[] = [];
  private expensesTypes: any[];
  private accountCharts: any[];
  private itemModel: ExpenseAsset = new ExpenseAsset();
  // @ViewChild('isDebt') EIsDebt :ElementRef;
  // @ViewChild('isCredit') EIsCredit : ElementRef;
}

