import { FinancialService } from '../../Services/financial.service';
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CasesLookup } from '../../Models/cases-lookup.model';
import { Beneficiaries } from '../../Models/beneficiaries.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { Cases } from '../../Models/receipts.model';
import { SettingService } from '../../../Setting/Services/setting.service';
import { FinancialSetting } from '../../../Setting/Models/financial-setting.model';
declare var $: any;

@Component({
  selector: 'app-select-cases',
  templateUrl: './select-cases.component.html',
  styleUrls: ['./select-cases.component.scss'],
  providers: [FinancialService]
})
export class SelectCasesComponent implements OnInit {
  @Input() donationValue: number;
  @Input() isDetails: boolean;
  @Input() donationDetails: [];

  casesLookup = new Array();
  beneficiaries: Cases[] = [];
  beneficiariesList = new Array();
  totalAssign: number = 0;
  addBeneficiaries: FormGroup;
  index = 1;
  size = 5;
  searchKey: string = " ";
  searchKeyID: number;
  propPageLoading = true;
  @Output() beneficiariesListChanged: EventEmitter<Cases[]> = new EventEmitter();
  private financialSetting: FinancialSetting = new FinancialSetting();
  editQuantity: any;


  constructor(
    public router: Router,
    private fb: FormBuilder,
    private financialService: FinancialService,
    private settingService: SettingService,
    private notification: NotificationService,
    private translateService: TranslateService
  ) {
    this.casesLookup = new Array();
  }

  ngOnInit() {
    this.getFinancialSetting();
    this.buildForm();
    this.getCasesLookup(null, this.searchKey, this.index, this.size, true);
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

  getCasesLookup(id, name, index, size, isIntail) {
    this.propPageLoading = true;
    this.financialService.getCasesLookup(id, " ", index, size, this.financialSetting.showCasesThatMetRequiredAmount)
      //this.financialService.getCasesLookup(id, name, index, size)
      .subscribe(res => {
        this.propPageLoading = false;
        //debugger;
        var CassessList = new Array<any>();
        res.forEach((item) => {

          if (isIntail != true) {
            let caseitem = this.casesLookup.find(x => x.id == item.Id);
            if (!caseitem) {
              this.casesLookup.push({ id: item.Id, name: item.Name, RequiredAmount: item.RequiredAmount, amount: 0,checked: false, display: true })
            }
          }
          CassessList.push({ id: item.Id, name: item.Name, RequiredAmount: item.RequiredAmount, amount: 0, checked: false, display: true })
        });

        if (isIntail)
          this.casesLookup = CassessList;
        this.index += 1;
      }, (error) => {
        this.propPageLoading = false;

        // debugger;
      }, () => {
        this.propPageLoading = false;
        // debugger;
      });
  }

  AddBeneficiaries() {
     debugger;
    let totalAmount = 0;
    this.beneficiariesList = [];

    this.casesLookup.filter(x => x.checked == true).forEach((item, index) => {
      console.log(item);
      let itemIndex = this.beneficiariesList.findIndex(x => x.CaseId == item.id);
      if (itemIndex == -1) {
        this.beneficiariesList.push({
          CaseId: item.id,
          Amount: item.amount,
          Name: item.name
        });
        totalAmount += item.amount;
      }
    });

    this.casesLookup.filter(x => !x.checked).forEach((item, index) => {
      let itemIndex = this.beneficiariesList.findIndex(x => x.CaseId == item.id);
      if (itemIndex != -1) {
        this.beneficiariesList.splice(itemIndex, 1);
      }
    });

    if (totalAmount <= this.donationValue) {
      $('#openCasesModalBTN').click();
    }
    // else {
    //   let key = 'financial.casesTotalValue';
    //   this.translateService.get([key]).subscribe(res => {
    //     this.notification.showErrorHtml(`<h5>${res[key]}</h5>`);
    //   });
    // }

    this.fireBeneficiariesListChanged();
  }


  getTotalAssign() {
    this.totalAssign = 0;
    for (let item of this.beneficiariesList) {
      this.totalAssign = this.totalAssign + item.assignValue;
    }
  }

  fireBeneficiariesListChanged(): void {

    this.beneficiariesListChanged.emit(this.beneficiariesList);
  }

  buildForm(): void {
    this.addBeneficiaries = this.fb.group({
      caseCode: [null, [Validators.required]],
      beneficiaries: []
    });
  }
  onScroll() {
    if (this.searchKey == null || this.searchKey == "") { this.searchKey = " " }
    this.getCasesLookup(null, this.searchKey, this.index, this.size, false);

  }

  Search() {
    if (this.searchKey == null || this.searchKey == "") { this.searchKey = " " }
    this.index = 1;
    this.searchKeyID = null;
    this.getCasesLookup(null, this.searchKey, this.index, this.size, true);
  }
  SecarchByID() {
    if (this.searchKey == null || this.searchKeyID == 0) { this.searchKeyID = null }
    this.index = 1;
    this.getCasesLookup(this.searchKeyID, " ", this.index, this.size, true);
  }
}
