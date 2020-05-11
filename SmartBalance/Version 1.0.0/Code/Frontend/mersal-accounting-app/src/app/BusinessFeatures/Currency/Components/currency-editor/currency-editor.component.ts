import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { Currency } from '../../Models/currency.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
// import { FinancialService } from '../../../Financial/Services/financial.service';
import { CurrencyService } from '../../Services/currency.service';
import { CurrencyRateService } from '../../Services/currency-rate.service.';
import { SettingService } from '../../../Setting/Services/setting.service';
import { SystemCurrencySetting } from '../../../Setting/Models/system-currency-setting.model';
// import { ElementDef } from '@angular/core/src/view';

@Component({
  selector: 'currency-editor',
  styleUrls: ['./currency-editor.component.scss'],
  templateUrl: './currency-editor.component.html'
})
export class CurrencyEditorComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    //     private ReceiptsServ: FinancialService,
    private currencyService: CurrencyService,
    private CurrencyServ: CurrencyService,
    private CurrencyRateService: CurrencyRateService,
    private SettingService: SettingService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.buildForm();
    //     this.getAccountChartsLookup();
    this.getCurrencyLookup();
    this.getSystemCurrencySetting();
    this.extractRouteParams();
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      code: [null, [Validators.required, Validators.pattern("([0-9]+\.)?[0-9]+")]],
      date: [new Date(), [Validators.required]],
      nameAr: [null, [Validators.required]],
      nameEn: [null, [Validators.required]],
      symbol: [null],
      descriptionAr: [null],
      descriptionEn: [null],
      price: [null, [Validators.required, Validators.pattern("([0-9]+\.)?[0-9]+")]],
      ExchangeCurrency: [null, [Validators.required]],
      //       accountChartId: [null],
    });

    this.editorForm.valueChanges
      .subscribe(res => {
        debugger;

      });
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
      this.currencyService.getCurrency(this.id)
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
    let url = [`/currency/list`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  //   //lookups  
  //   getAccountChartsLookup() {
  //     this.ReceiptsServ.getAccountChartsLookup()
  //       .subscribe(res => {
  //         //this.PageLoading = false;

  //         this.accountCharts = res;
  //       },
  //         (error) => {
  //           //this.PageLoading = false;

  //           this.notificationService.showOperationFailed();
  //         }, () => {
  //         });
  //   }

  getCurrencyLookup() {
    this.CurrencyServ.getCurrencysLookups()
      .subscribe(res => {
        //this.PageLoading = false;

        this.Currencys = res.collection;
        this.setDefaultCurrency();
        console.info(this.Currencys);
      },
        (error) => {
          //this.PageLoading = false;

          this.notificationService.showOperationFailed();
        }, () => {
        });
  }

  getSystemCurrencySetting() {
    this.SettingService.getSystemCurrencySetting()
      .subscribe(res => {
        debugger;
        this.systemCurrencySetting = res;
        this.setDefaultCurrency();
        this.PageLoading = false;

      }, () => {
        this.PageLoading = false;

        //this.notification.showOperationFailed();
      }, () => {
      });
  }

  setDefaultCurrency() {
    debugger;
    if (this.Currencys && this.Currencys.length > 0 &&
      this.systemCurrencySetting && this.systemCurrencySetting.currencyId) {

      //let val = this.Currencys.find(x => x.value == this.systemCurrencySetting.currencyId);
      if ( /*val &&*/ this.editorMode == this.editorModeEnum.add) {
        this.editorForm.controls["ExchangeCurrency"].setValue(this.systemCurrencySetting.currencyId);
      }
    }
  }

  bindModelToForm(): void {
         debugger;
    if (this.itemModel) {
      this.editorForm.patchValue({
        code: this.itemModel.code,
        //         //code: this.itemModel.id,
        date: new Date(this.itemModel.date),
        symbol: this.itemModel.symbol,
        descriptionAr: this.itemModel.descriptionAr,
        descriptionEn: this.itemModel.descriptionEn,
        nameAr: this.itemModel.nameAr,
        nameEn: this.itemModel.nameEn,
        price: this.itemModel.price,
       // ExchangeCurrency: this.itemModel.exchangeCurrencyId
      });
      if(this.itemModel.exchangeCurrencyId != null)
      {
        this.editorForm.controls["ExchangeCurrency"].setValue(this.itemModel.exchangeCurrencyId);
      }
      else{
        this.setDefaultCurrency();
      }
      console.log(this.itemModel);
    }
  }
  collectModelFromForm(): void {
    //     debugger;
    this.itemModel.code = this.editorForm.controls["code"].value;
    this.itemModel.date = this.editorForm.controls["date"].value;

    //     this.itemModel.isDebt = this.editorForm.controls["isDebt"].value;

    this.itemModel.descriptionAr = this.editorForm.controls["descriptionAr"].value;
    this.itemModel.descriptionEn = this.editorForm.controls["descriptionEn"].value;
    this.itemModel.symbol = this.editorForm.controls["symbol"].value;
    this.itemModel.nameAr = this.editorForm.controls["nameAr"].value;
    this.itemModel.nameEn = this.editorForm.controls["nameEn"].value;
    this.itemModel.price = this.editorForm.controls["price"].value;
    this.itemModel.exchangeCurrencyId = this.editorForm.controls["ExchangeCurrency"].value;

  }

  save(): void {
    debugger;
    if (this.canEdit()) {
      this.isProccessing = true;

      if (this.editorForm.valid) {
        if (this.editorMode == EditorMode.add) {
          this.collectModelFromForm();
          this.currencyService.addCurrency(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();
              this.gotoList();
            },
              (error) => {
                this.isProccessing = false;
                this.notificationService.showOperationFailed();
              },
              () => {
                console.log(`addCurrency completed.`);
              });
        }
        else if (this.editorMode == EditorMode.edit) {
          this.collectModelFromForm();
          this.currencyService.updateCurrency(this.itemModel)
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
  //   private banks: any[];
  //   private toBanks: any[];
  //   private safes: any[];
  //   private journalTypes: any[];
  //   private accountCharts: any[];
  private itemModel: Currency = new Currency();
  Currencys: any [];
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
  systemCurrencySetting: SystemCurrencySetting = new SystemCurrencySetting();
}

