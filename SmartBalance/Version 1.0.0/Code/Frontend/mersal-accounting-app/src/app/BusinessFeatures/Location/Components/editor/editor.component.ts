import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { LocationModel, LocationLight } from '../../Models/location.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { LocationService } from '../../Services/location.service';
import { from } from 'rxjs';
//import { ElementDef } from '@angular/core/src/view';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';

@Component({
  selector: 'location-editor',
  styleUrls: ['./editor.component.scss'],
  templateUrl: './editor.component.html'
})
export class EditorComponent implements OnInit {
  loadingtext: any;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private locationService: LocationService,
    private location: Location,
    private errorService: ErrorService
  ) { }

  ngOnInit(): void {
    this.buildForm();
    //this.getAccountChartsLookup();
    this.getLocationLookup();
    this.extractRouteParams();
    this.translateService.get('shared.loading').subscribe(
      success => {
          this.loadingtext = success;
          console.log("translation now " + success);
      })
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      code: [null, [Validators.required, Validators.pattern("([0-9]+\.)?[0-9]+")]],
      date: [new Date(), [Validators.required]],
      titleAr: [null, [Validators.required]],
      titleEn: [null, [Validators.required]],
      descriptionAr: [null],
      descriptionEn: [null],
      ParentLocation: [null]   
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
      this.locationService.getLocation(this.id)
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
    let url = [`/location/list`];
    this.router.navigate(url);
  }

  goToBack(){
    this.location.back();
  }

  //lookups

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

  getLocationLookup(){
    this.locationService.getLocationsLookups().subscribe(res =>{
      let locationIndex = res.collection.findIndex(x => x.id == this.id);
        if(locationIndex > -1)
        {
          res.collection.splice(locationIndex, 1);
        }
      this.locations = res.collection;
    })
  }

  locationvalueChange(event){
    debugger;
    this.itemModel.parentLocationId = event;
  }

  locationExpandOutPutEvent(event){
    let location: LocationLight = new LocationLight();
          location.displyedName = this.loadingtext; 
          let loodingArray = new Array();
    this.locationService.getLocationChildren(event.dataItem.id).subscribe(res => {
      res.forEach(x => {
        loodingArray.push(location)
          x.childLocations = loodingArray;
      });
      event.dataItem.childLocations = res;
    });
  }

  bindModelToForm(): void {
    debugger;
    if (this.itemModel) {
      this.editorForm.patchValue({
        code: this.itemModel.code,
        //code: this.itemModel.id,
        date: new Date(this.itemModel.date),

        descriptionAr: this.itemModel.descriptionAr,
        descriptionEn: this.itemModel.descriptionEn,
        titleAr: this.itemModel.titleAr,
        titleEn: this.itemModel.titleEn,
        ParentLocation: this.itemModel.parentLocationId
      });
      console.log(this.itemModel);
    }
  }
  collectModelFromForm(): void {
    debugger;
    this.itemModel.code = this.editorForm.controls["code"].value;
    this.itemModel.date = this.editorForm.controls["date"].value;

    this.itemModel.descriptionAr = this.editorForm.controls["descriptionAr"].value;
    this.itemModel.descriptionEn = this.editorForm.controls["descriptionEn"].value;
    this.itemModel.titleAr = this.editorForm.controls["titleAr"].value;
    this.itemModel.titleEn = this.editorForm.controls["titleEn"].value;
    //this.itemModel.parentLocationId = this.editorForm.controls["ParentLocation"].value;
  }

  save(): void {
    //debugger;
    if (this.canEdit()) {
      this.isProccessing = true;

      if (this.editorForm.valid) {
        if (this.editorMode == EditorMode.add) {
          this.collectModelFromForm();
          this.locationService.addLocation(this.itemModel)
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
                console.log(`addLocation completed.`);
              });
        }
        else if (this.editorMode == EditorMode.edit) {
          this.collectModelFromForm();
          this.locationService.updateLocation(this.itemModel)
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
                console.log(`updateLocation completed.`);
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
  //private accountCharts: any[];
  locations: any[];
  private itemModel: LocationModel = new LocationModel();
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
}

