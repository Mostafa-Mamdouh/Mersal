import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../../../router.animations';
import { TranslateService } from '@ngx-translate/core';
import { Router, NavigationEnd } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-store-balance',
  templateUrl: './store-balance.component.html',
  styleUrls: ['./store-balance.component.scss'],
  animations: [routerTransition()]
})
export class StoreBalanceComponent implements OnInit {
  products: any = [];
  addBill: FormGroup;
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
  }

  AddBill() {
    this.Bill.push({
      id: 2,
      DocumentNumber: this.addBill.controls['DocumentNumber'].value,
      DateDocument: this.addBill.controls['DateDocument'].value,
      StoreNumber: this.addBill.controls['StoreNumber'].value,
      StatementEn: this.addBill.controls['StatementEn'].value,
      StatementAr: this.addBill.controls['StatementAr'].value
    });
    console.log(this.Bill);
    this.buildForm();
  }

  cancel() {
    this.buildForm();
  }

  buildForm(): void {
    this.addBill = this.fb.group({
      DocumentNumber: [null, [Validators.required]],
      DateDocument: [new Date(), [Validators.required]],
      StoreNumber: [null, [Validators.required]],
      StatementEn: [null, [Validators.required]],
      StatementAr: [null, [Validators.required]]
    });
  }
}
