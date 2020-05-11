//master.component
import { Component, Input, Output, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { Safe } from '../../Models/safe.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { FinancialService } from '../../../Financial/Services/financial.service'
import { SafeService } from '../../Services/safe.service';

@Component({
  selector: 'safe-master',
  styleUrls: ['./master.component.scss'],
  templateUrl: './master.component.html'
})

export class MasterComponent implements OnInit {
  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService,
    private translateService: TranslateService,
    private ReceiptsServ: FinancialService,
    private safeService: SafeService
  ) { }

  ngOnInit(): void {
    this.extractRouteParams();
  }

  extractRouteParams(): void {
    debugger;
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
      this.safeService.getSafe(this.id)
        .subscribe(res => {
          //debugger;
          this.itemModel = res;
          
        },
          (error) => {
            this.notificationService.showOperationFailed();
          })
    }
  }


  gotoList() {
    let url = [`/safe/list`];
    this.router.navigate(url);
  }

  gotoEditor() {
    let url = [`/safe/master/add`];
    
    if(this.editorMode == this.editorModeEnum.edit) {      
      url = [`/safe/master/edit/${this.id}/edit/${this.id}`];
    }
    else if(this.editorMode == this.editorModeEnum.detail) {      
      url = [`/safe/master/detail/${this.id}/detail/${this.id}`];
    } 
    
    this.router.navigate(url);
  }
  gotoSafeAccountChat() {
    debugger;
    let url = [`/safe/master/edit/${this.id}/safe-accountCharts/edit/${this.id}`];

    if(this.editorMode == this.editorModeEnum.edit) {      
      url = [`/safe/master/edit/${this.id}/safe-accountCharts/edit/${this.id}`];
    }
    else if(this.editorMode == this.editorModeEnum.detail) {      
      url = [`/safe/master/detail/${this.id}/safe-accountCharts/detail/${this.id}`];
    }

    this.router.navigate(url);
  }



  PageLoading: boolean;
  private editorForm: FormGroup;
  private editorMode: EditorMode = EditorMode.add;
  private editorModeEnum = EditorMode;
  id: any;
  private isProccessing: boolean;
  private accountCharts: any[];
  itemModel: Safe = new Safe();
}