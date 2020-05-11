import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../../../router.animations';
import { TranslateService } from '@ngx-translate/core';
import { Router, NavigationEnd } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BsDatepickerViewMode } from 'ngx-bootstrap/datepicker/models';
import { BsDatepickerConfig } from 'ngx-bootstrap';
import { ReturnPurchasesService } from '../../services/return-purchases-product.service';

@Component({
  selector: 'app-return-purchases-product',
  templateUrl: './return-purchases-product.component.html',
  styleUrls: ['./return-purchases-product.component.scss'],
  animations: [routerTransition()],
  providers: [ReturnPurchasesService]
})
export class ReturnPurchasesComponent implements OnInit {
  products: any = [];
  addBill: FormGroup;
  Bill: any = [];
  HasDisCountValue = false;
  HasExpensesValue = false;
  bsValue: Date;
  BillTypes: { id: string; name: string; }[];

  constructor(private translate: TranslateService, public router: Router, private fb: FormBuilder,
    private salesServ: ReturnPurchasesService) {
    // this.translate.addLangs(['en', 'ar', 'ur', 'es', 'it', 'fa', 'de', 'zh-CHS']);
    // this.translate.setDefaultLang('en');
    // const browserLang = this.translate.getBrowserLang();
    // this.translate.use(browserLang.match(/en|ar|ur|es|it|fa|de|zh-CHS/) ? browserLang : 'en');
  }
  // tslint:disable-next-line:semicolon
  ngOnInit() {
    this.buildForm();
    this.bsValue = new Date();
    this.getAllBillTypes();
  }
  getAllBillTypes() {
    this.BillTypes = this.salesServ.getAllBillTypes();
  }
  AddBill() {
    this.Bill.push({
      id: 2,
      BillNumber: this.addBill.controls['BillNumber'].value,
      DateBill: this.addBill.controls['DateBill'].value,
      CostCenter: this.addBill.controls['CostCenter'].value,
      BillType: this.addBill.controls['BillType'].value,
      BillPurchasesNumber: this.addBill.controls['BillPurchasesNumber'].value,
      SupplierCode: this.addBill.controls['SupplierCode'].value,
      StoreNumber: this.addBill.controls['StoreNumber'].value,
      SalesOrOfferPrice: this.addBill.controls['SalesOrOfferPrice'].value,
      BillTotal: this.addBill.controls['BillTotal'].value,
      TotalCost: this.addBill.controls['TotalCost'].value,
      TotalDiscount: this.addBill.controls['TotalDiscount'].value,
      BillNet: this.addBill.controls['BillNet'].value,
      CashPayment: this.addBill.controls['CashPayment'].value,
      BillDiscount: this.addBill.controls['BillDiscount'].value,
      DiscountValue: this.addBill.controls['DiscountValue'].value,
      AdditionalExpenses: this.addBill.controls['AdditionalExpenses'].value,
      ExpensesValue: this.addBill.controls['ExpensesValue'].value,
      Products: this.products
    });
    console.log(this.Bill);
    this.buildForm();
  }

  cancel() {
    this.buildForm();
  }

  HasBillDiscount() {
    if (this.addBill.controls['BillDiscount'].value === true) {
      this.HasDisCountValue = true;
    } else {
      this.HasDisCountValue = false;
    }
  }

  HasAdditionalExpenses() {
    if (this.addBill.controls['AdditionalExpenses'].value === true) {
      this.HasExpensesValue = true;
    } else {
      this.HasExpensesValue = false;
    }
  }

  buildForm(): void {
    this.addBill = this.fb.group({
      BillNumber: [null, [Validators.required]],
      DateBill: [new Date(), [Validators.required]],
      CostCenter: [null, [Validators.required]],
      BillType: [null, [Validators.required]],
      BillPurchasesNumber: [null, [Validators.required]],
      SupplierCode: [null, [Validators.required]],
      StoreNumber: [null, [Validators.required]],
      SalesOrOfferPrice: [null, [Validators.required]],
      BillTotal: [null, [Validators.required]],
      TotalCost: [null, [Validators.required]],
      TotalDiscount: [null, [Validators.required]],
      BillNet: [null, [Validators.required]],
      CashPayment: [null, [Validators.required]],
      BillDiscount: [null, [Validators.required]],
      DiscountValue: [null, [Validators.required]],
      AdditionalExpenses: [null, [Validators.required]],
      ExpensesValue: [null, [Validators.required]]
    });
  }
}
