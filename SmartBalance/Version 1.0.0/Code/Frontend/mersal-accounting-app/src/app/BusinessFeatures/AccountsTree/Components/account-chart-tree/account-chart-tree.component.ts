import { Component, OnInit, Output, EventEmitter, Input, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { AccountsTreeService } from '../../Services/accounts-tree.service';
import { accountChartTreeList } from '../../Models/AccountChartTreeList.model';
import { of } from 'rxjs/internal/observable/of';
import { TreeViewItemContentDirective } from '@progress/kendo-angular-treeview';
import { itemAt } from '@progress/kendo-angular-grid/dist/es2015/data/data.iterators';
import { TranslateService } from '@ngx-translate/core';
import { ContextMenuComponent } from '@progress/kendo-angular-menu';
import { accountTree } from '../../Models/AccountTree.model';
import { observable } from 'rxjs';

@Component({
    selector: 'accountChart',
    templateUrl: './account-chart-tree.component.html',
    styleUrls: ['./account-chart-tree.component.scss'],
})
export class accountChartTreeComponent implements OnInit {
    ChartTreeList: accountChartTreeList[] = [];
    ListLoading: boolean = true;
    AddAccountChartCalled = false;
    ParentAccountChart: accountChartTreeList = null;
    AccountChartDetailsId: number;
    @ViewChild('treemenu')
    public gridContextMenu: ContextMenuComponent;

    loadingtext = "";

    constructor(
        private notification: NotificationService,
        private AccountChartServic: AccountsTreeService,
        private translateService: TranslateService
    ) { }


    ngOnInit() {
        this.setLanguageSubscriber();
        this.getAddKey();
        this.translateService.get('shared.loading').subscribe(
            success => {
                this.loadingtext = success;
                console.log("translation now " + success);
            })
        this.getAccountChartListTree();
    }


    setLanguageSubscriber(): void {
        //debugger;       
        this.language = this.translateService.currentLang;
        this.setDir();
        this.translateService.onLangChange.subscribe(val => {
            this.language = val.lang;
            this.setDir();
        },
            (error) => {

            },
            () => {

            });
    }

    setDir() {
        if (this.language == "en")
            this.dir = "ltr";
        else
            this.dir = "rtl";
    }

    getAddKey(): void {
        this.translateService.get(['shared.add'])
            .subscribe(res => {
                if (res) {
                    this.addTranslatedText = res['shared.add'];
                    this.items = [{ text: this.addTranslatedText, icon: 'save' }];
                }
            });
    }
    addTranslatedText = '';// this.translateService.get("shared.add");

    public items: any[] = [];// [{ text: this.addTranslatedText,icon:'save' }];
    private contextItem: any;
    public onNodeClick(e: any): void {
        // if (e.type === 'contextmenu'&&e.item.dataItem.isFinalNode!=true) {
        //     //request add new one
        //     const originalEvent = e.originalEvent;

        //     originalEvent.preventDefault();

        //     this.contextItem = e.item.dataItem;

        //     this.gridContextMenu.show({ left: originalEvent.pageX, top: originalEvent.pageY });
        // }
        // else{
        this.AddAccountChartCalled = false;
        this.AddAccountChartCalled = true;

        this.AccountChartDetailsId = e.item.dataItem.id;
        this.ParentAccountChart == null;

        // }
    }

    public onSelect({ item }): void {
        if (item.text === 'إضافة' || item.text === 'Add') {
            this.AddAccountChartCalled = false;
            this.AddAccountChartCalled = true;
            this.ParentAccountChart = this.contextItem;
            this.AccountChartDetailsId = null;
        }
    }

    AddMainAcc() {
        this.AddAccountChartCalled = false;
        this.AddAccountChartCalled = true;
        this.ParentAccountChart = null;
        this.AccountChartDetailsId = null;
    }
    SucessAddOperation(accountChart: accountTree) {
        // var obj= new accountChartTreeList();
        // obj.id=accountChart.id;
        // obj.IsFinalNode=accountChart.isFinalNode;
        // obj.code=accountChart.code;
        // obj.name=accountChart.nameAR;
        // if(this.contextItem!=null){
        // if(this.contextItem.childs!=null){
        // this.contextItem.childs.push(obj);
        // }
        // else{
        //     var array=new Array<accountChartTreeList>();
        //     array.push(obj);
        //     this.contextItem.childs=array;
        // }}
        // else{
        this.getAccountChartListTree();
        this.keys = [];
        // }
    }
    SucessEditOperation(accountChart: accountTree) {
        this.getAccountChartListTree();
        this.keys = [];
    }

    getAccountChartListTree() {
        this.ListLoading = true;

        this.AccountChartServic.getAccountTree().subscribe(
            response => {
                debugger;
                var data = response.collection;
                data.forEach(element => {
                    let Treeitem: accountChartTreeList = new accountChartTreeList();
                    Treeitem.name = this.loadingtext;
                    Treeitem.code = "50";
                    Treeitem.id = 200 + element.id;
                    Treeitem.parentAccountChartId = element.id;
                    var array = [];
                    array.push(Treeitem);
                    element.childs = array
                });
                this.ChartTreeList = [];
                this.ChartTreeList = data;
                this.ListLoading = false;
            },
            error => {
                this.ListLoading = false;
                this.notification.showOperationFailed();
            }
        );

    }

    /**
 * The field that holds the keys of the expanded nodes.
 */
    public keys: string[] = [];

    /**
     * A function that checks whether a given node index exists in the expanded keys collection.
     * If the index can be found, the node is marked as expanded.
     */
    public isExpanded = (dataItem: any, index: string) => {
        let selected = 1;
        // console.log(this.keys);
        let check = this.keys.indexOf(index) > -1;
        // if(selected==1)
        // {
        //     if(check)
        //     {
        //         console.log("item id that is Checked"+dataItem.id);
        //     }
        //     else
        //     {
        //         console.log("item id that is UnChecked"+dataItem.id);
        //     }
        //     selected=+1;
        // }

        return check;
    }

    /**
     * A `collapse` event handler that will remove the node hierarchical index
     * from the collection, collapsing its children.
     */
    public handleCollapse(node) {
        this.keys = this.keys.filter(k => k !== node.index);
        console.log(node.id);
        // let Treeitem:accountChartTreeList =new accountChartTreeList();
        // Treeitem.name="loaiding ...";
        // Treeitem.code="50";
        // Treeitem.id=200+node.dataItem.id;
        // Treeitem.parentAccountChartId=node.dataItem.id;
        // Treeitem.childs=[];
        // node.dataItem.childs=new Array();
        // node.dataItem.childs.push(Treeitem);

    }

    /**
     * An `expand` event handler that will add the node hierarchical index
     * to the collection, expanding the its children.
     */
    public handleExpand(node) {
        debugger;
        this.keys = this.keys.concat(node.index);
        console.log("item id that is Checked" + node.dataItem.id);
        let Treeitem: accountChartTreeList = new accountChartTreeList();
        Treeitem.name = this.loadingtext;
        Treeitem.code = "50";
        Treeitem.id = 200 + node.dataItem.id;
        Treeitem.parentAccountChartId = node.dataItem.id;
        Treeitem.childs = [];
        node.dataItem.childs = [];
        node.dataItem.childs.push(Treeitem);
        let items;
        this.AccountChartServic.getAccountTreeById(node.dataItem.id)
            .subscribe(res => {
                debugger;
                items = res.collection;

                const index = node.dataItem.childs.indexOf(Treeitem);
                node.dataItem.childs.splice(index, 1);

                if (items.length > 0) {
                    items.forEach(element => {
                        let Treeitem2: accountChartTreeList = new accountChartTreeList();
                        Treeitem2.name = this.loadingtext;
                        Treeitem2.code = "50";
                        Treeitem2.id = 200 + element.id;
                        Treeitem2.parentAccountChartId = node.dataItem.id;
                        var array = [];
                        array.push(Treeitem);
                        element.childs = array
                        node.dataItem.childs.push(element);
                    });
                }
            },
                (error) => {
                    const index = node.dataItem.childs.indexOf(Treeitem);
                    node.dataItem.childs.splice(index, 1);
                }
            );

        // var tempparent=this.ChartTreeList.find(x=>x.id==node.dataItem.id);
        // if(node.dataItem.parentAccountChartId==null)
        // {
        //      this.ChartTreeList.find(x=>x.id==node.dataItem.id).childs=[];
        //  this.ChartTreeList.find(x=>x.id==node.dataItem.id).childs.push(Treeitem);
        // }
        // else{
        //     this.getParentObject(node.dataItem.parentAccountChartId).childs=[];
        // this.getParentObject(node.dataItem.parentAccountChartId).childs.push(Treeitem)
        // }

        // this.ChartTreeList.find(x=>x.id==node.dataItem.id).childs=[];
        // this.ChartTreeList.find(x=>x.id==node.dataItem.id).childs.push(Treeitem);
        // node.dataItem.push(Treeitem);
    }
    public getParentObject(id: number): accountChartTreeList {
        var tempLastAccChart;
        var x = this.ChartTreeList.find(x => x.id == id);
        tempLastAccChart = x;
        if (x.parentAccountChartId != null) {
            this.getParentObject(tempLastAccChart.parentAccountChartId)
        }
        else {
            return x;
        }
    }

    public children = (dataitem: any): any => of(dataitem.childs);
    public hasChildren = (dataitem: any): boolean => !!dataitem.childs;
    dir: string = 'rtl';
    language: any;
    restrictMove: boolean;
}
