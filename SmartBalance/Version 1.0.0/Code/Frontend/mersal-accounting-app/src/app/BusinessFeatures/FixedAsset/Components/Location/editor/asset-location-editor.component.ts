import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { EditorMode } from '../../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { FixedAsset, AssetLocation } from '../../../Models/fixed-asset.model';
import { NotificationService } from '../../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FixedAssetService } from '../../../Services/fixed-asset.service';
import { LocationService } from '../../../../Location/Services/location.service';
import { LocationModel } from '../../../../Location/Models/location.model';
import { AssetLocationService } from '../../../Services/asset-location.service';
import { Location } from '@angular/common';
import { ErrorService } from '../../../../../SharedFeatures/SharedMain/Services/error.service';

@Component({
  selector: 'asset-location-editor',
  styleUrls: ['./asset-location-editor.component.scss'],
  templateUrl: './asset-location-editor.component.html'
})
export class AssetLocationEditorComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,  
    private locationService: LocationService,
    private fixedAssetService: FixedAssetService,   
    private location: Location,
    private assetLocationService: AssetLocationService,
    private errorService: ErrorService
  ) { }

  ngOnInit(): void {
    this.buildForm(); 
    this.getLocationsLookup();   
    this.getFixedAssetsLookups();  
    this.extractRouteParams();
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      date: [new Date()],
      locationId: [null, [Validators.required]],
      assetId: [null, [Validators.required]],     
      descriptionAr: [null],
      descriptionEn: [null],    
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
      this.assetLocationService.getassetLocation(this.id)
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
    let url = [`/asset/asset-location-list/list`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

  //lookups 

  getLocationsLookup() {
    this.locationService.getLocationsLookups()
      .subscribe(res => {
        //this.PageLoading = false;
        this.locations = res.collection;
      },
        (error) => {
          //this.PageLoading = false;
          this.notificationService.showOperationFailed();
        }, () => {
        });
  } 
 
  getFixedAssetsLookups() {
    this.fixedAssetService.getFixedAssetsLookups()
      .subscribe(res => {
        //debugger;
        //this.PageLoading = false;
        this.fixedAssets = res.collection;
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
        date: new Date(this.itemModel.date),
        locationId: this.itemModel.locationId,
        assetId: this.itemModel.assetId,       
        descriptionAr: this.itemModel.descriptionAr,
        descriptionEn: this.itemModel.descriptionEn,
      });
      console.log(this.itemModel);
    }
  }
  collectModelFromForm(): void {
    debugger;   
    this.itemModel.locationId = this.editorForm.controls["locationId"].value;
    this.itemModel.assetId = this.editorForm.controls["assetId"].value;
    this.itemModel.descriptionAr = this.editorForm.controls["descriptionAr"].value;
    this.itemModel.descriptionEn = this.editorForm.controls["descriptionEn"].value;     
  }

  save(): void {
    //debugger;
    if (this.canEdit()) {
      this.isProccessing = true;

      if (this.editorForm.valid) {
        // if (this.editorMode == EditorMode.add) {
        //   this.collectModelFromForm();
        //   this.assetLocationService.updateassetLocation(this.itemModel)
        //     .subscribe(res => {
        //       this.notificationService.showOperationSuccessed();
        //       this.gotoList();
        //     },
        //       (error) => {
        //         //debugger;
        //         this.isProccessing = false;
        //          this.errorService.handerErrors(error);
        //       },
        //       () => {
        //         console.log(`addBank completed.`);
        //       });
        // }
        
         if (this.editorMode == EditorMode.edit) {
          this.collectModelFromForm();
          this.assetLocationService.updateassetLocation(this.itemModel)
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
                console.log(`updateBank completed.`);
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
  private locations: any[];

  //private newLocation: LocationModel;
  //private isNewlocation: boolean;
  private itemModel: AssetLocation = new AssetLocation();
  fixedAssets: any[];
  maxDate: Date = new Date();
  minDate: Date = new Date(this.maxDate.getFullYear(), this.maxDate.getMonth(), 1);
}

