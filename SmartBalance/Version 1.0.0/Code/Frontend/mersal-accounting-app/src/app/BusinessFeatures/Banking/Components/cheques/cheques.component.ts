import { Component, OnInit, ViewChild, ElementRef, Input, Output, EventEmitter, SimpleChanges } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { process, State } from '@progress/kendo-data-query';

import { Search, PostSearch } from '../../Models/search.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { GridDataResult, PageChangeEvent, GridComponent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
//import { FinancialService } from '../../../Financial/Services/financial.service';
//import { ChecksUnderCollection} from '../../Models/checks-under-collection.model';
//import { SettingService } from '../../../Setting/Services/setting.service';
import { ChecksUnderCollectionService } from '../../../ChecksUnderCollection/Services/checks-under-collection.service';
import { BankService } from '../../../Bank/Services/bank.service';
import { PaginationOptions } from '../../../../SharedFeatures/SharedMain/Models/pagination-options.model';
import { PaginationService } from '../../../../SharedFeatures/SharedMain/Services/pagination.service';


@Component({
    selector: 'cheques-list',
    styleUrls: ['./cheques.component.scss'],
    templateUrl: './cheques.component.html'
})
export class chequesComponent implements OnInit {

    @Input() bankId:number;
    @Input() canEidt: boolean;
    @Input() cheques: any[];
    @Output() checkListChanged: EventEmitter<any[]> = new EventEmitter();

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private fb: FormBuilder,
        private translateService: TranslateService,
        private notification: NotificationService,
        private bankService: BankService,
        //private ReceiptsServ: FinancialService,
        private checksUnderCollectionService: ChecksUnderCollectionService,
        private paginationService: PaginationService
    ) { }

    ngOnInit(): void {
        this.pageSize = this.paginationService.getPaginationOptions().pageSize;
        this.pagenationSizeList = this.paginationService.getPaginationOptions().pagenationSizeList;
        this.pagenationSize = { value: this.pageSize };

        this.setLanguageSubscriber();
        this.getResourceKeys();
        this.getBankLookup();
        if(this.canEidt){
        this.getList();
        }
        else
        {
            this.list = this.cheques;
        }
        //this.extractRouteParams();
    }
    ngOnChanges(changes: SimpleChanges) {
        debugger;
        if(this.canEidt)
        {
        this.getList();
        }
        else{
            this.gridView = {
                data: this.cheques,
                total: this.cheques.length
            };
            this.list = this.cheques;
        }
        console.log(this.cheques);
    }

    extractRouteParams() {
        let pageIndex = +this.route.snapshot.params['pageIndex'];

        this.pageIndex = 0;
        if (pageIndex) {
            this.pageIndex = pageIndex;
            this.skip = this.pageIndex * this.pageSize;
        }
    }
    @ViewChild('exampleModal') exampleModal: ElementRef;

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
    banks: any[] = [];// BranchLookup[] = [];
    inventorys: any[] = [];
    list: any[] = [];
    ListLoading: boolean = false;

    public state: State = {
        // Initial filter descriptor
        filter: {
            logic: 'and',
            filters: []
        }
    };
    public BanksDropDownData: Array<KendoDropDown>;
    public filterSettings: DropDownFilterSettings = {
        caseSensitive: false,
        operator: 'contains'
    };

    postSearch: PostSearch = new PostSearch();
    filter: any;
    bank: number;
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

    isChecked: any[] = [];
    checkboxChange(event, id) {
        let item = { id: id, exchangeable: event };
        let pushItem: boolean = true;

        let existItemIndex = this.list.findIndex(x => x.id == id);
        if (existItemIndex >= 0) {
            let existItem = this.list[existItemIndex];
            if (event == true) {
                pushItem = false;
            }
            else if (event == false) {
                pushItem = false;
                this.list.splice(existItemIndex, 1);
                this.checkListChanged.emit(this.list);
            }
        }

        if (pushItem) {
            this.list.push(item);
            this.checkListChanged.emit(this.list);
        }

        //this.notification.showInfo(id + " " + JSON.stringify(event));
    }
    bankChange(event) {
        //debugger;
        this.pageIndex = 0;
        this.postSearch.bank = event.value;
        this.bank = this.postSearch.bank;
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
                    //this.filter.splice( _i,1);      
                } else {
                    this.postSearch.dateFrom = new Date(new Date().setMonth(new Date().getMonth() - 1)).toISOString().substring(0, 10);
                    this.postSearch.dateTo = new Date(Date.now()).toISOString().substring(0, 10);
                }

                if (this.filter[_i].field == "code") {
                    this.postSearch.code = this.filter[_i].value;
                }

                if (this.filter[_i].field == "date") {
                    this.postSearch.dateFrom = this.filter[_i].value.toISOString().substring(0, 10);
                    this.postSearch.dateTo = new Date(Date.now()).toISOString().substring(0, 10);
                }

                // if (this.filter[_i].field == "amount") {
                //     this.postSearch.amount = this.filter[_i].value;
                // }
            }
            this.postSearch.filters = this.filter;
            this.pageIndex = 0;
        }
        else {
            this.postSearch = new PostSearch();
            this.postSearch.bank = this.bank;
        }
        //debugger;
        this.postSearch.sort = this.state.sort;
        this.getList();
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

    createAllFilter(): KendoDropDown {
        let record = new KendoDropDown();
        record.text = this.allKey;
        record.value = null;

        return record;
    }

    getBankLookup() {
        this.bankService.getBanksLookups()
            .subscribe(res => {
                var array = new Array<any>();

                array.push(this.createAllFilter());

                res.collection.forEach(function (item) {
                    var record = new KendoDropDown();
                    record.text = item.name;
                    record.value = item.id;
                    array.push(record);
                });
                this.BanksDropDownData = array;
            },
                (error) => {
                    this.notification.showOperationFailed();
                }
            );
    }

    getList() {
        this.postSearch.pageSize = this.pageSize;
        this.postSearch.pageIndex = this.pageIndex;
        this.ListLoading = true;

        //this.postSearch.bank = (this.bankId ? this.bankId.value : this.bankId);

        //debugger
        this.checksUnderCollectionService.getCheckByBank(this.bankId)
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
                    //this.notification.showOperationFailed();
                    this.list = [];
                },
            );
    }

    save() {
        this.checksUnderCollectionService.UpdateCollectionOfCheckUnderCollection(this.list)
            .subscribe(res => {
                debugger;
                this.list = [];
                this.getList();
                this.notification.showOperationSuccessed();
            },
                (error) => {
                    debugger;
                    //this.isChecked[id] = false;
                    this.notification.showOperationFailed();
                },
                () => {

                });
    }

    setItemToDelete(id: any) {
        this.itemIdToDelete = id;
    }

    gotoList() {
        let url = [`/checks-under-collection/list`];
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