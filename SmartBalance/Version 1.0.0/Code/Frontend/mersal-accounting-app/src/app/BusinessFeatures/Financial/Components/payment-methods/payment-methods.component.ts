import { FinancialService } from '../../Services/financial.service';
import { Component, OnInit, Output, EventEmitter, Input, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormsModule, FormControl } from '@angular/forms';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { PaymentMethod } from '../../Models/payment-methods.model';
import { PaymentMethodsEnum } from '../../Models/payment-method.enum';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { pageSource } from '../../Models/source-type.enum';
import { FinancialSetting } from '../../../Setting/Models/financial-setting.model';
import { BankService } from '../../../Bank/Services/bank.service';
import { EditorMode } from 'src/app/SharedFeatures/SharedMain/Models/editor-mode.enum';
import { BankAccountChartService } from 'src/app/BusinessFeatures/Bank-Account-Chart/Services/bank-account-chart.service';
import { BankAccountChart } from 'src/app/BusinessFeatures/Bank-Account-Chart/Models/bank-account-chart.model';
import { SafeService } from '../../../Safe/Services/safe.service';

declare var $: any;

@Component({
  selector: 'app-payment-methods',
  templateUrl: './payment-methods.component.html',
  styleUrls: ['./payment-methods.component.scss'],
  providers: [FinancialService]
})
export class PaymentMethodsComponent implements OnInit {
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };
  IsCash: boolean = true;
  IsCheque: boolean = false;
  IsVisa: boolean = false;
  IsBank: boolean = false;
  BanksDropDownData: Array<KendoDropDown>;
  SafesDropDownData: Array<KendoDropDown>;
  PayMethods: typeof PaymentMethodsEnum = PaymentMethodsEnum;
  paymentMethod: PaymentMethod = new PaymentMethod();
  addPaymentMethods: FormGroup;
  @Output() paymentMethodsChanged: EventEmitter<PaymentMethod> = new EventEmitter();
  @Input() branchValue;
  @Input() DetailPaymentMethod: PaymentMethod;
  @Input() pageSource: pageSource;
  @Input() financialSetting: FinancialSetting;
  @Input() currency: any;
  @Input() isReceipt: boolean;
  pageSourceTypes: typeof pageSource = pageSource;
  methods: any[];
  isDetails: boolean = false;
  paymentMethodCode: any;
  safe: any;
  @Input() showExchangeable = true;
  private editorMode: EditorMode = EditorMode.add;
  private editorModeEnum = EditorMode;
  BankAcountChartsDropDownData: BankAccountChart[];
  AccountCharts: any[];
  @Input() isPayment: boolean = true;


  constructor(
    public router: Router,
    private fb: FormBuilder,
    private paymentMethodssServ: FinancialService,
    private notification: NotificationService,
    private bankService: BankService,
    private BankAccountChart: BankAccountChartService,
    private safeService: SafeService

  ) {

  }

  ngOnChanges(changes: SimpleChanges) {
    debugger;
    if (this.branchValue) {
      this.getSafes();
    }
    if (this.DetailPaymentMethod != null && this.DetailPaymentMethod != undefined && this.DetailPaymentMethod.ischanged == true) {
      // this.buildForm();
      this.setDeatilsValues();
      this.isDetails = true;
    }
  }

  ngOnInit() {
    this.buildForm();
    this.getReceivingMethodsLookup();
    this.getBanksLookup();

    this.paymentMethodCode = PaymentMethodsEnum.Cash;
    this.firepaymentMethodsChanged();
    console.log(this.methods);
  }

  buildForm(): void {
    this.addPaymentMethods = this.fb.group({
      ReceivingMethodId: [1, [Validators.required]],
      SafeId: [null],
      Safe: [null],
      VisaBankId: [null],
      FromBankId: [null],
      ToBankId: [null],
      ChequeNumber: [null],
      exchangeable: [null],
      Duedate: [new Date()],
      VisaNumber: [null],
      bankaccountchartId: [null],
      accountChart: [null]
    });
    if (this.pageSource == pageSource.receiptsMovement) {
      this.addPaymentMethods.addControl("ToBankId", new FormControl(''))
      this.addPaymentMethods.addControl("bankaccountchartId", new FormControl(''))

    }
  }

  getReceivingMethodsLookup() {
    this.paymentMethodssServ.getReceivingMethodsLookup()
      .subscribe(res => {
        //debugger;   
        this.methods = res;
      }, (error) => {
        this.notification.showOperationFailed();
        // debugger;
      }, () => {
        // debugger;
      });
  }

  getBanksLookup() {
    this.bankService.getBanksLookups()
      .subscribe(res => {
        //debugger;  
        var array = new Array<any>();
        res.collection.forEach(function (item) {
          var record = new KendoDropDown();
          record.text = item.code + " - " + item.name;
          record.value = +item.id;
          array.push(record);
        });
        this.BanksDropDownData = array;
      }, (error) => {
        this.notification.showOperationFailed();
        // debugger;
      }, () => {
        // debugger;
      });


  }

  getSafes() {
    //debugger;
    if (this.branchValue != null && this.branchValue != undefined) {
      this.paymentMethodssServ.getSafesByBranchId(this.branchValue)
        .subscribe((res) => {
          debugger;
          if (res) {
            this.safe = res.name;
            let currencyId: number;
            try {
              currencyId = this.currency.value
            } catch{ }
            this.safeService.getAccountcharts(res.id, currencyId).subscribe(res => {
              this.AccountCharts = res;
              console.log("AccountCharts")
              console.log(this.AccountCharts)

            })


            // this.safe=res.branch.name+"-"+res.name;
            this.addPaymentMethods.controls["SafeId"].setValue(res.id);
            this.addPaymentMethods.controls["Safe"].setValue(this.safe);
            this.firepaymentMethodsChanged();
          } else {
            this.addPaymentMethods.controls["SafeId"].setValue(null);
            this.addPaymentMethods.controls["Safe"].setValue(null);
            this.firepaymentMethodsChanged();
          }
          //debugger;   
        }, (error) => {
          this.notification.showOperationFailed();
        }
        );
    }
  }


  setDeatilsValues() {
    
    //this.addPaymentMethods.controls["SafeId"].setValue(this.DetailPaymentMethod.SafeId);
    this.addPaymentMethods.controls["accountChart"].setValue(this.DetailPaymentMethod.safeAccountChartId);
    this.addPaymentMethods.controls["VisaNumber"].setValue(this.DetailPaymentMethod.VisaNumber);
    this.addPaymentMethods.controls["Duedate"].setValue(this.DetailPaymentMethod.Duedate);
    this.addPaymentMethods.controls["exchangeable"].setValue(this.DetailPaymentMethod.exchangeable);
    this.addPaymentMethods.controls["ChequeNumber"].setValue(this.DetailPaymentMethod.ChequeNumber);
    this.addPaymentMethods.controls["ToBankId"].setValue(this.DetailPaymentMethod.ToBankId);
    if (this.DetailPaymentMethod.ToBankId != null && this.DetailPaymentMethod.ToBankId != undefined) {
      this.ToBankCahnged(this.DetailPaymentMethod.ToBankId);
    }
    this.addPaymentMethods.controls["bankaccountchartId"].setValue(this.DetailPaymentMethod.toBankAccountChartId);
    this.addPaymentMethods.controls["FromBankId"].setValue(this.DetailPaymentMethod.FromBankId);
    this.addPaymentMethods.controls["VisaBankId"].setValue(Number(this.DetailPaymentMethod.FromBankId));
    this.addPaymentMethods.controls["ReceivingMethodId"].setValue(this.DetailPaymentMethod.ReceivingMethodId);
    this.addPaymentMethods.disable();

  }

  paymentMethodChanged() {

    this.paymentMethodCode = this.methods.find(x => x.id == this.addPaymentMethods.controls["ReceivingMethodId"].value).code;
    switch (this.paymentMethodCode) {
      case "1": {
        //statements; 
        this.IsCash = true;
        this.IsCheque = false;
        this.IsVisa = false;
        //this.addPaymentMethods.controls["SafeId"].setValidators([Validators.required]);
        //this.addPaymentMethods.controls["SafeId"].updateValueAndValidity();

        this.addPaymentMethods.controls["accountChart"].setValidators([Validators.required]);
        this.addPaymentMethods.controls["accountChart"].updateValueAndValidity();

        this.addPaymentMethods.controls["VisaNumber"].setValidators(null);
        this.addPaymentMethods.controls["VisaNumber"].updateValueAndValidity();

        this.addPaymentMethods.controls["Duedate"].setValidators(null);
        this.addPaymentMethods.controls["Duedate"].setValue(null);
        this.addPaymentMethods.controls["Duedate"].updateValueAndValidity();

        this.addPaymentMethods.controls["exchangeable"].setValidators(null);
        this.addPaymentMethods.controls["exchangeable"].updateValueAndValidity();

        this.addPaymentMethods.controls["ChequeNumber"].setValidators(null);
        this.addPaymentMethods.controls["ChequeNumber"].updateValueAndValidity();

        if (this.pageSource == pageSource.receiptsMovement) {
          this.addPaymentMethods.controls["ToBankId"].setValidators(null);
          this.addPaymentMethods.controls["ToBankId"].updateValueAndValidity();
          this.addPaymentMethods.controls["bankaccountchartId"].setValidators(null);
          this.addPaymentMethods.controls["bankaccountchartId"].updateValueAndValidity();
        }

        this.addPaymentMethods.controls["FromBankId"].setValidators(null);
        this.addPaymentMethods.controls["FromBankId"].updateValueAndValidity();
        this.addPaymentMethods.controls["VisaBankId"].setValidators(null);
        this.addPaymentMethods.controls["VisaBankId"].updateValueAndValidity();

        break;
      }
      case "2": {
        //statements; 
        this.IsCash = false;
        this.IsCheque = true;
        this.IsVisa = false;
        //this.addPaymentMethods.controls["SafeId"].setValidators(null);
        //this.addPaymentMethods.controls["SafeId"].updateValueAndValidity();

        this.addPaymentMethods.controls["accountChart"].clearValidators();
        this.addPaymentMethods.controls["accountChart"].updateValueAndValidity();

        this.addPaymentMethods.controls["VisaNumber"].setValidators(null);
        this.addPaymentMethods.controls["VisaNumber"].updateValueAndValidity();

        this.addPaymentMethods.controls["Duedate"].setValidators([Validators.required]);
        this.addPaymentMethods.controls["Duedate"].setValue(new Date());
        this.addPaymentMethods.controls["Duedate"].updateValueAndValidity();

        this.addPaymentMethods.controls["exchangeable"].setValidators([Validators.required]);
        this.addPaymentMethods.controls["exchangeable"].updateValueAndValidity();

        this.addPaymentMethods.controls["ChequeNumber"].setValidators([Validators.required]);
        this.addPaymentMethods.controls["ChequeNumber"].updateValueAndValidity();
        if (this.pageSource == pageSource.receiptsMovement) {
          //this.addPaymentMethods.controls["ToBankId"].setValidators(null);
          this.addPaymentMethods.controls["ToBankId"].setValidators([null]);
          this.addPaymentMethods.controls["ToBankId"].updateValueAndValidity();

          this.addPaymentMethods.controls["bankaccountchartId"].setValidators(null);
          this.addPaymentMethods.controls["bankaccountchartId"].updateValueAndValidity();
        }
        this.addPaymentMethods.controls["FromBankId"].setValidators([Validators.required]);
        this.addPaymentMethods.controls["FromBankId"].updateValueAndValidity();
        this.addPaymentMethods.controls["VisaBankId"].setValidators(null);
        this.addPaymentMethods.controls["VisaBankId"].updateValueAndValidity();
        break;
      }
      case "3": {
        //statements; 
        //this.addPaymentMethods.controls["SafeId"].setValidators(null);
        //this.addPaymentMethods.controls["SafeId"].updateValueAndValidity();

        this.addPaymentMethods.controls["accountChart"].clearValidators();
        this.addPaymentMethods.controls["accountChart"].updateValueAndValidity();

        this.addPaymentMethods.controls["VisaNumber"].setValidators([Validators.required]);
        this.addPaymentMethods.controls["VisaNumber"].updateValueAndValidity();

        this.addPaymentMethods.controls["Duedate"].setValidators(null);
        this.addPaymentMethods.controls["Duedate"].setValue(null);
        this.addPaymentMethods.controls["Duedate"].updateValueAndValidity();


        this.addPaymentMethods.controls["exchangeable"].setValidators(null);
        this.addPaymentMethods.controls["exchangeable"].updateValueAndValidity();


        this.addPaymentMethods.controls["ChequeNumber"].setValidators(null);
        this.addPaymentMethods.controls["ChequeNumber"].updateValueAndValidity();

        if (this.pageSource == pageSource.receiptsMovement) {
          this.addPaymentMethods.controls["ToBankId"].setValidators(null);
          this.addPaymentMethods.controls["ToBankId"].updateValueAndValidity();
          this.addPaymentMethods.controls["bankaccountchartId"].setValidators(null);
          this.addPaymentMethods.controls["bankaccountchartId"].updateValueAndValidity();
        }



        this.addPaymentMethods.controls["FromBankId"].setValidators(null);
        this.addPaymentMethods.controls["FromBankId"].updateValueAndValidity();


        this.addPaymentMethods.controls["VisaBankId"].setValidators([Validators.required]);
        this.addPaymentMethods.controls["VisaBankId"].updateValueAndValidity();


        this.IsCash = false;
        this.IsCheque = false;
        this.IsVisa = true;
        break;
      }
      case "4" :{
        this.addPaymentMethods.controls["accountChart"].clearValidators();
        this.addPaymentMethods.controls["accountChart"].updateValueAndValidity();

        this.addPaymentMethods.controls["VisaNumber"].setValidators([Validators.required]);
        this.addPaymentMethods.controls["VisaNumber"].updateValueAndValidity();

        this.addPaymentMethods.controls["Duedate"].setValidators(null);
        this.addPaymentMethods.controls["Duedate"].setValue(null);
        this.addPaymentMethods.controls["Duedate"].updateValueAndValidity();


        this.addPaymentMethods.controls["exchangeable"].setValidators(null);
        this.addPaymentMethods.controls["exchangeable"].updateValueAndValidity();


        this.addPaymentMethods.controls["ChequeNumber"].setValidators(null);
        this.addPaymentMethods.controls["ChequeNumber"].updateValueAndValidity();

        if (this.pageSource == pageSource.receiptsMovement) {
          this.addPaymentMethods.controls["ToBankId"].setValidators(null);
          this.addPaymentMethods.controls["ToBankId"].updateValueAndValidity();
          this.addPaymentMethods.controls["bankaccountchartId"].setValidators(null);
          this.addPaymentMethods.controls["bankaccountchartId"].updateValueAndValidity();
        }



        this.addPaymentMethods.controls["ToBankId"].setValidators([Validators.required]);
        this.addPaymentMethods.controls["ToBankId"].updateValueAndValidity();


        this.addPaymentMethods.controls["bankaccountchartId"].setValidators([Validators.required]);
        this.addPaymentMethods.controls["bankaccountchartId"].updateValueAndValidity();


        this.IsCash = false;
        this.IsCheque = false; 
        this.IsVisa = false;
        this.IsBank = true;
        break;
      }
    }
    this.addPaymentMethods.controls["VisaBankId"].setValue(null);
    this.addPaymentMethods.controls["FromBankId"].setValue(null);
    if (this.pageSource == pageSource.receiptsMovement) {
      this.addPaymentMethods.controls["ToBankId"].setValue(null);
      this.addPaymentMethods.controls["bankaccountchartId"].setValue(null);
    }
    this.addPaymentMethods.controls["ChequeNumber"].setValue("");

    this.addPaymentMethods.controls["exchangeable"].setValue(false);
    this.addPaymentMethods.controls["Duedate"].setValue(new Date());
    this.addPaymentMethods.controls["VisaNumber"].setValue("");
    // this.addPaymentMethods.controls["SafeId"].setValue(null);
    // this.addPaymentMethods.controls["Safe"].setValue(this.safe);

    this.addPaymentMethods.markAsPristine();
    this.addPaymentMethods.markAsUntouched();
    this.firepaymentMethodsChanged()
  }

  firepaymentMethodsChanged(): void {
    debugger;
    //check weahter payment  is cash or not to send safe id
    if (this.paymentMethodCode == 1) {
      //this.paymentMethod.SafeId = this.addPaymentMethods.controls["SafeId"].value;
      this.paymentMethod.safeAccountChartId = this.addPaymentMethods.controls["accountChart"].value;
    }
    else {
      this.paymentMethod.SafeId = null;
    }
    // this.paymentMethod=this.addPaymentMethods.value;
    this.paymentMethod.Duedate = this.addPaymentMethods.controls["Duedate"].value;
    this.paymentMethod.VisaNumber = this.addPaymentMethods.controls["VisaNumber"].value;
    this.paymentMethod.exchangeable = this.addPaymentMethods.controls["exchangeable"].value;
    this.paymentMethod.ChequeNumber = this.addPaymentMethods.controls["ChequeNumber"].value;
    this.paymentMethod.ReceivingMethodId = this.addPaymentMethods.controls["ReceivingMethodId"].value;
    //this.paymentMethod.toBankAccountChartId = this.addPaymentMethods.controls["bankaccountchartId"].value;


    this.paymentMethodsChanged.emit(this.paymentMethod);
  }
  accountChartCahnged(value) {
    this.paymentMethod.safeAccountChartId = value;
    this.firepaymentMethodsChanged();
  }

  VisaBankCahnged(value) {
    this.paymentMethod.VisaBankId = value.value;
    this.firepaymentMethodsChanged();
  }



  FromBankCahnged(value) {
    this.paymentMethod.FromBankId = value.value;
    this.firepaymentMethodsChanged();
  }

  ToBankCahnged(value) {
    debugger
    if (value != "" && value != null && value != undefined) {
      this.addPaymentMethods.controls["bankaccountchartId"].setValidators(Validators.required);
      this.addPaymentMethods.controls["bankaccountchartId"].updateValueAndValidity();
      this.addPaymentMethods.controls['bankaccountchartId'].setErrors({ 'invalid': true })

    }
    else {
      this.addPaymentMethods.controls["bankaccountchartId"].setValidators(null);
      this.addPaymentMethods.controls["bankaccountchartId"].updateValueAndValidity();
    }
    this.paymentMethod.ToBankId = value;

    this.firepaymentMethodsChanged();

    this.BankAccountChart.getAccountCharts(value).subscribe(res => {
      console.log(res)
      var array = new Array<any>();
      res.forEach(function (item) {
        var record = new KendoDropDown();
        record.text = item.displyedName;
        record.value = +item.id;
        array.push(record);
      });
      this.BankAcountChartsDropDownData = array;

    }, (error) => {
      this.notification.showOperationFailed();
    }, () => {
    });

  }

  donatorChange(value) {
    debugger;
    this.paymentMethod.toBankAccountChartId = value.value;
    this.firepaymentMethodsChanged();
  }


}
