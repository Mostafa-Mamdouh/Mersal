import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { AssetInventory, AssetInventoryDetail } from '../../Models/fixed-asset.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { AssetInventoryService } from '../../Services/asset-inventory.service';
import { LocationService } from '../../../Location/Services/location.service';
import { BrandService } from '../../../Brand/Services/brand.service';
import { ElementDef } from '@angular/core/src/view';
import { elementEnd } from '@angular/core/src/render3';
import { ErrorService } from '../../../../SharedFeatures/SharedMain/Services/error.service';
import { LocationLight } from 'src/app/BusinessFeatures/Location/Models/location.model';

@Component({
  selector: 'asset-inventory-editor',
  styleUrls: ['./asset-inventory-editor.component.scss'],
  templateUrl: './asset-inventory-editor.component.html'
})
export class AssetInventoryEditorComponent implements OnInit {
  loadingtext = "";

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private assetInventoryService: AssetInventoryService,
    private brandService: BrandService,
    private locationService: LocationService,
    private errorService: ErrorService
  ) { }

  ngOnInit(): void {
    this.translateService.get('shared.loading').subscribe(
      success => {
          this.loadingtext = success;
          console.log("translation now " + success);
      });
    this.buildForm();
    this.getLocationsLookup();
    this.getBrandsLookup();
    this.extractRouteParams();
    
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      date: [new Date(), [Validators.required]],
      //locationId: [null, [Validators.required]],

      assetDetails: this.fb.array([]),

      descriptionAr: [null, [Validators.required]],
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

    if (detailId) {
      this.editorMode = EditorMode.detail;
      this.id = detailId;
    }
    else {
      this.editorMode = EditorMode.add;
    }

    if (this.id) {
      this.assetInventoryService.getassetInventory(this.id)
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

  actualQuantityValueChange(event,i)
  {
      debugger;
    let actualQuantity = ((this.editorForm.get('assetDetails') as FormArray).controls[i] as FormGroup).controls['actualQuantity'].value;
    let expectedQuantityControl = ((this.editorForm.get('assetDetails') as FormArray).controls[i] as FormGroup).controls['expectedQuantity'];
    let expectedQuantity = null;
    if(expectedQuantityControl) {
        //expectedQuantity = +event.target.value;
        //expectedQuantity = expectedQuantityControl.value;
        expectedQuantity = expectedQuantityControl.value;
    }

    let differenceControl = ((this.editorForm.get('assetDetails') as FormArray).controls[i] as FormGroup ).controls['difference'];
    if(differenceControl) {
        differenceControl.setValue(actualQuantity - expectedQuantity);
    }
  }
  addAssetDetails(asset) {
    const assetDetails = this.editorForm.get('assetDetails') as FormArray;
    
    assetDetails.push(this.createAssetDetails(asset));
  }

  createAssetDetails(asset): FormGroup {
    return this.fb.group({
      brandId: [asset.brandId],
      brandName: [asset.brand.displyedName],
      expectedQuantity: [asset.expectedQuantity],
      actualQuantity: [asset.actualQuantity, [Validators.pattern("^[0-9]+$")]],
      difference: [asset.difference]
    });
  }

  createAssetDetail(): FormGroup {
    return this.fb.group({
      brandId: [],
      brandName: [],
      expectedQuantity: [],
      actualQuantity: [],
      difference: [null]
    });
  }

  locationvalueChange(event) {
    debugger;
    this.itemModel.locationId = event
    this.locationRequired = false;
    let fa = (this.editorForm.get('assetDetails') as FormArray);
    for (let index = 0; index < fa.length; index++) {
      fa.removeAt(index);
      
    }
    
     this.assetInventoryService.getAssetDetailsByLocation(event)
     .subscribe(res =>{
        this.assetInventoryDetails = res;
        this.assetInventoryDetails.forEach(element =>{
            this.addAssetDetails(element);
        });
        console.log(this.assetInventoryDetails);
        console.log(this.editorForm);
    },
    (error) => {
      //this.PageLoading = false;

      this.notificationService.showOperationFailed();
    }, () => {
    });
  }

  locationExpandOutPutEvent(event){
    debugger;
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

  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }
  gotoList() {
    let url = [`/asset/asset-inventory-list/list`];
    this.router.navigate(url);
  }
  //lookups


  getLocationsLookup() {
    let location: LocationLight = new LocationLight();
          location.displyedName = this.loadingtext; 
          let loodingArray = new Array();
    this.locationService.getLocationsLookups()
      .subscribe(res => {
        //this.PageLoading = false;
        debugger;
        res.collection.forEach(x => {
          loodingArray.push(location)
            x.childLocations = loodingArray;
        });
        this.locations = res.collection;

      },
        (error) => {
          //this.PageLoading = false;

          this.notificationService.showOperationFailed();
        }, () => {
        });
  }

  getBrandsLookup() {
    debugger;
    this.brandService.getBrandsLookups()
      .subscribe(res => {
        //this.PageLoading = false;

        this.brands = res.collection;
        console.info(this.brands);
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
        //code: this.itemModel.id,
        date: new Date(this.itemModel.date),
        //locationId: this.itemModel.locationId,


        descriptionAr: this.itemModel.descriptionAr,
        descriptionEn: this.itemModel.descriptionEn,
      });
      this.fillForm();
      console.log(this.itemModel);
    }
  }

  fillForm() {
    debugger;
    this.itemModel.assetInventoryDetails.forEach((assetInventoryDetails, x) => {
      const detail = this.editorForm.get('assetDetails') as FormArray;
      detail.push(this.createAssetDetails(assetInventoryDetails));
    });
  }
  collectModelFromForm(): void {
    debugger;
    this.itemModel.date = this.editorForm.controls["date"].value;
    //this.itemModel.locationId = this.editorForm.controls["locationId"].value;

    this.itemModel.assetInventoryDetails = [];
    for (let index = 0; index < (this.editorForm.get('assetDetails') as FormArray).controls.length; index++) {
        this.itemModel.assetInventoryDetails[index] = new AssetInventoryDetail();
        let brand = ((this.editorForm.get('assetDetails') as FormArray).controls[index] as FormGroup).controls["brandId"].value;
        this.itemModel.assetInventoryDetails[index].brandId = brand;
        let expectedQuantity = ((this.editorForm.get('assetDetails') as FormArray).controls[index] as FormGroup).controls['expectedQuantity'].value;
        this.itemModel.assetInventoryDetails[index].expectedQuantity = expectedQuantity;
        let actualQuantity = ((this.editorForm.get('assetDetails') as FormArray).controls[index] as FormGroup).controls['actualQuantity'].value;
        this.itemModel.assetInventoryDetails[index].actualQuantity = actualQuantity
        let difference = ((this.editorForm.get('assetDetails') as FormArray).controls[index] as FormGroup).controls['difference'].value;
        this.itemModel.assetInventoryDetails[index].difference = difference;
    }

    this.itemModel.descriptionAr = this.editorForm.controls["descriptionAr"].value;
    this.itemModel.descriptionEn = this.editorForm.controls["descriptionEn"].value;

  }

  save(): void {
    debugger;
    if (this.canEdit()) {
      

      if (this.editorForm.valid) {
        if (this.editorMode == EditorMode.add) {
          this.collectModelFromForm();
          if(this.itemModel.locationId == undefined)
          {
            this.locationRequired = true;
            this.notificationService.showDataMissingError();
          }
          else
          {
            this.isProccessing = true;
          this.assetInventoryService.addassetInventory(this.itemModel)
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
                console.log(`addBank completed.`);
              });
        }
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
  private brands: any[];
  private assetInventoryDetails: any[];
  private itemModel: AssetInventory = new AssetInventory();
  maxDate: Date = new Date();
  locationRequired: boolean = false;
  // @ViewChild('isDebt') EIsDebt :ElementRef;
  // @ViewChild('isCredit') EIsCredit : ElementRef;
}

