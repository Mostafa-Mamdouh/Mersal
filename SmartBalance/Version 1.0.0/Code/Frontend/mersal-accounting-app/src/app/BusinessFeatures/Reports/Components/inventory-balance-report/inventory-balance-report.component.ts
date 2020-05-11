import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { TranslateService } from '@ngx-translate/core';

import { PostSearch } from '../../../Financial/Models/search.model';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { InventoryBalanceReport } from '../../Models/report-filter.model';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseService } from '../../../../SharedFeatures/SharedMain/Services/base.service';
import {InventoryService} from '../../../Store/Services/Inventory.service';

@Component({
  selector: 'app-inventory-balance-report',
  templateUrl: './inventory-balance-report.component.html',
  styleUrls: ['./inventory-balance-report.component.css']
})
export class InventoryBalanceReportComponent implements OnInit {

  searchForm: FormGroup;
  searchModel: InventoryBalanceReport;

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
  Inventorys: any[];


  constructor(private fb: FormBuilder,
    private ReceiptsServ: FinancialService,
    private notificationService: NotificationService,
    private router: Router,
    private route: ActivatedRoute,
    private baseService: BaseService,
    private inventoryService: InventoryService,
    private translateService: TranslateService
  ) {

  }

  ngOnInit() {
    this.date.setDate(this.date.getDate() - 7);
    this.buildForm();
    this.getInventorysLookups();
  }

  getInventorysLookups() {
    this.ListLoading = true;
    this.inventoryService.getInventorysLookups()
      .subscribe(res => {
        this.Inventorys = res.collection;
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

      inventoryId: [null, [Validators.required]],
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
      let inventoryId = this.searchModel.inventoryId;
      let dateFrom = this.searchModel.dateFrom.toISOString().slice(0, 10);
      let dateTo = this.searchModel.dateTo.toISOString().slice(0, 10);
      let url: string = `${rootUrl}Reports/InventoryBalanceReport/?inventoryId=${inventoryId}&dateFrom=${dateFrom}&dateTo=${dateTo}&lang=${lang}`;

      window.open(url, "_blank");
    }
    else {
      this.notificationService.showDataMissingError();
    }
  }

}
