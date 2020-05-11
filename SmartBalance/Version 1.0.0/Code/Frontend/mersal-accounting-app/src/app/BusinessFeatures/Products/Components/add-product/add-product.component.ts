import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProductList } from '../../Models/product-list.model';
import { AddProductService } from '../../Services/product.service';
import { ProductLookup } from '../../Models/product-lookup.model.';
import { UnitLookup } from '../../Models/unit-lookup.model';
import { Products } from '../../../Financial/Models/receipts.model';
import * as $ from 'jquery';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss'],
  providers: [AddProductService]
})
export class AddProductComponent implements OnInit {
  products: ProductList[] = [];
  outputProduct: any[] = [];
  addProduct: FormGroup;
  @Output() productListChanged: EventEmitter<Products[]> = new EventEmitter();
  productsList: ProductLookup[];
  unitList: UnitLookup[];
  editQuantity: any;
  productLookupList: ProductLookup[];

  constructor(
    public router: Router,
    private fb: FormBuilder,
    private productServ: AddProductService) { }
  ngOnInit() {
    this.ProductForm();
    this.getProductLookup();
    //  this.getUnitLookup(); 
    //  this.unitList = [{id:1,
    //   code:"dfhfd",
    //   name:"string"}]
  }
  getProductLookup() {
    this.productServ.getProductLookup()
      .subscribe(res => {
        ///debugger;
        var ProductsArray = new Array<any>();
        res.forEach(function (item) {
          let Proname = item.name + " - " + item.code;
          ProductsArray.push({ name: Proname, id: item.id, code: item.code, unit: item.unitId, price: 0, quantity: 0, checked: false, display: true });
        });
        this.productsList = ProductsArray;
      }, (error) => {
        // debugger;
      }, () => {
        // debugger;
      });
  }
  // getUnitLookup() {

  //   this.productServ.getUnitLookup()
  //     .subscribe(res => {
  //      // debugger
  //       this.unitList = res;
  //     },(error) => {
  //        // debugger;
  //     },() => {
  //         // debugger;
  //     });
  // }


  submitAddProducts() {
    // debugger;
    this.outputProduct = [];
    this.productsList.forEach((item, index) => {
      if (item.checked && item.price != 0 && item.price != null && item.quantity != 0 && item.quantity != null) {
        this.outputProduct.push({
          ProductId: item.id,
          Amount: item.price,
          Quantity: item.quantity
        });
      }
    });
    this.fireProductListChanged();
    $('#openProductsModalBTN').click();
  }

  search(key) {
    if (key == "" || key == " ") {
      this.productsList.forEach(function (item) {
        item.display = true;
      });
    }
    else {
      var resluts = this.productsList.filter(x => x.name.includes(key))
      if (resluts != null) {
        this.productsList.forEach(function (item) {
          if (resluts.find(x => x.id != item.id)) {
            item.display = false;
          }

        });
      }
      else {
        this.productsList.forEach(function (item) {
          item.display = false;
        });
      }
    }
  }


  fireProductListChanged(): void {
    this.productListChanged.emit(this.outputProduct);
  }



  ProductForm(): void {
    this.addProduct = this.fb.group({
      ProductCode: [null, [Validators.required]],
      ProductId: [null, [Validators.required]],
      UnitCode: [null, [Validators.required]],
      UnitId: [null, [Validators.required]],
      Quantity: [null, [Validators.required, Validators.min(0)]],
      price: [null, [Validators.required]]
    });
  }
}
