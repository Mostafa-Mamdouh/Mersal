import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { MenuItems } from '../../Models/menu-items.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
//import { FinancialService } from '../../../Financial/Services/financial.service'
import { MenuItemsService } from '../../Services/menu-items.service';
import { GenericResult } from 'src/app/SharedFeatures/SharedMain/Models/generic-result.model';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';

@Component({
  selector: 'menu-items-editor',
  styleUrls: ['./editor.component.scss'],
  templateUrl: './editor.component.html'
})

export class EditorComponent implements OnInit {
  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    //private ReceiptsServ: FinancialService,
    private menuItemsService: MenuItemsService,
    private location: Location,
    private errorService: ErrorService
  ) { }

  ngOnInit(): void {
    this.buildForm();
    this.getMenuItemsLookup();
    this.extractRouteParams();
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      code: [null, [Validators.required, Validators.pattern("([0-9]+\.)?[0-9]+")]],
      isActive: [true, [Validators.required]],
      url: [null], //, [Validators.required]],
      rootUrl: [null], //, [Validators.required]],
      itemOrder: [null, [Validators.required, Validators.min(1)]],
      allowAnonymous: [false, [Validators.required]],
      onErrorGoToURL: [null],

      nameAr: [null, [Validators.required]],
      nameEn: [null, [Validators.required]],
      titleAr: [null],
      titleEn: [null],
      descriptionAr: [null],
      descriptionEn: [null],

      parentMenuItemId: [null]
    });

    this.editorForm.valueChanges
      .subscribe(res => {
        //debugger;

      });
  }

  extractRouteParams(): void {
    //debugger;
    let editId = +this.route.snapshot.params['editId'];
    let detailId = +this.route.snapshot.params['detailId'];

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
      this.menuItemsService.getMenuItems(this.id)
        .subscribe(res => {
          debugger;
          this.itemModel = res;
          this.bindModelToForm();
        },
          (error) => {
            this.notificationService.showOperationFailed();
          })
    }
  }

  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }

  gotoList() {
    let url = [`/menu-items/list`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  gotoUserMenuItemList() {
    let url = [`/menu-items/master/edit/${this.id}/user-menu-item/edit/${this.id}`];
    this.router.navigate(url);
  }

  getMenuItemsLookup() {
    debugger;
    this.menuItemsService.getMenuItemsLookups()
      .subscribe(res => {
        //this.PageLoading = false;

        this.menuItems = res.collection;
      },
        (error) => {
          //this.PageLoading = false;

          this.notificationService.showOperationFailed();
        }, () => {
        });
  }

  bindModelToForm(): void {
    debugger;
    if (this.itemModel) {
      this.editorForm.patchValue({
        code: this.itemModel.code,
        isActive: this.itemModel.isActive,

        url: this.itemModel.url,
        rootUrl: this.itemModel.rootUrl,
        itemOrder: this.itemModel.itemOrder,
        allowAnonymous: this.itemModel.allowAnonymous,
        onErrorGoToURL: this.itemModel.onErrorGoToURL,
        parentMenuItemId: this.itemModel.parentMenuItemId,

        descriptionAr: this.itemModel.descriptionAr,
        descriptionEn: this.itemModel.descriptionEn,
        nameAr: this.itemModel.nameAr,
        nameEn: this.itemModel.nameEn,
        titleAr: this.itemModel.titleAr,
        titleEn: this.itemModel.titleEn
      });
      console.log(this.itemModel);
    }
  }

  collectModelFromForm(): void {
    debugger;
    this.itemModel.code = this.editorForm.controls["code"].value;
    this.itemModel.isActive = this.editorForm.controls["isActive"].value;

    this.itemModel.url = this.editorForm.controls["url"].value;
    this.itemModel.rootUrl = this.editorForm.controls["rootUrl"].value;
    this.itemModel.itemOrder = this.editorForm.controls["itemOrder"].value;
    this.itemModel.allowAnonymous = this.editorForm.controls["allowAnonymous"].value;
    this.itemModel.onErrorGoToURL = this.editorForm.controls["onErrorGoToURL"].value;

    this.itemModel.descriptionAr = this.editorForm.controls["descriptionAr"].value;
    this.itemModel.descriptionEn = this.editorForm.controls["descriptionEn"].value;
    this.itemModel.nameAr = this.editorForm.controls["nameAr"].value;
    this.itemModel.nameEn = this.editorForm.controls["nameEn"].value;
    this.itemModel.titleAr = this.editorForm.controls["titleAr"].value;
    this.itemModel.titleEn = this.editorForm.controls["titleEn"].value;

    this.itemModel.parentMenuItemId = this.editorForm.controls["parentMenuItemId"].value;
    if (this.itemModel.parentMenuItemId && this.itemModel.parentMenuItemId.value) {
      this.itemModel.parentMenuItemId = this.itemModel.parentMenuItemId.value;
    }
  }

  save(): void {
    debugger;
    if (this.canEdit()) {
      this.isProccessing = true;
      if (this.editorForm.valid) {

        if (this.editorMode == EditorMode.add) {
          this.collectModelFromForm();
          //debugger;
          this.menuItemsService.addMenuItems(this.itemModel)
            .subscribe(res => {
              this.id = res.id;
              this.notificationService.showOperationSuccessed();
              this.gotoUserMenuItemList();
            },
              (error) => {
                this.isProccessing = false;
                this.errorService.handerErrors(error);
              },
              () => {
                console.log(`addmenuIteme completed.`);
              });
        }
        else if (this.editorMode == EditorMode.edit) {
          //debugger;
          this.collectModelFromForm();
          if ((this.itemModel.parentMenuItemId == this.itemModel.id)) {
            let key = 'MenuItem.errors.parentIsSame';
            this.translateService.get([key])
              .subscribe(res => {
                this.notificationService.showErrorHtml(`<h5>${res[key]}</h5>`);
              });
            this.isProccessing = false;
            return;
          }
          this.menuItemsService.updateMenuItems(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();
              this.gotoUserMenuItemList();
            },
              (error) => {
                this.isProccessing = false;
                this.errorService.handerErrors(error);
              },
              () => {
                console.log(`updatemenuIteme completed.`);
              });
        }
      }
      else {
        this.isProccessing = false;
        this.notificationService.showDataMissingError();
      }
    }
  }

  PageLoading: boolean;
  private editorForm: FormGroup;
  private editorMode: EditorMode = EditorMode.add;
  private editorModeEnum = EditorMode;
  private id: any;
  private isProccessing: boolean;
  private menuItems: any;
  private itemModel: MenuItems = new MenuItems();
}