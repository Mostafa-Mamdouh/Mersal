import { Component, Input, Output, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { MovementTypeEnum } from '../../../JournalEntries/Models/movement-type-enum';
import { FinancialSetting } from '../../Models/financial-setting.model';
import { PostingSetting } from '../../Models/posting-setting.model';
import { VendorSetting } from '../../Models/vendor-setting.model';
import { GeneralSetting } from '../../Models/general-setting.model';
import { SettingService } from '../../../Setting/Services/setting.service';

@Component({
  selector: 'general-setting-editor',
  styleUrls: ['./general-setting-editor.component.scss'],
  templateUrl: './general-setting-editor.component.html'
})
export class GeneralSettingEditorComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private settingService: SettingService,
    private location: Location
  ) { 

  }

  ngOnInit(): void {
    this.buildForm();       
    this.extractRouteParams();   
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
      fiscalYearEndDay: [null, [Validators.required]],
      fiscalYearEndMonth: [null, [Validators.required]],
      fiscalYearStartDay: [null, [Validators.required]],
      fiscalYearStartMonth: [null, [Validators.required]],
      isInventoryRequired: [false, [Validators.required]]
    });   
  }

  extractRouteParams(): void {    
    this.PageLoading = true;
      this.settingService.getGeneralSetting()
        .subscribe(res => {  
          debugger;
          this.PageLoading = false;        
          this.itemModel = res;
          this.bindModelToForm();
        },
          (error) => {
            this.PageLoading = false;
            this.notificationService.showOperationFailed();
          },
          () => {

          });
  }

  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }
  gotoList() {
    this.location.back();

    // let url = [`/setting/control-panel`];
    // this.router.navigate(url);
  }
  
  bindModelToForm(): void {
    //debugger;
     if (this.itemModel) {
       this.editorForm.patchValue({      
        fiscalYearEndDay: this.itemModel.fiscalYearEndDay,
        fiscalYearEndMonth: this.itemModel.fiscalYearEndMonth,
        fiscalYearStartDay: this.itemModel.fiscalYearStartDay,
        fiscalYearStartMonth: this.itemModel.fiscalYearStartMonth,
        isInventoryRequired: this.itemModel.isInventoryRequired
       });
     }
  }
 
  save() {
    if (this.editorForm.valid) {      
      this.itemModel = this.editorForm.value;

      this.settingService.updateGeneralSetting(this.itemModel)
        .subscribe(res => {
          this.notificationService.showOperationSuccessed();
          this.gotoList();
        },
          (error) => {
            this.notificationService.showOperationFailed();
          },
          () => {

          });
    }
  }


  private editorForm: FormGroup;
  private editorMode: EditorMode = EditorMode.add;
  private editorModeEnum = EditorMode;
  private id: any;
  PageLoading: boolean = true;
  private isProccessing: boolean;
  private itemModel: GeneralSetting;
  private months: any[] =  [
    {id:"1", name: "1"},
    {id:"2", name: "2"},
    {id:"3", name: "3"},
    {id:"4", name: "4"},
    {id:"5", name: "5"},
    {id:"6", name: "6"},
    {id:"7", name: "7"},
    {id:"8", name: "8"},
    {id:"9", name: "9"},
    {id:"10", name: "10"},
    {id:"11", name: "11"},
    {id:"12", name: "12"},
  ];
  private days: any[] = [
    {id:"1", name: "1"},
    {id:"2", name: "2"},
    {id:"3", name: "3"},
    {id:"4", name: "4"},
    {id:"5", name: "5"},
    {id:"6", name: "6"},
    {id:"7", name: "7"},
    {id:"8", name: "8"},
    {id:"9", name: "9"},
    {id:"10", name: "10"},
    {id:"11", name: "11"},
    {id:"12", name: "12"},
    {id:"13", name: "13"},
    {id:"14", name: "14"},
    {id:"15", name: "15"},
    {id:"16", name: "16"},
    {id:"17", name: "17"},
    {id:"18", name: "18"},
    {id:"19", name: "19"},
    {id:"20", name: "20"},
    {id:"21", name: "21"},
    {id:"22", name: "22"},
    {id:"23", name: "23"},
    {id:"24", name: "24"},
    {id:"25", name: "25"},
    {id:"26", name: "26"},
    {id:"27", name: "27"},
    {id:"28", name: "28"},
    {id:"29", name: "29"},
    {id:"30", name: "30"},
    {id:"31", name: "31"},
  ];
}

