import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../../../router.animations';
import { TranslateService } from '@ngx-translate/core';
import { Router, NavigationEnd } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BsDatepickerViewMode } from 'ngx-bootstrap/datepicker/models';
import { BsDatepickerConfig } from 'ngx-bootstrap';
import { AddProductService } from '../../services/add-product.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss'],
  animations: [routerTransition()],
  providers: [AddProductService]
})
export class AddProductComponent implements OnInit {
  products: any = [];
  addBill: FormGroup;
  addProduct: FormGroup;
  Bill: any = [];
  HasDisCountValue = false;
  HasExpensesValue = false;
  bsValue: Date;

  constructor(
    private translate: TranslateService,
     public router: Router,
      private fb: FormBuilder,
       private productServ: AddProductService
       ) {
    // this.translate.addLangs(['en', 'ar', 'ur', 'es', 'it', 'fa', 'de', 'zh-CHS']);
    // this.translate.setDefaultLang('en');
    // const browserLang = this.translate.getBrowserLang();
    // this.translate.use(browserLang.match(/en|ar|ur|es|it|fa|de|zh-CHS/) ? browserLang : 'en');
  }
  // tslint:disable-next-line:semicolon
  ngOnInit() {
    this.ProductForm();

    this.bsValue = new Date();
   this.getAllProduct(); 
  }
  getAllProduct() {
    this.products = this.productServ.getAll();
  }
  AddProduct() {
    this.products.push({
      id: 2,
      ProductName: this.addProduct.controls['ProductName'].value,
      ProductCode: this.addProduct.controls['ProductCode'].value,
      price: this.addProduct.controls['price'].value,
      Quantity: this.addProduct.controls['Quantity'].value,
      Total: this.addProduct.controls['price'].value * this.addProduct.controls['Quantity'].value,
      UnitName: this.addProduct.controls['UnitName'].value,
      UnitCode: this.addProduct.controls['UnitCode'].value
    });
    this.ProductForm();
  }

  delete(item) {
    this.products.forEach((itm, index) => {
      if (item === itm) {
        this.products.splice(index, 1);
      }
    });
  }

  cancel() {
    this.ProductForm();
  }

  ProductForm(): void {
    this.addProduct = this.fb.group({
      ProductCode: [null, [Validators.required]],
      ProductName: [null, [Validators.required]],
      UnitCode: [null, [Validators.required]],
      UnitName: [null, [Validators.required]],
      Quantity: [null, [Validators.required]],
      price: [null, [Validators.required]]
    });
  }
}
