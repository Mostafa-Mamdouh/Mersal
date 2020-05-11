//role-permissions.component
import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { Role, RolePermissionList } from '../../Models/role.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service'
import { RoleService } from '../../Services/role.service';
import { PermissionService } from '../../../Permission/Services/permission.service';

@Component({
  selector: 'role-permissions-master',
  styleUrls: ['./role-permissions.component.scss'],
  templateUrl: './role-permissions.component.html'
})

export class RolePermissionsComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private roleService: RoleService,
    private permissionService: PermissionService
  ) { }

  ngOnInit(): void {
    this.extractRouteParams();
  }

  extractRouteParams(): void {

    let editId = +this.route.snapshot.params['editRoleId'];
    let detailId = +this.route.snapshot.params['detailRoleId'];
    this.id = +this.route.snapshot.params['roleId'];

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
      this.getRolePermissions(this.id);

      this.roleService.getRole(this.id)
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

  getAllUnSelectedPermissions(roleId: number) {
    this.isProccessing = true;
    this.permissionService.getAllUnSelectedPermissions(roleId)
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

  getRolePermissions(roleId: number) {
    this.roleService.getRolePermissions(roleId)
    .subscribe(res => {
      this.destList = res.list;
    },
    (error) => {

    })
  }

  gotoList() {
    let url = [`/role/list`];
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
      let model: RolePermissionList = new RolePermissionList();
      model.roleId = this.id;
      model.list = this.changedDestList;

      this.roleService.updateRolePermissions(model)
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

  itemModel: Role = new Role();
}