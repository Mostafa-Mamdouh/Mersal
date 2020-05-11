import { Component, Input, Output, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { MovementTypeEnum } from '../../../JournalEntries/Models/movement-type-enum';
import { FinancialSetting } from '../../Models/financial-setting.model';
import { PostingSetting } from '../../Models/posting-setting.model';
import { VendorSetting } from '../../Models/vendor-setting.model';
import { SettingService } from '../../../Setting/Services/setting.service';


@Component({
  selector: 'posting-setting-notification',
  styleUrls: ['./posting-setting-notification.component.scss'],
  templateUrl: './posting-setting-notification.component.html'
})
export class PostingSettingNotificationComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private settingService: SettingService
  ) { }

  ngOnInit(): void {
    this.getPostingSetting();
  }



  getPostingSetting(): void {
    this.PageLoading = true;   
    this.settingService.getPostingSetting()
      .subscribe(res => {
        //debugger;
        this.PageLoading = false;   
        this.itemModel = res;      
      },
        (error) => {
          this.PageLoading = false;   
          //this.notificationService.showOperationFailed();
        },
        () => {

        });
  }

  gotoPostingEditor() {
    let url = [`/setting/posting-editor`];
    this.router.navigate(url);
  }

 

 
  private editorForm: FormGroup;
  private editorMode: EditorMode = EditorMode.add;
  private editorModeEnum = EditorMode;
  private id: any;
  PageLoading: boolean = true;
  private isProccessing: boolean;
  itemModel: PostingSetting;
}
