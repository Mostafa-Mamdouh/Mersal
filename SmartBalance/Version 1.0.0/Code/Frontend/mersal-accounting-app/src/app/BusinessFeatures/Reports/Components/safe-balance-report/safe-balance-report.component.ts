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
import { SafeService } from '../../../Safe/Services/safe.service';

@Component({
  selector: 'app-safe-balance-report',
  templateUrl: './safe-balance-report.component.html',
  styleUrls: ['./safe-balance-report.component.css']
})
export class SafeBalanceReportComponent implements OnInit {

  searchForm: FormGroup;
  searchModel: ReportSearch;

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
  Safes: any[];


  constructor(private fb: FormBuilder,
    private ReceiptsServ: FinancialService,
    private notificationService: NotificationService,
    private router: Router,
    private route: ActivatedRoute,
    private baseService: BaseService,
    private safeService: SafeService,
    private translateService: TranslateService
  ) {

  }

  ngOnInit() {
    this.date.setDate(this.date.getDate() - 7);
    this.buildForm();
    this.getSafesLookups();
  }

  getSafesLookups() {
    this.ListLoading = true;
    this.safeService.getSafesLookups()
      .subscribe(res => {
        this.Safes = res.collection;
        this.ListLoading = false;
      }, () => {
        this.notificationService.showOperationFailed();
        this.ListLoading = false;
      }, () => {
      });
  }

  buildForm(): void {
    this.searchForm = this.fb.group({
      safeId: [null, [Validators.required]],
      dateFrom: [this.date],
      dateTo: [new Date()]
    });
  }
  gotoReport(): void {
    if(this.searchForm.valid) {
      //this.notificationService.showUnderDevelopmentInfo();

    this.searchModel = this.searchForm.value;
    if (this.searchModel.dateFrom > this.searchModel.dateTo) {
      this.notificationService.showTranslateError('financial.dateRang');
      return;
    }

    let lang = this.translateService.currentLang;
    //let userId = this._currentUserService.getCurrentUserIdString();

    let rootUrl = `${this.baseService.getEnvironmentApiUrl().mersalReportUrl}`;
    let safeId =this.searchModel.safeId;
    let dateFrom = this.searchModel.dateFrom.toISOString().slice(0, 10);
    let dateTo = this.searchModel.dateTo.toISOString().slice(0, 10);
    let url: string = `${rootUrl}Reports/SafeBalanceReport/?safeId=${safeId}&dateFrom=${dateFrom}&dateTo=${dateTo}&lang=${lang}`;

    window.open(url, "_blank");

  }
  else {
    this.notificationService.showDataMissingError();
  }
  }

}
