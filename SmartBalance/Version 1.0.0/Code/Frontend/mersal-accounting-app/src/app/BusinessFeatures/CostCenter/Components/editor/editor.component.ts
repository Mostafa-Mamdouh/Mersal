//editor.component
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Route, ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { CostCenter } from '../../Models/cost-center.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { CostCenterService } from '../../Services/cost-center.service';
import { CostCenterTypeService } from '../../../CostCenterType/Services/cost-center-type.service'
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';

@Component({
  selector: 'cost-center-editor',
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
    private costCenterService: CostCenterService,
    private costCenterTypeService: CostCenterTypeService,
    private location: Location,
    private errorService: ErrorService
  ) { }

  ngOnInit(): void {
    this.buildForm();
    this.getCostCenterTypeLookup();
    this.extractRouteParams();
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      code: [null, [Validators.required, Validators.pattern("([0-9]+\.)?[0-9]+")]],
      date: [new Date(), [Validators.required]],
      nameAr: [null, [Validators.required]],
      nameEn: [null, [Validators.required]],
      costCenterType: [null, [Validators.required]],
      //isActive: [true, [Validators.required]],
      openingCredit: [null, [Validators.pattern("([0-9]+\.)?[0-9]+")]],
      isDebt: [true],
      descriptionAr: [null],
      descriptionEn: [null],
      accountChartId: [null],
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
      this.costCenterService.getCostCenter(this.id)
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

  getCostCenterTypeLookup()
  {
    this.costCenterTypeService.getCostCenterTypesLookups().subscribe(res => {
      this.costCenterTypes = res.collection;
    });
  }

  gotoList() {
    let url = [`/cost-center/list`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  bindModelToForm(): void {
    debugger;
    if (this.itemModel) {
      this.editorForm.patchValue({
        code: this.itemModel.code,
        //code: this.itemModel.id,
        date: new Date(this.itemModel.date),
        isDebt: this.itemModel.isDebt,
        //isActive: this.itemModel.isActive,
        openingCredit: this.itemModel.openingCredit,
        descriptionAr: this.itemModel.descriptionAr,
        descriptionEn: this.itemModel.descriptionEn,
        nameAr: this.itemModel.nameAr,
        nameEn: this.itemModel.nameEn,
        costCenterType: this.itemModel.costCenterTypeId
      });
      console.log(this.itemModel);
    }
  }

  collectModelFromForm(): void {
    debugger;
    this.itemModel.code = this.editorForm.controls['code'].value;
    this.itemModel.date = this.editorForm.controls['date'].value;
    this.itemModel.nameAr = this.editorForm.controls['nameAr'].value;
    this.itemModel.nameEn = this.editorForm.controls['nameEn'].value;
    //this.itemModel.isActive = this.editorForm.controls['isActive'].value;
    this.itemModel.openingCredit = this.editorForm.controls['openingCredit'].value;
    this.itemModel.isDebt = this.editorForm.controls['isDebt'].value;
    this.itemModel.descriptionAr = this.editorForm.controls['descriptionAr'].value;
    this.itemModel.descriptionEn = this.editorForm.controls['descriptionEn'].value;
    this.itemModel.costCenterTypeId = this.editorForm.controls["costCenterType"].value;
  }

  save(): void {
    //debugger;
    if (this.canEdit()) {
      this.isProccessing = true;

      if (this.editorForm.valid) {
        if (this.editorMode == EditorMode.add) {
          this.collectModelFromForm();
          this.costCenterService.addCostCenter(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();
              this.gotoList();
            },
              (error) => {
                this.isProccessing = false;
                this.errorService.handerErrors(error);
              },
              () => {
                console.log('add cost center completed.')
              }
            );
        }
        else if (this.editorMode == EditorMode.edit) {
          this.collectModelFromForm();
          this.costCenterService.updateCostCenter(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();
              this.gotoList();
            },
              (error) => {
                this.isProccessing = false;
                this.errorService.handerErrors(error);
              },
              () => {
                console.log('update cost center completed');
              }
            );
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
   editorMode: EditorMode = EditorMode.add;
   editorModeEnum = EditorMode;
  private id: any;
  private isProccessing: boolean;
  private accountCharts: any[];
  private costCenterTypes: any[];
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
  itemModel: CostCenter = new CostCenter();

}