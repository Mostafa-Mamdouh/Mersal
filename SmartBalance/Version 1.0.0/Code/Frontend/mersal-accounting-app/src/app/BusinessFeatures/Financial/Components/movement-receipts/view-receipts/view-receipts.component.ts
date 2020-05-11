import { SourceType } from '../../../Models/source-type.enum';
import { PaymentMethodsEnum } from '../../../Models/payment-method.enum';
import { FinancialService } from '../../../Services/financial.service';
import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { NotificationService } from '../../../../../SharedFeatures/SharedMain/Services/notification.service';
declare var $: any;

@Component({
  selector: 'app-view-receipts',
  templateUrl: './view-receipts.component.html',
  styleUrls: ['./view-receipts.component.scss'],
  providers: [FinancialService]
})
export class ViewReceiptsComponent implements OnInit {
  @Input() inputID: number;
  details: {
    accountNumber: any;
    bankCode: any;
    bankName: any;
    branch: any;
    cases: [];
    chequeDuedate: any;
    chequeNumber: any;
    costCenters: [];
    customerAccountNumber: any;
    customerName: any;
    date: any;
    descriptionAR: any;
    descriptionEN: any;
    generalAccountAmount: any;
    id: any;
    inventorys: [];
    products: [];
    receivingMethodId: any;
    safeCode: any;
    safeName: any;
    sourceType: any;
    totalAmount: any;
    venderAccountNumber: any;
    vendorName: any;
    visaNumber: any;
  };
  payMethods: typeof PaymentMethodsEnum = PaymentMethodsEnum;
  sourceType: typeof SourceType = SourceType;

  constructor(
    public router: Router,
    private ReceiptsServ: FinancialService,
    private notification: NotificationService) { }
  ngOnInit() {
    debugger
    this.getPaymentDetails(this.inputID);
  }

  getPaymentDetails(id: number) {
    debugger;
    this.ReceiptsServ.getReceiptDetails(id)
      .subscribe(res => {
        debugger
        this.details = res;
        ;
      }, (error) => {
        debugger;
        this.notification.showOperationFailed();
        // debugger;
      }, () => {
        // debugger;
      });
  }


}
