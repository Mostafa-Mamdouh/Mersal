import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { Role } from '../../Models/role.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service'
import { RoleService } from '../../Services/role.service';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';

@Component({
  selector: 'role-editor',
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
    private ReceiptsServ: FinancialService,
    private roleService: RoleService,
    private location: Location,
    private errorService: ErrorService
  ) { }

  ngOnInit(): void {
    this.buildForm();
    //this.getAccountChartsLookup();
    this.extractRouteParams();
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      code: [null, [Validators.required, Validators.pattern("([0-9]+\.)?[0-9]+")]],
      isActive: [true, [Validators.required]],
      date: [new Date(), [Validators.required]],
      nameAr: [null, [Validators.required]],
      nameEn: [null, [Validators.required]],
      descriptionAr: [null],
      descriptionEn: [null]
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
      this.roleService.getRole(this.id)
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
    let url = [`/role/list`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  gotoRolePermissionList() {
    let url = [`/role/master/edit/${this.id}/role-permissions/edit/${this.id}`];
    this.router.navigate(url);
  }

  // getAccountChartsLookup() {
  //   this.ReceiptsServ.getAccountChartsLookup()
  //     .subscribe(res => {
  //       //this.PageLoading = false;

  //       this.accountCharts = res;
  //     },
  //       (error) => {
  //         //this.PageLoading = false;

  //         this.notificationService.showOperationFailed();
  //       }, () => {
  //       });
  // }

  bindModelToForm(): void {
    debugger;
    if (this.itemModel) {
      this.editorForm.patchValue({
        code: this.itemModel.code,
        isActive: this.itemModel.isActive,
        date: new Date(this.itemModel.date),
        descriptionAr: this.itemModel.descriptionAr,
        descriptionEn: this.itemModel.descriptionEn,
        nameAr: this.itemModel.nameAr,
        nameEn: this.itemModel.nameEn
      });
      console.log(this.itemModel);
    }
  }

  collectModelFromForm(): void {
    debugger;
    this.itemModel.code = this.editorForm.controls["code"].value;
    this.itemModel.isActive = this.editorForm.controls["isActive"].value;
    this.itemModel.date = this.editorForm.controls['date'].value;

    this.itemModel.descriptionAr = this.editorForm.controls["descriptionAr"].value;
    this.itemModel.descriptionEn = this.editorForm.controls["descriptionEn"].value;
    this.itemModel.nameAr = this.editorForm.controls["nameAr"].value;
    this.itemModel.nameEn = this.editorForm.controls["nameEn"].value;
  }

  save(): void {
    //debugger;
    if (this.canEdit()) {
      this.isProccessing = true;

      if (this.editorForm.valid) {
        if (this.editorMode == EditorMode.add) {
          this.collectModelFromForm();
          //debugger;
          this.roleService.addRole(this.itemModel)
            .subscribe(res => {
              this.id = res.id;
              this.notificationService.showOperationSuccessed();
              this.gotoRolePermissionList();
            },
              (error) => {
                this.isProccessing = false;
                this.errorService.handerErrors(error);
              },
              () => {
                console.log(`addRole completed.`);
              });
        }
        else if (this.editorMode == EditorMode.edit) {
          //debugger;
          this.collectModelFromForm();
          this.roleService.updateRole(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();
              this.gotoRolePermissionList();
            },
              (error) => {
                this.isProccessing = false;
                this.errorService.handerErrors(error);
              },
              () => {
                console.log(`updateRole completed.`);
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
  private accountCharts: any[];
  private itemModel: Role = new Role();
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1)
}