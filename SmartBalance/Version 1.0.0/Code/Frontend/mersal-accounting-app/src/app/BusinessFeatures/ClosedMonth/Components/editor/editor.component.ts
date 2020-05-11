import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { ClosedMonth } from '../../Models/closed-month.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { ClosedMonthService } from '../../Services/closed-month.service';
import { ElementDef } from '@angular/core/src/view';
import { InputControlService } from '../../../../SharedFeatures/SharedMain/Services/input-controls.service'
import { from } from 'rxjs';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';

@Component({
  selector: 'closed-month-editor',
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
    private closedMonthService: ClosedMonthService,
    private location: Location,
    private inputControl: InputControlService,
    private errorService: ErrorService
  ) { }

  ngOnInit(): void {
    let date = new Date();
    this.minDate = new Date(date.getFullYear(), date.getMonth(), 1);
    this.maxDate = date;
    this.buildForm();
    this.extractRouteParams();
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      month: [null],
      from: [new Date(), [Validators.required]],
      to: [new Date(), [Validators.required]],
      isClosed: [null, [Validators.required]],
      nameAr: [null],
      nameEn: [null],
      descriptionAr: [null],
      descriptionEn: [null],
    });

    this.editorForm.valueChanges
      .subscribe(res => {
        debugger;

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
      this.closedMonthService.getClosedMonth(this.id)
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
    let url = [`/closed-month/list`];
    this.router.navigate(url);
  }
  //lookups

  goToBack() {
    this.location.back()
  }


  bindModelToForm(): void {
    debugger;
    if (this.itemModel) {
      this.editorForm.patchValue({
        month: this.itemModel.month,
        from: this.itemModel.from,
        to: this.itemModel.to,
        isClosed: this.itemModel.isClosed,
        //code: this.itemModel.id,
        descriptionAr: this.itemModel.descriptionAr,
        descriptionEn: this.itemModel.descriptionEn,
        nameAr: this.itemModel.nameAr,
        nameEn: this.itemModel.nameEn,
      });
      console.log(this.itemModel);
    }
  }

  collectModelFromForm(): void {
    debugger;
    //this.itemModel.month = this.editorForm.controls["month"].value;
    this.itemModel.from = new Date(this.editorForm.controls["from"].value).toDateString();
    this.itemModel.to = new Date(this.editorForm.controls["to"].value).toDateString();
    this.itemModel.isClosed = this.editorForm.controls["isClosed"].value;

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
          this.closedMonthService.addClosedMonth(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();
              this.gotoList();
            },
              (error) => {
                //debugger;
                this.isProccessing = false;
                this.errorService.handerErrors(error);
              },
              () => {
                console.log(`addClosedMonth completed.`);
              });
        }
        else if (this.editorMode == EditorMode.edit) {
          this.collectModelFromForm();
          this.closedMonthService.updateClosedMonth(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();
              this.gotoList();
            },
              (error) => {
                //debugger;
                this.isProccessing = false;
                this.errorService.handerErrors(error);
              },
              () => {
                console.log(`updateClosedMonth completed.`);
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
   editorMode: EditorMode = EditorMode.add;
   editorModeEnum = EditorMode;
  private id: any;
  private isProccessing: boolean;
  private banks: any[];
  private toBanks: any[];
  private safes: any[];
  private journalTypes: any[];
  private accountCharts: any[];
  private itemModel: ClosedMonth = new ClosedMonth();
  maxDate: Date;
  minDate: Date;
  // @ViewChild('isDebt') EIsDebt :ElementRef;
  // @ViewChild('isCredit') EIsCredit : ElementRef;


 
}

