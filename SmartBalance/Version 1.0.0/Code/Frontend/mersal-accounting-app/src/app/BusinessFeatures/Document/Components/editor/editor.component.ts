import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { Document } from '../../Models/document.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service'
import { DocumentService } from '../../Services/document.service';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';

@Component({
  selector: 'document-editor',
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
    private documentService: DocumentService,
    private location: Location,
    private errorService: ErrorService
  ) { }

  ngOnInit(): void {
    this.buildForm();
    this.extractRouteParams();
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      documentNumber: [null, [Validators.required, Validators.pattern("([0-9]+\.)?[0-9]+")]],

      countReceipts: [null, [Validators.required]],

      firstNumber: [null, [Validators.required, Validators.pattern("([0-9]+\.)?[0-9]+")]]
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
      this.documentService.getDocument(this.id)
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
    let url = [`/document/list`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  bindModelToForm(): void {
    debugger;
    if (this.itemModel) {
      this.editorForm.patchValue({
        documentNumber: this.itemModel.documentNumber,

      countReceipts: this.itemModel.countReceipts,

      firstNumber: this.itemModel.firstNumber
      });
      console.log(this.itemModel);
    }
  }

  collectModelFromForm(): void {
    debugger;
    this.itemModel.documentNumber = this.editorForm.controls["documentNumber"].value;
    this.itemModel.countReceipts = this.editorForm.controls["countReceipts"].value;
    this.itemModel.firstNumber = this.editorForm.controls["firstNumber"].value;
  }

  save(): void {
    //debugger;
    if (this.canEdit()) {
      this.isProccessing = true;

      if (this.editorForm.valid) {
        if (this.editorMode == EditorMode.add) {
          this.collectModelFromForm();
          debugger;
          this.documentService.addDocument(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();
              this.gotoList();
            },
              (error) => {
                this.isProccessing = false;
                this.errorService.handerErrors(error);
              },
              () => {
                console.log(`add Document completed.`);
              });
        }
        else if (this.editorMode == EditorMode.edit) {
          //debugger;
          this.collectModelFromForm();
          this.documentService.updateDocument(this.itemModel)
            .subscribe(res => {
              this.notificationService.showOperationSuccessed();
              this.gotoList();
            },
              (error) => {
                this.isProccessing = false;
                this.errorService.handerErrors(error);
              },
              () => {
                console.log(`update Document completed.`);
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
  private itemModel: Document = new Document();
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
}