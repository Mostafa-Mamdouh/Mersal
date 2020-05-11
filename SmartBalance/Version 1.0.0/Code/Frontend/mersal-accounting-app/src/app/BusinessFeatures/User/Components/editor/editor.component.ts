import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { User } from '../../Models/user.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service'
import { UserService } from '../../Services/user.service';
import { BranchService } from '../../../Branch/Services/branch.service';
import { ChangePasswod } from '../../Models/change-password.model';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';

@Component({
  selector: 'user-editor',
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
    private branchService: BranchService,
    private userService: UserService,
    private location: Location,
    private errorService: ErrorService
  ) { }

  ngOnInit(): void {
    this.buildForm();
    this.buildChangePasswordForm();
    this.getBranchsLookup();
    this.extractRouteParams();
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      userName: [null, [Validators.required]],
      password: [null, [Validators.required, Validators.minLength(6)]],
      isActive: [true, [Validators.required]],
      birthDate: [new Date(), [Validators.required]],
      maxPaymentLimit: [null, [Validators.required, Validators.pattern('^[0-9]+$')]],
      nameAr: [null, [Validators.required]],
      nameEn: [null],
      phone: [null, [Validators.required, Validators.pattern('^[0-9]{11}$')]],
      email: [null, [Validators.required, Validators.email]],
      address: [null],
      //branchId: [null],
      //   descriptionAr: [null],
      //   descriptionEn: [null]
    });

    this.editorForm.valueChanges
      .subscribe(res => {
        //debugger;

      });
  }

  buildChangePasswordForm(): void {
    this.changePasswordForm = this.fb.group({
      userId: [null, [Validators.required]],
      oldPassword: [null, [Validators.required, Validators.minLength(6)]],
      newPassword: [null, [Validators.required, Validators.minLength(6)]],
      confirmPassword: [null, [Validators.required]]
    });

    this.changePasswordForm.valueChanges
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
      this.clearPasswordValidation();
    }
    else if (detailId) {
      this.editorMode = EditorMode.detail;
      this.id = detailId;
      this.clearPasswordValidation();
    }
    else {
      this.editorMode = EditorMode.add;
    }

    if (this.id) {
      this.userService.get(this.id)
        .subscribe(res => {
          debugger;
          this.itemModel = res;
          this.bindModelToForm();
          this.changePasswordForm.controls["userId"].setValue(this.id);
        },
          (error) => {
            this.notificationService.showOperationFailed();
          })
    }
  }

  clearPasswordValidation() {
    this.editorForm.controls['password'].setValue(null);
    this.editorForm.controls['password'].clearValidators();
    this.editorForm.controls['password'].updateValueAndValidity();
  }

  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }

  gotoList() {
    let url = [`/user/list`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  getBranchsLookup() {
    this.branchService.getBranchsLookups()
      .subscribe(res => {
        //this.PageLoading = false;

        this.branchs = res.collection;
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
        userName: this.itemModel.userName,
        isActive: this.itemModel.isActive,
        maxPaymentLimit: this.itemModel.maxPaymentLimit,
        birthDate: new Date(this.itemModel.birthDate),

        phone: this.itemModel.phone,
        email: this.itemModel.email,
        address: this.itemModel.address,

        nameAr: this.itemModel.nameAr,
        nameEn: this.itemModel.nameEn,
        //branchId: this.itemModel.branchId,
        // descriptionAr: this.itemModel.descriptionAr,
        // descriptionEn: this.itemModel.descriptionEn,
      });
      console.log(this.itemModel);
    }
  }

  collectModelFromForm(): void {
    debugger;
    this.itemModel.userName = this.editorForm.controls["userName"].value;
    this.itemModel.password = this.editorForm.controls['password'].value;

    this.itemModel.isActive = this.editorForm.controls["isActive"].value;
    this.itemModel.birthDate = this.editorForm.controls['birthDate'].value;
    this.itemModel.maxPaymentLimit = this.editorForm.controls['maxPaymentLimit'].value;

    this.itemModel.phone = this.editorForm.controls["phone"].value;
    this.itemModel.email = this.editorForm.controls["email"].value;
    this.itemModel.address = this.editorForm.controls["address"].value;

    this.itemModel.nameAr = this.editorForm.controls["nameAr"].value;
    this.itemModel.nameEn = this.editorForm.controls["nameEn"].value;
    //this.itemModel.branchId = this.editorForm.controls['branchId'].value;

    // this.itemModel.descriptionAr = this.editorForm.controls["descriptionAr"].value;
    // this.itemModel.descriptionEn = this.editorForm.controls["descriptionEn"].value;

  }

  save(): void {
    //debugger;
    if (this.canEdit()) {
      this.isProccessing = true;

      if (this.editorForm.valid) {
        if (this.editorMode == EditorMode.add) {
          this.collectModelFromForm();
          //debugger;
          this.userService.add(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();

              let url = [`/user/master/edit/${res.id}/user-permissions/edit/${res.id}`];
              this.router.navigate(url);
              //this.gotoList();
            },
              (error) => {
                this.isProccessing = false;
                this.errorService.handerErrors(error);
              },
              () => {
                console.log(`add completed.`);
              });
        }
        else if (this.editorMode == EditorMode.edit) {
          //debugger;
          this.collectModelFromForm();
          this.userService.update(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();
              this.gotoList();
            },
              (error) => {
                this.isProccessing = false;
                this.errorService.handerErrors(error);
              },
              () => {
                console.log(`update completed.`);
              });
        }
      }
      else {
        this.isProccessing = false;
        this.notificationService.showDataMissingError();
      }
    }
  }

  saveChangePassword():void
  {
    debugger;
    if(this.changePasswordForm.controls["newPassword"].value != this.changePasswordForm.controls["confirmPassword"].value)
    {
      //this.notificationService.showTranslateHtmlError_h5();
      this.changePasswordForm.controls["confirmPassword"].setErrors({ 'invalid': true, 'valid': false });
    }
    else
    {
      let model = new ChangePasswod();
      model.userId = this.id;
      model.oldPassword = this.changePasswordForm.controls["oldPassword"].value;
      model.newPassword = this.changePasswordForm.controls["newPassword"].value;
      this.userService.changePassword(model).subscribe(rec=>{
        this.notificationService.showOperationSuccessed();

      },
      (error) =>
      {
        this.notificationService.showTranslateHtmlError_h5("error.17")
      },
      () => {}
      );
    }
  }

  saveResetPassword()
  {
    this.userService.resetPassword(this.id).subscribe(rec =>{
      this.notificationService.showOperationSuccessed();
    },
    (error) => {
      this.notificationService.showOperationFailed();
    }
    )
  }

  PageLoading: boolean;
  editorForm: FormGroup;
  changePasswordForm: FormGroup;
  private editorMode: EditorMode = EditorMode.add;
  private editorModeEnum = EditorMode;
  private id: any;
  isProccessing: boolean;
  private branchs: any[];
  private itemModel: User = new User();
}