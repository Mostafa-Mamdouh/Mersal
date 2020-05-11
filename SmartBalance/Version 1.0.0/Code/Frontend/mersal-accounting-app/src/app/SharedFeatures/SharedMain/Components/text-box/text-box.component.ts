import { Component, OnInit, Output, EventEmitter, Input, } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormsModule, FormControl } from '@angular/forms';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { TranslateService } from '@ngx-translate/core';



@Component({
    selector: 'text-box',
    templateUrl: './text-box.component.html',
    styleUrls: ['./text-box.component.scss'],
})
export class textBoxComponent implements OnInit {

    @Input() control: FormControl;
    @Input() canEdit: boolean;
    @Output() textchangedOutPutEvent: EventEmitter<string> = new EventEmitter();

    isSubmited:boolean=false;
    language: any;
    constructor(
      
        //private fb: FormBuilder,
        private notification: NotificationService,
        private translateService: TranslateService) { }

    ngOnInit() {
      //this.buildForm();
      this.language = this.translateService.currentLang;
    }

    // buildForm(): void {
       
    //     this.textFormGroup = this.fb.group({
    //         controlName: [null],
    //     });
    // }
    clearControl(control: FormControl)
    {
        control.setValue(null);
        this.textchangedOutPutEvent.emit(null);
    }

    textChange(event){
        debugger;
        this.textchangedOutPutEvent.emit(event);
    }
   
}
