import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { Donator } from '../../Models/donator.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { DonatorService } from '../../Services/donator.service';
import { ElementDef } from '@angular/core/src/view';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';

@Component({
  selector: 'Donator-editor',
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
    private donatorService: DonatorService,
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
      date: [new Date(), [Validators.required]],
      name: [null, [Validators.required]],
      phone: [null, [Validators.pattern('^[0-9]{11}$')]],
      email: [null, [Validators.email]],
      address: [null],//, [Validators.required]],
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
      this.donatorService.getDonator(this.id)
        .subscribe(res => {
          debugger;
          this.itemModel = res;
          this.bindModelToForm();
          console.info(this.id);
          console.info(res);
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
    let url = [`/donator/list`];
    this.router.navigate(url);
  }

  goToBack(){
    this.location.back();
  }
  
  //lookups

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
        //code: this.itemModel.code,
        //code: this.itemModel.id,
        date: new Date(this.itemModel.creationDate),
        phone: this.itemModel.phone,
        email: this.itemModel.email,
        address: this.itemModel.address,
        name: this.itemModel.name,
        accountChartId: this.itemModel.accountChartId,
      });
      console.log(this.itemModel);
    }
  }
  collectModelFromForm(): void {
    debugger;
    this.itemModel.date = this.editorForm.controls["date"].value;


    this.itemModel.name = this.editorForm.controls["name"].value;

    this.itemModel.phone = this.editorForm.controls["phone"].value;
    this.itemModel.email = this.editorForm.controls["email"].value;
    this.itemModel.address = this.editorForm.controls["address"].value;

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
          this.donatorService.addDonator(this.itemModel)
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
                console.log(`addDonator completed.`);
              });
        }
        else if (this.editorMode == EditorMode.edit) {
          this.collectModelFromForm();
          this.donatorService.updateDonator(this.itemModel)
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
                console.log(`updateDonator completed.`);
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
  private Donators: any[];
  private toDonators: any[];
  private safes: any[];
  private journalTypes: any[];
  private accountCharts: any[];
  private itemModel: Donator = new Donator();
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
  // @ViewChild('isDebt') EIsDebt :ElementRef;
  // @ViewChild('isCredit') EIsCredit : ElementRef;
}

