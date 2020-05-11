import { Component, Input, Output, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Location } from '@angular/common';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { SettingService } from '../../Services/setting.service';
import { TestamentAndAdvancesSetting } from '../../Models/testament-and-advances-setting.model';


@Component({
  selector: 'testament-and-advances-editor',
  styleUrls: ['./testament-and-advances-editor.component.scss'],
  templateUrl: './testament-and-advances-editor.component.html'
})
export class TestamentAndAdvancesEditorComponent implements OnInit {

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
    this.getAccountChartsLookup();
    this.buildForm();       
    this.extractRouteParams();   
  }

  buildForm(): void {
    this.editorForm = this.fb.group({
     
      testamentAccountNumber: [null, [Validators.required]] ,
      advancesAccountNumber: [null, [Validators.required]] ,
    });   
  }

  extractRouteParams(): void {  
    this.PageLoading = true;     
      this.settingService.getTestamentAndAdvancesSetting()
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
        testamentAccountNumber: +this.itemModel.testamentAccountNumber,    
        advancesAccountNumber: +this.itemModel.advancesAccountNumber,    
       });
     }
  }

  getAccountChartsLookup() {
    this.ReceiptsServ.getAccountChartsLookup()
      .subscribe(res => {
        this.AccountCharts = res;        
      }, () => {
        this.notificationService.showOperationFailed();
      }, () => {
      });
  }

  save() {
    if (this.editorForm.valid) {
      this.itemModel = this.editorForm.value;
      this.settingService.updateTestamentAndAdvancesSetting(this.itemModel)
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
  private itemModel: TestamentAndAdvancesSetting = new TestamentAndAdvancesSetting();
  private AccountCharts: any[];
  
}
