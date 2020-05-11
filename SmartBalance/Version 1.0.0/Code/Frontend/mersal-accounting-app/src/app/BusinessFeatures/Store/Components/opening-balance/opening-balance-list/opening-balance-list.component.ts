import { PaginationService } from './../../../../../SharedFeatures/SharedMain/Services/pagination.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { process, State } from '@progress/kendo-data-query';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { GridDataResult, PageChangeEvent, GridComponent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { Search, PostSearch } from '../../../../Purchasing/Models/search.model';
import { BranchLookup } from '../../../../Financial/Models/branch-lookup.model';
import { KendoDropDown } from '../../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { NotificationService } from '../../../../../SharedFeatures/SharedMain/Services/notification.service';
import { StoreService } from '../../../Services/store.service';
import { FinancialService } from '../../../../Financial/Services/financial.service';



@Component({
  selector: 'opening-balance--list',
  templateUrl: './opening-balance-list.component.html',
  styleUrls: ['./opening-balance-list.component.css']
})
export class OpeningBalanceListComponent implements OnInit {
  //page 
  pageSize:number=5;
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
  public VendorsDropDownData:Array<KendoDropDown>;
  public InventorysDropDownData:Array<KendoDropDown>;
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };
  inventoryId: any;
  filter: any;
  postSearch: PostSearch = new PostSearch();
  inventoryList: any[];
  inventory: number;

  constructor(
    private notification: NotificationService,
    private translateService: TranslateService,
    private serv: StoreService,
    private paginationService: PaginationService,
    private ReceiptsServ: FinancialService,
    private router: Router,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit() {
    this.pageSize = this.paginationService.getPaginationOptions().pageSize;
    this.pagenationSizeList = this.paginationService.getPaginationOptions().pagenationSizeList;
    this.pagenationSize = {value: this.pageSize};

    this.setLanguageSubscriber();
    this.getInventoryLookup();   
    this.getResourceKeys();
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
        
        if (this.filter[_i].field == "date") {
          this.postSearch.dateFrom = this.filter[_i].value.toISOString().substring(0, 10);
          //this.postSearch.dateTo=new Date().toISOString().substring(0, 10);    
        }

        if (this.filter[_i].field == "code") {
          this.postSearch.code = this.filter[_i].value;
        }

        if (this.filter[_i].field == "description") {
         this.postSearch.description = this.filter[_i].value;
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
    this.pageIndex = (event.skip / this.pageSize);

    let url = [`/store/opening-balance/list/${this.pageIndex}`];
    this.router.navigate(url)
  }

  createAllFilter(): KendoDropDown {
    let record= new KendoDropDown();
    record.text= this.allKey;
    record.value= null;
    
    return record;
  }

  inventoryChange(event){
    //debugger;
    this.pageIndex=0;
    this.postSearch.inventory=event.value;
    this.inventory=this.postSearch.inventory;
    this.getList();
    }
  setLanguageSubscriber(): void {
    this.language = this.translateService.currentLang;
    this.translateService.onLangChange.subscribe(val => {
      this.language = val.lang;
      //this.getResourceKeys();
    },
      (error) => { },
      () => { });
  }

  getList() {
    this.postSearch.pageSize = this.pageSize;
    this.postSearch.pageIndex = this.pageIndex;
    this.ListLoading = true;
    this.serv.getJournalEntriesByPost(this.postSearch)
      .subscribe(res => {
        debugger;
        this.ListLoading = false;
        //debugger;
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
        }
      );
  }

  getResourceKeys() {
    this.translateService.get([
      'shared.all'
    ]).subscribe(res => {
      if(res) {
        this.allKey = res['shared.all'];
      }
    });
  }

  getInventoryLookup() {
    this.ReceiptsServ.getStoreLookup()
      .subscribe(res =>{
          var array=new Array<any>();
    
          array.push(this.createAllFilter());
    
          res.forEach(function(item){
            var record= new KendoDropDown();
            record.text=item.name;
            record.value=item.id;
            array.push(record);
          });
          this.InventorysDropDownData=array;
        },
        (error) => {         
          this.notification.showOperationFailed();
        }        
      );
    }
 
    gotoList() {
       let url = [`/store/opening-balance/list`];
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
