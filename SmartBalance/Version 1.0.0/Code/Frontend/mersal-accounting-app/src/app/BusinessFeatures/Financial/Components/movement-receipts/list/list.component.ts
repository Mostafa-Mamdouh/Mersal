import { PaymentMethod } from './../../../Models/payment-methods.model';
import { BranchLookup } from './../../../Models/branch-lookup.model';
import { Search, PostSearch } from './../../../Models/search.model';
import { FinancialService } from '../../../Services/financial.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { process, State } from '@progress/kendo-data-query';
import { NotificationService } from '../../../../../SharedFeatures/SharedMain/Services/notification.service';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { MovmentsList } from '../../../Models/movement-list.model';
import { GridDataResult, PageChangeEvent, GridComponent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { KendoDropDown } from '../../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { PaginationOptions } from '../../../../../SharedFeatures/SharedMain/Models/pagination-options.model';
import { PaginationService } from '../../../../../SharedFeatures/SharedMain/Services/pagination.service';
import { PermissionEnum } from '../../../../User/Models/permission-enum';
import { CurrentUserService } from '../../../../User/Services/current-user.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListReceiptsComponent implements OnInit {

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private translateService: TranslateService,
    private notification: NotificationService,
    private ReceiptsServ: FinancialService,
    private paginationService: PaginationService,
    private currentUserService: CurrentUserService,
  ) {
  }

  ngOnInit() {
    this.pageSize = this.paginationService.getPaginationOptions().pageSize;
    this.pagenationSizeList = this.paginationService.getPaginationOptions().pagenationSizeList;
    this.pagenationSize = {value: this.pageSize};

    this.setLanguageSubscriber();
    this.setCanPrintRecipt();
    this.getResourceKeys();
    this.getBranchLookup();
    this.getReceivingMethodsLookup();
 
    this.extractRouteParams();
  }

  extractRouteParams() {
    let pageIndex = +this.route.snapshot.params['pageIndex'];

    this.pageIndex = 0;
    if (pageIndex) {
      this.pageIndex = pageIndex;
      this.skip = this.pageIndex * this.pageSize;
    }

    this.getList();
  }

  setCanPrintRecipt(): void {
    this.canPrintRecipt = false;

    let user = this.currentUserService.getCurrentUser();
    if (user &&
      user.permissions &&
      user.permissions.find(x => x == +PermissionEnum.printReceipt)) {
      this.canPrintRecipt = true;
    }
  }

  branchChange(event) {
    this.pageIndex = 0;
    this.postSearch.branch = event.value;
    this.branch = this.postSearch.branch;
    this.getList();
  }
  paymentChange(event) {
    debugger;
    this.pageIndex = 0;
    this.postSearch.payment = event.value;
    this.payment = this.postSearch.payment;
    this.getList();
  }

  toggleAdvancedSearch() {
    this.showAdvancedSearch = !this.showAdvancedSearch;
  }

  dataStateChange(state: DataStateChangeEvent): void {
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
          this.postSearch.dateTo = new Date().toISOString().substring(0, 10);
        }

        if (this.filter[_i].field == "date") {
          this.postSearch.dateFrom = this.filter[_i].value.toISOString().substring(0, 10);
          this.postSearch.dateTo = new Date().toISOString().substring(0, 10);
        }

        if (this.filter[_i].field == "code") {
          this.postSearch.code = this.filter[_i].value;
        }

        if (this.filter[_i].field == "delegateManReciptNumber") {
          this.postSearch.delegateManReciptNumber = this.filter[_i].value;
        }

        if (this.filter[_i].field == "amount") {
          this.postSearch.amountTo = this.filter[_i].value;
        }
      }
      this.postSearch.filters = this.filter;
      this.pageIndex = 0;
    }
    else {
      this.postSearch = new PostSearch();
      this.postSearch.branch = this.branch;
      this.postSearch.payment = this.payment;
    }
    //debugger;
    this.postSearch.sort = this.state.sort;
    this.getList();
  }

  public pageChange(event: PageChangeEvent): void {
    this.pageIndex = (event.skip / this.pageSize);

    let url = [`/financial/financial-list/${this.pageIndex}`];
    this.router.navigate(url);
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
  setLanguageSubscriber(): void {
    this.language = this.translateService.currentLang;
    this.translateService.onLangChange.subscribe(val => {
      this.language = val.lang;
      this.getResourceKeys();
    },
      (error) => { },
      () => { });
  }
  getList() {
    this.postSearch.pageSize = this.pageSize;
    this.postSearch.pageIndex = this.pageIndex;
    this.ListLoading = true;

    this.ReceiptsServ.getReceiptByPost(this.postSearch)
      .subscribe(res => {
        this.ListLoading = false;
        //debugger;       
        for (let index = 0; index < res.collection.length; index++) {
          res.collection[index].printRecipt = false;
          
        }
        this.gridView = {
          data: res.collection,
          total: res.totalCount
        };
        console.log(JSON.stringify(res))
      },
        (error) => {
          this.ListLoading = false;

          // debugger;
          this.notification.showOperationFailed();
          this.list = [];
        }
      );
  }
  createAllFilter(): KendoDropDown {
    let record = new KendoDropDown();
    record.text = this.allKey;
    record.value = null;

    return record;
  }
  getBranchLookup() {
    this.ReceiptsServ.getBranchLookup()
      .subscribe(res => {
        var array = new Array<any>();

        array.push(this.createAllFilter());

        res.forEach(function (item) {
          var record = new KendoDropDown();
          record.text = item.name;
          record.value = item.id;
          array.push(record);
        });
        this.BranchesDropDownData = array;
      },
        error => {
          error;
          this.notification.showOperationFailed();
        }

      );
  }
  getReceivingMethodsLookup() {
    this.ReceiptsServ.getReceivingMethodsLookup()
      .subscribe(res => {
        var array = new Array<any>();

        array.push(this.createAllFilter());

        res.forEach(function (item) {
          var record = new KendoDropDown();
          record.text = item.name;
          record.value = item.id;
          array.push(record);
        });
        this.PaymentDropDownData = array;
      },
        error => {
          error;
          this.notification.showOperationFailed();
        }

      );
  }
  // Search(search:Search) {
  //       this.pageIndex=0;
  //       this.branchId=null;
  //       this.PaymentId=null;
  //       this.searchModel=search;
  //       this.postSearch.branch=this.searchModel.Branch?this.searchModel.Branch.value:null;
  //       this.postSearch.dateFrom=this.searchModel.DateFrom.toISOString().substring(0, 10);
  //       this.postSearch.dateTo=this.searchModel.DateTo.toISOString().substring(0, 10);
  //       this.postSearch.amountFrom=this.searchModel.AmountFrom;
  //       this.postSearch.amountTo=this.searchModel.AmountTo;
  //       this.getList();
  // } 
  setItemToDelete(id: any) {
    this.itemIdToDelete = id;
  }
  print(): void {
    if (this.canPrintRecipt) {
      let printContents, popupWin;
      printContents = document.getElementById('print-section').innerHTML;
      popupWin = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
      popupWin.document.open();
      popupWin.document.write(`
      <html>
        <head>
          <title>Print tab</title>
          <style>
          //........Customized style.......
          </style>
        </head>
    <body onload="window.print();window.close()">${printContents}</body>
      </html>`
      );
      popupWin.document.close();
    }
  }
 
  gotoList() {
    let url = [`/financial/financial-list`];
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

  printRecipt(dataItem)
  {
    dataItem.printRecipt = true;
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
  searchModel: Search;

  language: any;
  itemIdToDelete: any;

  showAdvancedSearch: boolean = false;

  Branches: BranchLookup[] = [];
  list: MovmentsList[] = [];

  PaymentId;
  ListLoading: boolean = false;
  allKey: string;


  public state: State = {
    // Initial filter descriptor
    filter: {
      logic: 'and',
      filters: []
    }
  };
  //branch
  branchId: number;
  public BranchesDropDownData: Array<KendoDropDown>;
  public PaymentDropDownData: Array<KendoDropDown>;
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };

  postSearch: PostSearch = new PostSearch();
  filter: any;
  branch: number;
  payment: number;
  canPrintRecipt: boolean = false; 
}
