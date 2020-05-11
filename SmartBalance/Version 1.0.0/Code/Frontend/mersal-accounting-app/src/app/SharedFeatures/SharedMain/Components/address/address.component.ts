import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormsModule } from '@angular/forms';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';


@Component({
    selector: 'address',
    templateUrl: './address.component.html',
    styleUrls: ['./address.component.scss'],
})
export class addressComponent implements OnInit {
    @Output() addresschangedOutPutEvent: EventEmitter<string> = new EventEmitter();
    addressFormGroup: FormGroup;
    isSubmited:boolean=false;
     address:string;
    constructor(
      
        private fb: FormBuilder,
        private notification: NotificationService) { }
    ngOnInit() {
      this.buildForm();
      this.addressFormGroup.get('address');

    }

    addressChanged(): void {
      
        let address=this.addressFormGroup.controls['address'].value;
        let validEmail:boolean=this.addressFormGroup.controls['address'].valid;
     if(validEmail)
     {
        this.addresschangedOutPutEvent.emit(address);
     }
    
    }
   
     
    buildForm(): void {
       
        this.addressFormGroup = this.fb.group({
            address: ["", [Validators.minLength(5),Validators.maxLength(400)]],
        });
    }
 
   
}
