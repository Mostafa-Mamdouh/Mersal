import { Component, Input, Output, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
//import { FinancialService } from '../../../Financial/Services/financial.service';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import {MovementTypeEnum} from '../../../JournalEntries/Models/movement-type-enum';
import {SystemCurrencySetting} from '../../Models/system-currency-setting.model';
import {PostingSetting} from '../../Models/posting-setting.model';
import {VendorSetting} from '../../Models/vendor-setting.model';
import { SettingService } from '../../../Setting/Services/setting.service';
import {CurrencyService} from '../../../Currency/Services/currency.service';

@Component({
  selector: 'system-currency-editor-editor',
  styleUrls: ['./system-currency-editor.component.scss'],
  templateUrl: './system-currency-editor.component.html'
})
export class SystemCurrencyEditorComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    //private ReceiptsServ: FinancialService,
    private settingService: SettingService,
    private currencyService: CurrencyService,
    private location: Location
  ) { 

  }

  ngOnInit(): void {
    this.getCurrencysLookup();
    //this.getAccountChartsLookup();
    this.buildForm();       
    this.extractRouteParams();   
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      currencyId: [null, [Validators.required]],
    });   
  }

  extractRouteParams(): void {  
    this.PageLoading = true;     
      this.settingService.getSystemCurrencySetting()
        .subscribe(res => {  
          this.PageLoading = false;           
          this.itemModel = res;
          this.bindModelToForm();
        },
          (error) => {
            this.PageLoading = false;   
            this.notificationService.showOperationFailed();
          },
          () => {

          });
  }

  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }
  gotoList() {
    this.location.back();

    // let url = [`/setting/control-panel`];
    // this.router.navigate(url);
  }
  
  bindModelToForm(): void {
    //debugger;
     if (this.itemModel) {
       this.editorForm.patchValue({
        currencyId: this.itemModel.currencyId,
       });
     }
  }

  getCurrencysLookup() {
    this.currencyService.getCurrencysLookups()
      .subscribe(res => {
        //this.PageLoading = false;

        this.Currencys = res.collection;        
      }, () => {
        //this.PageLoading = false;

        this.notificationService.showOperationFailed();
      }, () => {
      });
  }

  // getAccountChartsLookup() {
  //   this.ReceiptsServ.getAccountChartsLookup()
  //     .subscribe(res => {
  //       //this.PageLoading = false;

  //       this.AccountCharts = res;        
  //     }, () => {
  //       //this.PageLoading = false;

  //       this.notificationService.showOperationFailed();
  //     }, () => {
  //     });
  // }

  save() {
    if (this.editorForm.valid) {
      this.itemModel = this.editorForm.value;

      this.settingService.updateSystemCurrencySetting(this.itemModel)
        .subscribe(res => {
          this.notificationService.showOperationSuccessed();
          this.gotoList();
        },
          (error) => {
            this.notificationService.showOperationFailed();
          },
          () => {

          });
    }
  }


  private editorForm: FormGroup;
  private editorMode: EditorMode = EditorMode.add;
  private editorModeEnum = EditorMode;
  private id: any;
  PageLoading: boolean = true;
  private isProccessing: boolean;
  private itemModel: SystemCurrencySetting = new SystemCurrencySetting();
  private AccountCharts: any[];
  private Currencys: any[];
}
