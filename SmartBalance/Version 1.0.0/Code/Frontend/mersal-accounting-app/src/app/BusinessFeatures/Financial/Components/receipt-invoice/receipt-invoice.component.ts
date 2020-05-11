import { FinancialService } from '../../Services/financial.service';
import { Component, OnInit, Output, EventEmitter, Input, AfterContentInit, OnDestroy, AfterViewChecked } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormsModule } from '@angular/forms';
import { Donator } from '../../Models/receipts.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import * as $ from 'jquery';


@Component({
    selector: 'receipt-invoice',
    templateUrl: './receipt-invoice.component.html',
    styleUrls: ['./receipt-invoice.component.scss'],
    providers: [FinancialService]
})
export class receiptinvoice implements OnInit,  AfterViewChecked {
    ngAfterViewChecked(): void {
        debugger;
        this.ReceiptsServ.getDonationInvoice(this.id).subscribe(
            success => {
                debugger;
                this.data = success
            },
            (error) => {
                debugger;
                //this.notification.showOperationFailed();
            },
            () => {
                
            }
        );
    }
   
    @Input('id') id: any;
    data: any;

    constructor(
        public router: Router,
        // private fb: FormBuilder,
        private ReceiptsServ: FinancialService,
        private notification: NotificationService
    ) { }
    ngOnInit() {
        console.log(this.data);
        
    }

}
