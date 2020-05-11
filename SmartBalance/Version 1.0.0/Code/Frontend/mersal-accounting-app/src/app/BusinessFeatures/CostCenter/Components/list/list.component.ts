import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { process, State } from '@progress/kendo-data-query';

import { PostSearch } from '../../Models/search.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { GridDataResult, PageChangeEvent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { CostCenterService } from '../../Services/cost-center.service';
import { CostCenterTypeService } from '../../../CostCenterType/Services/cost-center-type.service'
import { PaginationService } from '../../../../SharedFeatures/SharedMain/Services/pagination.service';

@Component({
  selector: 'cost-center-list',
  styleUrls: ['./list.component.scss'],
  templateUrl: './list.component.html'
})

export class ListComponent implements OnInit {

  constructor(
    private router: Router,
    private translateService: TranslateService,
    private notification: NotificationService,
    private costCenterService: CostCenterService,
    private costCenterTypeService: CostCenterTypeService,
    private paginationService: PaginationService
  ) { }

  ngOnInit(): void {
    this.pageSize = this.paginationService.getPaginationOptions().pageSize;
    this.pagenationSizeList = this.paginationService.getPaginationOptions().pagenationSizeList;
    this.pagenationSize = { value: this.pageSize };

    this.setLanguageSubscriber();
    this.getResourceKeys();
    this.getList();
    this.getCostCenterTypeLookup();
  }

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
  CostCenters: any[] = [];
  journalTypes: any[] = [];
  list: any[] = [];
  ListLoading: boolean = false;
  costCenterTypes: Array<KendoDropDown>;

  public state: State = {
    // Initial filter descriptor
    filter: {
      logic: 'and',
      filters: []
    }
  };

  CostCenterId: any;
  public CostCentersDropDownData: Array<KendoDropDown>;
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };

  postSearch: PostSearch = new PostSearch();
  filter: any;
  CostCenter: number;
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

  CostCenterChange(event) {
    //debugger;
    this.pageIndex = 0;
    //this.postSearch.bank = event.value;
    //this.bank = this.postSearch.bank;
    this.getList();
  }

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
          //this.postSearch.dateFrom = x[0].value.toISOString().substring(0, 10);
          //this.postSearch.dateTo = x[1].value.toISOString().substring(0, 10);
          this.filter.splice(_i, 1);
        } else {
          //this.postSearch.dateFrom = new Date(new Date().setMonth(new Date().getMonth() - 1)).toISOString().substring(0, 10);
          //this.postSearch.dateTo = new Date(Date.now()).toISOString().substring(0, 10);
        }

        if (this.filter[_i].field == "code") {
          this.postSearch.code = this.filter[_i].value;
        }

        if (this.filter[_i].field == "name") {
          this.postSearch.name = this.filter[_i].value;
        }

        // if (this.filter[_i].field == "isActive") {
        //   this.postSearch.isActive = this.filter[_i].value.toISOString().substring(0, 10);
        // }

        if (this.filter[_i].field == "openingCredit") {
          this.postSearch.openingCreditTo = this.filter[_i].value;
        }

        if (this.filter[_i].field == "costCenterTypeName") {
          this.postSearch.costCenterTypeId = this.filter[_i].value;
        }
      }
      this.postSearch.filters = this.filter;
      this.pageIndex = 0;
    } else {
      this.postSearch = new PostSearch();
      //this.postSearch.bank = this.bank;
      //this.postSearch.journalType = this.journalType;
    }
    //debugger;
    this.postSearch.sort = this.state.sort;
    this.getList();
  }

  public pageChange(event: PageChangeEvent): void {
    this.pageIndex = (event.skip / this.pageSize);

    let url = [`/cost-center/list/${this.pageIndex}`];
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

  getCostCenterTypeLookup()
  {
    debugger;
    this.costCenterTypeService.getCostCenterTypesLookups().subscribe(res => {
      //this.costCenterTypes = res.collection;
      this.costCenterTypes = new Array<KendoDropDown>();
      let record = new KendoDropDown();
    record.text = this.allKey;
    record.value = null;
      this.costCenterTypes.push(record);
      res.collection.forEach(r =>{
        var recordAll = new KendoDropDown();
        recordAll.text = r.displyedName;
        recordAll.value = r.id;
        this.costCenterTypes.push(recordAll);
        });
    });
    console.log(this.costCenterTypes);
  }

  costCenterTypeChange(event){
    debugger;
    this.pageIndex = 0;
    this.postSearch.costCenterTypeId = event;
    this.getList();
  }

  getList() {
    this.postSearch.pageSize = this.pageSize;
    this.postSearch.pageIndex = this.pageIndex;
    this.ListLoading = true;

    //this.postSearch.bank = (this.bankId ? this.bankId.value : this.bankId);
    //debugger
    this.costCenterService.getCostCentersByPost(this.postSearch)
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
 
  gotoList() {
    let url = [`/cost-center/list`];
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
}