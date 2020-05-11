//master.component
import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { MenuItems } from '../../Models/menu-items.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service'
import { MenuItemsService } from '../../Services/menu-items.service';

@Component({
  selector: 'menu-items-master',
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
    private menuItemsService: MenuItemsService
  ) { }

  ngOnInit(): void {
    this.extractRouteParams();
  }

  extractRouteParams(): void {
    debugger;
    let editUserId = +this.route.snapshot.params['editUserId'];
    let detailUserId = +this.route.snapshot.params['detailUserId'];

    //let editId = +this.route.snapshot.params['editId'];
    //let detailId = +this.route.snapshot.params['detailId'];

    //this.id = +this.route.snapshot.params['roleId'];

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
      this.menuItemsService.getMenuItems(this.id)
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
    let url = [`/menu-items/list`];
    this.router.navigate(url);
  }

  gotoEditor() {
    let url = [`/menu-items/master/add`];
    
    if(this.editorMode == this.editorModeEnum.edit) {      
      url = [`/menu-items/master/edit/${this.id}/edit/${this.id}`];
    }
    else if(this.editorMode == this.editorModeEnum.detail) {      
      url = [`/menu-items/master/detail/${this.id}/detail/${this.id}`];
    } 
    
    this.router.navigate(url);
  }
  gotoUserMenuItems() {
    debugger;    
    let url = [`/menu-items/master/edit/${this.id}/user-menu-item/edit/${this.id}`];

    if(this.editorMode == this.editorModeEnum.edit) {      
      url = [`/menu-items/master/edit/${this.id}/user-menu-item/edit/${this.id}`];
    }
    else if(this.editorMode == this.editorModeEnum.detail) {      
      url = [`/menu-items/master/detail/${this.id}/user-menu-item/detail/${this.id}`];
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
  itemModel: MenuItems = new MenuItems();
}