import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormsModule } from '@angular/forms';
import { LocationModel, LocationLight } from '../../../Location/Models/location.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import * as $ from 'jquery';
import { LocationService } from '../../Services/location.service';
import { TranslateService } from '@ngx-translate/core';
import { EditorMode } from 'src/app/SharedFeatures/SharedMain/Models/editor-mode.enum';


@Component({
    selector: 'app-add-location',
    templateUrl: './add-location.component.html',
    styleUrls: ['./add-location.component.scss'],
})
export class AddLocationComponent implements OnInit {
    @Output() addlocationChanged: EventEmitter<LocationModel> = new EventEmitter();
    @Output() cancelNewlocation: EventEmitter<any> = new EventEmitter();
    addlocation: FormGroup;
    isSubmited: boolean = false;
    location: LocationModel = new LocationModel();
    AccountCharts: any[];
    locations: any[];
    loadingtext: any;
    private editorMode: EditorMode = EditorMode.add;
    private editorModeEnum = EditorMode;
    private itemModel: LocationModel = new LocationModel();
    constructor(
        public router: Router,
        private fb: FormBuilder,
        private notification: NotificationService,
        private locationService: LocationService,
        private translateService: TranslateService,  
) {      }

    ngOnInit() {
        this.translateService.get('shared.loading').subscribe(
            success => {
                this.loadingtext = success;
                console.log("translation now " + success);
            })

        this.buildForm();
        this.getLocationLookup();

    }

    getLocationLookup(){
        this.locationService.getLocationsLookups().subscribe(res =>{
            debugger;
          //this.locations = res.collection;
          //console.log

        //   let locationIndex = res.collection.findIndex(x => x.id == this.id);
        //   if(locationIndex > -1)
        //   {
        //     res.collection.splice(locationIndex, 1);
        //   }
        this.locations = res.collection;
        })
      }

      locationvalueChange(event){
        this.location.parentLocationId = event;
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

      canEdit(): boolean {
        return this.editorMode != EditorMode.detail;
      }

    Addlocation(): void {
        if (this.addlocation.valid) {
            this.location.code = this.addlocation.controls["code"].value;
            this.location.titleAr = this.addlocation.controls["titleAr"].value;
            this.location.titleEn = this.addlocation.controls["titleEn"].value;
            this.location.descriptionAr = this.addlocation.controls["descriptionAr"].value;
            this.location.descriptionEn = this.addlocation.controls["descriptionEn"].value;
debugger
            this.addlocationChanged.emit(this.location);
            // this.addlocation.reset();
            // this.isSubmited=true;
            this.Close();
        }
        else {
            this.notification.showDataMissingError();
        }
    }

    buildForm(): void {
        this.location = new LocationModel();
        this.addlocation = this.fb.group({
            code: ["", [Validators.required, Validators.pattern("([0-9]+\.)?[0-9]+")]],
            titleAr: [null, [Validators.required]],
            titleEn: [null, [Validators.required]],
            descriptionAr: [null, [Validators.required]],
            descriptionEn: [null, [Validators.required]],
            ParentLocation: [null]   
        });
    }
    get name() {
        return this.addlocation.get('code');
    }
    cancel(): void {
        this.cancelNewlocation.emit();
        this.buildForm();
    }
    Close() {
        $("#addnewLocation").click();
    }

    fireAddEvent() {
        this.Addlocation();
    }
}
