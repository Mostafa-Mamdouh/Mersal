import { Component, Input, Output, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { JournalTypeCodes } from '../../Models/journal-type-codes.enum';
import { BankMovement } from '../../Models/bank-movement.model';
import { BankingService } from '../../Services/banking.service';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { PurchasingService } from '../../../Purchasing/Services/Purchasing.service';
import { BankService } from '../../../Bank/Services/bank.service';
import { SettingService } from '../../../Setting/Services/setting.service';
import { SystemCurrencySetting } from '../../../Setting/Models/system-currency-setting.model';
import { PostingSetting } from '../../../Setting/Models/posting-setting.model';
import { BankAccountChartService } from '../../../Bank-Account-Chart/Services/bank-account-chart.service';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';
import { BankAccountChart } from 'src/app/BusinessFeatures/Bank-Account-Chart/Models/bank-account-chart.model';
import { DISABLED } from '@angular/forms/src/model';
declare var $: any;

@Component({
  selector: 'banking-movement-editor',
  styleUrls: ['./editor.component.scss'],
  templateUrl: './editor.component.html'
})
export class EditorComponent implements OnInit {
  journalPreview: any;
  journalPreviewShow: boolean;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private purchasingService: PurchasingService,
    private bankingService: BankingService,
    private bankService: BankService,
    private settingService: SettingService,
    private location: Location,
    private bankAccountChartService: BankAccountChartService,
    private errorService: ErrorService,
  ) { }

  ngOnInit(): void {
    this.buildForm();

    this.extractRouteParams();
    this.getCurrencyLookup();
    this.getSystemCurrencySetting();
    this.getPostingSetting();
    this.getJournalTypes();
    this.getAccountChartsLookup();
    this.getBanks();
    this.getToBanks();
    this.getSafes();
    this.getCostCenters();
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      code: [null],//, [Validators.required]],
      date: [new Date(), [Validators.required]],
      amount: [null, [Validators.required, Validators.min(1)]],
      bankId: [null, [Validators.required]],
      journalTypeId: [null, [Validators.required]],
      descriptionAr: [null, [Validators.required]],
      //safeId: [null],
      descriptionEn: [null],
      toBankId: [null],
      accountChartId: [null],
      remittanceVoucherNumber: [null],
      directlyDonationBankId: [null],
      capturePapersbankId: [null],
      bankaccountchartId: [null, [Validators.required]],
      tobankaccountchartId: [null],
      OnCostCenterValue: [],
      Currency: [null, [Validators.required]],
      ChequeNumber: [],
      CostCentersCheck: [],
      OneCostCenterCheck: [],
    });

    this.editorForm.valueChanges
      .subscribe(res => {

      });
  }

  OneCostCenterCHekedToggle(val) {
    this.IsOneCostCenterChecked = val.checked;
    this.editorForm.controls['CostCentersCheck'].setValue(false);
  }
  getCurrencyLookup() {
    this.ReceiptsServ.getCurrenciesLookup()
      .subscribe(res => {
        this.PageLoading = false;
        var array = new Array<any>();
        res.forEach(function (item) {
          var record = new KendoDropDown();
          record.text = item.displyedName;
          record.value = +item.id;
          array.push(record);
        });
        this.CurrenciesDropDownData = array;
        this.setDefaultCurrency();
        console.log("curriencies" + JSON.stringify(this.CurrenciesDropDownData));
        debugger
        if (this.itemModel.currencyId != null) {
          this.editorForm.controls['Currency'].setValue(this.CurrenciesDropDownData.find(a => a.value == this.itemModel.currencyId))

        }

      },
        // this.Branches = res,
        error => {
          this.PageLoading = false;

          error;
          this.notificationService.showOperationFailed();
        }

      );
  }
  setDefaultCurrency() {
    ;
    if (this.CurrenciesDropDownData && this.CurrenciesDropDownData.length > 0 &&
      this.systemCurrencySetting && this.systemCurrencySetting.currencyId) {

      let val = this.CurrenciesDropDownData.find(x => x.value == this.systemCurrencySetting.currencyId);
      if (val && this.editorMode != this.editorModeEnum.detail) {
        this.editorForm.controls["Currency"].setValue(val);
      }

    }
  }

  addCostCenters(costCentersList) {
    debugger;
    this.totalCostCenters = 0;
    costCentersList.forEach(item => {
      this.totalCostCenters = this.totalCostCenters + item.assignValue;
    });
    if (this.totalCostCenters != this.editorForm.controls['amount'].value) {
      this.notificationService.showTranslateError('financial.costCenterTotalValue');
    }
    else {
      this.CostCenters = costCentersList;
      this.itemModel.costCenters = costCentersList;
      this.notificationService.showTranslateSuccess('costCenter.SucessCostCentersAdd');
    }

  }

  extractRouteParams(): void {
    ;
    let editId = +this.route.snapshot.params['editId'];
    let detailId = +this.route.snapshot.params['detailId'];

    if (editId) {
      this.editorMode = EditorMode.edit
      this.id = editId;
    }
    else if (detailId) {
      this.editorMode = EditorMode.detail;
      this.id = detailId;
      this.isDetails = true;
    }
    else {
      this.editorMode = EditorMode.add;
    }

    if (this.id) {
      this.bankingService.getBankMovement(this.id)
        .subscribe(res => {
          ;


          this.itemModel = res;
          console.log("this.itemModel")

          console.log(this.itemModel)

          this.bindModelToForm();
        },
          (error) => {
            this.notificationService.showOperationFailed();
          })
    }
  }

  journalTypeIdChanged(evnt: any) {


    if (evnt == JournalTypeCodes.deposit) {
      this.getAccountChartsLookup();

      this.editorForm.controls['OnCostCenterValue'].setValidators([Validators.required]);
      this.editorForm.controls['bankId'].setValidators([Validators.required]);
      this.editorForm.controls['bankaccountchartId'].setValidators([Validators.required]);
      this.editorForm.controls['Currency'].setValidators([Validators.required]);



      this.editorForm.controls['toBankId'].setValidators(null);
      this.editorForm.controls['tobankaccountchartId'].setValidators(null);

      this.editorForm.controls['remittanceVoucherNumber'].setValidators(null);
      //this.editorForm.controls['safeId'].setValidators(null);

      this.editorForm.controls['toBankId'].setValue(null);
      this.editorForm.controls['toBankId'].clearValidators();
      this.editorForm.controls['toBankId'].updateValueAndValidity();

      this.editorForm.controls['ChequeNumber'].setValue(null);
      this.editorForm.controls['ChequeNumber'].clearValidators();
      this.editorForm.controls['ChequeNumber'].updateValueAndValidity();

      this.editorForm.controls['accountChartId'].setValue(null);
      this.editorForm.controls['accountChartId'].clearValidators();
      this.editorForm.controls['accountChartId'].updateValueAndValidity();

      this.editorForm.controls['tobankaccountchartId'].setValue(null);
      this.editorForm.controls['tobankaccountchartId'].clearValidators();
      this.editorForm.controls['tobankaccountchartId'].updateValueAndValidity();

      this.editorForm.controls['remittanceVoucherNumber'].setValue(null);
      this.editorForm.controls['remittanceVoucherNumber'].clearValidators();
      this.editorForm.controls['remittanceVoucherNumber'].updateValueAndValidity();

      this.editorForm.controls['directlyDonationBankId'].setValue(null);
      this.editorForm.controls['directlyDonationBankId'].clearValidators();
      this.editorForm.controls['directlyDonationBankId'].updateValueAndValidity();
    }
    else if (evnt == JournalTypeCodes.bankTransfers) {
      this.editorForm.controls['accountChartId'].setValidators(null);
      this.editorForm.controls['toBankId'].setValidators([Validators.required]);
      this.editorForm.controls['bankId'].setValidators([Validators.required]);
      this.editorForm.controls['bankaccountchartId'].setValidators([Validators.required]);
      this.editorForm.controls['Currency'].setValidators([Validators.required]);

      this.editorForm.controls['ChequeNumber'].setValue(null);
      this.editorForm.controls['ChequeNumber'].clearValidators();
      this.editorForm.controls['ChequeNumber'].updateValueAndValidity();

      this.editorForm.controls['accountChartId'].setAsyncValidators(null);
      this.editorForm.controls['toBankId'].setValidators([Validators.required]);
      this.editorForm.controls['tobankaccountchartId'].setValidators([Validators.required]);

      this.editorForm.controls['accountChartId'].setValue(null);
      this.editorForm.controls['accountChartId'].clearValidators();
      this.editorForm.controls['accountChartId'].updateValueAndValidity();

      this.editorForm.controls['OnCostCenterValue'].setValue(null);
      this.editorForm.controls['OnCostCenterValue'].clearValidators();
      this.editorForm.controls['OnCostCenterValue'].updateValueAndValidity();

      this.editorForm.controls['directlyDonationBankId'].setValue(null);
      this.editorForm.controls['directlyDonationBankId'].clearValidators();
      this.editorForm.controls['directlyDonationBankId'].updateValueAndValidity();

    }
    else if (evnt == JournalTypeCodes.bankingExpenses) {


      this.getAccountChartsLookup();
      this.editorForm.controls['bankId'].setValidators([Validators.required]);
      this.editorForm.controls['bankaccountchartId'].setValidators([Validators.required]);
      this.editorForm.controls['Currency'].setValidators([Validators.required]);
      this.editorForm.controls['ChequeNumber'].setValue(null);
      this.editorForm.controls['ChequeNumber'].clearValidators();
      this.editorForm.controls['ChequeNumber'].updateValueAndValidity();

      this.editorForm.controls['accountChartId'].setValue(null);
      this.editorForm.controls['accountChartId'].clearValidators();
      this.editorForm.controls['accountChartId'].updateValueAndValidity();

      this.editorForm.controls['toBankId'].setValidators(null);
      this.editorForm.controls['tobankaccountchartId'].setValidators(null);

      this.editorForm.controls['remittanceVoucherNumber'].setValidators(null);

      this.editorForm.controls['toBankId'].setValue(null);
      this.editorForm.controls['toBankId'].clearValidators();
      this.editorForm.controls['toBankId'].updateValueAndValidity();

      this.editorForm.controls['tobankaccountchartId'].setValue(null);
      this.editorForm.controls['tobankaccountchartId'].clearValidators();
      this.editorForm.controls['tobankaccountchartId'].updateValueAndValidity();

      this.editorForm.controls['remittanceVoucherNumber'].setValue(null);
      this.editorForm.controls['remittanceVoucherNumber'].clearValidators();
      this.editorForm.controls['remittanceVoucherNumber'].updateValueAndValidity();

      this.editorForm.controls['OnCostCenterValue'].setValue(null);
      this.editorForm.controls['OnCostCenterValue'].clearValidators();
      this.editorForm.controls['OnCostCenterValue'].updateValueAndValidity();

      this.editorForm.controls['directlyDonationBankId'].setValue(null);
      this.editorForm.controls['directlyDonationBankId'].clearValidators();
      this.editorForm.controls['directlyDonationBankId'].updateValueAndValidity();
    }
    else if (evnt == JournalTypeCodes.bankTransfers) {

      this.editorForm.controls['bankId'].setValidators([Validators.required]);
      this.editorForm.controls['bankaccountchartId'].setValidators([Validators.required]);
      this.editorForm.controls['Currency'].setValidators([Validators.required]);
      this.editorForm.controls['ChequeNumber'].setValue(null);
      this.editorForm.controls['ChequeNumber'].clearValidators();
      this.editorForm.controls['ChequeNumber'].updateValueAndValidity();

      this.editorForm.controls['accountChartId'].setValidators(null);
      this.editorForm.controls['toBankId'].setValidators([Validators.required]);

      this.editorForm.controls['accountChartId'].setAsyncValidators(null);
      this.editorForm.controls['toBankId'].setValidators([Validators.required]);
      this.editorForm.controls['tobankaccountchartId'].setValidators([Validators.required]);

      this.editorForm.controls['accountChartId'].setValue(null);
      this.editorForm.controls['accountChartId'].clearValidators();
      this.editorForm.controls['accountChartId'].updateValueAndValidity();

      this.editorForm.controls['OnCostCenterValue'].setValue(null);
      this.editorForm.controls['OnCostCenterValue'].clearValidators();
      this.editorForm.controls['OnCostCenterValue'].updateValueAndValidity();

      this.editorForm.controls['directlyDonationBankId'].setValue(null);
      this.editorForm.controls['directlyDonationBankId'].clearValidators();
      this.editorForm.controls['directlyDonationBankId'].updateValueAndValidity();
    }
    else if (evnt == JournalTypeCodes.directDonations) {
      this.editorForm.controls['directlyDonationBankId'].setValidators(Validators.required);
      this.editorForm.controls['directlyDonationBankId'].updateValueAndValidity();

      this.editorForm.controls['OnCostCenterValue'].setValidators([Validators.required]);
      this.editorForm.controls['OnCostCenterValue'].updateValueAndValidity();


      this.editorForm.controls['accountChartId'].setValidators(Validators.required);
      this.editorForm.controls['accountChartId'].updateValueAndValidity();

      this.editorForm.controls['toBankId'].setValue(null);
      this.editorForm.controls['toBankId'].clearValidators();
      this.editorForm.controls['toBankId'].updateValueAndValidity();

      this.editorForm.controls['bankId'].setValidators(null);
      this.editorForm.controls['bankId'].setValue(null);
      this.editorForm.controls['bankId'].clearValidators();
      this.editorForm.controls['bankId'].updateValueAndValidity();

      this.editorForm.controls['Currency'].setValidators(null);
      this.editorForm.controls['Currency'].setValue(null);
      this.editorForm.controls['Currency'].clearValidators();
      this.editorForm.controls['Currency'].updateValueAndValidity();


      this.editorForm.controls['bankaccountchartId'].setValidators(null);
      this.editorForm.controls['bankaccountchartId'].setValue(null);
      this.editorForm.controls['bankaccountchartId'].clearValidators();
      this.editorForm.controls['bankaccountchartId'].updateValueAndValidity();


      this.editorForm.controls['ChequeNumber'].setValue(null);
      this.editorForm.controls['ChequeNumber'].clearValidators();
      this.editorForm.controls['ChequeNumber'].updateValueAndValidity();

      this.editorForm.controls['tobankaccountchartId'].setValue(null);
      this.editorForm.controls['tobankaccountchartId'].clearValidators();
      this.editorForm.controls['tobankaccountchartId'].updateValueAndValidity();

      this.editorForm.controls['OnCostCenterValue'].setValue(null);
      this.editorForm.controls['OnCostCenterValue'].clearValidators();
      this.editorForm.controls['OnCostCenterValue'].updateValueAndValidity();

      this.editorForm.controls['remittanceVoucherNumber'].setValue(null);
      this.editorForm.controls['remittanceVoucherNumber'].clearValidators();
      this.editorForm.controls['remittanceVoucherNumber'].updateValueAndValidity();
    }
    else if (evnt == JournalTypeCodes.paymentPapers) {
      this.editorForm.controls['accountChartId'].setValidators(Validators.required);
      this.editorForm.controls['toBankId'].setValidators(null);
      this.editorForm.controls['tobankaccountchartId'].setValidators(null);
      this.editorForm.controls['bankId'].setValidators([Validators.required]);
      this.editorForm.controls['bankaccountchartId'].setValidators([Validators.required]);
      this.editorForm.controls['Currency'].setValidators([Validators.required]);
      this.editorForm.controls['ChequeNumber'].setValidators(Validators.required);


      this.editorForm.controls['remittanceVoucherNumber'].setValidators(null);

      this.editorForm.controls['OnCostCenterValue'].setValue(null);
      this.editorForm.controls['OnCostCenterValue'].clearValidators();
      this.editorForm.controls['OnCostCenterValue'].updateValueAndValidity();


      this.editorForm.controls['toBankId'].setValue(null);
      this.editorForm.controls['toBankId'].clearValidators();
      this.editorForm.controls['toBankId'].updateValueAndValidity();

      this.editorForm.controls['tobankaccountchartId'].setValue(null);
      this.editorForm.controls['tobankaccountchartId'].clearValidators();
      this.editorForm.controls['tobankaccountchartId'].updateValueAndValidity();

      this.editorForm.controls['remittanceVoucherNumber'].setValue(null);
      this.editorForm.controls['remittanceVoucherNumber'].clearValidators();
      this.editorForm.controls['remittanceVoucherNumber'].updateValueAndValidity();

      this.editorForm.controls['directlyDonationBankId'].setValue(null);
      this.editorForm.controls['directlyDonationBankId'].clearValidators();
      this.editorForm.controls['directlyDonationBankId'].updateValueAndValidity();
    }
    else if (evnt == JournalTypeCodes.repatedPaymentPapers) {
      this.editorForm.controls['accountChartId'].setValidators(Validators.required);
      this.editorForm.controls['toBankId'].setValidators(null);
      this.editorForm.controls['tobankaccountchartId'].setValidators(null);
      this.editorForm.controls['bankId'].setValidators([Validators.required]);
      this.editorForm.controls['bankaccountchartId'].setValidators([Validators.required]);
      this.editorForm.controls['Currency'].setValidators([Validators.required]);
      this.editorForm.controls['ChequeNumber'].setValidators(Validators.required);


      this.editorForm.controls['remittanceVoucherNumber'].setValidators(null);

      this.editorForm.controls['OnCostCenterValue'].setValue(null);
      this.editorForm.controls['OnCostCenterValue'].clearValidators();
      this.editorForm.controls['OnCostCenterValue'].updateValueAndValidity();


      this.editorForm.controls['toBankId'].setValue(null);
      this.editorForm.controls['toBankId'].clearValidators();
      this.editorForm.controls['toBankId'].updateValueAndValidity();

      this.editorForm.controls['tobankaccountchartId'].setValue(null);
      this.editorForm.controls['tobankaccountchartId'].clearValidators();
      this.editorForm.controls['tobankaccountchartId'].updateValueAndValidity();

      this.editorForm.controls['remittanceVoucherNumber'].setValue(null);
      this.editorForm.controls['remittanceVoucherNumber'].clearValidators();
      this.editorForm.controls['remittanceVoucherNumber'].updateValueAndValidity();

      this.editorForm.controls['directlyDonationBankId'].setValue(null);
      this.editorForm.controls['directlyDonationBankId'].clearValidators();
      this.editorForm.controls['directlyDonationBankId'].updateValueAndValidity();
    }
    else if (evnt == JournalTypeCodes.capturePapers) {
      this.editorForm.controls['accountChartId'].setValidators(null);
      this.editorForm.controls['toBankId'].setValidators(null);
      this.editorForm.controls['tobankaccountchartId'].setValidators(null);
      this.editorForm.controls['bankId'].setValidators([Validators.required]);
      this.editorForm.controls['bankaccountchartId'].setValidators([Validators.required]);

      this.editorForm.controls['ChequeNumber'].setValidators(Validators.required);
      this.editorForm.controls['Currency'].setValidators([Validators.required]);

      this.editorForm.controls['remittanceVoucherNumber'].setValidators(null);

      this.editorForm.controls['OnCostCenterValue'].setValue(null);
      this.editorForm.controls['OnCostCenterValue'].clearValidators();
      this.editorForm.controls['OnCostCenterValue'].updateValueAndValidity();

      this.editorForm.controls['accountChartId'].setValue(null);
      this.editorForm.controls['accountChartId'].clearValidators();
      this.editorForm.controls['accountChartId'].updateValueAndValidity();


      this.editorForm.controls['toBankId'].setValue(null);
      this.editorForm.controls['toBankId'].clearValidators();
      this.editorForm.controls['toBankId'].updateValueAndValidity();

      this.editorForm.controls['tobankaccountchartId'].setValue(null);
      this.editorForm.controls['tobankaccountchartId'].clearValidators();
      this.editorForm.controls['tobankaccountchartId'].updateValueAndValidity();

      this.editorForm.controls['remittanceVoucherNumber'].setValue(null);
      this.editorForm.controls['remittanceVoucherNumber'].clearValidators();
      this.editorForm.controls['remittanceVoucherNumber'].updateValueAndValidity();

      this.editorForm.controls['directlyDonationBankId'].setValue(null);
      this.editorForm.controls['directlyDonationBankId'].clearValidators();
      this.editorForm.controls['directlyDonationBankId'].updateValueAndValidity();
    }
  }


  onOneCostCenterChanged(id) {
    let totalAmount = this.editorForm.controls['amount'].value;
    if (totalAmount == null || totalAmount == 0) {
      this.editorForm.controls['OnCostCenterValue'].setValue(null);
      this.SelectedCostCenter = null;
      this.notificationService.showTranslateError('movements.TotalAmount');
    }
    else {
      this.itemModel.costCenters = new Array();
      this.itemModel.costCenters.push({ id: id.value, costCenterId: id.value, amount: totalAmount, assignValue: totalAmount })
      console.log("one cost center to Api " + JSON.stringify(this.itemModel.costCenters))
    }

  }

  CostCentersCHekedToggle() {
    this.editorForm.controls['CostCentersCheck'].valueChanges.subscribe(value => {
      if (this.editorMode != this.editorModeEnum.add) {
        $('#openCostCentersModalBTN').click();
      }
      else {
        if (value == true) {
          this.editorForm.controls['OneCostCenterCheck'].setValue(false);
          this.IsOneCostCenterChecked = false;
          $('#openCostCentersModalBTN').click();
          $('#openCostCentersModalBTN').html("Heloo");
        }
        else {
          this.itemModel.costCenters = new Array();
        }
      }
    });
  }
  bankValueChanged(event) {
    if (event) {
      this.bankAccountChartService.getAccountCharts(event).subscribe(res => {
        ;

        //this.accountCharts = res;
        this.directlyDonationBankaccountChartList = res


        //this.bankDocuments = res
      });
    }
  }

  checkListChanged(event) {
    ;
    this.itemModel.cheques = event;
  }

  journalValueChange(event) {
    this.itemModel.journal = event;
  }
  journalApprove(event) {
    ;
    this.collectModelFromForm();
    this.itemModel.journal = event;
    this.bankingService.addBankMovement(this.itemModel)
      .subscribe(res => {
        ;
        this.PageLoading = false;
        $('#openPostlBTN').click();
        //this.notification.showSuccessAlertForSavedDocument(this.receipt.code);
        this.gotoList();
        //;
      }, (error) => {
        // ;
        console.error(JSON.stringify(error));
        this.PageLoading = false;

        this.errorService.handerErrors(error);
        // ;
      }, () => {
        this.PageLoading = false;

        // ;
      });
  }

  journalReject(event) {
    $('#openPostlBTN').click();
    this.notificationService.showSuccessAlertForSavedDocument(this.itemModel.code);
    this.notificationService.showJournalcanceled();
    this.gotoList();
  }

  getSystemCurrencySetting() {
    this.settingService.getSystemCurrencySetting()
      .subscribe(res => {
        //;
        this.systemCurrencySetting = res;
        this.PageLoading = false;

      }, () => {
        this.PageLoading = false;

        //this.notification.showOperationFailed();
      }, () => {
      });
  }
  getPostingSetting() {
    this.settingService.getPostingSetting()
      .subscribe(res => {
        this.postingSetting = res;
        this.PageLoading = false;
      },
        (error) => {
          this.PageLoading = false;
        },
        () => {

        });
  }

  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }
  gotoList() {
    let url = [`/banking/bank-movement/list`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  fromBankAccountCahnged(value) {

    var currencyid = this.BankAcountChartsList.find(x => x.id == value).currencyId;
    var currency = this.CurrenciesDropDownData.find(c => c.value == currencyid);
    this.editorForm.controls['Currency'].setValue(currency);

  }

  FromBankCahnged(value) {
    if (value) {
      this.bankAccountChartService.getAccountCharts(value).subscribe(res => {
        console.log("res")

        console.log(res)
        var array = new Array<any>();
        res.forEach(function (item) {
          var record = new KendoDropDown();
          record.text = item.displyedName;
          record.value = +item.id;
          array.push(record);
        });
        this.BankAcountChartsList = res;
        this.BankAcountChartsDropDownData = array;

        if (this.itemModel.bankAccountChartId != null) {
          this.editorForm.controls['bankaccountchartId'].setValue(this.itemModel.bankAccountChartId)

        }



      },
        (error) => {
          this.notificationService.showOperationFailed();
        }, () => {
        });
    }
  }


  ToBankCahnged(value) {
    if (value) {
      this.bankAccountChartService.getAccountCharts(value).subscribe(res => {
        console.log("res")

        console.log(res)
        var array = new Array<any>();
        res.forEach(function (item) {
          var record = new KendoDropDown();
          record.text = item.displyedName;
          record.value = +item.id;
          array.push(record);
        });
        this.toBankAcountChartsList = res;
        this.toBankAcountChartsDropDownData = array;

        if (this.itemModel.toBankAccountChartId != null) {
          this.editorForm.controls['tobankaccountchartId'].setValue(this.itemModel.toBankAccountChartId)

        }

      }, (error) => {
        this.notificationService.showOperationFailed();
      }, () => {
      });
    }
  }


  //lookups
  getBanks() {
    this.bankService.getBanksLookups()
      .subscribe(
        res => {
          ;
          //this.PageLoading = false;
          // var array = new Array<any>();
          // res.collection.forEach(function (item) {
          //   var record = new KendoDropDown();
          //   record.text = item.name;
          //   record.value = item.id;
          //   array.push(record);
          // });
          this.banks = res.collection;
          //this.toBanks = res.collection;
        }, () => {
          //this.PageLoading = false;
          this.notificationService.showOperationFailed();
        }
      );
  }
  getToBanks() {
    this.bankService.getBanksLookups()
      .subscribe(
        res => {
          ;
          //this.PageLoading = false;

          // var array = new Array<any>();
          // res.collection.forEach(function (item) {
          //   var record = new KendoDropDown();
          //   record.text = item.name;
          //   record.value = item.id;
          //   array.push(record);
          // });
          //this.banks = res.collection;

          this.toBanks = res.collection;
        }, () => {
          //this.PageLoading = false;
          this.notificationService.showOperationFailed();
        }
      );
  }
  getSafes() {
    this.purchasingService.getSafesLookups()
      .subscribe(
        res => {
          //this.PageLoading = false;
          var array = new Array<any>();
          res.collection.forEach(function (item) {
            var record = new KendoDropDown();
            record.text = item.name;
            record.value = item.id;
            array.push(record);
          });
          this.safes = res.collection;
        }, () => {
          //this.PageLoading = false;
          this.notificationService.showOperationFailed();
        }
      );
  }
  getJournalTypes() {
    this.bankingService.getJournalTypes()
      .subscribe(
        res => {
          ;
          //this.PageLoading = false;
          var array = new Array<any>();
          res.collection.forEach(function (item) {
            var record = new KendoDropDown();
            record.text = item.name;
            record.value = item.id;
            array.push(record);
          });
          console.log
          this.journalTypes = res.collection;
        },
        (error) => {
          //this.PageLoading = false;
          this.notificationService.showOperationFailed();
        }
      );
  }
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

  getSelectedJournalType(): any {
    let val = this.editorForm.controls['journalTypeId'].value;

    if (val && val.value) {
      val = val.value;
    }

    if (val == JournalTypeCodes.bankTransfers) {
      return JournalTypeCodes.bankTransfers;
    }
    else if (val == JournalTypeCodes.bankingExpenses) {
      return JournalTypeCodes.bankingExpenses;
    }
    else if (val == JournalTypeCodes.deposit) {
      return JournalTypeCodes.deposit;
    }
    // else if (val == JournalTypeCodes.withdrawal) {
    //   return JournalTypeCodes.withdrawal;
    // }
    else if (val == JournalTypeCodes.capturePapers) {
      return JournalTypeCodes.capturePapers;
    }
    else if (val == JournalTypeCodes.directDonations) {
      return JournalTypeCodes.directDonations;
    }
    else if (val == JournalTypeCodes.paymentPapers) {
      return JournalTypeCodes.paymentPapers;
    }
    else if (val == JournalTypeCodes.repatedPaymentPapers) {
      return JournalTypeCodes.repatedPaymentPapers;
    }
    else {
      return val;
    }
  }

  showCheck() {
    this.showChecks = true;
  }

  bindModelToForm(): void {
    debugger
    if (this.itemModel) {

      this.editorForm.patchValue({
        //code: this.itemModel.code,
        code: this.itemModel.id,
        date: new Date(this.itemModel.date),
        bankId: this.itemModel.bankId,
        amount: this.itemModel.amount,
        //safeId: this.itemModel.safeId,
        journalTypeId: this.itemModel.journalTypeId,
        descriptionAr: this.itemModel.descriptionAr,
        descriptionEn: this.itemModel.descriptionEn,
        toBankId: this.itemModel.toBankId,
        accountChartId: this.itemModel.accountChartId,
        remittanceVoucherNumber: this.itemModel.remittanceVoucherNumber,
        directlyDonationBankId: this.itemModel.directlyDonationBankId,
        capturePapersbankId: this.itemModel.capturePapersbankId,
        bankAccountChartId: this.itemModel.bankAccountChartId,
        currencyId: this.itemModel.currencyId,
        OnCostCenterValue: this.itemModel.costCenterId,
        ChequeNumber: this.itemModel.chequeNo
      });

      this.FromBankCahnged(this.itemModel.bankId);
      if (this.itemModel.currencyId != null) {
        this.editorForm.controls['Currency'].setValue(this.CurrenciesDropDownData.find(a => a.value == this.itemModel.currencyId))

      }

      if (this.itemModel.toBankId) {
        this.ToBankCahnged(this.itemModel.toBankId);

      }


      if (this.editorForm.controls['journalTypeId'].value === JournalTypeCodes.directDonations) {
        if (this.itemModel.directlyDonationBankId) {
          this.bankValueChanged(this.itemModel.directlyDonationBankId);
        }
      }

      if (this.itemModel.costCenters) {
        this.itemModel.costCenters.forEach(item => {
          item.id = item.costCenterId;
          item.amount = item.amount;
        });

        if (this.itemModel.costCenters.length == 1) {
          this.IsOneCostCenterChecked = true;
          this.editorForm.controls['OneCostCenterCheck'].setValue(true);

          if (this.CostCenterDropDown && this.CostCenterDropDown.length > 0) {
            let val = this.CostCenterDropDown.find(x => x.value == this.itemModel.costCenters[0].costCenterId);
            if (val) {
              this.editorForm.controls['OnCostCenterValue'].setValue(val);
            }
          }
        }
        else if (this.itemModel.costCenters.length > 1) {
          this.editorForm.controls['CostCentersCheck'].setValue(true);
          this.CostCenters = this.itemModel.costCenters;
        }
      }


    }
  }
  collectModelFromForm(): void {
    debugger;
    this.itemModel.code = this.editorForm.controls["code"].value;
    this.itemModel.chequeNo = this.editorForm.controls["ChequeNumber"].value;

    this.itemModel.date = this.editorForm.controls["date"].value;
    this.itemModel.amount = this.editorForm.controls["amount"].value;
    this.itemModel.descriptionAr = this.editorForm.controls["descriptionAr"].value;
    this.itemModel.descriptionEn = this.editorForm.controls["descriptionEn"].value;
    this.itemModel.remittanceVoucherNumber = this.editorForm.controls["remittanceVoucherNumber"].value;
    this.itemModel.directlyDonationBankId = this.editorForm.controls["directlyDonationBankId"].value;
    this.itemModel.capturePapersbankId = this.editorForm.controls["capturePapersbankId"].value;

    this.itemModel.bankId = this.editorForm.controls["bankId"].value;
    if (this.itemModel.bankId != null) {
      if (this.itemModel.bankId.value) {
        this.itemModel.bankId = this.itemModel.bankId.value;
      }
    }
    if (this.editorForm.controls["Currency"] != null) {
      if (this.editorForm.controls["Currency"].value)
        this.itemModel.currencyId = this.editorForm.controls["Currency"].value.value;
    }
    if (this.editorForm.controls["bankaccountchartId"] != null) {
      this.itemModel.bankAccountChartId = this.editorForm.controls["bankaccountchartId"].value;
    }

    this.itemModel.toBankAccountChartId = this.editorForm.controls["tobankaccountchartId"].value;
    this.itemModel.costCenterId = this.editorForm.controls["OnCostCenterValue"].value;


    this.itemModel.journalTypeId = this.editorForm.controls["journalTypeId"].value
    if (this.itemModel.journalTypeId.value) {
      this.itemModel.journalTypeId = this.itemModel.journalTypeId.value;
    }

    // this.itemModel.safeId = this.editorForm.controls['safeId'].value;
    // if (this.itemModel.safeId && this.itemModel.safeId.value) {
    //   this.itemModel.safeId = this.itemModel.safeId.value;
    // }

    this.itemModel.toBankId = this.editorForm.controls["toBankId"].value;
    if (this.itemModel.toBankId && this.itemModel.toBankId.value) {
      this.itemModel.toBankId = this.itemModel.toBankId.value;
    }

    this.itemModel.accountChartId = this.editorForm.controls["accountChartId"].value;
    if (this.itemModel.accountChartId && this.itemModel.accountChartId.value) {
      this.itemModel.accountChartId = this.itemModel.accountChartId.value;
    }
  }

  checkAccountAndCurrencyAreMatches(): boolean {
    let selectedAccountChartId: any = this.editorForm.controls['accountChartId'].value;
    let selectedCurrencyId: any = this.systemCurrencySetting.currencyId;
    let accountChartItem: any = this.accountCharts.find(x => x.id == selectedAccountChartId);

    if (!this.postingSetting.allowPostingAccountCurrencyMisMatch &&
      accountChartItem && accountChartItem.currencyId != selectedCurrencyId) {

      let wrongAccountKey = 'error.accountCurrencyNotMatchSystemCurrencyg';
      this.translateService.get([wrongAccountKey])
        .subscribe(res => {
          this.notificationService.showErrorHtml(`<h5>${res[wrongAccountKey]}</h5>`);
        });
      return false;
    }
    else {
      return true;
    }
  }
  // checkDate(): boolean {
  //   ;
  //   let selectedDate: any = this.editorForm.controls['date'].value;
  //   let now = new Date(Date.now());

  //   if (selectedDate > now) {
  //     this.notificationService.showTranslateHtmlError_h5('error.maxDateAlert');
  //     return false;
  //   }
  //   else {
  //     return true;
  //   }
  // }

  save(): void {
    //;
    if (this.canEdit()) {
      this.isProccessing = true;

      if (this.editorForm.valid) {

        //if(this.checkDate() == false) return;

        // if (this.checkAccountAndCurrencyAreMatches() == false) {
        //   this.isProccessing = false;
        //   return;
        // }

        if (this.editorMode == EditorMode.add) {
          this.collectModelFromForm();
          this.bankingService.addBankMovement(this.itemModel)
            .subscribe(res => {
              this.PageLoading = false;
              this.itemModel = res;
              this.journalPreview = res.journal;
              this.journalPreviewShow = true;
              $('#openPostlBTN').click();

            },
              (error) => {
                this.isProccessing = false;
                this.errorService.handerErrors(error);
              },
              () => {
                this.isProccessing = false;
                console.log(`addBankMovement completed.`);
              });
        }
        else if (this.editorMode == EditorMode.edit) {
          this.collectModelFromForm();
          this.bankingService.updateBankMovement(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();
              this.gotoList();
            },
              (error) => {
                this.isProccessing = false;
                this.errorService.handerErrors(error);
              },
              () => {
                console.log(`updateBankMovement completed.`);
              });
        }
      }
      else {
        this.isProccessing = false;
        this.notificationService.showDataMissingError();
      }
    }
  }

  getCostCenters() {
    this.ReceiptsServ.getCostCentersLookups()
      .subscribe(
        res => {
          this.PageLoading = false;

          var array = new Array<any>();
          res.forEach(function (item) {
            var record = new KendoDropDown();
            record.text = item.displyedName;
            record.value = item.id;
            array.push(record);
          });
          //debugger;
          this.CostCenterDropDown = array;
          if (this.itemModel.costCenterId != null) {
            this.editorForm.controls['OnCostCenterValue'].setValue(this.CostCenterDropDown.find(a => a.value == this.itemModel.costCenterId))

          }
        },
        // this.Branches = res,
        error => {
          this.PageLoading = false;

          error;
          this.notificationService.showOperationFailed();
        }

      );
  }
  isDetails: boolean = false;
  PageLoading: boolean;
  IsOneCostCenterChecked = false;
  private editorForm: FormGroup;
  editorMode: EditorMode = EditorMode.add;
  editorModeEnum = EditorMode;
  private id: any;
  private journalTypeCodesEnum = JournalTypeCodes;
  private isProccessing: boolean;
  private banks: any[];
  private toBanks: any[];
  private safes: any[];
  private journalTypes: any[];
  private accountCharts: any[];
  private itemModel: BankMovement = new BankMovement();
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
  systemCurrencySetting: SystemCurrencySetting = new SystemCurrencySetting();
  postingSetting: PostingSetting = new PostingSetting();
  showChecks: boolean = false;
  directlyDonationBankaccountChartList: any[];
  BankAcountChartsDropDownData: BankAccountChart[];
  BankAcountChartsList: BankAccountChart[];

  toBankAcountChartsDropDownData: BankAccountChart[];
  toBankAcountChartsList: BankAccountChart[];
  CostCenterDropDown = new Array();
  public CurrenciesDropDownData: Array<KendoDropDown>;


  CostCenters = [];
  SelectedCostCenter: number;

  totalCostCenters: number = 0;
}
