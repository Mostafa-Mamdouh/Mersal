import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { TranslateService } from '@ngx-translate/core';

import { PostSearch } from '../../../Financial/Models/search.model';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { ReportSearch } from '../../Models/report-filter.model';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseService } from '../../../../SharedFeatures/SharedMain/Services/base.service';
import { CurrencyService } from '../../../Currency/Services/currency.service';

@Component({
  selector: 'app-accounts-report',
  templateUrl: './accounts-report.component.html',
  styleUrls: ['./accounts-report.component.css']
})
export class AccountsReportComponent implements OnInit {

  searchForm: FormGroup;
  searchModel: ReportSearch;

  language: any;
  itemIdToDelete: any;
  date: Date = new Date();

  showAdvancedSearch: boolean = false;
  ListLoading: boolean = false;
  postSearch: PostSearch = new PostSearch();

  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };
  AccountCharts: any[];


  constructor(private fb: FormBuilder,
    private currencyService: CurrencyService,
    private ReceiptsServ: FinancialService,
    private notificationService: NotificationService,
    private router: Router,
    private route: ActivatedRoute,
    private baseService: BaseService,
    private translateService: TranslateService
  ) {

  }

  ngOnInit() {
    this.date.setDate(this.date.getDate() - 7);
    this.buildForm();
    this.getAccountChartsLookup();
    this.getCurrencysLookups();
  }

  getAccountChartsLookup() {
    this.ListLoading = true;
    this.ReceiptsServ.getAccountChartsLookup()
      .subscribe(res => {
        this.AccountCharts = res;
        this.ListLoading = false;
      }, () => {
        this.notificationService.showOperationFailed();
        this.ListLoading = false;
      }, () => {
      });
  }

  getCurrencysLookups() {
    //this.ListLoading = true;
    this.currencyService.getCurrencysLookups()
      .subscribe(res => {
        this.currencys = [{ id: null, displyedName: "" }];
        res.collection.forEach(item => {
          this.currencys.push(item);
        });
        //this.ListLoading = false;
      }, (error) => {
        this.notificationService.showOperationFailed();
        //this.ListLoading = false;
      }, () => {
      });
  }

  buildForm(): void {
    this.searchForm = this.fb.group({
      accountChartId: [null, [Validators.required]],
      currencyId: [null],
      dateFrom: [this.date],
      dateTo: [new Date()]
    });
  }

  gotoReport(): void {
    if (this.searchForm.valid) {

      this.searchModel = this.searchForm.value;
      if (this.searchModel.dateFrom > this.searchModel.dateTo) {
        this.notificationService.showTranslateError('financial.dateRang');
        return;
      }

      let lang = this.translateService.currentLang;
      //let userId = this._currentUserService.getCurrentUserIdString();

      let rootUrl = `${this.baseService.getEnvironmentApiUrl().mersalReportUrl}`;
      let accountId = this.searchModel.accountChartId;
      let currencyId = this.searchModel.currencyId;
      let dateFrom = this.searchModel.dateFrom.toISOString().slice(0, 10);
      let dateTo = this.searchModel.dateTo.toISOString().slice(0, 10);
      let url: string = `${rootUrl}Reports/AccountReport/?accountChartId=${accountId}&currencyId=${currencyId}&dateFrom=${dateFrom}&dateTo=${dateTo}&lang=${lang}`;

      window.open(url, "_blank");

      // window.open("http://localhost:56630/Reports/Index/?accountChartId=" + this.searchModel.accountChartId + "&dateFrom=" +
      //   this.searchModel.dateFrom.toISOString().slice(0, 10) + "&dateTo=" + this.searchModel.dateTo.toISOString().slice(0, 10), "_blank");
    }
    else {
      this.notificationService.showDataMissingError();
    }
  }


  currencys: any[];
}