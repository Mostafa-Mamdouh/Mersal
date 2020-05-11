import { FinancialService } from '../../../Services/financial.service';
import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { NotificationService } from '../../../../../SharedFeatures/SharedMain/Services/notification.service';
import { SourceType } from '../../../Models/source-type.enum';
import { PaymentMethodsEnum } from '../../../Models/payment-method.enum';


@Component({
    selector: 'app-view-payments',
    templateUrl: './view-payments.component.html',
    styleUrls: ['./view-payments.component.scss'],
    providers: [FinancialService]
})
export class ViewPaymentComponent implements OnInit {
  @Input() inputID: number;
  details: any;
  payMethods: typeof PaymentMethodsEnum = PaymentMethodsEnum;
  sourceType: typeof SourceType = SourceType;

    constructor(
        public router: Router,
        private ReceiptsServ: FinancialService,
        private notification: NotificationService) { }
    ngOnInit() {
      this.getPaymentDetails(this.inputID);
    }

    getPaymentDetails(id:number) {
        this.ReceiptsServ.getPaymentDetails(id)
          .subscribe(res => {
           this.details = res;
            //debugger;   
          }, (error) => {
            this.notification.showOperationFailed();
            // debugger;
          }, () => {
            // debugger;
          });
      }

    
}
