import { Component, Input, Output, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { SettingService } from '../../../Setting/Services/setting.service';

@Component({
  selector: 'control-panel-editor',
  styleUrls: ['./control-panel.component.scss'],
  templateUrl: './control-panel.component.html'
})
export class ControlPanelComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private settingService: SettingService
  ) { }

  ngOnInit(): void {
  
  }

  

 
}
