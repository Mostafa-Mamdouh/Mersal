import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { TranslateService } from '@ngx-translate/core';

import { PostSearch } from '../../../Financial/Models/search.model';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { DonationCasesBalanceReport } from '../../Models/report-filter.model';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseService } from '../../../../SharedFeatures/SharedMain/Services/base.service';
import { DonatorService } from '../../../Donator/Services/donator.service';

@Component({
  selector: 'app-donation-cases-balance-report',
  templateUrl: './donation-cases-balance-report.component.html',
  styleUrls: ['./donation-cases-balance-report.component.css']
})
export class DonationCasesBalanceReportComponent implements OnInit {

  searchForm: FormGroup;
  searchModel: DonationCasesBalanceReport;

  language: any;
  itemIdToDelete: any;
  date:Date=new Date();
 
  showAdvancedSearch: boolean = false;
  ListLoading: boolean = false;
  postSearch: PostSearch = new PostSearch();

  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };
  cases: any[];
  allKey: string;


  constructor(private fb: FormBuilder,
    private ReceiptsServ: FinancialService,
    private notificationService: NotificationService,
    private router: Router,
    private route: ActivatedRoute,
    private baseService: BaseService,
    private donatorService: DonatorService,
    private translateService: TranslateService
  ) {

  }

  ngOnInit() {
    this.getAllKey();
    this.date.setDate(this.date.getDate() - 7);
    this.buildForm();
    this.getLocalCasesLookups();
  }

  getAllKey(): void {
    let key = 'shared.all';
    this.translateService.get([key])
    .subscribe(res => {
      this.allKey = res[key];
    });
  }

  getLocalCasesLookups() {
    this.ListLoading = true;
    this.donatorService.getLocalCasesLookups()
      .subscribe(res => {  
        this.cases = [];  
        this.cases.push({
          externalId: null,
          name: this.allKey
        });       
        res.collection.forEach(item => {
          this.cases.push({externalId: item.externalId, name: item.name});
        });
        this.ListLoading = false;
      }, () => {
        this.notificationService.showOperationFailed();
        this.ListLoading = false;
      }, () => {
      });
  }

  // getAccountChartsLookup() {
  //   this.ListLoading = true;
  //   this.ReceiptsServ.getAccountChartsLookup()
  //     .subscribe(res => {
  //       this.AccountCharts = res;
  //       this.ListLoading = false;
  //     }, () => {
  //       this.notificationService.showOperationFailed();
  //       this.ListLoading = false;
  //     }, () => {
  //     });
  // }

  buildForm(): void {
    this.searchForm = this.fb.group({
      caseId: [null],
      dateFrom: [this.date],
      dateTo: [new Date()]
    });

    // this.searchForm.valueChanges.subscribe(res => {
    //   debugger;

    // });
  }
  gotoReport(): void {
    if (this.searchForm.valid) {
      //this.notificationService.showUnderDevelopmentInfo();

      this.searchModel = this.searchForm.value;

      if (this.searchModel.dateFrom > this.searchModel.dateTo) {
        this.notificationService.showTranslateError('financial.dateRang');
        return;
      }

      let lang = this.translateService.currentLang;
      //let userId = this._currentUserService.getCurrentUserIdString();

      let rootUrl = `${this.baseService.getEnvironmentApiUrl().mersalReportUrl}`;
      let caseId = this.searchModel.caseId;
      let dateFrom = this.searchModel.dateFrom.toISOString().slice(0, 10);
      let dateTo = this.searchModel.dateTo.toISOString().slice(0, 10);
      let url: string = `${rootUrl}Reports/DonationCasesBalanceReport/?caseId=${caseId}&dateFrom=${dateFrom}&dateTo=${dateTo}&lang=${lang}`;

      let params = {
        access_token: 'An access_token',
        other_header: 'other_header'
    };

      window.open(url, "_blank", JSON.stringify(params));
    }
    else {
      this.notificationService.showDataMissingError();
    }
  }

}
