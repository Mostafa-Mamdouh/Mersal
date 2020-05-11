// import { Component, Input, Output, OnInit } from '@angular/core';
// import { FormGroup, FormBuilder, Validators } from '@angular/forms';
// import { Router, ActivatedRoute } from '@angular/router';
// import { TranslateService } from '@ngx-translate/core';

// import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
// import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
// import { FinancialService } from '../../../Financial/Services/financial.service';
// import { KendoDropDown } from '../../../../SharedFeatures/SharedMain/Models/KendoDropDown.model';
// import { MovementTypeEnum} from '../../../JournalEntries/Models/movement-type-enum';
// import { ChecksUnderCollection} from '../../Models/checks-under-collection.model';
// import { SettingService } from '../../../Setting/Services/setting.service';
// import {ChecksUnderCollectionService} from '../../Services/checks-under-collection.service';

// @Component({
//   selector: 'checks-under-collection-editor-editor',
//   styleUrls: ['./editor.component.scss'],
//   templateUrl: './editor.component.html'
// })
// export class EditorComponent implements OnInit {

//   constructor(
//     private fb: FormBuilder,
//     private route: ActivatedRoute,
//     private router: Router,
//     private notificationService: NotificationService,
//     private translateService: TranslateService,
//     private financialService: FinancialService,
//     private settingService: SettingService,
//     private checksUnderCollectionService: ChecksUnderCollectionService
//   ) { 

//   }

//   ngOnInit(): void {
//     this.buildForm();       
//     this.extractRouteParams();   
//   }

//   buildForm(): void {
//     this.editorForm = this.fb.group({
//         code: [null],
//         date: [null],
//         amount: [null]
//     });   
//   }

//   extractRouteParams(): void {    
//     this.id = +this.route.snapshot.params['id'];    

//     if (this.id) {
//       this.PageLoading = true;
//       this.financialService.getReceiptDetails(this.id)
//         .subscribe(res => {  
//           this.PageLoading = false;        
//           this.itemModel = res;
//           this.bindModelToForm();
//         },
//           (error) => {
//             this.PageLoading = false;
//             this.notificationService.showOperationFailed();
//           },
//           () => {

//           });
//         }
//   }

//   canEdit(): boolean {
//     return this.editorMode != EditorMode.detail;
//   }
//   gotoList() {
//     let url = [`/checks-under-collection/list`];
//     this.router.navigate(url);
//   }
  
//   bindModelToForm(): void {
//     //debugger;
//      if (this.itemModel) {
//        this.editorForm.patchValue({
//         code: this.itemModel.codel,
//         date: this.itemModel.date,
//         amount: this.itemModel.amount,
//        });
//      }
//   }  

//   save() {
//     if (this.editorForm.valid) {
//       //debugger;
//       this.itemModel = this.editorForm.value;

//       this.settingService.updateVAT(this.itemModel)
//         .subscribe(res => {
//           this.notificationService.showOperationSuccessed();
//           this.gotoList();
//         },
//           (error) => {
//             this.notificationService.showOperationFailed();
//           },
//           () => {

//           });
//     }
//   }


//   private editorForm: FormGroup;
//    editorMode: EditorMode = EditorMode.edit;
//    editorModeEnum = EditorMode;
//   private id: any;
//   private PageLoading: boolean = true;
//   private isProccessing: boolean;
//   private itemModel: any;
// }
