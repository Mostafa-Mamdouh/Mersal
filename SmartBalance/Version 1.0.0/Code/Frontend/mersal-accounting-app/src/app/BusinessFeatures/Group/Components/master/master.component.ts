//master.component
import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { Group } from '../../Models/group.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service'
import { GroupService } from '../../Services/group.service';

@Component({
  selector: 'group-master',
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
    private groupService: GroupService
  ) { }

  ngOnInit(): void {
    this.extractRouteParams();
  }

  extractRouteParams(): void {
    debugger;
    let editGroupId = +this.route.snapshot.params['editGroupId'];
    let detailGroupId = +this.route.snapshot.params['detailGroupId'];

    //let editId = +this.route.snapshot.params['editId'];
    //let detailId = +this.route.snapshot.params['detailId'];

    //this.id = +this.route.snapshot.params['groupId'];

    if (editGroupId) {
      this.editorMode = EditorMode.edit
      this.id = editGroupId;
    }
    else if (detailGroupId) {
      this.editorMode = EditorMode.detail;
      this.id = detailGroupId;
    }
    else {
      this.editorMode = EditorMode.add;
    }

    if (this.id) {
      this.groupService.getGroup(this.id)
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
    let url = [`/group/list`];
    this.router.navigate(url);
  }

  gotoEditor() {
    let url = [`/group/master/add`];
    
    if(this.editorMode == this.editorModeEnum.edit) {      
      url = [`/group/master/edit/${this.id}/edit/${this.id}`];
    }
    else if(this.editorMode == this.editorModeEnum.detail) {      
      url = [`/group/master/detail/${this.id}/detail/${this.id}`];
    } 
    
    this.router.navigate(url);
  }
  gotoGroupPermissions() {
    debugger;
    let url = [`/group/master/edit/${this.id}/group-permissions/edit/${this.id}`];

    if(this.editorMode == this.editorModeEnum.edit) {      
      url = [`/group/master/edit/${this.id}/group-permissions/edit/${this.id}`];
    }
    else if(this.editorMode == this.editorModeEnum.detail) {      
      url = [`/group/master/detail/${this.id}/group-permissions/detail/${this.id}`];
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
  itemModel: Group = new Group();
}