import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { Vendor } from '../../Models/vendor.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service'
import { VendorService } from '../../Services/vendor.service';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';

@Component({
  selector: 'vendor-editor',
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
    private vendorService: VendorService,
    private location: Location,
    private errorService: ErrorService
  ) { }

  ngOnInit(): void {
    this.buildForm();
    this.getAccountChartsLookup();
    this.extractRouteParams();
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      code: [null, [Validators.required, Validators.pattern("([0-9]+\.)?[0-9]+")]],
      date: [new Date(), [Validators.required]],
      nameAr: [null, [Validators.required]],
      nameEn: [null, [Validators.required]],
      openingCredit: [null, [Validators.pattern("([0-9]+\.)?[0-9]+")]],
      isDebt: [true],
      descriptionAr: [null],
      descriptionEn: [null],
      accountChartId: [null, [Validators.required]],

      phone: [null, [Validators.pattern('^[0-9]{11}$')]],
      address: [],
      commercialRegister: [],
      taxcard: [],
      exemptFromTax: [],
      payeeName: [],
      VATRegistrationCertificate: []
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
      this.vendorService.getVendor(this.id)
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
    let url = [`/vendor/list`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  getAccountChartsLookup() {
    this.ReceiptsServ.getAccountChartsLookup()
      .subscribe(res => {
        //this.PageLoading = false;

        this.accountCharts = res;
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
        //code: this.itemModel.id,
        date: new Date(this.itemModel.date),
        isDebt: this.itemModel.isDebt,

        openingCredit: this.itemModel.openingCredit,
        descriptionAr: this.itemModel.descriptionAr,
        descriptionEn: this.itemModel.descriptionEn,
        nameAr: this.itemModel.nameAr,
        nameEn: this.itemModel.nameEn,
        accountChartId: this.itemModel.accountChartId,

        phone: this.itemModel.phone,
        address: this.itemModel.address,
        commercialRegister: this.itemModel.commercialRegister,
        taxcard: this.itemModel.taxCard,
        exemptFromTax: this.itemModel.exemptFromTax,
        payeeName: this.itemModel.payeeName,
        VATRegistrationCertificate: this.itemModel.vatRegistrationCertificate
      });
      console.log(this.itemModel);
    }
  }

  collectModelFromForm(): void {
    debugger;
    this.itemModel.code = this.editorForm.controls["code"].value;
    this.itemModel.date = this.editorForm.controls["date"].value;

    this.itemModel.isDebt = this.editorForm.controls["isDebt"].value;

    this.itemModel.descriptionAr = this.editorForm.controls["descriptionAr"].value;
    this.itemModel.descriptionEn = this.editorForm.controls["descriptionEn"].value;
    this.itemModel.openingCredit = this.editorForm.controls["openingCredit"].value;
    this.itemModel.nameAr = this.editorForm.controls["nameAr"].value;
    this.itemModel.nameEn = this.editorForm.controls["nameEn"].value;
    this.itemModel.phone = this.editorForm.controls["phone"].value;
    this.itemModel.address = this.editorForm.controls["address"].value;
    this.itemModel.commercialRegister = this.editorForm.controls["commercialRegister"].value;
    this.itemModel.taxCard = this.editorForm.controls["taxcard"].value;
    this.itemModel.exemptFromTax = this.editorForm.controls["exemptFromTax"].value;
    this.itemModel.payeeName = this.editorForm.controls["payeeName"].value;
    this.itemModel.vatRegistrationCertificate = this.editorForm.controls["VATRegistrationCertificate"].value;

    this.itemModel.accountChartId = this.editorForm.controls["accountChartId"].value;
    if (this.itemModel.accountChartId && this.itemModel.accountChartId.value) {
      this.itemModel.accountChartId = this.itemModel.accountChartId.value;
    }
  }

  save(): void {
    //debugger;
    if (this.canEdit()) {
      this.isProccessing = true;

      if (this.editorForm.valid) {
        if (this.editorMode == EditorMode.add) {
          this.collectModelFromForm();
          //debugger;
          this.vendorService.addVendor(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();
              this.gotoList();
            },
              (error) => {
                this.isProccessing = false;
                //this.notificationService.showOperationFailed();
                this.errorService.handerErrors(error);
              },
              () => {
                console.log(`addVendor completed.`);
              });
        }
        else if (this.editorMode == EditorMode.edit) {
          //debugger;
          this.collectModelFromForm();
          this.vendorService.updateVendor(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();
              this.gotoList();
            },
              (error) => {
                this.isProccessing = false;
                this.notificationService.showOperationFailed();
              },
              () => {
                console.log(`updateVendor completed.`);
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
  private itemModel: Vendor = new Vendor();
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
}