import { FinancialService } from '../../Services/financial.service';
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormsModule } from '@angular/forms';
import { Donator } from '../../Models/receipts.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import * as $ from 'jquery';


@Component({
    selector: 'app-add-donator',
    templateUrl: './add-donator.component.html',
    styleUrls: ['./add-donator.component.scss'],
    providers: [FinancialService]
})
export class AddDonerComponent implements OnInit {
    @Output() adddonatorChanged: EventEmitter<Donator> = new EventEmitter();
    @Output() cancelNewdonator: EventEmitter<any> = new EventEmitter();
    addDoner: FormGroup;
    isSubmited: boolean = false;
    doner: Donator = new Donator();
    AccountCharts: any[];

    constructor(
        public router: Router,
        private fb: FormBuilder,
        private ReceiptsServ: FinancialService,
        private notification: NotificationService) { 

        }

    ngOnInit() {
        this.buildForm();
        this.getAccountChartsLookup();
    }
    buildForm(): void {
        this.doner = new Donator();
        this.addDoner = this.fb.group({
            donerName: ["", [Validators.minLength(4), Validators.maxLength(250)]],
            //, Validators.maxLength(100), Validators.minLength(4)
            donerPhoneNumber: ["", [Validators.maxLength(11), Validators.minLength(1)
                , Validators.pattern('^[0-9]{11}$')]],
            email: ["", [Validators.email]],
            address: ["", []]
                // 
            //\\\ donerAccountChart: [null, [Validators.required]]
        });
    }
    getAccountChartsLookup() {
        this.ReceiptsServ.getAccountChartsLookup()
            .subscribe(res => {
                this.AccountCharts = res;
                //debugger;   
            }, (error) => {
                this.notification.showOperationFailed();
                // debugger;
            }, () => {
                // debugger;
            });
    }

    AddDoner(): void {
if(this.addDoner.valid) {
        this.doner = {
            name: this.addDoner.controls['donerName'].value,
            phone: this.addDoner.controls['donerPhoneNumber'].value,
            email: this.addDoner.controls['email'].value,
            address: this.addDoner.controls['address'].value
            // accountChartId:null,
        };
        this.adddonatorChanged.emit(this.doner);
        // this.addDoner.reset();
        // this.isSubmited=true;
        this.Close();
    }
    else {       
        this.notification.showDataMissingError();
      }
    }
    emailchangedOutPutEvent(email: string) {
        console.log("EmailEvent Raise = " + email);
        this.addDoner.controls['email'].setValue(email);
            this.addDoner.updateValueAndValidity();
    }
    addresschangedOutPutEvent(address: string) {
        console.log("AddressEvent Raise = " + address);
        this.addDoner.controls['address'].setValue(address);
        this.addDoner.updateValueAndValidity();
    }
    mobilechangedOutPutEvent(mobile: string){
        console.log("mobileEvent Raise = " + mobile);
        this.addDoner.controls['donerPhoneNumber'].setValue(mobile);
        this.addDoner.updateValueAndValidity();
    }
   
    get name() {
        return this.addDoner.get('donerName');
     }  
    cancel(): void {
        this.cancelNewdonator.emit();
        this.buildForm();
    }
    Close() {
        $("#addnewDonator").click();
    }
}
