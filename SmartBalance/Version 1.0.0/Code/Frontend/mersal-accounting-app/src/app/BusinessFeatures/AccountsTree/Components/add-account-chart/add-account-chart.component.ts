import { Component, OnInit, Output, EventEmitter, Input, SimpleChanges, ViewChild, ElementRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { AccountsTreeService } from '../../Services/accounts-tree.service';
import { accountChartTreeList } from '../../Models/AccountChartTreeList.model';
import { of } from 'rxjs/internal/observable/of';
import { TreeViewItemContentDirective } from '@progress/kendo-angular-treeview';
import { itemAt } from '@progress/kendo-angular-grid/dist/es2015/data/data.iterators';
import { TranslateService } from '@ngx-translate/core';
import { KendoDropDown } from 'src/app/SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { simpleLookupModel } from '../../Models/simple-lookup.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { accountTree } from '../../Models/AccountTree.model';
import { levelModel } from '../../Models/level.model';
import { accountTypeLookup } from '../../Models/account-type-lookup';
import { AccountTypeEnum } from '../../Models/account-type.enum';
import { stringify } from 'querystring';
import { CurrencyService } from '../../../Currency/Services/currency.service';
import { SettingService } from '../../../Setting/Services/setting.service';
import { SystemCurrencySetting } from '../../../Setting/Models/system-currency-setting.model';
import { UserService } from '../../../User/Services/user.service';
import { PermissionEnum } from 'src/app/BusinessFeatures/User/Models/permission-enum';
import { BranchService } from '../../../Branch/Services/branch.service';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';

@Component({
    selector: 'addAccountChart',
    templateUrl: './add-account-chart.component.html',
    styleUrls: ['./add-account-chart.component.scss'],
})
export class AddAccountTreeComponent implements OnInit {
    PageLoading: boolean = true;
    public AccountsGroupsDropDownData: Array<simpleLookupModel>;
    public AccountsCategoriesDropDownData: Array<simpleLookupModel>;
    public AccountsTypeDropDownData: Array<accountTypeLookup>;
    bsDatePickerValue: Date;
    hasOpeningBalance: boolean = false;

    levels: levelModel[];
    maxlevels: number;
    accountChartFormModel: FormGroup;
    accountChartmodel: accountTree;
    codelength: number;
    @Input() ParentAccountChart: accountChartTreeList;
    @Input() AccountChartDetailsId: number;
    @Output() SucessAddOperation = new EventEmitter();
    @Output() SucessEditOperation = new EventEmitter();
    IsDetails: boolean = false;

    constructor(
        private notification: NotificationService,
        private AccountChartServic: AccountsTreeService,
        private translateService: TranslateService,
        private formbuilder: FormBuilder,
        private route: ActivatedRoute,
        private currencyService: CurrencyService,
        private settingService: SettingService,
        private userService: UserService,
        private branchService: BranchService,
        private errorService: ErrorService
    ) { }


    ngOnInit() {
        this.checkIfCurrentUserHassPermission();
        this.getBranchsLookups();
        this.getCurrencys();
        this.getSystemCurrencySetting();
        this.buildForms();

        this.getAccountChartGroups();
        this.getAccountChartTypes();
        this.getAccountChartCategories();

        this.bsDatePickerValue = new Date();
        this.form = this.formbuilder.group({
            avatar: [null]
          });
        // this.buildForms();
    }

    ngOnChanges(changes: SimpleChanges) {
        this.buildForms();
        this.getAccountChartTypes();
        this.accountChartmodel = new accountTree();
        if (this.ParentAccountChart != null) {
            this.accountChartmodel.parentAccountChartId = this.ParentAccountChart.id;
            //    let AccountTypeId=this.AccountsTypeDropDownData.find(x=>x.code=='2').id;
            //    this.accountChartFormModel.controls['AccountCategory'].setValue(AccountTypeId)  
        }
        else {

            this.accountChartmodel.parentAccountChartId = null;
            //    let AccountTypeId=this.AccountsTypeDropDownData.find(x=>x.code=='1').id;
            //    this.accountChartFormModel.controls['AccountCategory'].setValue(AccountTypeId)  
        }
        debugger;
        // this.accountChartFormModel.markAsPristine();
        if (this.AccountChartDetailsId != null && this.AccountChartDetailsId != 0) {
            //    this.GetPaymovmentById(+id);

            this.fillDetailsData();
        }
        else {
            this.accountChartFormModel.enable();
            this.IsDetails = false;
            this.accountChartFormModel.reset();
            this.GetLevels();
        }
    }

    buildForms(): void {
        this.accountChartFormModel = this.formbuilder.group({
            NameAR: [null, [Validators.required, Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
            NameEN: [null, [Validators.required, Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
            descriptionAr: [null],
            descriptionEn: [null],

            AccountGroup: [null, [Validators.required]],
            AccountCategory: [null, [Validators.required]],
            AccountType: [null, [Validators.required]],
            Date: [null],//, [Validators.required]],
            Amount: [null, [//Validators.required,
                Validators.min(1)]],
            IsCreditor: [null, []],
            Code: [null, [Validators.required]],
            currencyId: [null],
            currentDebitBalance: [null],
            currentCreditBalance: [null],
            isCreditAccount: [false],
            accountChartFormModel: [null],
            branchId: [null]
            //   IsFinalNode:[]
        });

        this.accountChartFormModel.valueChanges
            .subscribe(res => {
                this.hasOpeningBalance = (res.AccountType == AccountTypeEnum.main);
            });
    }

    setBranchOptional(): void {
        this.branchRequired = false;
        this.accountChartFormModel.controls['branchId'].clearValidators();
        this.accountChartFormModel.controls['branchId'].updateValueAndValidity();
    }
    setBranchRequired(): void {
        this.branchRequired = true;
        this.accountChartFormModel.controls['branchId'].setValidators([Validators.required]);
        this.accountChartFormModel.controls['branchId'].updateValueAndValidity();
    }

    onBranchChange(evnt: any) {
        //debugger;
        if (this.IsDetails) {
            this.setBranchOptional();
        }
        else {
            if (evnt.id == AccountTypeEnum.main) {
                this.setBranchOptional();
            }
            else if (evnt.id == AccountTypeEnum.subMain) {
                this.setBranchRequired();
            }
        }
    }

    getAccountChartGroups() {
        this.PageLoading = true;
        this.AccountChartServic.GetAccountChartGroupsLookup().subscribe(
            response => {
                this.PageLoading = false;
                this.AccountsGroupsDropDownData = response;
            },
            error => {
                this.PageLoading = false;
            }
        )
    }

    checkIfCurrentUserHassPermission(): void {
        this.userService.isCurrentUserHassPermission(PermissionEnum.editAccountChart)
            .subscribe(res => {
                debugger;
                this.isCurrentUserHassPermission = res;
            },
                (error) => {

                },
                () => {

                })
    }

    getBranchsLookups() {
        this.branchService.getBranchsLookups().subscribe(res => {
            this.branchs = res.collection;
        },
            (error) => {
                console.error(JSON.stringify(error));
            },
            () => {

            });
    }

    getCurrencys() {
        this.currencyService.getCurrencysLookups()
            .subscribe(res => {
                this.currencys = res.collection;
                this.setDefaultCurrency();
            },
                (error) => {

                });
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
        if (!this.IsDetails &&
            this.currencys && this.currencys.length > 0 &&
            this.systemCurrencySetting && this.systemCurrencySetting.currencyId) {

            let val = this.currencys.find(x => x.id == this.systemCurrencySetting.currencyId);
            if (val && !this.accountChartFormModel.controls["currencyId"].value) {
                this.accountChartFormModel.controls["currencyId"].setValue(val.id);
            }
        }
    }

    fillDetailsData() {
        this.PageLoading = true;
        this.AccountChartServic.getDetails(this.AccountChartDetailsId).subscribe(
            success => {

                this.setBranchOptional();
                this.PageLoading = false;
                this.IsDetails = true;
                this.model = success;

                if (this.IsDetails && !this.isCurrentUserHassPermission) {
                    this.accountChartFormModel.disable();
                }

                this.accountChartFormModel.controls['Amount'].setValue(success.openingCredit);

                this.accountChartFormModel.controls['NameEN'].setValue(success.nameEN);
                this.accountChartFormModel.controls['NameAR'].setValue(success.nameAR);
                this.accountChartFormModel.controls['descriptionAr'].setValue(success.descriptionAr);
                this.accountChartFormModel.controls['descriptionEn'].setValue(success.descriptionEn);

                this.accountChartFormModel.controls['AccountGroup'].setValue(success.groupId);
                this.accountChartFormModel.controls['AccountCategory'].setValue(success.categoryId);
                this.accountChartFormModel.controls['AccountType'].setValue(success.accountTypeId);
                this.accountChartFormModel.controls['IsCreditor'].setValue(success.isDebt);
                this.accountChartFormModel.controls['isCreditAccount'].setValue(success.isCreditAccount);
                this.accountChartFormModel.controls['Date'].setValue(success.date);
                this.accountChartFormModel.controls['Code'].setValue(success.code);
                this.accountChartFormModel.controls['currencyId'].setValue(success.currencyId);

                this.accountChartFormModel.controls['currentDebitBalance'].setValue(success.currentDebitBalance);
                this.accountChartFormModel.controls['currentCreditBalance'].setValue(success.currentCreditBalance);

                if(this.branchs) {
                    let branch = this.branchs.find(x => x.id == success.branchId);
                    this.accountChartFormModel.controls['branchId'].setValue(branch);
                }
                // this.accountChartFormModel.controls['IsFinalNode'].setValue(success.isFinalNode);
                debugger;
            },
            error => {
                this.PageLoading = false;
                this.notification.showOperationFailed();
            }
        );
    }
    getAccountChartTypes() {
        this.PageLoading = true;
        this.AccountChartServic.GetAccountChartTypesLookup().subscribe(
            response => {
                this.PageLoading = false;
                this.AccountsTypeDropDownData = response;
                //                 if(this.ParentAccountChart!=null)
                //    {
                //     //    this.accountChartmodel.parentAccountChartId=this.ParentAccountChart.id;
                //        let AccountTypeId=this.AccountsTypeDropDownData.find(x=>x.code=='2').id;
                //        this.accountChartFormModel.controls['AccountType'].setValue(AccountTypeId);
                //        this.accountChartFormModel.updateValueAndValidity();  
                //    }
                //    else{

                //     // this.accountChartmodel.parentAccountChartId=null;
                //        let AccountTypeId=this.AccountsTypeDropDownData.find(x=>x.code=='1').id;
                //        this.accountChartFormModel.controls['AccountType'].setValue(AccountTypeId)  ;
                //        this.accountChartFormModel.updateValueAndValidity();  

                //    }
            },
            error => {
                this.PageLoading = false;
            }
        )
    }

    GetLevels() {
        this.PageLoading = true;
        this.AccountChartServic.GetLevels().subscribe(
            response => {
                this.PageLoading = false;
                this.levels = response;
                this.maxlevels = this.levels.length;
                //     if(!this.IsDetails){
                //     if(this.ParentAccountChart!=null){
                //         this.codelength=this.levels.find(x=>x.level==(this.ParentAccountChart.accountLevel+1).toString()).length;
                //     }
                //     else{
                //         this.codelength=this.levels.find(x=>x.level==(1).toString()).length;
                //     }
                //     this.accountChartFormModel.controls['Code'].setValidators([Validators.maxLength(this.codelength)
                //         ,Validators.minLength(this.codelength)
                //         ,Validators.required]);

                //     this.accountChartFormModel.controls['Code'].updateValueAndValidity();
                // }
            },
            error => {
                this.PageLoading = false;
                this.notification.showOperationFailed();

            }
        )
    }
    getAccountChartCategories() {
        this.PageLoading = true;
        this.AccountChartServic.GetAccountChartCategoriesLookup().subscribe(
            response => {
                this.PageLoading = false;
                this.AccountsCategoriesDropDownData = response;
            },
            error => {
                this.PageLoading = false;
            }
        )
    }  

    CheckAccountChartCode() {
        let code: string = this.accountChartFormModel.controls['Code'].value;

        if (code.length > 0) {
            this.AccountChartServic.checkCode(code).subscribe(
                success => {
                    debugger;
                    let msg: string = 'accountChart.CreateProcess';
                    if (success != 0) {
                        this.AccountChartDetailsId = success;
                        this.accountChartmodel = new accountTree();
                        msg = 'accountChart.DetailsProcess';
                        this.fillDetailsData();

                    }
                    this.translateService.get(msg).subscribe(
                        msg => {
                            this.notification.showWarningHtml(`<h5>${msg}</h5>`);
                        }
                    );
                },
                (error) => {
                    debugger;
                    let statuscode: string = "";
                    if (error.statuscode == 404) {
                        statuscode = 'shared.Exception.AccountChart404';

                        this.translateService.get(statuscode).subscribe(res => {
                            this.notification.showWarningHtml(`<h5>${res}</h5>`);
                        });
                    }
                    else if (error.statuscode == 406) {
                        statuscode = 'shared.Exception.AccountChart406';

                        this.translateService.get(statuscode).subscribe(res => {
                            this.notification.showWarningHtml(`<h5>${res}</h5>`);
                        });
                    }
                    else if (error.status == 1) {
                        statuscode = 'error.1';

                        this.translateService.get(statuscode).subscribe(res => {
                            this.notification.showErrorHtml(`<h5>${res}</h5>`);
                        });
                    }
                    else if (error.status == 2) {
                        statuscode = 'error.2';

                        this.translateService.get(statuscode).subscribe(res => {
                            this.notification.showErrorHtml(`<h5>${res}</h5>`);
                        });
                    }
                    else if (error.status == 3) {
                        statuscode = 'error.3';

                        this.translateService.get(statuscode).subscribe(res => {
                            this.notification.showErrorHtml(`<h5>${res}</h5>`);
                        });
                    }
                    else if (error.status == 4) {
                        statuscode = 'error.4';

                        this.translateService.get(statuscode).subscribe(res => {
                            this.notification.showErrorHtml(`<h5>${res}</h5>`);
                        });
                    }
                    else {
                        statuscode = 'shared.Exception.AccountChart403';

                        this.translateService.get(statuscode).subscribe(res => {
                            this.notification.showErrorHtml(`<h5>${res}</h5>`);
                        });
                    }
                }
            )
        }
    }
    ResetForm() {
        this.accountChartFormModel.enable();
        this.accountChartFormModel.reset();
        this.IsDetails = false;
        this.AccountChartDetailsId = null;
        this.accountChartmodel = new accountTree();
        this.setDefaultCurrency();
        this.setBranchOptional();
    }

    checkvalidation() {
        console.log(this.accountChartFormModel);
    }

    editAccountChart() {
        if (this.accountChartFormModel.valid) {
            this.PageLoading = true;

            this.accountChartmodel = new accountTree();
            this.accountChartmodel.id = this.AccountChartDetailsId;
            this.accountChartmodel.openingCredit = this.accountChartFormModel.controls['Amount'].value;

            this.accountChartmodel.nameEN = this.accountChartFormModel.controls['NameEN'].value;
            this.accountChartmodel.nameAR = this.accountChartFormModel.controls['NameAR'].value;
            this.accountChartmodel.descriptionAr = this.accountChartFormModel.controls['descriptionAr'].value;
            this.accountChartmodel.descriptionEn = this.accountChartFormModel.controls['descriptionEn'].value;


            this.accountChartmodel.groupId = this.accountChartFormModel.controls['AccountGroup'].value;
            this.accountChartmodel.categoryId = this.accountChartFormModel.controls['AccountCategory'].value;
            this.accountChartmodel.accountTypeId = this.accountChartFormModel.controls['AccountType'].value;
            this.accountChartmodel.isDebt = this.accountChartFormModel.controls['IsCreditor'].value;
            this.accountChartmodel.isCreditAccount = this.accountChartFormModel.controls['isCreditAccount'].value;
            this.accountChartmodel.date = this.accountChartFormModel.controls['Date'].value;
            this.accountChartmodel.code = this.accountChartFormModel.controls['Code'].value;
            this.accountChartmodel.currencyId = this.accountChartFormModel.controls['currencyId'].value;
          
            let branch = this.accountChartFormModel.controls['branchId'].value;
            if (branch) {
                this.accountChartmodel.branchId = branch.id;
            }

            // this.accountChartmodel.isFinalNode=this.accountChartFormModel.controls['IsFinalNode'].value;

            this.AccountChartServic.editAccount(this.accountChartmodel).subscribe(
                success => {
                    this.PageLoading = false;
                    //this.accountChartFormModel.reset();
                    this.notification.showSuccessAlertForSavedDocument(success.code);
                    this.SucessEditOperation.emit(success);
                },
                (error) => {
                    this.PageLoading = false;
                    debugger;
                    this.errorService.handerErrors(error);
                }
            );
        }
        else {
            this.notification.showDataMissingError();
        }
    }

    addAccountChart() {
        debugger;
        if (this.accountChartFormModel.valid) {
            this.PageLoading = true;
            // if(this.ParentAccountChart!=null)
            // {
            //     this.accountChartmodel.parentAccountChartId=this.ParentAccountChart.id;
            // }
            // else
            // {
            //     this.accountChartmodel.parentAccountChartId=null;
            // }
            this.accountChartmodel.openingCredit = this.accountChartFormModel.controls['Amount'].value;

            this.accountChartmodel.nameEN = this.accountChartFormModel.controls['NameEN'].value;
            this.accountChartmodel.nameAR = this.accountChartFormModel.controls['NameAR'].value;
            this.accountChartmodel.descriptionAr = this.accountChartFormModel.controls['descriptionAr'].value;
            this.accountChartmodel.descriptionEn = this.accountChartFormModel.controls['descriptionEn'].value;


            this.accountChartmodel.groupId = this.accountChartFormModel.controls['AccountGroup'].value;
            this.accountChartmodel.categoryId = this.accountChartFormModel.controls['AccountCategory'].value;
            this.accountChartmodel.accountTypeId = this.accountChartFormModel.controls['AccountType'].value;
            this.accountChartmodel.isDebt = this.accountChartFormModel.controls['IsCreditor'].value;
            this.accountChartmodel.isCreditAccount = this.accountChartFormModel.controls['isCreditAccount'].value;
            this.accountChartmodel.date = this.accountChartFormModel.controls['Date'].value;
            this.accountChartmodel.code = this.accountChartFormModel.controls['Code'].value;
            this.accountChartmodel.currencyId = this.accountChartFormModel.controls['currencyId'].value;

            let branch = this.accountChartFormModel.controls['branchId'].value;
            if (branch) {
                this.accountChartmodel.branchId = branch.id;
            }
            // this.accountChartmodel.isFinalNode=this.accountChartFormModel.controls['IsFinalNode'].value;

            this.AccountChartServic.AddAccount(this.accountChartmodel).subscribe(
                success => {
                    this.PageLoading = false;
                    this.accountChartFormModel.reset();
                    this.notification.showSuccessAlertForSavedDocument(success.code);
                    this.SucessAddOperation.emit(success);
                },
                (error) => {
                    this.PageLoading = false;
                    debugger;
                    this.errorService.handerErrors(error);
                }
            );
        }
        else {
            this.notification.showDataMissingError();
        }
    }

    addOrEditAccountChart() {
        if (this.IsDetails) {
            this.editAccountChart();
        }
        else {
            this.addAccountChart();
        }
    }

    triggerFileUpload() {
        let fileElement: HTMLElement = this.fileUpload.nativeElement;
        fileElement.click();
      }

    onFileChange(event) {
        debugger;
        if (event.target.files.length > 0) {
          const file = event.target.files[0];
          //this.form.controls['avatar'].setValue(file);
    
          let x = this.form.controls['avatar'].value;
          this.form.get('avatar').setValue(file);
    
          this.onSubmit();
        }
      }
      onSubmit() {
        debugger;
        this.PageLoading = true;
        const formData = new FormData();
        formData.append('file', this.form.get('avatar').value);
    
        this.AccountChartServic.uploadExcelFile(formData).subscribe(
          (res) => {
            debugger;
            this.PageLoading = false;
            this.translateService.get(['shared.added', 'financial.accountChart']).subscribe(tres => {
              //debugger;
              this.notification.showSuccessHtml(`${tres['shared.added']} ${res} ${tres['financial.accountChart']}`);
            });
    
            if (res != 0) {
              //this.getList();
            }

            this.accountChartFormModel.reset();          
            this.SucessAddOperation.emit(res);

            //alert("success");
            //this.uploadResponse = res,
          },
          (error) => {
            this.PageLoading = false;
            if (error.status == 20) {
              this.notification.showTranslateHtmlError_h5('error.20');
            }
            else {
              this.notification.showOperationFailed();
            }
            console.error(error);
          }
        );
      }

    


    currencys: any[];
    systemCurrencySetting: SystemCurrencySetting = new SystemCurrencySetting();
    isCurrentUserHassPermission: boolean = false;
    model: accountTree;
    branchs: any[];
    branchRequired: boolean = false;
    form: FormGroup;
    @ViewChild('fileUpload') fileUpload: ElementRef<HTMLElement>;
    //accountTypeEnumOption = AccountTypeEnum;
}
