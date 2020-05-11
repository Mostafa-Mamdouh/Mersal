import { Component, OnInit, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { FinancialService } from '../../../Services/financial.service';
import { Receipt, CostCenters, Donator } from '../../../Models/receipts.model';
import { PaymentMethod } from '../../../Models/payment-methods.model';
import { PaymentMethodsEnum } from '../../../Models/payment-method.enum';
import { SourceType, pageSource } from '../../../Models/source-type.enum';
import { NotificationService } from '../../../../../SharedFeatures/SharedMain/Services/notification.service';
import { BranchLookup } from '../../../Models/branch-lookup.model';
import { SalesService } from '../../../../SalesBill/Services/sales-bill.service';
import { Delegate } from '../../../../SalesBill/Models/delegate.model';
import { KendoDropDown } from 'src/app/SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { PaymentMovment } from '../../../Models/payment-movment.model';
import { validateStyleProperty } from '@angular/animations/browser/src/render/shared';
import { CostCenter } from 'src/app/BusinessFeatures/SalesBill/Models/cost-center.model';
import { SettingService } from '../../../../Setting/Services/setting.service';
import { SystemCurrencySetting } from '../../../../Setting/Models/system-currency-setting.model';
import { EditorMode } from '../../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { UserService } from '../../../../User/Services/user.service';
import { CurrentUserService } from '../../../../User/Services/current-user.service';
import { PostingSetting } from 'src/app/BusinessFeatures/Setting/Models/posting-setting.model';
import { ExpensesTypeService } from '../../../../ExpensesType/Services/expenses-type.service';
import { Location } from '@angular/common';
import { ErrorService } from '../../../../../SharedFeatures/SharedMain/Services/error.service';
import { DocumentService } from '../../../../Document/Services/document.service';

declare var $: any;

@Component({
  selector: 'app-payments-movement',
  templateUrl: './payments-movement.component.html',
  styleUrls: ['./payments-movement.component.scss'],
  providers: [FinancialService]
})
export class PaymentMovementComponent implements OnInit {

  receipt: PaymentMovment = new PaymentMovment();
  Branches: BranchLookup[] = [];
  PaymentMethods: { id: string; name: string; }[];
  Organizations: { id: string; name: string; }[];
  editorForm: FormGroup;
  bsDatePickerValue: Date;
  ReceiptValue: any;
  payMethods: typeof PaymentMethodsEnum = PaymentMethodsEnum;
  sourceType: typeof SourceType = SourceType;
  Vendors: any[];
  AccountCharts: any[];
  CostCenters = [];
  SelectedCostCenter: number;

  totalCostCenters: number = 0;
  DelegateList: Delegate[];
  validForm: boolean = true;
  selectedSourceType = 0;
  PageLoading = true;
  IsOneCostCenterChecked = false;

  delegateMensDropDownData: Array<KendoDropDown>;
  public BranchesDropDownData: Array<KendoDropDown>;
  public CurrenciesDropDownData: Array<KendoDropDown>;
  CostCenterDropDown = new Array();
  isDetails: boolean = false;
  DetailPaymentMethod: PaymentMethod = new PaymentMethod();
  DetailsCostCenters;
  pageSource: typeof pageSource = pageSource;
  selectedCaseRequiredAmount: any;
  SelectedCases: any;
  journalPreview: any;
  journalPreviewShow: boolean;
  liquidationNumber

  constructor(
    private ReceiptsServ: FinancialService,
    public router: Router,
    private fb: FormBuilder,
    private notification: NotificationService,
    private paymentMethodssServ: FinancialService,
    private salesService: SalesService,
    private settingService: SettingService,
    private route: ActivatedRoute,
    private translateService: TranslateService,
    private userService: UserService,
    private currentUserService: CurrentUserService,
    private location: Location,
    private expensesTypeService: ExpensesTypeService,
    private errorService: ErrorService,
    private documentService: DocumentService
  ) {
  }


  ngOnInit() {
    this.selectedSourceType = 1;
    this.buildForms();
    this.getCurrentUserBranch();
    this.getDiscountPercentagesLookup();
    this.getMaxPaymentLimitForCurrentUser();
    this.getBranchLookup();
    this.getCurrencyLookup();
    this.getAccountChartsLookup();
    this.getVendorsLookup();
    this.getExpensesTypesLookup();
    this.getdonatorLookup();
    this.getAllDonationTypesLookup();
    this.getDonationTypeLookup(1);
    this.getCostCenters();
    this.getDelegateMensLookup();
    this.getSystemCurrencySetting();
    this.getPostingSetting();
    this.getDocumentLookups();
    this.bsDatePickerValue = new Date();
    this.extractRouteParams();
  }

  buildForms(): void {
    this.editorForm = this.fb.group({
      reciptNumber: [null],
      code: [null],
      Branch: [null, [Validators.required]],
      Date: [new Date(), [Validators.required]],
      DescriptionEN: [null],
      DescriptionAR: [null, [Validators.required]],
      Amount: [null, [Validators.required, Validators.max(1000000), Validators.min(10)]],
      SourceType: [1, [Validators.required]],
      CostCentersCheck: [],
      NotificationsDiscount: this.fb.array([]),
      CostCenter: [],
      VendorId: [null],

      AccountChart: [null],
      OneCostCenterCheck: [],
      OnCostCenterValue: [],
      delegateManId: [],
      delegateManReciptNumber: [],
      documentId: [null],
      Currency: [null, Validators.required],
      expensesType: [null, [Validators.required]],
      paymentDueDate: [new Date, [Validators.required]],

      donatorId: [],
      donationTypeId: [null],
      SecDonationTypeId: [null],
      ThirdDonationTypeId: [null],
    });

  }

  createNotificationDiscount(NotificationDiscount: any = undefined): FormGroup {
    return this.fb.group({
      discountpercentageId: [(NotificationDiscount) ? NotificationDiscount.discountPercentageId : null, [Validators.required]],
      DiscountAmount: [(NotificationDiscount) ? NotificationDiscount.discountAmount : null, [Validators.required, Validators.max(1000000), Validators.min(10)]],
      InvoiceAmount: [(NotificationDiscount) ? NotificationDiscount.invoiceAmount : null, [Validators.required, Validators.max(1000000), Validators.min(10)]],
      NotificationReceiptNumber: [(NotificationDiscount) ? NotificationDiscount.notificationReceiptNumber : null, [Validators.required, Validators.pattern("^[0-9]+$")]],

    });
  }

  addNotificationDiscount(NotificationDiscount: any = undefined) {
    const NotificationsDiscount = this.editorForm.get('NotificationsDiscount') as FormArray;
    NotificationsDiscount.push(this.createNotificationDiscount(NotificationDiscount));
  }


  deleteNotificationDiscount(item) {
    (this.editorForm.get('NotificationsDiscount') as FormArray).removeAt(item);
  }


  directionValidation() {
    var VendorId = this.editorForm.controls['VendorId'].value;
    var AccountChart = this.editorForm.controls['AccountChart'].value;
    var donatorId = this.editorForm.controls['donatorId'].value;

    var result: boolean = false;

    if (VendorId || AccountChart || donatorId) {
      result = true;
      if (VendorId)
        this.receipt.sourceType = VendorId;
      else if (AccountChart)
        this.receipt.sourceType = AccountChart;
      else if (donatorId)
        this.receipt.sourceType = donatorId;
    }
    else {
      this.notification.showPaymentDirectionError();
      result = false;
    }
    return result;
  }

  extractRouteParams() {
    debugger;
    let editId = +this.route.snapshot.params['editId'];
    let detailId = +this.route.snapshot.params['detailId'];
    this.liquidationNumber = this.route.snapshot.params['liquidationNumber'];
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
      this.GetPaymovmentById(this.id);
    }
    else {
      this.ReceiptsServ.generateNewReciptNumber().subscribe(res => {
        this.editorForm.controls['reciptNumber'].setValue(res);
      })
    }
  }

  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }

  getDiscountPercentagesLookup() {
    this.ReceiptsServ.getDiscountPercentagesLookup()
      .subscribe(res => {
        debugger;
        this.discountPercentages = res.collection;

      },
        (error) => {

        });
  }

  getMaxPaymentLimitForCurrentUser() {
    this.userService.getMaxPaymentLimitForCurrentUser()
      .subscribe(res => {
        this.maxPaymentLimit = res;
      },
        (error) => {

        });
  }

  getCurrentUserBranch() {
    this.userService.getCurrentUserBranch()
      .subscribe(res => {
        this.userBranch = res;
        this.setDefaultUserBranch();
      },
        (error) => {

        },
        () => {

        });
  }

  removeControlSelection(controlName: string) {
    this.editorForm.controls[controlName].setValue(null);
  }

  getAccountChartsLookup() {
    this.ReceiptsServ.getAccountChartsLookup()
      .subscribe(res => {
        this.PageLoading = false;

        this.AccountCharts = res;
      }, () => {
        this.PageLoading = false;

        this.notification.showOperationFailed();
      }, () => {
      });
  }

  getVendorsLookup() {
    this.ReceiptsServ.getVendorsLookup()
      .subscribe(res => {
        this.Vendors = res;
        this.PageLoading = false;

      }, () => {
        this.PageLoading = false;

        this.notification.showOperationFailedToLoadVendors();
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

          //this.notificationService.showOperationFailed();
        }, () => {
        });
  }

  getdonatorLookup() {
    this.ReceiptsServ.getDonatorLookup()
      .subscribe(res => {
        this.donators = res;
      }, () => {
        this.notification.showOperationFailed();
      }, () => {
      });
  }

  getAllDonationTypesLookup() {
    this.ReceiptsServ.getAllDonationTypesLookup()
      .subscribe(res => {

        //debugger;
        this.PageLoading = false;
        this.allDonationType = res.collection;
        if (res.collection != null) {
          //var array = new Array<any>();
          // res.collection.forEach(function (item) {
          //   var record = new KendoDropDown();
          //   record.text = item.name;
          //   record.value = +item.id;
          //   array.push(record);
          // });

        }
      },
        // this.Branches = res,
        (error) => {
          //debugger;
          this.PageLoading = false;
          //this.notification.showOperationFailed();
        }
      );
  }

  getDonationTypeLookup(level: number) {
    this.ReceiptsServ.getDonationTypesLookup(this.SelectedDonationTypeId)
      .subscribe(res => {

        debugger;
        this.PageLoading = false;
        if (res.collection != null) {
          var array = res.collection;
          // res.collection.forEach(function (item) {
          //   var record = new KendoDropDown();
          //   record.text = item.name;
          //   record.value = +item.id;
          //   array.push(record);
          // });
          if (level == 1) {

            this.editorForm.controls['SecDonationTypeId'].setValue(null);
            this.editorForm.controls['SecDonationTypeId'].markAsPristine();

            this.editorForm.controls['ThirdDonationTypeId'].setValue(null);
            this.editorForm.controls['ThirdDonationTypeId'].markAsPristine();
            this.SeconedLevelDonationTypeData = null;
            this.DonationTypesDropDownData = array;

          }
          else if (level == 2) {
            this.editorForm.controls['SecDonationTypeId'].setValue(null);
            this.editorForm.controls['SecDonationTypeId'].markAsPristine();
            this.ThirdLevelDonationTypeData = null;
            this.editorForm.controls['SecDonationTypeId'].setValue(null);
            this.editorForm.controls['SecDonationTypeId'].clearValidators();
            this.editorForm.controls['SecDonationTypeId'].updateValueAndValidity();
            this.SeconedLevelDonationTypeData = array;
            if (array.length != 0) {
              this.editorForm.controls['SecDonationTypeId'].setValidators([Validators.required]);
              this.editorForm.controls['SecDonationTypeId'].updateValueAndValidity();
            }
            else {
              this.editorForm.controls['SecDonationTypeId'].clearValidators();
              this.editorForm.controls['SecDonationTypeId'].updateValueAndValidity();
            }

          }
          else if (level == 3) {
            this.editorForm.controls['ThirdDonationTypeId'].setValue(null);
            this.editorForm.controls['ThirdDonationTypeId'].markAsPristine();
            this.ThirdLevelDonationTypeData = null;
            this.editorForm.controls['ThirdDonationTypeId'].setValue(null);
            this.editorForm.controls['ThirdDonationTypeId'].clearValidators();
            this.editorForm.controls['ThirdDonationTypeId'].updateValueAndValidity();
            this.ThirdLevelDonationTypeData = array;
            if (array.length != 0) {
              this.editorForm.controls['ThirdDonationTypeId'].setValidators([Validators.required]);
              this.editorForm.controls['ThirdDonationTypeId'].updateValueAndValidity();
            }
            else {
              this.editorForm.controls['ThirdDonationTypeId'].clearValidators();
              this.editorForm.controls['ThirdDonationTypeId'].updateValueAndValidity();
            }
          }
          console.log("DonationTypesDropDownData" + JSON.stringify(res.collection));
          //this.bindModelToForm();
        }
      },
        // this.Branches = res,
        (error) => {
          // debugger;
          this.PageLoading = false;
          this.notification.showOperationFailed();
        }
      );
  }

  onOneCostCenterChanged(id) {
    let totalAmount = this.editorForm.controls['Amount'].value;
    if (totalAmount == null || totalAmount == 0) {
      this.editorForm.controls['OnCostCenterValue'].setValue(null);
      this.SelectedCostCenter = null;
      this.notification.showTranslateError('movements.TotalAmount');
    }
    else {
      this.receipt.CostCenters = new Array();
      this.receipt.CostCenters.push({ id: id.value, costCenterId: id.value, amount: totalAmount, assignValue: totalAmount })
      console.log("one cost center to Api " + JSON.stringify(this.receipt.CostCenters))
    }

  }

  getDelegateMensLookup() {
    this.paymentMethodssServ.getDelegateMensLookup()
      .subscribe(res => {
        //debugger;  
        var array = new Array<any>();
        res.collection.forEach(function (item) {
          var record = new KendoDropDown();
          record.text = item.code + " - " + item.name;
          record.value = +item.id;
          array.push(record);
        });
        this.delegateMensDropDownData = array;
      }, () => {
        this.notification.showOperationFailed();
        // debugger;
      }, () => {
        // debugger;
      });
  }

  getBranchLookup() {
    this.ReceiptsServ.getBranchLookup()
      .subscribe(
        res => {
          this.PageLoading = false;
          var array = new Array<any>();
          res.forEach(function (item) {
            var record = new KendoDropDown();
            record.text = item.code + " - " + item.name;
            record.value = item.id;
            array.push(record);
          });
          this.BranchesDropDownData = array;

          this.setDefaultUserBranch();
        },
        // this.Branches = res,
        error => {
          this.PageLoading = false;
          error;
          this.notification.showOperationFailed();
        }

      );
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

  setDefaultUserBranch() {
    if (this.editorMode == this.editorModeEnum.add) {
      debugger;
      if (this.userBranch && this.BranchesDropDownData) {
        let kendoItem = this.BranchesDropDownData.find(x => x.value == this.userBranch.id);
        this.editorForm.controls['Branch'].setValue(kendoItem.value);
      }

      // let user = this.currentUserService.getCurrentUser();
      // if (user) {
      //   let kendoItem = this.BranchesDropDownData.find(x => x.value == user.branchId);
      //   this.editorForm.controls['Branch'].setValue(kendoItem.value);
      // }
    }
  }

  getSystemCurrencySetting() {
    this.settingService.getSystemCurrencySetting()
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

  setDefaultCurrency() {
    debugger;
    if (this.CurrenciesDropDownData && this.CurrenciesDropDownData.length > 0 &&
      this.systemCurrencySetting && this.systemCurrencySetting.currencyId) {

      let val = this.CurrenciesDropDownData.find(x => x.value == this.systemCurrencySetting.currencyId);
      if (val && !this.isDetails) {
        this.editorForm.controls["Currency"].setValue(val);
      }
    }
  }

  OneCostCenterCHekedToggle(val) {
    this.IsOneCostCenterChecked = val.checked;
    this.editorForm.controls['CostCentersCheck'].setValue(false);
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
        },
        // this.Branches = res,
        error => {
          this.PageLoading = false;

          error;
          this.notification.showOperationFailed();
        }

      );
  }

  addCostCenters(costCentersList) {
    debugger;
    this.totalCostCenters = 0;
    costCentersList.forEach(item => {
      this.totalCostCenters = this.totalCostCenters + item.assignValue;
    });
    if (this.totalCostCenters != this.editorForm.controls['Amount'].value) {
      this.notification.showTranslateError('financial.costCenterTotalValue');
    }
    else {
      this.CostCenters = costCentersList;
      this.receipt.CostCenters = costCentersList;
      this.notification.showTranslateSuccess('costCenter.SucessCostCentersAdd');
    }

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
      },
        // this.Branches = res,
        error => {
          this.PageLoading = false;

          error;
          this.notification.showOperationFailed();
        }

      );
  }


  addNewdonator(donator) {
    this.Newdonator = donator;
    this.receipt.donator = donator;
    this.isNewdonator = true;
    this.editorForm.controls['donatorId'].setValue(null);
    this.editorForm.controls['donatorId'].clearValidators();
    this.editorForm.controls['donatorId'].updateValueAndValidity();
    this.notification.showOperationSuccessed();

    console.log("donator insider obj " + this.receipt.donator);
    console.log("donator insider obj " + this.Newdonator);

  }

  //End Cost Center Logic
  cancelNewdonator() {
    this.isNewdonator = false;
    this.Newdonator = null;
    this.receipt.donator = null;
  }

  adddonator() {
    this.isNewdonator = true;
  }

  donatorChange() {
    this.receipt.donator = null;
    this.Newdonator = null;
  }




  onCaseChanged(val) {
    this.selectedCaseRequiredAmount = val.requiredAmount;
    let totalAmount = this.editorForm.controls['Amount'].value;
    if (totalAmount == null || totalAmount == 0) {
      this.notification.showTranslateError('movements.TotalAmount');
    }
    else {
      this.receipt.cases = new Array();
      var newcase = { CaseId: val.id, Amount: totalAmount, Name: val.name };
    }
    if (totalAmount > this.selectedCaseRequiredAmount) {
      newcase.Amount = this.selectedCaseRequiredAmount;
    }
    this.receipt.cases.push(newcase);
    console.log("one cost center to Api " + JSON.stringify(this.receipt.costCenters));
  }

  getSelectedCases(selectedCases) {
    debugger;
    this.totalSelectedCases = 0;
    this.SelectedCases = selectedCases;

    this.SelectedCases.forEach((item) => {
      this.totalSelectedCases = this.totalSelectedCases + item.Amount;
    });
    if (this.totalSelectedCases > this.editorForm.controls['Amount'].value) {
      this.showCaseAmountOverflowError();
    }
    else {
      this.receipt.cases = selectedCases;
      console.log("cases to api " + JSON.stringify(this.receipt.cases));
      // this.notification.showOperationSuccessed();
    }
  }

  showCaseAmountOverflowError() {
    let key = 'financial.casesTotalValue';
    this.translateService.get([key]).subscribe(res => {
      this.notification.showErrorHtml(`<h5>${res[key]}</h5>`);
    });
  }

  donationTypeCahnged(level, value) {
    debugger;
    this.receipt.donationTypeId = value.id;
    this.SelectedDonationTypeId = value.id;
    this.getDonationTypeLookup(level + 1);
  }

  checkAccountAndCurrencyAreMatches(): boolean {
    let selectedAccountChartId: any = this.editorForm.controls['AccountChart'].value;
    let selectedCurrencyId: any = this.editorForm.controls['Currency'].value.value;
    let accountChartItem: any = this.AccountCharts.find(x => x.id == selectedAccountChartId);

    if (!this.postingSetting.allowPostingAccountCurrencyMisMatch &&
      accountChartItem &&
      accountChartItem.currencyId != selectedCurrencyId) {

      let wrongAccountKey = 'error.accountCurrencyNotMatchSelectedCurrencyg';
      this.translateService.get([wrongAccountKey])
        .subscribe(res => {
          this.notification.showErrorHtml(`<h5>${res[wrongAccountKey]}</h5>`);
        });
      return false;
    }
    else {
      return true;
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
          this.receipt.CostCenters = new Array();
        }
      }
    });
  }

  onPaymentMethodsChanged(evnt: PaymentMethod) {
    debugger;
    this.receipt.ReceivingMethodId = evnt.ReceivingMethodId;
    this.receipt.FromBankId = evnt.FromBankId;
    this.receipt.ToBankId = evnt.ToBankId;
    this.receipt.toBankAccountChartId = evnt.toBankAccountChartId;
    //this.receipt.SafeId = evnt.SafeId;
    this.receipt.ChequeNumber = evnt.ChequeNumber;
    this.receipt.Duedate = evnt.Duedate;
    this.receipt.VisaNumber = evnt.VisaNumber;
    this.receipt.VisaBankId = evnt.VisaBankId;
    this.receipt.exchangeable = evnt.exchangeable;
    this.receipt.safeAccountChartId = evnt.safeAccountChartId;
  }

  cancel() {
    this.buildForms()
  }

  gotoList() {
    let url = [`/financial/payment-list`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  journalValueChange(event) {
    this.receipt.journal = event;
  }

  journalApprove(event) {
    debugger;
    //this.collectModelFromForm();
    this.receipt.journal = event;
    this.ReceiptsServ.addPaymentMovments(this.receipt)
      .subscribe(res => {
        debugger;
        this.PageLoading = false;
        $('#openPostlBTN').click();
        this.notification.showSuccessAlertForSavedDocument(this.receipt.code);
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
    this.notification.showSuccessAlertForSavedDocument(this.receipt.code);
    this.notification.showJournalcanceled();
    this.gotoList();
  }

  GetPaymovmentById(id: number) {
    this.PageLoading = true;
    this.paymentMethodssServ.PaymentMovmentDetails(id)
      .subscribe(
        response => {
          debugger;
          let res = response;

          console.log("response is now ready " + JSON.stringify(res))
          this.PageLoading = false;
          this.editorForm.controls["code"].setValue(res.code);
          this.editorForm.controls["reciptNumber"].setValue(res.reciptNumber);
          this.editorForm.controls["Amount"].setValue(res.amount);
          this.editorForm.controls["Date"].setValue(res.date);
          this.editorForm.controls["SourceType"].setValue(res.sourceType);
          this.editorForm.controls["DescriptionEN"].setValue(res.descriptionEN);
          this.editorForm.controls["DescriptionAR"].setValue(res.descriptionAR);
          if (this.BranchesDropDownData.length != 0) {
            this.editorForm.controls["Branch"].setValue(res.branchId);
          }
          this.editorForm.controls["VendorId"].setValue(res.vendorId);
          this.editorForm.controls["AccountChart"].setValue(res.accountChartId);
          this.editorForm.controls["delegateManId"].setValue(res.delegateManId);
          this.editorForm.controls["delegateManReciptNumber"].setValue(res.delegateManReciptNumber);
          this.editorForm.controls["documentId"].setValue(res.documentId);
          this.editorForm.controls["expensesType"].setValue(res.expensesTypeId);
          this.editorForm.controls['paymentDueDate'].setValue(res.paymentDueDate);
          console.log(this.delegateMensDropDownData);
          this.editorForm.controls["donatorId"].setValue(res.donatorId);



          let donationType = this.allDonationType.find(x =>
            x.id == res.donationTypeId);
          debugger;
          if (donationType && donationType.parentId) {
            for (let index = 0; index < res.donatoinTypesLevel.length; index++) {
              switch (index) {
                case 0:
                  {
                    if (res.donatoinTypesLevel.length == 3) {
                      //this.getDonationTypeLookup(3);
                      //this.editorForm.controls['ThirdDonationTypeId'].setValue(this.receipt.donatoinTypesLevel[0]);
                      let thirdLevelDonationType = this.allDonationType.find(x => x.id == res.donatoinTypesLevel[0]);
                      this.ThirdLevelDonationTypeData = [{ thirdLevelDonationType }];
                      this.editorForm.controls['ThirdDonationTypeId'].setValue(thirdLevelDonationType);
                    }
                    else if (res.donatoinTypesLevel.length == 2) {
                      let SeconedLevelDonationType = this.allDonationType.find(x => x.id == res.donatoinTypesLevel[0]);
                      this.SeconedLevelDonationTypeData = [{ SeconedLevelDonationType }];
                      this.editorForm.controls['SecDonationTypeId'].setValue(SeconedLevelDonationType);
                    }
                  }
                  break;

                case 1:
                  {
                    if (res.donatoinTypesLevel.length == 3) {
                      let SeconedLevelDonationType = this.allDonationType.find(x => x.id == res.donatoinTypesLevel[1]);
                      this.SeconedLevelDonationTypeData = [{ SeconedLevelDonationType }];
                      this.editorForm.controls['SecDonationTypeId'].setValue(SeconedLevelDonationType);
                    }
                    else if (res.donatoinTypesLevel.length == 2) {
                      let firstLevelDonationType = this.DonationTypesDropDownData.find(x => x.id == res.donatoinTypesLevel[1]);
                      this.editorForm.controls['donationTypeId'].setValue(firstLevelDonationType);
                    }
                  }
                  break;
                case 2:
                  {
                    let firstLevelDonationType = this.DonationTypesDropDownData.find(x => x.id == res.donatoinTypesLevel[2]);
                    this.editorForm.controls['donationTypeId'].setValue(firstLevelDonationType);
                  }
                  break;
                default:
                  break;
              }


            }
          }
          this.donationDetails = res.cases;

          // this.editorForm.controls['discountpercentageId'].setValue(res.discountPercentageId);
          // this.editorForm.controls['DiscountAmount'].setValue(res.discountAmount);
          // this.editorForm.controls['InvoiceAmount'].setValue(res.invoiceAmount);
          // this.editorForm.controls['NotificationReceiptNumber'].setValue(res.notificationReceiptNumber);

          let val = this.CurrenciesDropDownData.find(x => x.value == res.currencyId);
          this.editorForm.controls["Currency"].setValue(val);

          //set payment method values
          //this.DetailPaymentMethod.SafeId = res.safeId;
          this.DetailPaymentMethod.safeAccountChartId = res.safeAccountChartId;
          this.DetailPaymentMethod.VisaNumber = res.visaNumber;
          this.DetailPaymentMethod.Duedate = res.duedate;
          this.DetailPaymentMethod.exchangeable = res.exchangeable;
          this.DetailPaymentMethod.ChequeNumber = res.chequeNumber;
          this.DetailPaymentMethod.ToBankId = res.toBankId;
          this.DetailPaymentMethod.FromBankId = res.fromBankId;
          this.DetailPaymentMethod.VisaBankId = res.visaBankId;
          this.DetailPaymentMethod.ReceivingMethodId = res.receivingMethodId;
          this.DetailPaymentMethod.toBankAccountChartId = res.toBankAccountChartId;

          this.DetailPaymentMethod.ischanged = true;


          this.receipt = res;

          if (this.receipt.costCenters) {
            this.receipt.costCenters.forEach(item => {
              item.id = item.costCenterId;
              item.assignValue = item.amount;
            });



            for (var index = 0; index < res.notificationsDiscount.length; index++) {
            console.log(res.notificationsDiscount[index])  
              this.addNotificationDiscount(res.notificationsDiscount[index]);

            }

            if (this.receipt.costCenters.length == 1) {
              this.IsOneCostCenterChecked = true;
              this.editorForm.controls['OneCostCenterCheck'].setValue(true);

              if (this.CostCenterDropDown && this.CostCenterDropDown.length > 0) {
                let costCenterVal = this.CostCenterDropDown.find(x => x.value == this.receipt.costCenters[0].costCenterId);
                if (costCenterVal) {
                  this.editorForm.controls['OnCostCenterValue'].setValue(costCenterVal.value);
                }
              }
            }
            else if (this.receipt.costCenters.length > 1) {
              this.editorForm.controls['CostCentersCheck'].setValue(true);
              this.DetailsCostCenters = this.receipt.costCenters;
              this.CostCenters = this.receipt.costCenters;
            }
          }
          this.liquidationNumber = this.receipt.liquidationNumber;
        },
        (error) => {
          this.PageLoading = false;
        }
      )
      ;
  }

  // checkInvoveAmount() {
  //   var DiscountAmount = this.editorForm.controls['DiscountAmount'].value;
  //   var InvoiceAmount = this.editorForm.controls['InvoiceAmount'].value;
  //   var amount = this.editorForm.controls['Amount'].value;
  //   if (InvoiceAmount > 0) {
  //     if (InvoiceAmount != (amount + DiscountAmount))
  //     {
  //       this.notification.showPaymentError();
  //       return false;
  //     }
  //     else
  //       return true;


  //   }
  // }

  AddBills() {
    debugger;

    if (this.liquidationNumber) {

      if (this.totalCostCenters > this.editorForm.controls['Amount'].value) {
        this.notification.showTranslateError('financial.costCenterTotalValue');
        return;
      }
      if (!this.directionValidation()) {
        return;
      }

      if (this.totalSelectedCases > this.editorForm.controls['Amount'].value) {
        this.showCaseAmountOverflowError();
        //this.notification.showTranslateError('financial.casesTotalValue');
        return;
      }

      if (this.totalSelectedCases) {
        if (this.totalSelectedCases == 0 && this.SelectedCases.length > 0) {
          this.notification.showTranslateError('financial.casesAssignValue');
          return;
        }
      }

      debugger;
      if (this.receipt.CostCenters != null &&
        this.receipt.CostCenters.length > 0) {
        let total: number = 0;
        this.receipt.CostCenters.forEach(item => {
          item.amount = item.assignValue;
          item.costCenterId = item.id;
          total += item.assignValue;
        });

        if (total > this.editorForm.controls['Amount'].value) {
          this.notification.showTranslateError('financial.costCenterNotificationError');
          return;
        }
      }

      this.receipt.reciptNumber = this.editorForm.controls['reciptNumber'].value;
      this.receipt.Amount = this.editorForm.controls['Amount'].value;
      this.receipt.Date = this.editorForm.controls['Date'].value;
      this.receipt.DescriptionEN = this.editorForm.controls['DescriptionEN'].value;
      this.receipt.DescriptionAR = this.editorForm.controls['DescriptionAR'].value;
      this.receipt.VendorId = this.editorForm.controls['VendorId'].value;
      this.receipt.sourceType = this.editorForm.controls['SourceType'].value;
      this.receipt.AccountChartId = this.editorForm.controls['AccountChart'].value;
      this.receipt.BranchId = this.editorForm.controls['Branch'].value;
      this.receipt.DelegateManId = this.editorForm.controls['delegateManId'].value;
      this.receipt.CurrencyId = this.editorForm.controls['Currency'].value.value;
      this.receipt.DelegateManReciptNumber = this.editorForm.controls['delegateManReciptNumber'].value;
      this.receipt.documentId = this.editorForm.controls['documentId'].value;
      this.receipt.liquidationNumber = this.liquidationNumber;
      this.receipt.notificationsDiscount = this.editorForm.controls['NotificationsDiscount'].value

      let paymentsMovements = JSON.parse(localStorage.getItem("paymentsMovements")) as any[];
      if (paymentsMovements == null)
        paymentsMovements = [];
      paymentsMovements.push(this.receipt);

      localStorage.setItem("paymentsMovements", JSON.stringify(paymentsMovements));
      let url = [`/financial/testament/liquidation`];
      this.router.navigate(url);
    } else {
      if (this.editorForm.valid) {
        this.validForm = true;

        if (this.checkAccountAndCurrencyAreMatches() == false) return;
        // if (this.checkInvoveAmount() == false) return;

        //if (this.checkDate() == false) return;
        this.receipt.expensesTypeId = this.editorForm.controls['expensesType'].value;
        this.receipt.paymentDueDate = this.editorForm.controls['paymentDueDate'].value;
        this.receipt.donatorId = this.editorForm.controls['donatorId'].value;
        this.receipt.notificationsDiscount = this.editorForm.controls['NotificationsDiscount'].value

        let amount: any = this.editorForm.controls['Amount'].value;
        if (this.maxPaymentLimit != null && amount > this.maxPaymentLimit) {
          let maxPaymentLimitKey = `user.shared.maxPaymentLimitAlert`;
          this.translateService.get([maxPaymentLimitKey])
            .subscribe(res => {
              this.notification.showErrorHtml(`<h5>${res[maxPaymentLimitKey]} ${this.maxPaymentLimit}</h5>`)
            });
          return;
        }


        if (this.editorMode == this.editorModeEnum.edit) {

          this.receipt.DescriptionEN = this.editorForm.controls['DescriptionEN'].value;
          this.receipt.DescriptionAR = this.editorForm.controls['DescriptionAR'].value;

          this.ReceiptsServ.updatePaymentMovments(this.receipt)
            .subscribe((res) => {
              this.notification.showSuccessAlertForSavedDocument(res.id);
              this.gotoList();
              //debugger;   
            },
              (error) => {
                this.errorService.handerErrors(error);
                // debugger;
              }, () => {
                // debugger;
              });

          return;
        }
      }

    if (this.isDetails == true) {
      this.validForm = false;
      return;
    }
    //debugger
    if (this.receipt.safeAccountChartId == null) {
      if (this.receipt.ChequeNumber == null ||
        this.receipt.FromBankId == null || this.receipt.Duedate == null) {
        if (this.receipt.VisaNumber == null || this.receipt.VisaBankId == null) {
          if(this.receipt.ToBankId == null || this.receipt.toBankAccountChartId == null){
          this.notification.showTranslateError('financial.paymentNotificationError');
          this.validForm = false;
          }
        }
      }
    }
    if (this.totalCostCenters > this.editorForm.controls['Amount'].value) {
      this.notification.showTranslateError('financial.costCenterTotalValue');
      this.validForm = false;
    }
    if (!this.directionValidation()) {
      this.validForm = false;
    }

      if (this.totalSelectedCases > this.editorForm.controls['Amount'].value) {
        this.showCaseAmountOverflowError();
        //this.notification.showTranslateError('financial.casesTotalValue');
        this.validForm = false;
      }

      if (this.totalSelectedCases) {
        if (this.totalSelectedCases == 0 && this.SelectedCases.length > 0) {
          this.notification.showTranslateError('financial.casesAssignValue');
          this.validForm = false;
        }
      }

      debugger;
      if (this.receipt.CostCenters != null &&
        this.receipt.CostCenters.length > 0) {
        let total: number = 0;
        this.receipt.CostCenters.forEach(item => {
          item.amount = item.assignValue;
          item.costCenterId = item.id;
          total += item.assignValue;
        });

        if (total > this.editorForm.controls['Amount'].value) {
          this.notification.showTranslateError('financial.costCenterNotificationError');
          return;
        }
      }

      debugger

      // // Validate Vendor
      // if (this.editorForm.controls['SourceType'].value == this.sourceType.vendor) {

      //   if (this.editorForm.controls['VendorId'].value === null || this.editorForm.controls['VendorId'].value === undefined) {
      //     this.editorForm.controls['VendorId'].setErrors({ 'invalid': true });
      //     this.notification.showTranslateError('financial.vendorNotificationError');
      //     this.validForm = false;
      //   }

      //   if (this.editorForm.controls['discountpercentageId'].value === null || this.editorForm.controls['discountpercentageId'].value === undefined) {
      //     this.editorForm.controls['discountpercentageId'].setErrors({ 'invalid': true });
      //     //this.notification.showTranslateError('financial.vendorNotificationError');
      //     this.validForm = false;
      //   }

      //   if (this.editorForm.controls['DiscountAmount'].value === null || this.editorForm.controls['DiscountAmount'].value === undefined) {
      //     this.editorForm.controls['DiscountAmount'].setErrors({ 'invalid': true });
      //     //this.notification.showTranslateError('financial.vendorNotificationError');
      //     this.validForm = false;
      //   }

      //   if (this.editorForm.controls['InvoiceAmount'].value === null || this.editorForm.controls['InvoiceAmount'].value === undefined) {
      //     this.editorForm.controls['InvoiceAmount'].setErrors({ 'invalid': true });
      //     //this.notification.showTranslateError('financial.vendorNotificationError');
      //     this.validForm = false;
      //   }

      //   if (this.editorForm.controls['NotificationReceiptNumber'].value === null || this.editorForm.controls['NotificationReceiptNumber'].value === undefined) {
      //     this.editorForm.controls['NotificationReceiptNumber'].setErrors({ 'invalid': true });
      //     this.notification.showTranslateError('financial.vendorNotificationError');
      //     this.validForm = false;
      //   }
      // }

      // // Validate AccountChart
      // if (this.editorForm.controls['SourceType'].value == this.sourceType.AccountChart) {
      //   if (this.editorForm.controls['AccountChart'].value === null ||
      //     this.editorForm.controls['AccountChart'].value === undefined) {
      //     console.log('Error in AccountChart !!');
      //     this.editorForm.controls['AccountChart'].setErrors({ 'invalid': true });
      //     this.notification.showTranslateError('financial.accountChartNotificationError');
      //     this.validForm = false;
      //   }
      // }


      // Validate ToBankAccountChartID

      if (this.receipt.ToBankId !== null && this.receipt.ToBankId != undefined &&
        (this.receipt.toBankAccountChartId === undefined || this.receipt.toBankAccountChartId === null)) {
        console.log('Error in AccountChart !!');
        this.notification.showTranslateError('financial.accountChartNotificationError');
        this.validForm = false;
      }



      // Validate donators
      if (this.editorForm.controls['SourceType'].value == this.sourceType.Donator) {
        if ((this.editorForm.controls['donatorId'].value === null || this.editorForm.controls['donatorId'].value === undefined) && !this.isNewdonator) {
          console.log('Error in donator ID !!');
          this.editorForm.controls['donatorId'].setErrors({ 'invalid': true });
          this.notification.showTranslateError('financial.donatorNotificationError');
          this.validForm = false;
        } else if (this.isNewdonator && (this.Newdonator === null || this.Newdonator === undefined)) {
          console.log('Error in donator ID !!');
          this.editorForm.controls['donatorId'].setErrors({ 'invalid': true });
          this.notification.showTranslateError('financial.donatorNotificationError');
          this.validForm = false;
        }
        else {
          this.receipt.donatorId = this.editorForm.controls['donatorId'].value;
        }
      }

      if (this.validForm) {
        if (this.editorForm.valid) {
          this.receipt.reciptNumber = this.editorForm.controls['reciptNumber'].value;
          this.receipt.Amount = this.editorForm.controls['Amount'].value;
          this.receipt.Date = this.editorForm.controls['Date'].value;
          this.receipt.DescriptionEN = this.editorForm.controls['DescriptionEN'].value;
          this.receipt.DescriptionAR = this.editorForm.controls['DescriptionAR'].value;
          this.receipt.VendorId = this.editorForm.controls['VendorId'].value;
          this.receipt.sourceType = this.editorForm.controls['SourceType'].value;
          this.receipt.AccountChartId = this.editorForm.controls['AccountChart'].value;
          this.receipt.BranchId = this.editorForm.controls['Branch'].value;
          this.receipt.DelegateManId = this.editorForm.controls['delegateManId'].value;
          this.receipt.CurrencyId = this.editorForm.controls['Currency'].value.value;
          this.receipt.DelegateManReciptNumber = this.editorForm.controls['delegateManReciptNumber'].value;
          this.receipt.documentId = this.editorForm.controls['documentId'].value;

          debugger;

          if (this.editorMode == this.editorModeEnum.add) {
            this.ReceiptsServ.addPaymentMovments(this.receipt)
              .subscribe((res) => {
                this.receipt = res;
                this.journalPreview = res.journal;
                this.journalPreviewShow = true;
                $('#openPostlBTN').click();
                this.PageLoading = false;
                //this.notification.showSuccessAlertForSavedDocument(res.code);
                //this.gotoList();
                //debugger;   
              }, (error) => {
                this.errorService.handerErrors(error);
                // debugger;
              }, () => {
                this.PageLoading = false;
                // debugger;
              });

            // this.buildForms();
            // this.receipt = new PaymentMovment();
          }
        }
        else {
          const editorFormFormKeys = Object.keys(this.editorForm.controls);
          editorFormFormKeys.forEach((control) => {
            console.log(control);
            this.editorForm.controls[control].markAsTouched();
          });
          this.editorForm.setErrors({ 'invalid': true, 'valid': false });
          //this.notification.showTranslateError('financial.formNotificationError');
          this.notification.showDataMissingError();
        }
      }
      else {
        this.validForm = false;
        this.notification.showDataMissingError();
      }
    }
  }

  isDiscountApproved: boolean = false;
  editorMode: EditorMode = EditorMode.add;
  editorModeEnum = EditorMode;
  private id: any;
  maxPaymentLimit: number = null;
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
  systemCurrencySetting: SystemCurrencySetting = new SystemCurrencySetting();
  postingSetting: PostingSetting = new PostingSetting();
  userBranch: any;
  expensesTypes: any;
  donators: any[];
  SelectedDonationTypeId: any;
  SeconedLevelDonationTypeData: any;
  DonationTypesDropDownData: any[];
  ThirdLevelDonationTypeData: any;

  isNewdonator: boolean = false;
  Newdonator: Donator;
  totalSelectedCases: number = 0;
  allDonationType: any[];
  donationDetails: any[];
  discountPercentages: any[];
  documents: any[];
}
