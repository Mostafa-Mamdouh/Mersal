//role-permissions.component
import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { Safe, SafeAccountChartList } from '../../Models/safe.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service'
import { SafeService } from '../../Services/safe.service';
import { PermissionService } from '../../../Permission/Services/permission.service';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';
import { AccountsTreeService } from '../../../AccountsTree/Services/accounts-tree.service';

@Component({
  selector: 'safe-accountCharts-master',
  styleUrls: ['./safe-accountCharts.component.scss'],
  templateUrl: './safe-accountCharts.component.html'
})

export class SafeAccountChartsComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private safeService: SafeService,
    private accountsTreeService: AccountsTreeService,
    private errorService: ErrorService
  ) { }

  ngOnInit(): void {
    this.extractRouteParams();
  }

  extractRouteParams(): void {

    let editId = +this.route.snapshot.params['editId'];
    let detailId = +this.route.snapshot.params['detailId'];
    this.id = +this.route.snapshot.params['userId'];

    if (editId) {
      this.editorMode = EditorMode.edit
      this.id = editId;
    }
    else if (detailId) {
      this.editorMode = EditorMode.detail;
      this.id = detailId;
    }
    else {
      this.editorMode = EditorMode.add;
    }

    if (this.id) {
      this.getAllUnSelectedBranchs(this.id);
      this.getSafeAccountcharts(this.id);

      this.safeService.getSafe(this.id)
        .subscribe(res => {
          //debugger;
          this.itemModel = res;

        },
          (error) => {
            this.notificationService.showOperationFailed();
          });
    }
  }

  canEdit(): boolean {
    return (this.editorMode == this.editorModeEnum.edit);
  }

  getAllUnSelectedBranchs(userId: number) {
    this.isProccessing = true;
    this.accountsTreeService.getAllUnSelectedAccountchartsForSafe(userId)
      .subscribe(res => {
        debugger;
        this.isProccessing = false;
        this.sourceList = res;
        console.log(this.sourceList);
      },
        (error) => {
          this.isProccessing = false;
          this.notificationService.showOperationFailed();
        });
  }

  getSafeAccountcharts(safeId: number) {
    this.safeService.getSafeAccountcharts(safeId)
      .subscribe(res => {
        this.destList = res.list;
      },
        (error) => {

        })
  }

  gotoList() {
    let url = [`/safe/list`];
    this.router.navigate(url);
  }

  onSourceListChanged(collection: any[]) {
    debugger;
    this.changedSourceList = collection;
    this.hasChange = true;
  }
  onDestListChanged(collection: any[]) {
    debugger;
    this.changedDestList = collection;
    this.hasChange = true;
  }

  save() {
    if (this.hasChange) {
      this.isProccessing = true;
      let model: SafeAccountChartList = new SafeAccountChartList();
      model.safeId = this.id;
      model.list = this.changedDestList;

      this.safeService.updateSafeAccountcharts(model)
        .subscribe(res => {
          debugger;
          this.notificationService.showOperationSuccessed();
          this.hasChange = false;
          this.isProccessing = false;
          this.gotoList();
        },
          (error) => {
            this.isProccessing = false;
            this.errorService.handerErrors(error);
          });
    }
  }


  PageLoading: boolean;
  private editorForm: FormGroup;
  private editorMode: EditorMode = EditorMode.add;
  private editorModeEnum = EditorMode;
  id: any;
  isProccessing: boolean;
  hasChange: boolean = false;
  private sourceList: any[] = [];
  private destList: any[] = [];

  private changedSourceList: any[];
  private changedDestList: any[];

  itemModel: Safe = new Safe();
}