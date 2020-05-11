import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormsModule } from '@angular/forms';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';


@Component({
    selector: 'mobile',
    templateUrl: './mobile.component.html',
    styleUrls: ['./mobile.component.scss'],
})
export class mobileComponent implements OnInit {
    @Output() mobilechangedOutPutEvent: EventEmitter<string> = new EventEmitter();
    mobileFormGroup: FormGroup;
    isSubmited:boolean=false;
    constructor(
      
        private fb: FormBuilder,
        private notification: NotificationService) { }
    ngOnInit() {
      this.buildForm();
    }

    mobileChanged(): void {
      
        let mobile=this.mobileFormGroup.controls['mobile'].value;
        let validEmail:boolean=this.mobileFormGroup.controls['mobile'].valid;
     if(validEmail)
     {
        this.mobilechangedOutPutEvent.emit(mobile);
     }
    
    }
    buildForm(): void {
       
        this.mobileFormGroup = this.fb.group({
            mobile: [null,[Validators.maxLength(11), Validators.minLength(1)
                , Validators.pattern('^[0-9]{11}$')]],
        });
    }
 
   
}
