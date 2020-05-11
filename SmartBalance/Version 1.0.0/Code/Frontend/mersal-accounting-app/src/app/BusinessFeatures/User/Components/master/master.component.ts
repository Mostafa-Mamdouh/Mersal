//master.component
import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { User } from '../../Models/user.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service'
import { UserService } from '../../Services/user.service';

@Component({
  selector: 'user-master',
  styleUrls: ['./master.component.scss'],
  templateUrl: './master.component.html'
})

export class MasterComponent implements OnInit {
  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.userService.setActiveTab("user");
    this.extractRouteParams();
  }

  extractRouteParams(): void {
    debugger;
    let editUserId = +this.route.snapshot.params['editUserId'];
    let detailUserId = +this.route.snapshot.params['detailUserId'];

    if (editUserId) {
      this.editorMode = EditorMode.edit
      this.id = editUserId;
    }
    else if (detailUserId) {
      this.editorMode = EditorMode.detail;
      this.id = detailUserId;
    }
    else {
      this.editorMode = EditorMode.add;
    }

    if (this.id) {
      this.userService.get(this.id)
        .subscribe(res => {
          //debugger;
          this.itemModel = res;
          
        },
          (error) => {
            this.notificationService.showOperationFailed();
          })
    }
  }


  gotoList() {
    let url = [`/user/list`];
    this.router.navigate(url);
  }

  gotoEditor() {
    let url = [`/user/master/add`];
    
    if(this.editorMode == this.editorModeEnum.edit) {      
      url = [`/user/master/edit/${this.id}/edit/${this.id}`];
    }
    else if(this.editorMode == this.editorModeEnum.detail) {      
      url = [`/user/master/detail/${this.id}/detail/${this.id}`];
    } 
    
    this.router.navigate(url);
  }
  gotoUserPermissions() {
    debugger;
    let url = [`/user/master/edit/${this.id}/user-permissions/edit/${this.id}`];

    if(this.editorMode == this.editorModeEnum.edit) {      
      url = [`/user/master/edit/${this.id}/user-permissions/edit/${this.id}`];
    }
    else if(this.editorMode == this.editorModeEnum.detail) {      
      url = [`/user/master/detail/${this.id}/user-permissions/detail/${this.id}`];
    }

    this.router.navigate(url);
  }
  gotoUserRoles() {
    debugger;
    let url = [`/user/master/edit/${this.id}/user-roles/edit/${this.id}`];

    if(this.editorMode == this.editorModeEnum.edit) {      
      url = [`/user/master/edit/${this.id}/user-roles/edit/${this.id}`];
    }
    else if(this.editorMode == this.editorModeEnum.detail) {      
      url = [`/user/master/detail/${this.id}/user-roles/detail/${this.id}`];
    }

    this.router.navigate(url);
  }
  gotoUserGroups() {
    debugger;
    let url = [`/user/master/edit/${this.id}/user-groups/edit/${this.id}`];

    if(this.editorMode == this.editorModeEnum.edit) {      
      url = [`/user/master/edit/${this.id}/user-groups/edit/${this.id}`];
    }
    else if(this.editorMode == this.editorModeEnum.detail) {      
      url = [`/user/master/detail/${this.id}/user-groups/detail/${this.id}`];
    }

    this.router.navigate(url);
  }
  gotoUserMenuItems() {
    debugger;
    let url = [`/user/master/edit/${this.id}/user-menu-items/edit/${this.id}`];

    if(this.editorMode == this.editorModeEnum.edit) {      
      url = [`/user/master/edit/${this.id}/user-menu-items/edit/${this.id}`];
    }
    else if(this.editorMode == this.editorModeEnum.detail) {      
      url = [`/user/master/detail/${this.id}/user-menu-items/detail/${this.id}`];
    }

    this.router.navigate(url);
  }

  gotoUserBranchs() {
    let url = [`/user/master/edit/${this.id}/user-branchs/edit/${this.id}`];

    if(this.editorMode == this.editorModeEnum.edit) {      
      url = [`/user/master/edit/${this.id}/user-branchs/edit/${this.id}`];
    }
    else if(this.editorMode == this.editorModeEnum.detail) {      
      url = [`/user/master/detail/${this.id}/user-branchs/detail/${this.id}`];
    }

    this.router.navigate(url);
  }

  getActiveTab(): string {
    return this.userService.getActiveTab();
  }

  PageLoading: boolean;
  private editorForm: FormGroup;
  private editorMode: EditorMode = EditorMode.add;
  private editorModeEnum = EditorMode;
  id: any;
  private isProccessing: boolean;
  private accountCharts: any[];
  itemModel: User = new User();
}