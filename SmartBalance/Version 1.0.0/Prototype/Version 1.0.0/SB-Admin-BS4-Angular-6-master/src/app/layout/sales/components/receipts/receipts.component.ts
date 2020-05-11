import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../../../router.animations';
import { TranslateService } from '@ngx-translate/core';
import { Router, NavigationEnd } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ReceiptsService } from '../../services/Receipts.service';

@Component({
  selector: 'app-receipts',
  templateUrl: './receipts.component.html',
  styleUrls: ['./receipts.component.scss'],
  animations: [routerTransition()],
  providers: [ReceiptsService]
})
export class ReceiptsComponent implements OnInit {
  products: any = [];
  addBill: FormGroup;
  addProduct: FormGroup;
  Bill: any = [];
  HasDisCountValue = false;
  HasExpensesValue = false;
  PaymentMethods: { id: string; name: string; }[];
  Organizations: { id: string; name: string; }[];

  constructor(private translate: TranslateService, public router: Router, private fb: FormBuilder,
    private receiptsServ: ReceiptsService) {
    // this.translate.addLangs(['en', 'ar', 'ur', 'es', 'it', 'fa', 'de', 'zh-CHS']);
    // this.translate.setDefaultLang('en');
    // const browserLang = this.translate.getBrowserLang();
    // this.translate.use(browserLang.match(/en|ar|ur|es|it|fa|de|zh-CHS/) ? browserLang : 'en');
  }
  // tslint:disable-next-line:semicolon
  ngOnInit() {
    this.buildForm();
    this.getAllPaymentMethods();
    this.getAllOrganizations();
  }
  getAllPaymentMethods() {
    this.PaymentMethods = this.receiptsServ.getAllBillTypes();
  }
  getAllOrganizations() {
    this.Organizations = this.receiptsServ.getAllBillTypes();
  }

  AddBill() {
    this.Bill.push({
      id: 2,
      DocumentNumber: this.addBill.controls['DocumentNumber'].value,
      DateDocument: this.addBill.controls['DateDocument'].value,
      CostCenter: this.addBill.controls['CostCenter'].value,
      Organization: this.addBill.controls['Organization'].value,
      AssociatedProducts: this.addBill.controls['AssociatedProducts'].value,
      PaymentMethod: this.addBill.controls['PaymentMethod'].value,
      StoreNumber: this.addBill.controls['StoreNumber'].value,
      MultiCostCenter: this.addBill.controls['MultiCostCenter'].value,
      Value: this.addBill.controls['Value'].value,
      Customer: this.addBill.controls['Customer'].value,
      StatementEn: this.addBill.controls['StatementEn'].value,
      StatementAr: this.addBill.controls['StatementAr'].value
    });
    console.log(this.Bill);
    this.buildForm();
  }

  cancel(form) {
    if (form === '0') {
      this.buildForm();
    } else {
    }
  }

  buildForm(): void {
    this.addBill = this.fb.group({
      DocumentNumber: [null, [Validators.required]],
      DateDocument: [new Date(), [Validators.required]],
      CostCenter: [null, [Validators.required]],
      Organization: [null, [Validators.required]],
      AssociatedProducts: [null, [Validators.required]],
      PaymentMethod: [null, [Validators.required]],
      StoreNumber: [null, [Validators.required]],
      MultiCostCenter: [null, [Validators.required]],
      Value: [null, [Validators.required]],
      Customer: [null, [Validators.required]],
      StatementEn: [null, [Validators.required]],
      StatementAr: [null, [Validators.required]]
    });
  }
}
