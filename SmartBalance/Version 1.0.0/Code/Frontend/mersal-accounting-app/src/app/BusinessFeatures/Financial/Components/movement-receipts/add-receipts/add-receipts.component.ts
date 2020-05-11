import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FinancialService } from '../../../Services/financial.service';
import { Receipt, CostCenters, Donator, Cases } from '../../../Models/receipts.model';
import { PaymentMethod } from '../../../Models/payment-methods.model';
import { PaymentMethodsEnum } from '../../../Models/payment-method.enum';
import { SourceType, pageSource } from '../../../Models/source-type.enum';
import { NotificationService } from '../../../../../SharedFeatures/SharedMain/Services/notification.service';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { KendoDropDown } from '../../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { FinancialSetting } from '../../../../Setting/Models/financial-setting.model';
import { SystemCurrencySetting } from '../../../../Setting/Models/system-currency-setting.model';
import { SettingService } from '../../../../Setting/Services/setting.service';
import { EditorMode } from '../../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { ActivatedRoute } from '@angular/router';
import { CurrentUserService } from '../../../../User/Services/current-user.service';
import { PostingSetting } from '../../../../Setting/Models/posting-setting.model';
import { UserService } from '../../../../User/Services/user.service';
import { Location } from '@angular/common';
import { DocumentService } from '../../../../Document/Services/document.service';
import { ErrorService } from '../../../../../SharedFeatures/SharedMain/Services/error.service';
import { PostingStatus } from '../../../../JournalPosting/Models/posting-status.enum';
import { SafeService } from '../../../../Safe/Services/safe.service';
//import * as $ from 'jquery';
declare var $: any;

@Component({
  selector: 'app-add-receipts',
  templateUrl: './add-receipts.component.html',
  styleUrls: ['./add-receipts.component.scss'],
  providers: [FinancialService]
})
export class AddReceiptsComponent implements OnInit {

  constructor(
    private ReceiptsServ: FinancialService,
    private paymentMethodssServ: FinancialService,
    public router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private translateService: TranslateService,
    private notification: NotificationService,
    private settingService: SettingService,
    private currentUserService: CurrentUserService,
    private userService: UserService,
    private documentService: DocumentService,
    private location: Location,
    private errorService: ErrorService,
    private safeService: SafeService
  ) {

  }

  ngOnInit() {
    debugger
    this.selectedSourceType = 1;
    this.getFinancialSetting();
    this.getPostingSetting();
    this.buildForms();
    this.getCurrentUserBranch();
    this.getVendorsLookup();
    this.getAccountChartsLookup();
    this.getdonatorLookup();
    this.getBranchLookup();
    this.getCurrencyLookup();
    this.getAllDonationTypesLookup();
    this.getDonationTypeLookup(1);
    this.getCostCenters();
    this.bsDatePickerValue = new Date();
    //this.generateCode();
    this.getCasesLookup();
    this.getDelegateMensLookup();
    this.getSystemCurrencySetting();
    this.getDocumentLookups();
    this.extractRouteParams();
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
      this.ReceiptsServ.getReceiptById(this.id)
        .subscribe(res => {
          console.log("response is now ready " + JSON.stringify(res))
          this.PageLoading = false;
          this.editorForm.controls["code"].setValue(res.code);
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



           debugger;
          this.receipt = res;
          
          if (this.receipt.costCenters) {
            this.receipt.costCenters.forEach(item => {
              item.id = item.costCenterId;
              item.assignValue = item.amount;
            });

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
         // this.bindModelToForm();
        },
          (error) => {
            this.notification.showOperationFailed();
          })
    }
  }

  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }

  buildForms(): void {
    this.editorForm = this.fb.group({
      code: [null],
      reciptDate: [new Date(), [Validators.required]],
      Branch: [null, [Validators.required]],
      Date: [new Date(), [Validators.required]],
      DescriptionEN: [null],
      DescriptionAR: [null, [Validators.required]],
      Amount: [null, [Validators.required, Validators.min(10), Validators.max(1000000)]],
      SourceType: [1, [Validators.required]],
      CostCentersCheck: [],
      donatorId: [],
      donationTypeId: [null],
      SecDonationTypeId: [null],
      ThirdDonationTypeId: [null],
      VendorId: [],
      AccountChart: [],
      AssociatedProducts: [],
      AssociatedBeneficiariesCases: [],
      movementCode: [{ disabled: true }],
      Currency: [null, Validators.required],
      OneCostCenterCheck: [],
      OnCostCenterValue: [],
      OnCaseValue: [],
      delegateManId: [null],
      delegateManReciptNumber: [null],
      documentId: [null]
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

  getFinancialSetting(): void {
    this.settingService.getFinancialSetting()
      .subscribe(res => {
        this.financialSetting = res;
      },
        (error) => {
          console.error(`Failed to get financialSetting, error: ${JSON.stringify(error)}`);
        },
        () => {

        });
  }

  checkFormStaus() {
    console.log(this.editorForm.controls);
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

          // if (this.editorMode == this.editorModeEnum.add) {
          //   debugger;
          //   let user = this.currentUserService.getCurrentUser();
          //   if (user) {
          //     let kendoItem = this.BranchesDropDownData.find(x => x.value == user.branchId);
          //     this.editorForm.controls['Branch'].setValue(kendoItem.value);
          //   }
          // }
        },
        // this.Branches = res,
        error => {
          this.PageLoading = false;
          error;
          this.notification.showOperationFailed();
        }

      );
  }

  removeControlSelection(controlName: string) {
    this.editorForm.controls[controlName].setValue(null);
  }

  setDefaultUserBranch() {
    if (this.editorMode == this.editorModeEnum.add) {
      // debugger;
      if (this.userBranch && this.BranchesDropDownData) {
        let kendoItem = this.BranchesDropDownData.find(x => x.value == this.userBranch.id);
        this.editorForm.controls['Branch'].setValue(kendoItem.value);
      }

      //   let user = this.currentUserService.getCurrentUser();
      //   if (user) {
      //     let kendoItem = this.BranchesDropDownData.find(x => x.value == user.branchId);
      //     this.editorForm.controls['Branch'].setValue(kendoItem.value);
      //   }

    }
  }

  handleBranchesFilter(value) {
    this.BranchesDropDownData = this.BranchesDropDownData.filter((s) => s.text.toLowerCase().indexOf(value.toLowerCase()) !== -1);
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

  getSystemCurrencySetting() {
    this.settingService.getSystemCurrencySetting()
      .subscribe(res => {
        //debugger;
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
    //debugger;
    if (this.editorMode == this.editorModeEnum.add &&
      this.CurrenciesDropDownData && this.CurrenciesDropDownData.length > 0 &&
      this.systemCurrencySetting && this.systemCurrencySetting.currencyId) {

      let val = this.CurrenciesDropDownData.find(x => x.value == this.systemCurrencySetting.currencyId);
      if (val && !this.editorForm.controls["Currency"].value) {
        this.editorForm.controls["Currency"].setValue(val);
      }
    }
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
          console.log(res.collection);

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

  //1= first level , 2= seconed level ,3= third level
  getDonationTypeLookup(level: number) {
    this.ReceiptsServ.getDonationTypesLookup(this.SelectedDonationTypeId)
      .subscribe(res => {

         debugger;
        this.PageLoading = false;
        if (res.collection != null) {
          var array = res.collection; //new Array<any>();
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

  delegateManCahnged(value) {
    debugger;
    if (value || this.editorForm.controls["delegateManReciptNumber"].value || this.editorForm.controls["documentId"].value) {
      this.receipt.delegateManId = value.value;
      this.delegateManSelected = true;
      this.editorForm.controls["delegateManReciptNumber"].setValidators([Validators.required]);
      this.editorForm.controls["delegateManReciptNumber"].updateValueAndValidity();
      this.editorForm.controls["documentId"].setValidators([Validators.required]);
      this.editorForm.controls["documentId"].updateValueAndValidity();
      this.editorForm.controls["delegateManId"].setValidators([Validators.required]);
      this.editorForm.controls["delegateManId"].updateValueAndValidity();
    }
    else {
      this.delegateManSelected = false;
      this.editorForm.controls["delegateManReciptNumber"].clearValidators();
      this.editorForm.controls["delegateManReciptNumber"].updateValueAndValidity();
      this.editorForm.controls["documentId"].clearValidators();
      this.editorForm.controls["documentId"].updateValueAndValidity();
      this.editorForm.controls["delegateManId"].clearValidators();
      this.editorForm.controls["delegateManId"].updateValueAndValidity();
    }
  }

  documentCahnged(event) {
    if (event || this.editorForm.controls["delegateManReciptNumber"].value || this.editorForm.controls["delegateManId"].value) {
      this.delegateManSelected = true;
      this.editorForm.controls["delegateManReciptNumber"].setValidators([Validators.required]);
      this.editorForm.controls["delegateManReciptNumber"].updateValueAndValidity();
      this.editorForm.controls["documentId"].setValidators([Validators.required]);
      this.editorForm.controls["documentId"].updateValueAndValidity();
      this.editorForm.controls["delegateManId"].setValidators([Validators.required]);
      this.editorForm.controls["delegateManId"].updateValueAndValidity();
    }
    else {
      this.delegateManSelected = false;
      this.editorForm.controls["delegateManReciptNumber"].clearValidators();
      this.editorForm.controls["delegateManReciptNumber"].updateValueAndValidity();
      this.editorForm.controls["documentId"].clearValidators();
      this.editorForm.controls["documentId"].updateValueAndValidity();
      this.editorForm.controls["delegateManId"].clearValidators();
      this.editorForm.controls["delegateManId"].updateValueAndValidity();
    }
  }

  textCahnged(event) {
    if (event || this.editorForm.controls["delegateManReciptNumber"].value || this.editorForm.controls["documentId"].value || this.editorForm.controls["delegateManId"].value) {
      this.delegateManSelected = true;
      this.editorForm.controls["delegateManReciptNumber"].setValidators([Validators.required]);
      this.editorForm.controls["delegateManReciptNumber"].updateValueAndValidity();
      this.editorForm.controls["documentId"].setValidators([Validators.required]);
      this.editorForm.controls["documentId"].updateValueAndValidity();
      this.editorForm.controls["delegateManId"].setValidators([Validators.required]);
      this.editorForm.controls["delegateManId"].updateValueAndValidity();
    }
    else {
      this.delegateManSelected = false;
      this.editorForm.controls["delegateManReciptNumber"].clearValidators();
      this.editorForm.controls["delegateManReciptNumber"].updateValueAndValidity();
      this.editorForm.controls["documentId"].clearValidators();
      this.editorForm.controls["documentId"].updateValueAndValidity();
      this.editorForm.controls["delegateManId"].clearValidators();
      this.editorForm.controls["delegateManId"].updateValueAndValidity();
    }
  }

  donationTypeCahnged(level, value) {
debugger;
    this.receipt.DonationTypeId = value.id;
    this.SelectedDonationTypeId = value.id;
    this.getDonationTypeLookup(level + 1);

  }

  OneCostCenterCheckChanged($event) {
    debugger;
    if ($event.currentTarget.checked) {
      this.editorForm.controls['OnCostCenterValue'].setValidators([Validators.required]);
      this.editorForm.controls['OnCostCenterValue'].updateValueAndValidity();
    }
    else {
      this.editorForm.controls['OnCostCenterValue'].clearValidators();
      this.editorForm.controls['OnCostCenterValue'].updateValueAndValidity();
    }
  }

  OneCostCenterCHekedToggle(val) {
    debugger;
    this.IsOneCostCenterChecked = val.checked;
    this.editorForm.controls['CostCentersCheck'].setValue(false);
  }

  onOneCostCenterChanged(id) {
    let totalAmount = this.editorForm.controls['Amount'].value;
    if (totalAmount == null || totalAmount == 0) {
      this.editorForm.controls['OnCostCenterValue'].setValue(null);
      this.SelectedCostCenter = null;
      this.notification.showTranslateError('movements.TotalAmount');
    }
    else {
      this.receipt.costCenters = new Array();
      this.receipt.costCenters.push({ id: id.value, costCenterId: id.value, amount: totalAmount, assignValue: totalAmount })
      console.log("one cost center to Api " + JSON.stringify(this.receipt.costCenters))
    }

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

  journalValueChange(event){
    this.receipt.journal = event;
  }
  journalApprove(event){
    debugger;
    this.collectModelFromForm();
    this.receipt.journal = event;
    this.ReceiptsServ.add(this.receipt)
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

  journalReject(event){
    $('#openPostlBTN').click();
    this.notification.showSuccessAlertForSavedDocument(this.receipt.code);
    this.notification.showJournalcanceled();
    this.gotoList();
  }

  handleCurrienciesFilter(value) {
    this.CurrenciesDropDownData = this.CurrenciesDropDownData.filter((s) => s.text.toLowerCase().indexOf(value.toLowerCase()) !== -1);
  }

  handleDonationTypesFilter(value) {
    this.DonationTypesDropDownData = this.DonationTypesDropDownData.filter((s) => s.text.toLowerCase().indexOf(value.toLowerCase()) !== -1);
  }

  getVendorsLookup() {
    this.ReceiptsServ.getVendorsLookup()
      .subscribe(res => {
        //debugger;
        this.Vendors = res;
        this.PageLoading = false;

      }, () => {
        this.PageLoading = false;

        this.notification.showOperationFailedToLoadVendors();
      }, () => {
      });
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

  getdonatorLookup() {
    this.ReceiptsServ.getDonatorLookup()
      .subscribe(res => {
        this.donators = res;
      }, () => {
        this.notification.showOperationFailed();
      }, () => {
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

  generateCode() {
    // var datetime = new Date();
    // var valRand = Math.floor(100 + Math.random() * 200);

    // var code = datetime.getDate().toString() + (datetime.getMonth() + 1).toString() + datetime.getFullYear().toString() +
    //   datetime.getHours().toString() + datetime.getMinutes().toString() + datetime.getSeconds().toString() + "-" +
    //   valRand;
    // this.receipt.code = code;
    // this.movementCode = code;
    // this.editorForm.controls['movementCode'].setValue[code];
    // console.log("code" + " " + this.receipt.code);
  }

  showCaseAmountOverflowError() {
    let key = 'financial.casesTotalValue';
    this.translateService.get([key]).subscribe(res => {
      this.notification.showErrorHtml(`<h5>${res[key]}</h5>`);
    });
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

  //cost centers logic
  addCostCenters(costCentersList) {
    this.totalCostCenters = 0;
    this.IsOneCostCenterChecked = false;

    // this.CostCenters = costCentersList;
    costCentersList.forEach((item) => {
      this.totalCostCenters = this.totalCostCenters + item.assignValue;
    });
    if (this.totalCostCenters != this.editorForm.controls['Amount'].value) {
      this.notification.showTranslateError('financial.costCenterTotalValue');
    }
    else {
      this.receipt.costCenters = new Array();
      this.receipt.costCenters = costCentersList;
      this.notification.showTranslateSuccess('costCenter.SucessCostCentersAdd');
    }
    console.log("api call object insider cost centers " + JSON.stringify(this.receipt.costCenters))
  }

  CostCentersCHekedToggle() {
    debugger;
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
          this.receipt.costCenters = new Array();
        }
      }
    });
  }

  ProductsCHekedToggle() {
    this.editorForm.controls['AssociatedProducts'].valueChanges.subscribe(value => {
      if (value == true) {
        $('#openProductsModalBTN').click();
      }
      else {
        this.receipt.products = new Array();
      }
    });
  }

  CasesCHekedToggle() {
    this.editorForm.controls['AssociatedBeneficiariesCases'].valueChanges.subscribe(value => {
      if (value == true) {
        $('#openCasesModalBTN').click();
      }
      else {
        this.receipt.cases = new Array();
      }
    });
  }

  bindModelToForm(): void {
    debugger;
    if (this.receipt) {
      this.donationDetails = this.receipt.cases;
      this.editorForm.controls['Amount'].setValue(this.receipt.amount);

      if (this.CurrenciesDropDownData && this.CurrenciesDropDownData.length > 0) {
        let val = this.CurrenciesDropDownData.find(x => x.value == this.receipt.currencyId);
        if (val) {
          this.editorForm.controls['Currency'].setValue(val);
        }
      }
      debugger;
      this.editorForm.controls['reciptDate'].setValue(this.receipt.reciptDate);
      this.editorForm.controls['Date'].setValue(this.receipt.date);
      this.editorForm.controls['DescriptionAR'].setValue(this.receipt.descriptionAR);
      this.editorForm.controls['DescriptionEN'].setValue(this.receipt.descriptionEN);

      this.editorForm.controls['VendorId'].setValue(this.receipt.vendorId);
      this.editorForm.controls['documentId'].setValue(this.receipt.documentId);


      this.editorForm.controls['AccountChart'].setValue(this.receipt.accountChartId);
      this.editorForm.controls['Branch'].setValue(this.receipt.branchId);
      this.editorForm.controls['donatorId'].setValue(this.receipt.donatorId);

      if (this.delegateMensDropDownData && this.delegateMensDropDownData.length > 0) {
        let delegateMan = this.delegateMensDropDownData.find(x => x.value == this.receipt.delegateManId);
        if (delegateMan) {
          this.editorForm.controls["delegateManId"].setValue(delegateMan);
        }
      }

      this.editorForm.controls['delegateManReciptNumber'].setValue(this.receipt.delegateManReciptNumber);

      if (this.receipt.costCenters) {
        this.receipt.costCenters.forEach(item => {
          item.id = item.costCenterId;
          item.assignValue = item.amount;
        });

        if (this.receipt.costCenters.length == 1) {
          this.IsOneCostCenterChecked = true;
          this.editorForm.controls['OneCostCenterCheck'].setValue(true);

          if (this.CostCenterDropDown && this.CostCenterDropDown.length > 0) {
            let val = this.CostCenterDropDown.find(x => x.value == this.receipt.costCenters[0].costCenterId);
            if (val) {
              this.editorForm.controls['OnCostCenterValue'].setValue(val);
            }
          }
        }
        else if (this.receipt.costCenters.length > 1) {
          this.editorForm.controls['CostCentersCheck'].setValue(true);
          this.CostCenters = this.receipt.costCenters;
        }
      }



      let donationType = this.allDonationType.find(x =>
        x.id == this.receipt.donationTypeId);
      debugger;
      if (donationType && donationType.parentId) {
        for (let index = 0; index < this.receipt.donatoinTypesLevel.length; index++) {
          switch (index) {
            case 0:
              {
                if (this.receipt.donatoinTypesLevel.length == 3) {
                  //this.getDonationTypeLookup(3);
                  //this.editorForm.controls['ThirdDonationTypeId'].setValue(this.receipt.donatoinTypesLevel[0]);
                  let thirdLevelDonationType = this.allDonationType.find(x => x.id == this.receipt.donatoinTypesLevel[0]);
                  this.ThirdLevelDonationTypeData = [{ thirdLevelDonationType }];
                  this.editorForm.controls['ThirdDonationTypeId'].setValue(thirdLevelDonationType);
                }
                else if (this.receipt.donatoinTypesLevel.length == 2) {
                  let SeconedLevelDonationType = this.allDonationType.find(x => x.id == this.receipt.donatoinTypesLevel[0]);
                  this.SeconedLevelDonationTypeData = [{ SeconedLevelDonationType }];
                  this.editorForm.controls['SecDonationTypeId'].setValue(SeconedLevelDonationType);
                }
              }
              break;

            case 1:
              {
                if (this.receipt.donatoinTypesLevel.length == 3) {
                  let SeconedLevelDonationType = this.allDonationType.find(x => x.id == this.receipt.donatoinTypesLevel[1]);
                  this.SeconedLevelDonationTypeData = [{ SeconedLevelDonationType }];
                  this.editorForm.controls['SecDonationTypeId'].setValue(SeconedLevelDonationType);
                }
                else if (this.receipt.donatoinTypesLevel.length == 2) {
                  let firstLevelDonationType = this.DonationTypesDropDownData.find(x => x.id == this.receipt.donatoinTypesLevel[1]);
                  this.editorForm.controls['donationTypeId'].setValue(firstLevelDonationType);
                }
              }
              break;
            case 2:
              {
                let firstLevelDonationType = this.DonationTypesDropDownData.find(x => x.id == this.receipt.donatoinTypesLevel[2]);
                this.editorForm.controls['donationTypeId'].setValue(firstLevelDonationType);
              }
              break;
            default:
              break;
          }


        }
      }
      this.donationDetails = this.receipt.cases;
debugger
      //this.DetailPaymentMethod.SafeId = this.receipt.safeId;
      this.DetailPaymentMethod.safeAccountChartId = this.receipt.safeAccountChartId;
      this.DetailPaymentMethod.VisaNumber = this.receipt.visaNumber;
      this.DetailPaymentMethod.Duedate = this.receipt.duedate;
      this.DetailPaymentMethod.exchangeable = this.receipt.exchangeable;
      this.DetailPaymentMethod.ChequeNumber = this.receipt.chequeNumber;
      this.DetailPaymentMethod.ToBankId = this.receipt.toBankId;
      this.DetailPaymentMethod.toBankAccountChartId = this.receipt.toBankAccountChartId;

      this.DetailPaymentMethod.FromBankId = this.receipt.fromBankId;
      this.DetailPaymentMethod.VisaBankId = this.receipt.visaBankId;
      this.DetailPaymentMethod.ReceivingMethodId = this.receipt.receivingMethodId;
      this.DetailPaymentMethod.ischanged = true;
debugger
    }
  }

  collectModelFromForm(): void {
    debugger;
    this.receipt.amount = this.editorForm.controls['Amount'].value;
    this.receipt.CurrencyId = this.editorForm.controls['Currency'].value.value;
    console.log("sel Cur Id " + this.editorForm.controls['Currency'].value.value);
    this.receipt.date = this.editorForm.controls['Date'].value;
    this.receipt.descriptionEN = this.editorForm.controls['DescriptionEN'].value;
    this.receipt.descriptionAR = this.editorForm.controls['DescriptionAR'].value;
    this.receipt.vendorId = this.editorForm.controls['VendorId'].value;
    this.receipt.sourceType = this.editorForm.controls['SourceType'].value;
    this.receipt.accountChartId = this.editorForm.controls['AccountChart'].value;
    this.receipt.branchId = this.editorForm.controls['Branch'].value;
    this.receipt.donatorId = this.editorForm.controls['donatorId'].value;
    this.receipt.reciptDate = this.editorForm.controls['reciptDate'].value;
    this.receipt.documentId = this.editorForm.controls['documentId'].value;

    let delegateManIdValue = this.editorForm.controls["delegateManId"].value;
    if (delegateManIdValue) {
      this.receipt.delegateManId = delegateManIdValue.value;
    }
    this.receipt.delegateManReciptNumber = this.editorForm.controls["delegateManReciptNumber"].value;

    // debugger;
    console.log(this.receipt);
  }

  checkAccountAndCurrencyAreMatches(): boolean {
    let selectedAccountChartId: any = this.editorForm.controls['AccountChart'].value;
    let selectedCurrencyId: any = this.editorForm.controls['Currency'].value.value;
    let accountChartItem: any = this.AccountCharts.find(x => x.id == selectedAccountChartId);

    if (!this.postingSetting.allowPostingAccountCurrencyMisMatch &&
      accountChartItem && accountChartItem.currencyId != selectedCurrencyId) {

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

  checkDate(): boolean {
    // debugger;
    let selectedDate: any = this.editorForm.controls['Date'].value;
    let now = new Date(Date.now());

    if (selectedDate > now) {
      this.notification.showTranslateHtmlError_h5('error.maxDateAlert');
      return false;
    }
    else {
      return true;
    }
  }

  adddonator() {
    this.isNewdonator = true;
  }

  handleProductChange(products) {
    this.receipt.products = [];
    this.receipt.products = products;
    console.log("products to api " + JSON.stringify(this.receipt.products));
    this.notification.showOperationSuccessed();
  }

  onPaymentMethodsChanged(evnt: PaymentMethod) {
   debugger;
    this.receipt.receivingMethodId = evnt.ReceivingMethodId;
    this.receipt.FromBankId = evnt.FromBankId;
    this.receipt.ToBankId = evnt.ToBankId;
    this.receipt.toBankAccountChartId = evnt.toBankAccountChartId;
    this.receipt.safeId = evnt.SafeId;
    this.receipt.chequeNumber = evnt.ChequeNumber;
    this.receipt.duedate = evnt.Duedate;
    this.receipt.visaNumber = evnt.VisaNumber;
    this.receipt.VisaBankId = evnt.VisaBankId;
    this.receipt.exchangeable = evnt.exchangeable;
    this.receipt.safeAccountChartId = evnt.safeAccountChartId;
  }

  SourceTypeChange() {
    let cahngedValue = this.editorForm.controls['SourceType'].value;
    console.log("SOurce Type Changed to " + cahngedValue);
    this.selectedSourceType = +cahngedValue;
    if (cahngedValue == 1) {
      this.editorForm.controls['donatorId'].clearValidators();
      this.editorForm.controls['donatorId'].updateValueAndValidity();
      this.editorForm.controls['AccountChart'].clearValidators();
      this.editorForm.controls['AccountChart'].updateValueAndValidity();
      this.editorForm.controls['VendorId'].setValidators([Validators.required]);
      this.editorForm.controls['VendorId'].updateValueAndValidity();
      this.editorForm.controls['OnCostCenterValue'].clearValidators();
      this.editorForm.controls['OnCostCenterValue'].updateValueAndValidity();

      this.editorForm.controls['donationTypeId'].clearValidators();
      this.editorForm.controls['donationTypeId'].updateValueAndValidity();
      this.editorForm.controls['SecDonationTypeId'].clearValidators();
      this.editorForm.controls['SecDonationTypeId'].updateValueAndValidity();
      this.editorForm.controls['ThirdDonationTypeId'].clearValidators();
      this.editorForm.controls['ThirdDonationTypeId'].updateValueAndValidity();


    }
    else if (cahngedValue == 2) {
      this.editorForm.controls['donatorId'].setValidators([Validators.required]);
      this.editorForm.controls['donatorId'].updateValueAndValidity();
      this.editorForm.controls['AccountChart'].clearValidators();
      this.editorForm.controls['AccountChart'].updateValueAndValidity();
      this.editorForm.controls['VendorId'].clearValidators();
      this.editorForm.controls['VendorId'].updateValueAndValidity();
      // this.editorForm.controls['OnCostCenterValue'].setValidators([Validators.required]);
      // this.editorForm.controls['OnCostCenterValue'].updateValueAndValidity();
      this.editorForm.controls['OnCostCenterValue'].clearValidators();
      this.editorForm.controls['OnCostCenterValue'].updateValueAndValidity();

      this.editorForm.controls['donationTypeId'].setValidators([Validators.required]);
      this.editorForm.controls['donationTypeId'].updateValueAndValidity();
    }
    else if (cahngedValue == 3) {
      this.editorForm.controls['donatorId'].clearValidators();
      this.editorForm.controls['donatorId'].updateValueAndValidity();
      this.editorForm.controls['AccountChart'].setValidators([Validators.required]);
      this.editorForm.controls['AccountChart'].updateValueAndValidity();
      this.editorForm.controls['VendorId'].clearValidators();
      this.editorForm.controls['VendorId'].updateValueAndValidity();
      this.editorForm.controls['OnCostCenterValue'].clearValidators();
      this.editorForm.controls['OnCostCenterValue'].updateValueAndValidity();

      this.editorForm.controls['donationTypeId'].clearValidators();
      this.editorForm.controls['donationTypeId'].updateValueAndValidity();
      this.editorForm.controls['SecDonationTypeId'].clearValidators();
      this.editorForm.controls['SecDonationTypeId'].updateValueAndValidity();
      this.editorForm.controls['ThirdDonationTypeId'].clearValidators();
      this.editorForm.controls['ThirdDonationTypeId'].updateValueAndValidity();
    }
    this.editorForm.controls["AccountChart"].setValue(null);
    this.editorForm.controls["VendorId"].setValue(null);
    this.editorForm.controls["donatorId"].setValue(null);
    this.editorForm.controls["ThirdDonationTypeId"].setValue(null);
    this.editorForm.controls["SecDonationTypeId"].setValue(null);
    this.editorForm.controls["donationTypeId"].setValue(null);
    //clearing data;
    this.receipt.products = new Array();
    this.receipt.cases = new Array();
    this.receipt.vendorId = null;
    this.receipt.accountChartId = null;
    this.receipt.donatorId = null;
    this.receipt.donator = null;
    this.receipt.DonationTypeId = null;
    this.SeconedLevelDonationTypeData = null;
    this.ThirdLevelDonationTypeData = null;
  }

  donatorChange() {
    this.receipt.donator = null;
    this.Newdonator = null;
  }

  gotoList() {
    let url = [`/financial/financial-list`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  getCasesLookup() {
    this.PageLoading = true;
    this.ReceiptsServ.getCasesLookup(null, " ", 1, 10000, this.financialSetting.showCasesThatMetRequiredAmount)
      .subscribe(res => {
        this.PageLoading = false;
        // debugger;
        res.forEach((item) => {
          this.casesLookup.push({
            id: item.Id,
            name: item.Name,
            displayname: item.Id,
            requiredAmount: item.RequiredAmount
          })
        });
      }, () => {
        this.PageLoading = false;

        // debugger;
      }, () => {
        this.PageLoading = false;
        // debugger;
      });
  }

  directionValidation() {
    var VendorId = this.editorForm.controls['VendorId'].value;
    var AccountChart = this.editorForm.controls['AccountChart'].value;
    var donatorId = this.editorForm.controls['donatorId'].value;

    var result: boolean = false;

    if (VendorId || AccountChart || donatorId|| this.isNewdonator) {
      result = true;
      if (VendorId)
        this.receipt.sourceType = VendorId;
      else if (AccountChart)
        this.receipt.sourceType = AccountChart;
      else if (donatorId || this.isNewdonator)
        this.receipt.sourceType = donatorId;
    }
    else {
      this.notification.showPaymentDirectionError();
      result = false;
    }
    return result;
  }

  save() {
    debugger
    if (this.canEdit() == false) {
      return;
    }

    if (this.editorForm.valid) {

      if (this.checkAccountAndCurrencyAreMatches() == false) return;

      if (!this.directionValidation()) {
        return;
      }

      if (this.checkDate() == false) return;

      if (this.editorMode != this.editorModeEnum.detail) {
        this.collectModelFromForm();

        if (this.editorMode == this.editorModeEnum.add)  {
          this.ReceiptsServ.add(this.receipt)
          .subscribe(res => {
            this.receipt = res;
            this.journalPreview = res.journal;
            this.journalPreviewShow = true;
            $('#openPostlBTN').click();
            this.PageLoading = false;

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
        else if (this.editorMode == this.editorModeEnum.edit){
          this.ReceiptsServ.update(this.receipt)
          .subscribe(res => {
            this.PageLoading = false;

            this.notification.showSuccessAlertForSavedDocument(res);
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
        else{
          const editorFormFormKeys = Object.keys(this.editorForm.controls);
          editorFormFormKeys.forEach((control) => {
            console.log(control);
            this.editorForm.controls[control].markAsTouched();
          });
          this.editorForm.setErrors({ 'invalid': true, 'valid': false });
          //this.notification.showTranslateError('financial.formNotificationError');
          this.notification.showDataMissingError();
        }

      

        return;
      }

    }


    this.validForm = true;
    if (this.receipt.safeAccountChartId == null) {
      if (this.receipt.chequeNumber == null ||
        //this.receipt.FromBankId == null ||
       this.receipt.ToBankId == null || 
        this.receipt.duedate == null) {
        if (this.receipt.visaNumber == null || this.receipt.VisaBankId == null) {
          this.notification.showTranslateError('financial.paymentNotificationError');
          this.validForm = false;
        }
      }
    }
    ;
    if (this.editorForm.controls['SourceType'].value == 2 &&
      this.totalSelectedCases > this.editorForm.controls['Amount'].value) {
      this.showCaseAmountOverflowError();
      //this.notification.showTranslateError('financial.casesTotalValue');
      this.validForm = false;
    }
    // if (this.editorForm.controls['SourceType'].value == this.sourceType.Donator &&
    //     this.SelectedCases.length<1
    // ) {
    //   this.notification.showDataMissingError();
    //   //this.notification.showTranslateError('financial.casesTotalValue');
    //   this.validForm = false;
    // }
    if (this.totalSelectedCases == 0 && this.SelectedCases.length > 0) {
      this.notification.showTranslateError('financial.casesAssignValue');
      this.validForm = false;
    }

    debugger;
    if (this.receipt.costCenters != null &&
      this.receipt.costCenters.length > 0) {
      let total: number = 0;
      this.receipt.costCenters.forEach(item => {
        item.amount = item.assignValue;
        item.costCenterId = item.id;
        total += item.assignValue;
      });

      if (total > this.editorForm.controls['Amount'].value) {
        this.notification.showTranslateError('financial.costCenterNotificationError');
        return;
      }
    }

    // if (this.totalCostCenters > this.editorForm.controls['Amount'].value) {
    //   this.notification.showTranslateError('financial.costCenterTotalValue');
    //   this.validForm = false;
    // }
    // // Validate cost centers
    // if (this.receipt.costCenters != null && this.receipt.costCenters.length != 0) {
    //   let costcenters = this.receipt.costCenters.filter(x => x.amount == 0 || x.amount == null);
    //   if (costcenters != null && costcenters.length != 0) {
    //     this.notification.showTranslateError('financial.costCenterNotificationError');
    //   }
    // }
    // Validate Vendor
    if (this.editorForm.controls['SourceType'].value == this.sourceType.vendor) {
      if (this.editorForm.controls['VendorId'].value === null || this.editorForm.controls['VendorId'].value === undefined) {
        this.editorForm.controls['VendorId'].setErrors({ 'invalid': true });
        this.notification.showTranslateError('financial.vendorNotificationError');
        this.validForm = false;
      }
    }
    // Validate AccountChart
    if (this.editorForm.controls['SourceType'].value == this.sourceType.AccountChart) {
      if (this.editorForm.controls['AccountChart'].value === null || this.editorForm.controls['AccountChart'].value === undefined) {
        console.log('Error in AccountChart !!');
        this.editorForm.controls['AccountChart'].setErrors({ 'invalid': true });
        this.notification.showTranslateError('financial.accountChartNotificationError');
        this.validForm = false;
      }
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
    }
    if (this.validForm) {
      if (this.editorForm.valid) {
        this.collectModelFromForm();

        this.PageLoading = true;

        if (this.editorMode == this.editorModeEnum.add) {
          this.ReceiptsServ.add(this.receipt)
            .subscribe(res => {
              debugger;
              this.PageLoading = false;
              this.receipt = res;
              this.journalPreview = res.journal;
              this.journalPreviewShow = true;
              $('#openPostlBTN').click();

              //this.notification.showSuccessAlertForSavedDocument(res.code);
              //this.gotoList();
              debugger;
            },
              (error) => {
                // debugger;
                console.log(error);
                this.PageLoading = false;
                this.errorService.handerErrors(error);
                // debugger;
              }, () => {
                this.PageLoading = false;

                // debugger;
              });
        }
        //this.buildForms();
        // this.receipt= new Receipt();
      } else {
        const editorFormFormKeys = Object.keys(this.editorForm.controls);
        editorFormFormKeys.forEach((control) => {
          console.log(control);          
          //this.editorForm.controls[control].markAsTouched();
        });
        this.editorForm.setErrors({ 'invalid': true, 'valid': false });
        //this.notification.showTranslateError('financial.formNotificationError');
        this.notification.showDataMissingError();
      }
    }
    else {
      this.validForm = false;
      //this.notification.showTranslateError('financial.formNotificationError');
      this.notification.showDataMissingError();
    }
  }



  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };


  receipt: Receipt = new Receipt();
  // Branches: BranchLookup[] = [];
  public BranchesDropDownData: Array<KendoDropDown>;
  public CurrenciesDropDownData: Array<KendoDropDown>;
  public SelectedDonationTypeId = null;
  public DonationTypesDropDownData: Array<any>;
  public SeconedLevelDonationTypeData: Array<any>;
  public ThirdLevelDonationTypeData: Array<any>;
  addBill: FormGroup;
  addProduct: FormGroup;
  PaymentMethods: { id: string; name: string; }[];
  Organizations: { id: string; name: string; }[];
  editorForm: FormGroup;
  editorMode: EditorMode = EditorMode.add;
  editorModeEnum = EditorMode;
  private id: any;
  isNewdonator: boolean = false;
  Newdonator: Donator;
  bsDatePickerValue: Date;
  ReceiptValue: any;
  payMethods: typeof PaymentMethodsEnum = PaymentMethodsEnum;
  sourceType: typeof SourceType = SourceType;
  Vendors: any[];
  AccountCharts: any[];
  donators: any[];
  CostCenters: CostCenters[] = [];
  DetailsCostCenters;
  CostCenterDropDown = new Array();
  IsOneCostCenterChecked = false;
  SelectedCases: Cases[] = [];
  totalCostCenters: number = 0;
  totalSelectedCases: number = 0;
  validForm: boolean = true;
  movementCode: string = "";
  SelectedCostCenter: number;
  selectedSourceType = 0;
  PageLoading = true;
  casesLookup = new Array();
  selectedCaseRequiredAmount: any;
  delegateMensDropDownData: Array<KendoDropDown>;
  pageSource: typeof pageSource = pageSource;
  private financialSetting: FinancialSetting = new FinancialSetting();
  systemCurrencySetting: SystemCurrencySetting = new SystemCurrencySetting();
  DetailPaymentMethod: PaymentMethod = new PaymentMethod();
  //private itemModel: Receipt = new Receipt();
  donationDetails: any[];
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
  postingSetting: PostingSetting = new PostingSetting();
  userBranch: any;
  allDonationType: any[];
  documents: any;
  delegateManSelected: boolean = false;
  journalPreview: any;
  journalPreviewShow: boolean = false;
  costCentersShow: boolean = false;
}
