import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { process, State } from '@progress/kendo-data-query';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { JournalEntriesService } from '../../Services/journal-entries.service';
import { GridDataResult, PageChangeEvent, GridComponent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { PostSearch } from '../../Models/search.model';
import { BranchLookup } from '../../../Financial/Models/branch-lookup.model';
import { MovmentsList } from '../../../Financial/Models/movement-list.model';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { PaginationOptions } from '../../../../SharedFeatures/SharedMain/Models/pagination-options.model';
import { PaginationService } from '../../../../SharedFeatures/SharedMain/Services/pagination.service';
import { SettingService } from '../../../Setting/Services/setting.service';
import { PostingSetting } from '../../../Setting/Models/posting-setting.model';
import { UserService } from '../../../User/Services/user.service';
import { PermissionEnum } from 'src/app/BusinessFeatures/User/Models/permission-enum';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
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

  Branches: BranchLookup[] = [];
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

  filter: any;
  postSearch: PostSearch = new PostSearch();

  constructor(
    private notification: NotificationService,
    private translateService: TranslateService,
    private serv: JournalEntriesService,
    private paginationService: PaginationService,
    private settingService: SettingService,
    private router: Router,
    private route: ActivatedRoute,
    private userService: UserService
  ) {
  }

  ngOnInit() {
    this.pageSize = this.paginationService.getPaginationOptions().pageSize;
    this.pagenationSizeList = this.paginationService.getPaginationOptions().pagenationSizeList;
    this.pagenationSize = { value: this.pageSize };

    this.setLanguageSubscriber();
    this.checkIsCurrentUserHassPermission();
    this.getPostingSetting();
    this.extractRouteParams();
    //  this.getResourceKeys();
  }

  extractRouteParams() {
    debugger;
    let previewIndex = this.router.url.indexOf('/journal/preview-list');
    if (previewIndex != -1) {
      //debugger;
      let postReceiptsMovement = this.route.snapshot.params['postReceiptsMovement'];
      let postPaymentMovement = this.route.snapshot.params['postPaymentMovement'];
      let postBankMovement = this.route.snapshot.params['postBankMovement'];
      let postPurchaseInvoice = this.route.snapshot.params['postPurchaseInvoice'];
      let postPurchaseRebate = this.route.snapshot.params['postPurchaseRebate'];
      let postStoreMovement = this.route.snapshot.params['postStoreMovement'];
      let postSalesInvoice = this.route.snapshot.params['postSalesInvoice'];
      let postSalesRebate = this.route.snapshot.params['postSalesRebate'];
      let pageIndex = +this.route.snapshot.params['pageIndex'];
      this.pageIndex = 0;
      if (pageIndex) {
        this.pageIndex = pageIndex;
        this.skip = this.pageIndex * this.pageSize;
      }

      if (postReceiptsMovement == "true") {
        this.postSearch.postReceiptsMovement = true;
      }
      else {
        this.postSearch.postReceiptsMovement = false;
      }

      if (postPaymentMovement == "true") {
        this.postSearch.postPaymentMovement = true;
      }
      else {
        this.postSearch.postPaymentMovement = false;
      }

      if (postBankMovement == "true") {
        this.postSearch.postBankMovement = true;
      }
      else {
        this.postSearch.postBankMovement = false;
      }

      if (postPurchaseInvoice == "true") {
        this.postSearch.postPurchaseInvoice = true;
      }
      else {
        this.postSearch.postPurchaseInvoice = false;
      }

      if (postPurchaseRebate == "true") {
        this.postSearch.postPurchaseRebate = true;
      }
      else {
        this.postSearch.postPurchaseRebate = false;
      }

      if (postStoreMovement == "true") {
        this.postSearch.postStoreMovement = true;
      }
      else {
        this.postSearch.postStoreMovement = false;
      }

      if (postSalesInvoice == "true") {
        this.postSearch.postSalesInvoice = true;
      }
      else {
        this.postSearch.postSalesInvoice = false;
      }

      if (postSalesRebate == "true") {
        this.postSearch.postSalesRebate = true;
      }
      else {
        this.postSearch.postSalesRebate = false;
      }

      this.previewJournal = true;
      this.getList(true);
    }
    else {
      this.previewJournal = false;
      this.getList(false);
    }
  }

  checkIsCurrentUserHassPermission(): void {
    this.userService.isCurrentUserHassPermission(PermissionEnum.approveOrRejectJournalEntriesUnderReview)
    .subscribe(res => {
      this.canApproveOrRejectJournalEntriesUnderReview = res;
    })
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

        });
  }

  dataStateChange(state: DataStateChangeEvent): void {
    debugger
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
          //this.postSearch.dateFrom=new Date(new Date().setMonth(new Date().getMonth() - 1)).toISOString().substring(0, 10);
          //this.postSearch.dateTo=new Date().toISOString().substring(0, 10);    
        }

        if (this.filter[_i].field == "code") {
          this.postSearch.code = this.filter[_i].value;
        }

        if (this.filter[_i].field == "date") {
          this.postSearch.dateFrom = this.filter[_i].value.toISOString().substring(0, 10);
          this.postSearch.dateTo = new Date().toISOString().substring(0, 10);
        }

        if (this.filter[_i].field == "descriptionAr") {
          this.postSearch.descriptionAr = this.filter[_i].value;
        }
        if (this.filter[_i].field == "descriptionEn") {
          this.postSearch.descriptionEn = this.filter[_i].value;
        }

      }
      this.postSearch.filters = this.filter;
      this.pageIndex = 0;
    } else {
      this.postSearch = new PostSearch();
    }

    this.postSearch.sort = this.state.sort;
    this.getList();
  }
  public pageChange(event: PageChangeEvent): void {

  }

  //  getResourceKeys() {
  //    this.translateService.get([
  //      'shared.all'
  //    ]).subscribe(res => {
  //      if(res) {
  //        this.allKey = res['shared.all'];
  //      }
  //    });
  //  }
  setLanguageSubscriber(): void {
    this.language = this.translateService.currentLang;
    this.translateService.onLangChange.subscribe(val => {
      this.language = val.lang;
      //this.getResourceKeys();
    },
      (error) => { },
      () => { });
  }

  getList(preview: boolean = false) {
    //debugger;
    this.postSearch.preview = preview;
    this.postSearch.pageSize = this.pageSize;
    this.postSearch.pageIndex = this.pageIndex;
    this.ListLoading = true;

    this.serv.getJournalEntriesByPost(this.postSearch)
      .subscribe(res => {
        this.ListLoading = false;
        debugger;
        this.list = res.collection;
        this.gridView = {
          data: res.collection,
          total: res.totalCount
        };
        console.log(JSON.stringify(res))

        if (this.postSearch.preview == true && this.list.length == 0) {
          this.notification.showTranslateHtmlInfo_h5('journalEntries.post.noJournalUnderPreview');
        }
      },
        (error) => {
          this.ListLoading = false;
          // debugger;
          this.notification.showOperationFailed();
        }
      );
  }

  approve() {
    //debugger;
    if (this.approveList.length > 0) {

      let model = {
        collection: []//this.approveList
      };

      for (let i = 0; i < this.approveList.length; i++) {
        model.collection.push(this.approveList[i].id);
      }

      this.serv.approveCollection(model)
        .subscribe(res => {
          this.notification.showOperationSuccessed();
          this.gotoJournalList();
        },
          (error) => {
            this.notification.showOperationFailed();
          },
          () => { });
    }
  }
  reject() {
    if (this.rejectList.length > 0) {

      let model = {
        collection: []// this.reject
      };

      for (let i = 0; i < this.rejectList.length; i++) {
        model.collection.push(this.rejectList[i].id);
      }

      this.serv.reject(model)
        .subscribe(res => {
          this.notification.showOperationSuccessed();
          this.gotoJournalList();
        },
          (error) => {
            this.notification.showOperationFailed();
          },
          () => { });
    }
  }

  approveAndRejectList() {
    debugger;

    if(!this.canApproveOrRejectJournalEntriesUnderReview) {
      this.notification.showTranslateHtmlError_h5('error.auth');
      return;
    }

    let model = {
      approvedCollection: [], //this.approveList,
      rejectedCollection: [] //this.rejectList
    };

    for (let i = 0; i < this.approveList.length; i++) {
      model.approvedCollection.push(this.approveList[i].id);
    }

    for (let y = 0; y < this.rejectList.length; y++) {
      model.rejectedCollection.push(this.rejectList[y].id);
    }

    //return;

    this.serv.approveAndRejectCollection(model)
      .subscribe(res => {
        this.notification.showOperationSuccessed();

        this.approveList = [];
        this.approveingList = [];
        this.rejectList = [];
        this.rejectingList = [];

        this.getList(true);
        //this.gotoJournalList();
      },
        (error) => {
          this.notification.showOperationFailed();
        },
        () => {

        });
  }

  approveAll(): void {
    if (this.approveList && this.list && this.approveList.length == this.list.length) {
      this.rejectList = [];
      this.approveList = [];

      this.rejectingList = [];
      this.approveingList = [];
    }
    else {
      this.rejectList = [];
      this.approveList = [];

      this.rejectingList = [];
      this.approveingList = [];

      this.list.forEach(x => {
        this.approveList.push({ id: x.id });
        this.approveingList[x.id] = true;
      });
    }
  }

  rejectAll(): void {
    if (this.rejectList && this.list && this.rejectList.length == this.list.length) {
      this.rejectList = [];
      this.approveList = [];

      this.rejectingList = [];
      this.approveingList = [];
    }
    else {
      this.rejectList = [];
      this.approveList = [];

      this.rejectingList = [];
      this.approveingList = [];

      this.list.forEach(x => {
        this.rejectList.push({ id: x.id });
        this.rejectingList[x.id] = true;
      });
    }
  }

  save(): void {
    this.approveAndRejectList();
  }

  checkboxChangeApprove(event, id) {
    debugger;
    let item = { id: id };
    let pushItem: boolean = true;

    // remove item if it is in another list.
    let existItemIndexInReject = this.rejectList.findIndex(x => x.id == id);
    if (existItemIndexInReject >= 0) {
      //let existItem = this.rejectList[existItemIndexInReject];
      this.rejectList.splice(existItemIndexInReject, 1);
      this.rejectingList.splice(id, 1);
    }

    let existItemIndex = this.approveList.findIndex(x => x.id == id);
    if (existItemIndex >= 0) {
      let existItem = this.approveList[existItemIndex];
      if (event == true) {
        pushItem = false;
      }
      else if (event == false) {
        pushItem = false;
        this.approveList.splice(existItemIndex, 1);
      }
    }

    if (pushItem) {
      this.approveList.push(item);
    }
  }

  checkboxChangeReject(event, id) {
    debugger;
    let item = { id: id };
    let pushItem: boolean = true;

    // remove item if it is in another list.
    let existItemIndexInaApprove = this.approveList.findIndex(x => x.id == id);
    if (existItemIndexInaApprove >= 0) {
      //let existItem = this.rejectList[existItemIndexInReject];
      this.approveList.splice(existItemIndexInaApprove, 1);
      this.approveingList.splice(id, 1);
    }


    let existItemIndex = this.rejectList.findIndex(x => x.id == id);
    if (existItemIndex >= 0) {
      let existItem = this.rejectList[existItemIndex];
      if (event == true) {
        pushItem = false;
      }
      else if (event == false) {
        pushItem = false;
        this.rejectList.splice(existItemIndex, 1);
      }
    }

    if (pushItem) {
      this.rejectList.push(item);
    }
  }

  approveAllCheckboxChange(event) {
    this.approveAll();
  }
  rejectAllCheckboxChange(event) {
    this.rejectAll();
  }


  gotoJournalList(): void {
    let url = [`/journal/list`];
    this.router.navigate(url);
  }

  gotoList() {
    let url = [`/journal/list`];
    if (this.previewJournal) {
      url = [`/journal/preview-list`];
    }
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
  previewJournal: boolean = false;
  postingSetting: PostingSetting = {
    isBulkPosting: false,
    isPostingAutomatic: true,
    allowPostingAccountCurrencyMisMatch: false
  };
  list: any[];
  approveList: any[] = [];
  rejectList: any[] = [];

  approveingList: any[] = [];
  rejectingList: any[] = [];
  canApproveOrRejectJournalEntriesUnderReview: boolean = false;
}
