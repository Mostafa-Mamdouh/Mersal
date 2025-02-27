//-editor.component

import { Component, Input, Output, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import {MovementTypeEnum} from '../../../JournalEntries/Models/movement-type-enum';
import {FinancialSetting} from '../../Models/financial-setting.model';
import {PostingSetting} from '../../Models/posting-setting.model';
import {VendorSetting} from '../../Models/vendor-setting.model';
import { SettingService } from '../../../Setting/Services/setting.service';


@Component({
  selector: 'vat-editor-editor',
  styleUrls: ['./vat-editor.component.scss'],
  templateUrl: './vat-editor.component.html'
})
export class VatEditorComponent implements OnInit {

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
      vat: [null, [Validators.required, Validators.pattern('[0-9]*\.?[0-9]+')]],   
    });   
  }

  extractRouteParams(): void {    
    this.PageLoading = true;
      this.settingService.getVAT()
        .subscribe(res => {  
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
        vat: this.itemModel
       });
     }
  }  

  save() {
    if (this.editorForm.valid) {
      //debugger;
      this.itemModel = this.editorForm.value;

      this.settingService.updateVAT(this.itemModel)
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
  private itemModel: number;
}
