//role-permissions.component
import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
//import { Role, RolePermissionList } from '../../Models/role.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service'
import { MenuItemsService } from '../../Services/menu-items.service';
import { PermissionService } from '../../../Permission/Services/permission.service';
import { MenuItemUsersLisrt, MenuItems } from '../../Models/menu-items.model';

@Component({
  selector: 'user-menu-item-master',
  styleUrls: ['./user-menuItem.component.scss'],
  templateUrl: './user-menuItem.component.html'
})

export class UserMenuItemComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private menuItemsService: MenuItemsService,
    private permissionService: PermissionService
  ) { }

  ngOnInit(): void {
    this.extractRouteParams();
  }

  extractRouteParams(): void {

    let editId = +this.route.snapshot.params['editUserId'];
    let detailId = +this.route.snapshot.params['detailUserId'];
    this.id = +this.route.snapshot.params['UserId'];

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
      this.getAllUnSelectedUsersForMenuItem(this.id);
      this.getMenuItemUsers(this.id);

      this.menuItemsService.getMenuItems(this.id)
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

  getAllUnSelectedUsersForMenuItem(menuItemId: number) {
    this.isProccessing = true;
    this.menuItemsService.getAllUnSelectedUsersForMenuItem(menuItemId)
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

  getMenuItemUsers(menuItemId: number) {
    this.menuItemsService.getMenuItemUsers(menuItemId)
    .subscribe(res => {
      this.destList = res.list;
    },
    (error) => {

    })
  }

  gotoList() {
    let url = [`/menu-items/list`];
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
      let model: MenuItemUsersLisrt = new MenuItemUsersLisrt();
      model.MenuItemId = this.id;
      model.list = this.changedDestList;

      this.menuItemsService.updateMenuItemUsers(model)
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

  itemModel: MenuItems = new MenuItems();
}