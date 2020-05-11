//role-permissions.component
import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { User, UserBranchList } from '../../Models/user.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service'
import { UserService } from '../../Services/user.service';
import { PermissionService } from '../../../Permission/Services/permission.service';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';
import { BranchService } from '../../../Branch/Services/branch.service';

@Component({
  selector: 'user-branchs-master',
  styleUrls: ['./user-branchs.component.scss'],
  templateUrl: './user-branchs.component.html'
})

export class UserBranchsComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private userService: UserService,
    private branchService: BranchService,
    private errorService: ErrorService
  ) { }

  ngOnInit(): void {
    this.userService.setActiveTab("userBranch");

    this.extractRouteParams();
  }

  extractRouteParams(): void {

    let editId = +this.route.snapshot.params['editUserId'];
    let detailId = +this.route.snapshot.params['detailUserId'];
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
      this.getUserBranchs(this.id);

      this.userService.get(this.id)
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
    this.branchService.getAllUnSelectedBranchsForUser(userId)
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

  getUserBranchs(userId: number) {
    this.userService.getUserBranchs(userId)
      .subscribe(res => {
        this.destList = res.list;
      },
        (error) => {

        })
  }

  gotoList() {
    let url = [`/user/list`];
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
      let model: UserBranchList = new UserBranchList();
      model.userId = this.id;
      model.list = this.changedDestList;

      this.userService.updateUserBranchs(model)
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

  itemModel: User = new User();
}