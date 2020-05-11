//master.component
import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { Role } from '../../Models/role.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service'
import { RoleService } from '../../Services/role.service';

@Component({
  selector: 'role-master',
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
    private roleService: RoleService
  ) { }

  ngOnInit(): void {
    this.extractRouteParams();
  }

  extractRouteParams(): void {
    debugger;
    let editRoleId = +this.route.snapshot.params['editRoleId'];
    let detailRoleId = +this.route.snapshot.params['detailRoleId'];

    //let editId = +this.route.snapshot.params['editId'];
    //let detailId = +this.route.snapshot.params['detailId'];

    //this.id = +this.route.snapshot.params['roleId'];

    if (editRoleId) {
      this.editorMode = EditorMode.edit
      this.id = editRoleId;
    }
    else if (detailRoleId) {
      this.editorMode = EditorMode.detail;
      this.id = detailRoleId;
    }
    else {
      this.editorMode = EditorMode.add;
    }

    if (this.id) {
      this.roleService.getRole(this.id)
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
    let url = [`/role/list`];
    this.router.navigate(url);
  }

  gotoEditor() {
    let url = [`/role/master/add`];
    
    if(this.editorMode == this.editorModeEnum.edit) {      
      url = [`/role/master/edit/${this.id}/edit/${this.id}`];
    }
    else if(this.editorMode == this.editorModeEnum.detail) {      
      url = [`/role/master/detail/${this.id}/detail/${this.id}`];
    } 
    
    this.router.navigate(url);
  }
  gotoRolePermissions() {
    debugger;
    let url = [`/role/master/edit/${this.id}/role-permissions/edit/${this.id}`];

    if(this.editorMode == this.editorModeEnum.edit) {      
      url = [`/role/master/edit/${this.id}/role-permissions/edit/${this.id}`];
    }
    else if(this.editorMode == this.editorModeEnum.detail) {      
      url = [`/role/master/detail/${this.id}/role-permissions/detail/${this.id}`];
    }

    this.router.navigate(url);
  }


  PageLoading: boolean;
  private editorForm: FormGroup;
  private editorMode: EditorMode = EditorMode.add;
  private editorModeEnum = EditorMode;
  id: any;
  private isProccessing: boolean;
  private accountCharts: any[];
  itemModel: Role = new Role();
}