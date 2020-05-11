import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { TranslateService } from '@ngx-translate/core';

import { PostSearch } from '../../../Financial/Models/search.model';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { VendorReportSearch } from '../../Models/report-filter.model';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseService } from '../../../../SharedFeatures/SharedMain/Services/base.service';
import { VendorService } from '../../../Vendor/Services/vendor.service';

@Component({
  selector: 'app-vendor-account-report',
  templateUrl: './vendor-account-report.component.html',
  styleUrls: ['./vendor-account-report.component.css']
})
export class VendorAccountReportComponent implements OnInit {

  searchForm: FormGroup;
  searchModel: VendorReportSearch;

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
  Vendors: any[];


  constructor(private fb: FormBuilder,
    private ReceiptsServ: FinancialService,
    private notificationService: NotificationService,
    private router: Router,
    private route: ActivatedRoute,
    private baseService: BaseService,
    private vendorService: VendorService,
    private translateService: TranslateService
  ) {

  }

  ngOnInit() {
    this.date.setDate(this.date.getDate() - 7);
    this.buildForm();
    this.getVendorsLookups();
  }
  getVendorsLookups() {
    this.ListLoading = true;
    this.vendorService.getVendorsLookups()
      .subscribe(res => {
        this.Vendors = res.collection;
        this.ListLoading = false;
      }, () => {
        this.notificationService.showOperationFailed();
        this.ListLoading = false;
      }, () => {
      });
  }

  buildForm(): void {
    this.searchForm = this.fb.group({
      vendorId: [null, [Validators.required]],
      dateFrom: [this.date],
      dateTo: [new Date()]
    });
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
      let vendorId = this.searchModel.vendorId;
      let dateFrom = this.searchModel.dateFrom.toISOString().slice(0, 10);
      let dateTo = this.searchModel.dateTo.toISOString().slice(0, 10);
      let url: string = `${rootUrl}Reports/VendorAccountReport/?vendorId=${vendorId}&dateFrom=${dateFrom}&dateTo=${dateTo}&lang=${lang}`;

      window.open(url, "_blank");
    }
    else {
      this.notificationService.showDataMissingError();
    }
  }

}
