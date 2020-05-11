import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormsModule } from '@angular/forms';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';


@Component({
    selector: 'email',
    templateUrl: './email.component.html',
    styleUrls: ['./email.component.scss'],
})
export class emailComponent implements OnInit {
    @Output() emailchangedOutPutEvent: EventEmitter<string> = new EventEmitter();
    emailFormGroup: FormGroup;
    isSubmited:boolean=false;
    constructor(
      
        private fb: FormBuilder,
        private notification: NotificationService) { }
    ngOnInit() {
      this.buildForm();
    }

    emailChanged(): void {
        let email=this.emailFormGroup.controls['email'].value;
        this.emailchangedOutPutEvent.emit(email);
    }
    buildForm(): void {
       
        this.emailFormGroup = this.fb.group({
            email: ["", [Validators.email]],
        });
    }
 
   
}
