import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';
import { TranslateService } from '@ngx-translate/core';
import { Router, NavigationEnd } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
    selector: 'app-sales',
    templateUrl: './sales.component.html',
    styleUrls: ['./sales.component.scss'],
     animations: [routerTransition()]
})
export class SalesComponent implements OnInit {
    products: any = [];
    addBill: FormGroup;
    addProduct: FormGroup;
    Bill: any = [];
    HasDisCountValue = false;
    HasExpensesValue = false;


    constructor(private translate: TranslateService,
         public router: Router,
         private fb: FormBuilder) {

        // this.translate.addLangs(['en', 'ar', 'ur', 'es', 'it', 'fa', 'de', 'zh-CHS']);
        // this.translate.setDefaultLang('en');
        // const browserLang = this.translate.getBrowserLang();
        // this.translate.use(browserLang.match(/en|ar|ur|es|it|fa|de|zh-CHS/) ? browserLang : 'en');
    }
    // tslint:disable-next-line:semicolon
    ngOnInit() {}

}
