import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { process, State } from '@progress/kendo-data-query';

import { PostSearch } from '../../Models/search.model';
//import {PurchasingService} from '../../Services/Purchasing.service';
//import { DonatoringService } from '../../Services/Donatoring.service';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { GridDataResult, PageChangeEvent, GridComponent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
//import { FinancialService } from '../../../Financial/Services/financial.service';
import { DonatorService } from '../../../Donator/Services/donator.service';
import { PaginationOptions } from '../../../../SharedFeatures/SharedMain/Models/pagination-options.model';
import { PaginationService } from '../../../../SharedFeatures/SharedMain/Services/pagination.service';

@Component({
  selector: 'donator-list',
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
    //private purchasingService: PurchasingService,
    //private DonatoringService: DonatoringService,
    //private ReceiptsServ: FinancialService,
    private donatorService: DonatorService,
    private paginationService: PaginationService
  ) { }

  ngOnInit(): void {
    this.pageSize = this.paginationService.getPaginationOptions().pageSize;
    this.pagenationSizeList = this.paginationService.getPaginationOptions().pagenationSizeList;
    this.pagenationSize = { value: this.pageSize };

    this.setLanguageSubscriber();
    this.getResourceKeys();
    //this.getDonatorLookup();
    //this.getJournalTypesLookup();
    this.getList();

    this.form = this.fb.group({
      avatar: [null]
    });

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
  Donators: any[] = [];// BranchLookup[] = [];
  journalTypes: any[] = [];
  list: any[] = [];
  ListLoading: boolean = false;

  public state: State = {
    // Initial filter descriptor
    filter: {
      logic: 'and',
      filters: []
    }
  };
  DonatorId: any;
  journalTypeId: any;
  public DonatorsDropDownData: Array<KendoDropDown>;
  public journalTypesDropDownData: Array<KendoDropDown>;
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };

  postSearch: PostSearch = new PostSearch();
  //postSearch: any;
  filter: any;
  Donator: number;
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

  DonatorChange(event) {
    //debugger;
    this.pageIndex = 0;
    //this.postSearch.Donator = event.value;
    //this.Donator = this.postSearch.Donator;
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
          this.postSearch.dateFrom = x[0].value.toISOString().substring(0, 10);
          this.postSearch.dateTo = x[1].value.toISOString().substring(0, 10);
          this.filter.splice(_i, 1);
        } else {
          this.postSearch.dateFrom = new Date(new Date().setMonth(new Date().getMonth() - 1)).toISOString().substring(0, 10);
          this.postSearch.dateTo = new Date(Date.now()).toISOString().substring(0, 10);
        }

        if (this.filter[_i].field == "phone") {
          this.postSearch.phone = this.filter[_i].value;
        }

        if (this.filter[_i].field == "name") {
          this.postSearch.name = this.filter[_i].value;
        }

        if (this.filter[_i].field == "email") {
          this.postSearch.email = this.filter[_i].value;
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
      //this.postSearch.Donator = this.Donator;
      //this.postSearch.journalType = this.journalType;
    }
    //debugger;
    this.postSearch.sort = this.state.sort;
    this.getList();
  }

  public pageChange(event: PageChangeEvent): void {
    this.pageIndex = (event.skip / this.pageSize);

    let url = [`/donator/list/${this.pageIndex}`];
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

  // createAllFilter(): KendoDropDown {
  //   let record = new KendoDropDown();
  //   record.text = this.allKey;
  //   record.value = null;

  //   return record;
  // }

  // getDonatorLookup() {
  //   this.DonatorService.getDonatorsLookups()
  //     .subscribe(res => {
  //       var array = new Array<any>();

  //       array.push(this.createAllFilter());

  //       res.collection.forEach(function (item) {
  //         var record = new KendoDropDown();
  //         record.text = item.name;
  //         record.value = item.id;
  //         array.push(record);

  //       });
  //       this.DonatorsDropDownData = array;
  //     },
  //       (error) => {
  //         this.notification.showOperationFailed();
  //       }
  //     );
  // }



  getList() {
    this.postSearch.pageSize = this.pageSize;
    this.postSearch.pageIndex = this.pageIndex;
    this.ListLoading = true;

    //this.postSearch.Donator = (this.DonatorId ? this.DonatorId.value : this.DonatorId);
    //debugger
    this.donatorService.getDonatorsByPost(this.postSearch)
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


  onFileChange(event) {
    debugger;
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      //this.form.controls['avatar'].setValue(file);

      let x = this.form.controls['avatar'].value;
      this.form.get('avatar').setValue(file);

      this.onSubmit();
    }
  }
  onSubmit() {
    debugger;
    this.processFile = true;
    const formData = new FormData();
    formData.append('file', this.form.get('avatar').value);

    this.donatorService.uploadDonorsExcelFile(formData).subscribe(
      (res) => {
        debugger;
        this.processFile = false;
        this.translateService.get(['shared.added', 'financial.donator']).subscribe(tres => {
          //debugger;
          this.notification.showSuccessHtml(`${tres['shared.added']} ${res} ${tres['financial.donator']}`);
        });

        if (res != 0) {
          this.getList();
        }
        //alert("success");
        //this.uploadResponse = res,
      },
      (error) => {
        this.processFile = false;
        if (error.status == 20) {
          this.notification.showTranslateHtmlError_h5('error.20');
        }
        else {
          this.notification.showOperationFailed();
        }
        console.error(error);
      }
    );
  }
  triggerFileUpload() {
    let fileElement: HTMLElement = this.fileUpload.nativeElement;
    fileElement.click();
  }



  gotoList() {
    let url = [`/donator/list`];
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

  @ViewChild('fileUpload') fileUpload: ElementRef<HTMLElement>;

  files: FileList;
  form: FormGroup;
  processFile: boolean;
}