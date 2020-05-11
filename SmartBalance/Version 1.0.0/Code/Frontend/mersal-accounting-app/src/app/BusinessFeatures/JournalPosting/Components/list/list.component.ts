import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { process, State } from '@progress/kendo-data-query';

import { PostSearch } from '../../Models/search.model';
import { JournalPostingService } from '../../Services/journal-posting.service';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { GridDataResult, PageChangeEvent, GridComponent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { SettingService } from '../../../Setting/Services/setting.service';
import { PostingSetting } from '../../../Setting/Models/posting-setting.model';
import { Observable } from 'rxjs';
import {PaginationOptions} from '../../../../SharedFeatures/SharedMain/Models/pagination-options.model';
import {PaginationService} from '../../../../SharedFeatures/SharedMain/Services/pagination.service';
 
@Component({
  selector: 'journal-posting-list',
  styleUrls: ['./list.component.scss'],
  templateUrl: './list.component.html'
})
export class ListComponent implements OnInit {

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private translateService: TranslateService,
    private notification: NotificationService,
    private journalPostingService: JournalPostingService,
    private ReceiptsServ: FinancialService,
    private settingService: SettingService,
    private paginationService: PaginationService
  ) { }

  ngOnInit(): void {
    this.pageSize = this.paginationService.getPaginationOptions().pageSize;
    this.pagenationSizeList = this.paginationService.getPaginationOptions().pagenationSizeList;
    this.pagenationSize = {value: this.pageSize};

    this.setLanguageSubscriber();
    this.getResourceKeys();
    this.getPostingSetting();
    this.getAutomaticPostingOptions();
    // this.getJournalTypesLookup();
    this.getList();
    this.extractRouteParams();
  }

  extractRouteParams() {
    let pageIndex = +this.route.snapshot.params['pageIndex'];

    this.pageIndex = 0;
    if (pageIndex) {
      this.pageIndex = pageIndex;
      this.skip = this.pageIndex * this.pageSize;  
    }
  }

  getResourceKeys() {
    this.translateService.get([
      'shared.all'
    ]).subscribe(res => {
      if (res) {
        this.allKey = res['shared.all'];
      }
    });
  }

  getPostingSetting(): void {
    this.ListLoading = true;
    this.settingService.getPostingSetting()
      .subscribe(res => {
        this.ListLoading = false;
        this.postingSetting = res;
      },
        (error) => {
          this.ListLoading = false;
        },
        () => {

        })
  }
  isAutomaticPostingChange(event) {
    //debugger;
    this.pageIndex = 0;
    if (event.value == 0) {
      this.postSearch.isAutomaticPosting = false;
    }
    else if (event.value == 1) {
      this.postSearch.isAutomaticPosting = true;
    }

    if(this.postSearch.isAutomaticPosting == true) {
    this.isAutomaticPosting = 1;
    }
    else if(this.postSearch.isAutomaticPosting == false) {
      this.isAutomaticPosting = 0;
      }

    this.getList();
  }
  //   journalTypeChange(event){
  //     //debugger;
  //     this.pageIndex=0;
  //     this.postSearch.journalType=event.value;
  //     this.journalType=this.postSearch.journalType;
  //     this.getList();
  //   }

  dataStateChange(state: DataStateChangeEvent): void {
    //debugger;
    this.skip = state.skip;
    this.pageIndex = (this.skip / this.pageSize);
    this.state = state;
    this.filter = this.state.filter.filters;
    if (this.filter.length > 0) {
      for (var _i = 0; _i < this.filter.length; _i++) {
        if (this.filter[_i].filters) {
          var x = this.filter[_i].filters;
          this.postSearch.dateFrom = x[0].value.toISOString().substring(0, 10);
          this.postSearch.dateTo = x[1].value.toISOString().substring(0, 10);
          //this.filter.splice( _i,1);      
        } else {
          this.postSearch.dateFrom = new Date(new Date().setMonth(new Date().getMonth() - 1)).toISOString().substring(0, 10);
          this.postSearch.dateTo = new Date(Date.now()).toISOString().substring(0, 10);
        }

        if (this.filter[_i].field == "id") {
          this.postSearch.id = this.filter[_i].value;
        }

        if (this.filter[_i].field == "isAutomaticPosting") {
          this.postSearch.isAutomaticPosting = this.filter[_i].value;
        }

        if (this.filter[_i].field == "date") {
          this.postSearch.dateFrom = this.filter[_i].value.toISOString().substring(0, 10);
          this.postSearch.dateTo = new Date(Date.now()).toISOString().substring(0, 10);
        }
      }
      this.postSearch.filters = this.filter;
      this.pageIndex = 0;
    } else {
      this.postSearch = new PostSearch();

      if(this.isAutomaticPosting == 0){
      this.postSearch.isAutomaticPosting = false;
      }
      else if(this.isAutomaticPosting == 1) {
        this.postSearch.isAutomaticPosting = true;
      }
      //    this.postSearch.journalType=this.journalType;   
    }
    //debugger;
    this.postSearch.sort = this.state.sort;
    this.getList();
  }

  public pageChange(event: PageChangeEvent): void {
    this.pageIndex = (event.skip / this.pageSize);

    let url = [`/journal-posting/list/${this.pageIndex}`];
    this.router.navigate(url);
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

  createAllFilter(): KendoDropDown {
    let record = new KendoDropDown();
    record.text = this.allKey;
    record.value = null;
    return record;
  }

  getAutomaticPostingOptions() {
    this.translateService.get([
      'shared.true',
      'shared.false'
    ])
      .subscribe(res => {
        var array = new Array<any>();

        array.push(this.createAllFilter());

        var recordTrue = new KendoDropDown();
        recordTrue.text = res['shared.true'];
        recordTrue.value = 1;
        array.push(recordTrue);

        var recordFalse = new KendoDropDown();
        recordFalse.text = res['shared.false'];
        recordFalse.value = 0;
        array.push(recordFalse);

        this.AutomaticPostingDropDownData = array;
      });
  }

  //    getJournalTypesLookup() {
  //     this.bankingService.getJournalTypes()
  //     .subscribe(res =>{
  //         var array=new Array<any>();

  //         array.push(this.createAllFilter());

  //         res.collection.forEach(function(item){
  //           var record= new KendoDropDown();
  //           record.text=item.name;
  //           record.value=item.id;
  //           array.push(record);
  //         });
  //         this.journalTypesDropDownData=array;
  //       },
  //       (error) => {         
  //         this.notification.showOperationFailed();
  //       }        
  //       );
  //   }

  getList() {
    this.postSearch.pageSize = this.pageSize;
    this.postSearch.pageIndex = this.pageIndex;
    this.ListLoading = true;

    //this.postSearch.bank=(this.bankId ? this.bankId.value : this.bankId);
    //this.postSearch.journalType=(this.journalTypeId? this.journalTypeId.value : this.journalTypeId);
    debugger
    this.journalPostingService.getJournalPostingsByPost(this.postSearch)
      .subscribe(res => {
        this.ListLoading = false;
        this.gridView = {
          data: res.collection,
          total: res.totalCount
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

  setItemToDelete(id: any) {
    this.itemIdToDelete = id;
  }

 
  gotoList() {
    let url = [`/journal-posting/list`];
    this.router.navigate(url);
  }

  pagenationSizeChange(event: any) {
    debugger;
    this.paginationService.setPaginationOptions(this.pagenationSize.value);
    if (this.pageIndex == 0) {
      this.pageSize = this.pagenationSize.value;
      this.pageIndex = 0;
      this.skip = 0;
      this.getList();
    }
    else {
      this.gotoList();
    }
  }


  pagenationSize: any;
  pagenationSizeList: any[];
  //page
  pageSize;
  pageIndex: number = 0;
  total: number;
  skip = 0;
  gridView: GridDataResult;
  data: any[];
  searchForm: FormGroup;
  language: any;
  itemIdToDelete: any;
  showAdvancedSearch: boolean = false;
  //banks: any[] = [];// BranchLookup[] = [];
  //journalTypes: any[] = [];
  list: any[] = [];
  ListLoading: boolean = false;
  public state: State = {
    // Initial filter descriptor
    filter: {
      logic: 'and',
      filters: []
    }
  };
  bankId: any;
  journalTypeId: any;
  public AutomaticPostingDropDownData: Array<KendoDropDown>;
  //public journalTypesDropDownData: Array<KendoDropDown>;
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };
  postSearch: PostSearch = new PostSearch();
  filter: any;
  isAutomaticPosting?: number;
  //journalType: number;
  allKey: string;
  postingSetting: PostingSetting = {
    isBulkPosting: false,
    isPostingAutomatic: true,
    allowPostingAccountCurrencyMisMatch: false
  };
}