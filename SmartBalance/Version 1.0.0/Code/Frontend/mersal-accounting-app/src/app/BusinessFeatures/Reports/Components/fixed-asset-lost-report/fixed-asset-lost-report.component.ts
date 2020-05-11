import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { TranslateService } from '@ngx-translate/core';

import { PostSearch } from '../../../Financial/Models/search.model';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { FixedAssetLostReportSearch } from '../../Models/report-filter.model';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseService } from '../../../../SharedFeatures/SharedMain/Services/base.service';
import {BankService} from '../../../Bank/Services/bank.service';
import { LocationService } from '../../../Location/Services/location.service';

@Component({
  selector: 'app-fixed-asset-lost-report',
  templateUrl: './fixed-asset-lost-report.component.html',
  styleUrls: ['./fixed-asset-lost-report.component.css']
})
export class FixedAssetLostReportComponent implements OnInit {

  searchForm: FormGroup;
  searchModel: FixedAssetLostReportSearch;

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
  locations: any[];
  allKey: string;


  constructor(private fb: FormBuilder,
    private ReceiptsServ: FinancialService,
    private notificationService: NotificationService,
    private router: Router,
    private route: ActivatedRoute,
    private baseService: BaseService,
    private bankService: BankService,
    private translateService: TranslateService,
    private locationService: LocationService
  ) {

  }

  ngOnInit() {
    this.getAllKey();
    this.date.setDate(this.date.getDate() - 7);
    this.buildForm();
    this.getLocationsLookups();
  }

  getAllKey(): void {
    let key = 'shared.all';
    this.translateService.get([key])
    .subscribe(res => {
      this.allKey = res[key];
    });
  }

  getLocationsLookups() {
    this.ListLoading = true;
    this.locationService.getLocationsLookups()
      .subscribe(res => {
        this.locations = [];   
        this.locations.push({
          id: null,
          displyedName: this.allKey
        });       
         res.collection.forEach(item => {
           this.locations.push(item);
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

      locationId: [null],
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
      let locationId = this.searchModel.locationId;
      let dateFrom = this.searchModel.dateFrom.toISOString().slice(0, 10);
      let dateTo = this.searchModel.dateTo.toISOString().slice(0, 10);
      let url: string = `${rootUrl}Reports/FixedAssetsLostReport/?locationId=${locationId}&dateFrom=${dateFrom}&dateTo=${dateTo}&lang=${lang}`;

      window.open(url, "_blank");
    }
    else {
      this.notificationService.showDataMissingError();
    }
  }

}
