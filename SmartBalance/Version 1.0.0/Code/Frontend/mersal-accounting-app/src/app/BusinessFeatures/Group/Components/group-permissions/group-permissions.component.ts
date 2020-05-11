import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { Group, GroupPermissionList } from '../../Models/group.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service'
import { GroupService } from '../../Services/group.service';
import { PermissionService } from '../../../Permission/Services/permission.service';

@Component({
  selector: 'group-permissions-master',
  styleUrls: ['./group-permissions.component.scss'],
  templateUrl: './group-permissions.component.html'
})

export class GroupPermissionsComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private groupService: GroupService,
    private permissionService: PermissionService
  ) { }

  ngOnInit(): void {
    this.extractRouteParams();
  }

  extractRouteParams(): void {

    let editId = +this.route.snapshot.params['editGroupId'];
    let detailId = +this.route.snapshot.params['detailGroupId'];
    this.id = +this.route.snapshot.params['groupId'];

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
      this.getAllUnSelectedPermissions(this.id);
      this.getGroupPermissions(this.id);

      this.groupService.getGroup(this.id)
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

  getAllUnSelectedPermissions(groupId: number) {
    this.isProccessing = true;
    this.permissionService.getAllUnSelectedPermissionsForGroup(groupId)
      .subscribe(res => {
        debugger;
        this.isProccessing = false;
        this.sourceList = res;

      },
        (error) => {
          this.isProccessing = false;
          this.notificationService.showOperationFailed();
        });
  }

  getGroupPermissions(groupId: number) {
    this.groupService.getGroupPermissions(groupId)
    .subscribe(res => {
      this.destList = res.list;
    },
    (error) => {

    })
  }

  gotoList() {
    let url = [`/group/list`];
    this.router.navigate(url);
  }

  onSourceListChanged(collection: any[]) {
    this.changedSourceList = collection;
    this.hasChange = true;
  }
  onDestListChanged(collection: any[]) {
    this.changedDestList = collection;
    this.hasChange = true;
  }


  save() {
    if(this.hasChange) {
      this.isProccessing = true;
      let model: GroupPermissionList = new GroupPermissionList();
      model.groupId = this.id;
      model.list = this.changedDestList;

      this.groupService.updateGroupPermissions(model)
      .subscribe(res => {        
        this.notificationService.showOperationSuccessed();
        this.hasChange=false;
        this.isProccessing=false;
        this.gotoList();
      },
      (error) => {
        this.isProccessing=false;
        this.notificationService.showOperationFailed();
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

  itemModel: Group = new Group();
}