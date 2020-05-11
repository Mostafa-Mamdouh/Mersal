import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { CurrencyRate } from '../../Models/currency-rate.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { CurrencyService } from '../../Services/currency.service';
import { CurrencyRateService } from '../../Services/currency-rate.service.';
import { SettingService } from '../../../Setting/Services/setting.service';
import { SystemCurrencySetting } from '../../../Setting/Models/system-currency-setting.model';
import { variable } from '@angular/compiler/src/output/output_ast';
import { from } from 'rxjs';
import { notEqual } from 'assert';
// import { ElementDef } from '@angular/core/src/view';

@Component({
  selector: 'currency-exchange-editor',
  styleUrls: ['./currency-exchange-editor.component.scss'],
  templateUrl: './currency-exchange-editor.component.html'
})
export class CurrencyExchangeEditorComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private CurrencyServ: CurrencyService,
    private CurrencyRateService: CurrencyRateService,
    private SettingService: SettingService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.max = this.SettingService.getMaxLength();
    this.buildForm();
    this.getCurrencyLookup();
    this.getSystemCurrencySetting();
    this.extractRouteParams();
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      currency: [null, [Validators.required, notEqual]],
      date: [new Date(), [Validators.required]],
      price: [null, [Validators.required, Validators.pattern("([0-9]+\.)?[0-9]+"), Validators.max(this.max)]],
      ExchangeCurrency: [null, [Validators.required, notEqual]],
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
      this.CurrencyRateService.getCurrency(this.id)
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
    let url = [`/currency/exchange/list`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  //lookups
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
        //code: this.itemModel.code,
        //code: this.itemModel.id,
        date: new Date(this.itemModel.date),
        currency: this.itemModel.currencyId,

        price: this.itemModel.price,
        ExchangeCurrency: this.itemModel.exchangeCurrencyId
      });
      console.log(this.itemModel);
    }
  }
  collectModelFromForm(): void {
    this.itemModel.currencyId = this.editorForm.controls["currency"].value;
    this.itemModel.date = this.editorForm.controls["date"].value;
    this.itemModel.price = this.editorForm.controls["price"].value;
    this.itemModel.exchangeCurrencyId = this.editorForm.controls["ExchangeCurrency"].value;
  }

  save(): void {
    if (this.canEdit()) {
      this.isProccessing = true;
      //debugger;
      if (this.editorForm.valid) {
        this.collectModelFromForm();

        if (this.itemModel.currencyId == this.itemModel.exchangeCurrencyId) {
          let key = 'currency.exchange.errors.sameSourceAndDest';
          this.translateService.get([key])
            .subscribe(res => {
              this.notificationService.showErrorHtml(`<h5>${res[key]}</h5>`);
            });
          this.isProccessing = false;
          return;
        }

        if (this.editorMode == EditorMode.add) {
          // debugger;
          this.CurrencyRateService.addCurrency(this.itemModel)
            .subscribe(res => {
              debugger;
              this.notificationService.showOperationSuccessed();
              this.gotoList();
            },
              (error) => {
                this.isProccessing = false;
                this.notificationService.showOperationFailed();
              },
              () => {
                console.log(`addCurrencyRate completed.`);
              });
        }
        else if (this.editorMode == EditorMode.edit) {
          this.CurrencyRateService.updateCurrency(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();
              this.gotoList();
            },
              (error) => {
                this.isProccessing = false;
                this.notificationService.showOperationFailed();
              },
              () => {
                console.log(`updateCurrencyRate completed.`);
              });
        }
      }
      else {
        this.isProccessing = false;
        this.notificationService.showDataMissingError();
      }
    }
  }

  static notEqual(form: AbstractControl) {
    return form.get('currency').value != form.get('ExchangeCurrency');
  }

  PageLoading: boolean;
  private editorForm: FormGroup;
   editorMode: EditorMode = EditorMode.add;
   editorModeEnum = EditorMode;
  private id: any;
  private isProccessing: boolean;
  private max;
  //   private CurrencyRates: any[];
  //   private toCurrencyRates: any[];
  //   private safes: any[];
  //   private journalTypes: any[];
  private Currencys: any[];
  private itemModel: CurrencyRate = new CurrencyRate();
  systemCurrencySetting: SystemCurrencySetting = new SystemCurrencySetting();
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
}

