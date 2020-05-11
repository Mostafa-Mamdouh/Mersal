import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../../../router.animations';
import { TranslateService } from '@ngx-translate/core';
import { Router, NavigationEnd } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-daily-restrictions',
  templateUrl: './daily-restrictions.component.html',
  styleUrls: ['./daily-restrictions.component.scss'],
  animations: [routerTransition()]
})
export class DailyRestrictionsComponent implements OnInit {
  products: any = [];
  addBill: FormGroup;
  addProduct: FormGroup;
  Bill: any = [];
  HasDisCountValue = false;
  HasExpensesValue = false;

  constructor(private translate: TranslateService, public router: Router, private fb: FormBuilder) {
    // this.translate.addLangs(['en', 'ar', 'ur', 'es', 'it', 'fa', 'de', 'zh-CHS']);
    // this.translate.setDefaultLang('en');
    // const browserLang = this.translate.getBrowserLang();
    // this.translate.use(browserLang.match(/en|ar|ur|es|it|fa|de|zh-CHS/) ? browserLang : 'en');
  }
  // tslint:disable-next-line:semicolon
  ngOnInit() {
    this.buildForm();
    this.ProductForm();
    this.products = [
      // tslint:disable-next-line:max-line-length
      {
        id: 'FB1',
        AccountName: 'Donuts0',
        AccountNumber: 'FB1',
        CostCenterName: 1.99,
        CostCenterCode: 43,
        Total: 43,
        Debtor: 'Breads',
        Creditor: 'FB1',
        discription: 'Breads'
      },
      // tslint:disable-next-line:max-line-length,discription:''
      {
        id: 'FB1',
        AccountName: 'Donuts1',
        AccountNumber: 'FB1',
        CostCenterName: 1.99,
        CostCenterCode: 43,
        Total: 43,
        Debtor: 'Breads',
        Creditor: 'FB1',
        discription: 'Breads'
      },
      // tslint:disable-next-line:max-line-length,discription:''
      {
        id: 'FB1',
        AccountName: 'Donuts2',
        AccountNumber: 'FB1',
        CostCenterName: 1.99,
        CostCenterCode: 43,
        Total: 43,
        Debtor: 'Breads',
        Creditor: 'FB1',
        discription: 'Breads'
      },
      // tslint:disable-next-line:max-line-length,discription:''
      {
        id: 'FB1',
        AccountName: 'Donuts3',
        AccountNumber: 'FB1',
        CostCenterName: 1.99,
        CostCenterCode: 43,
        Total: 43,
        Debtor: 'Breads',
        Creditor: 'FB1',
        discription: 'Breads'
      }
    ];
  }
  AddProduct() {
    this.products.push({
      id: 2,
      AccountName: this.addProduct.controls['AccountName'].value,
      AccountNumber: this.addProduct.controls['AccountNumber'].value,
      CostCenterName: this.addProduct.controls['CostCenterName'].value,
      CostCenterCode: this.addProduct.controls['CostCenterCode'].value,
      Total: this.addProduct.controls['CostCenterName'].value * this.addProduct.controls['CostCenterCode'].value,
      Debtor: this.addProduct.controls['Debtor'].value,
      Creditor: this.addProduct.controls['Creditor'].value,
      discription: this.addProduct.controls['discription'].value
    });
    this.ProductForm();
  }

  AddBill() {
    this.Bill.push({
      id: 2,
      DocumentNumber: this.addBill.controls['DocumentNumber'].value,
      DateDocument: this.addBill.controls['DateDocument'].value,
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
      this.ProductForm();
    }
  }
  delete(item) {
    this.products.forEach((itm, index) => {
      if (item === itm) {
        this.products.splice(index, 1);
      }
    });
  }
  buildForm(): void {
    this.addBill = this.fb.group({
      DocumentNumber: [null, [Validators.required]],
      DateDocument: [new Date(), [Validators.required]],
      StatementEn: [null, [Validators.required]],
      StatementAr: [null, [Validators.required]]
    });
  }
  ProductForm(): void {
    this.addProduct = this.fb.group({
      AccountNumber: [null, [Validators.required]],
      AccountName: [null, [Validators.required]],
      Creditor: [null, [Validators.required]],
      Debtor: [null, [Validators.required]],
      CostCenterCode: [null, [Validators.required]],
      CostCenterName: [null, [Validators.required]],
      discription: [null, [Validators.required]]
    });
  }
}
