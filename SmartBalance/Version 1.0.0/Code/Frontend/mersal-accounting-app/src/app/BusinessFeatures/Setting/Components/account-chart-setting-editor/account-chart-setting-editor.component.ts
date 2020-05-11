import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { process, State } from '@progress/kendo-data-query';

//import {PurchasingService} from '../../Services/Purchasing.service';
//import { BankingService } from '../../Services/banking.service';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { GridDataResult, PageChangeEvent, GridComponent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { PaginationOptions } from '../../../../SharedFeatures/SharedMain/Models/pagination-options.model';
import { PaginationService } from '../../../../SharedFeatures/SharedMain/Services/pagination.service';
import { SettingService } from '../../Services/setting.service';

@Component({
  selector: 'account-chart-setting-editor',
  styleUrls: ['./account-chart-setting-editor.component.scss'],
  templateUrl: './account-chart-setting-editor.component.html'
})
export class AccountChartSettingeEditorComponent implements OnInit {

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private translateService: TranslateService,
    private notification: NotificationService,
    //private purchasingService: PurchasingService,
    //private bankingService: BankingService,
    //private ReceiptsServ: FinancialService,
    private settingService: SettingService,
    private paginationService: PaginationService
  ) { }

  ngOnInit(): void {
    this.pageSize = this.paginationService.getPaginationOptions().pageSize;  
    this.setLanguageSubscriber();
    this.getResourceKeys();
    //this.getBankLookup();
    //this.getJournalTypesLookup();
    this.getList();
  }

  //page
  pageSize;
  pageIndex: number = 0;
  total: number;
  skip = 0;
  gridView: GridDataResult;
  data: any[];
  searchForm: FormGroup;
  //searchModel: Search;
  language: any;
  itemIdToDelete: any;
  showAdvancedSearch: boolean = false;
  banks: any[] = [];// BranchLookup[] = [];
  journalTypes: any[] = [];
  list: any[] = [];
  ListLoading: boolean = false;

  public levelCount: number;
  journalType: number;
  allKey: string;



  getResourceKeys() {
    this.translateService.get([
      'shared.all'
    ]).subscribe(res => {
      if (res) {
        this.allKey = res['shared.all'];
      }
    });
  }



  public pageChange(event: PageChangeEvent): void {

  }
  setLanguageSubscriber(): void {
    this.language = this.translateService.currentLang;
    this.translateService.onLangChange.subscribe(val => {
      this.language = val.lang;
      this.getResourceKeys();
    },
      (error) => { },
      () => { });
  }

  // createAllFilter(): KendoDropDown {
  //   let record = new KendoDropDown();
  //   record.text = this.allKey;
  //   record.value = null;

  //   return record;
  // }

  // getBankLookup() {
  //   this.bankService.getBanksLookups()
  //     .subscribe(res => {
  //       var array = new Array<any>();

  //       array.push(this.createAllFilter());

  //       res.collection.forEach(function (item) {
  //         var record = new KendoDropDown();
  //         record.text = item.name;
  //         record.value = item.id;
  //         array.push(record);
          
  //       });
  //       this.banksDropDownData = array;
  //     },
  //       (error) => {
  //         this.notification.showOperationFailed();
  //       }
  //     );
  // }

 

  getList() {
    this.ListLoading = true;

    //this.postSearch.bank = (this.bankId ? this.bankId.value : this.bankId);
    //debugger
    this.settingService.getAccountChartSetting()
      .subscribe(res => {
        this.ListLoading = false;
        this.levelCount = res.levelCount;
        this.gridView = {
          data: res.accountChartLevelSettings,
          total: res.accountChartLevelSettings.length
        };
        console.log(res)
      },
        (error) => {
          // debugger;
          this.ListLoading = false;
          this.notification.showOperationFailed();
          this.list = [];
        },
      );
  }
  


 
}