//role-permissions.component
import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
//import { FinancialService } from '../../../Financial/Services/financial.service'
import { MenuItemsService } from '../../../MenuItem/Services/menu-items.service';
//import { PermissionService } from '../../../Permission/Services/permission.service';
import { MenuItems, UserMenuItemsLisrt } from '../../../MenuItem/Models/menu-items.model';
import { User } from '../../Models/user.model';
import { UserService } from '../../Services/user.service';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';

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
    private menuItemsService: MenuItemsService,
    private userService: UserService,
    private errorService: ErrorService
    //private permissionService: PermissionService
  ) { }

  ngOnInit(): void {
    this.userService.setActiveTab("userMenuItems");

    this.extractRouteParams();
  }

  extractRouteParams(): void {
debugger
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
      this.getAllUnSelectedMenuItemsForUser(this.id);
      this.getUserMenuItems(this.id);

      this.userService.get(this.id)
      .subscribe(res => {
        //debugger;
        this.itemModel = res;

      },
        (error) => {
          this.notificationService.showOperationFailed();
        });


      this.menuItemsService.getMenuItems(this.id)
        .subscribe(res => {
          //debugger;
          this.menuItemModel = res;

        },
          (error) => {
            this.notificationService.showOperationFailed();
          });
    }
  }

  canEdit(): boolean {
    return (this.editorMode == this.editorModeEnum.edit);
  }

  getAllUnSelectedMenuItemsForUser(userId: number) {
    this.isProccessing = true;
    this.menuItemsService.getAllUnSelectedMenuItemsForUser(userId)
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

  getUserMenuItems(userId: number) {
    this.menuItemsService.getUserMenuItems(userId)
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

  goToBranch(){
    let url = [`/user/master/edit/${this.id}/user-branchs/edit/${this.id}`];
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
      let model: UserMenuItemsLisrt = new UserMenuItemsLisrt();
      model.userId = this.id;
      model.list = this.changedDestList;

      this.menuItemsService.updateUserMenuItems(model)
      .subscribe(res => {        
        this.notificationService.showOperationSuccessed();
        this.hasChange=false;
        this.isProccessing=false;
        //this.gotoList();
        this.goToBranch();
      },
      (error) => {
        this.isProccessing=false;
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

  private menuItemModel: MenuItems = new MenuItems();
  itemModel: User = new User();
}