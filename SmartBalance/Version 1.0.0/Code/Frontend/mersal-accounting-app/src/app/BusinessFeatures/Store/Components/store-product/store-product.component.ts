import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { Component, OnInit, EventEmitter, Output, Input, SimpleChanges } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { PurchasingService } from '../../../Purchasing/Services/Purchasing.service';
import { StoreProducts } from '../../Models/opening-balance.model';
import { StoreService } from '../../Services/store.service';
import { BrandService } from '../../../Brand/Services/brand.service';
import { BrandLight } from '../../../Brand/Models/brand.model';
import { TranslateService } from '@ngx-translate/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../../User/Services/user.service'
import { PermissionEnum } from 'src/app/BusinessFeatures/User/Models/permission-enum';

@Component({
  selector: 'store-product',
  styleUrls: ['./store-product.component.scss'],
  templateUrl: './store-product.component.html',
  providers: [PurchasingService]
})
export class StoreProductComponent implements OnInit {
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };
  editorMode: EditorMode = EditorMode.add;
  editorModeEnum = EditorMode;
  model: any;
  modelForm: FormGroup;
  @Input() editId: number;
  @Input() detailId: number;
  @Input() isTransfer: boolean;
  @Input() products: StoreProducts[];
  @Input() canEditPrice:boolean;
  @Output() productListChanged: EventEmitter<FormArray> = new EventEmitter();
  brands: any[] = [];
  measurementUnits: any[] = [];
  allBrands: any[];
  filterBrands: any[];
  loadingtext:string = "";
  @Input() productsCount: number;
  isStorekeeper: boolean;
  //units: any[] = [];

  constructor(
    private serv: PurchasingService,
    private fb: FormBuilder,
    private storeServ: StoreService,
    private brandService: BrandService,
    private notification: NotificationService,
    private route: ActivatedRoute,
    private userService: UserService,
    private translateService: TranslateService) {
    this.buildForms();
  }

  ngOnInit() {
   debugger;
    this.translateService.get('shared.loading').subscribe(
      success => {
          this.loadingtext = success;
          console.log("translation now " + success);
      })
      this.userService.isCurrentUserHassPermission(PermissionEnum.Storekeeper).subscribe(res =>{
        this.isStorekeeper = res;
      })

    this.getBrands();
    this.getMeasurementUnits();
    // debugger;
    if (this.editId) {
      this.editorMode = EditorMode.edit;

    }
    else if (this.detailId) {
      this.editorMode = EditorMode.detail;
      this.modelForm.disable();
    }
    else {
      this.editorMode = EditorMode.add;
      // this.buildForms();
      this.addProduct();
    }

    //debugger;
    this.modelForm.valueChanges.subscribe(() => {
      this.fireProductListChanged();
    }, () => {
    });
  }

  ngOnChanges(changes: SimpleChanges) {
    if (this.products != null) {
      this.products.forEach((element, index) => {
        (this.modelForm.get('products') as FormArray).removeAt(index);
      });
      (this.modelForm.get('products') as FormArray).removeAt(0);
      this.bindModelToForm();
    }
  }

  onBrandChange(index, brandId) {
    debugger;
    (this.modelForm.get('products') as FormArray).controls[index]['controls']['brandId'].setValue(brandId);
    if ((this.modelForm.get('products') as FormArray).value.length < 2) {

      return;
    }
    else {
      var list = (this.modelForm.get('products') as FormArray).value;
      var isUnique = list.filter(x => x.brandId === brandId).length > 1;
      if (isUnique) {
        (this.modelForm.get('products') as FormArray).controls[index]['controls']['brandId'].setErrors({ notUnique: true });
        (this.modelForm.get('products') as FormArray).controls[index]['controls']['brandId'].setValue(null);
        (this.modelForm.get('products') as FormArray).controls[index].markAsTouched();
        this.notification.showTranslateError('addProduct.brandIsUnique');
      }
    }
  }
  onQuantityChange(index) {
    debugger;
    console.log((this.modelForm.get('products') as FormArray).controls[index]['controls']['quantity'].value);
    console.log((this.modelForm.get('products') as FormArray).controls[index]['controls']['oldQuantity'].value);
    if (!this.isTransfer) {
      return;
    }
    else {
      if ((this.modelForm.get('products') as FormArray).controls[index]['controls']['quantity'].value >
        (this.modelForm.get('products') as FormArray).controls[index]['controls']['oldQuantity'].value) {
        //(this.modelForm.get('products') as FormArray).controls[index]['controls']['quantity'].setErrors({ notUnique: true });
        //(this.modelForm.get('products') as FormArray).controls[index]['controls']['quantity'].setValue(null);
        (this.modelForm.get('products') as FormArray).controls[index].markAsTouched();
        this.notification.showTranslateError('addProduct.quantityMax');
      }

    }
  }

  bindModelToForm(): void {
    debugger
    if (this.products.length > 0) {
      const list = this.modelForm.get('products') as FormArray;
      list.value.forEach((element, index) => {
        (this.modelForm.get('products') as FormArray).removeAt(0);
      });
      this.products.forEach(element => {
        this.addProduct();
      });
      (this.modelForm.get('products') as FormArray).patchValue(this.products);
      this.products.forEach((element, i) => {
        //debugger;
        (this.modelForm.get('products') as FormArray).at(i).get('quantity').setValue(element.quantity);
        (this.modelForm.get('products') as FormArray).at(i).get('oldQuantity').setValue(element.quantity);
        (this.modelForm.get('products') as FormArray).at(i).get('brandName').setValue(element.brandName);
        this.calculateForProduct(i);
      });
    }
  }

  fireProductListChanged(): void {
    //debugger;
    this.productListChanged.emit(this.modelForm.get('products') as FormArray);
  }

  getBrands() {
    let brand: BrandLight = new BrandLight();
    brand.displyedName = this.loadingtext; 
          let loodingArray = new Array();
          loodingArray.push(loodingArray);
    this.serv.getBrands().subscribe(res => {
      //debugger;
      this.brands = res.collection;
      this.brands.forEach(x => {
        x.childBrands = loodingArray;
      });
      this.allBrands = res.collection;
      this.filterBrands = res.collection;

    },
      (error) => {
        //debugger;
        console.error(JSON.stringify(error));
        this.notification.showOperationFailed();
      }
    );
  }
  getMeasurementUnits() {
    this.serv.getMeasurementUnitsLookups().subscribe(res => {
      //debugger;
      this.measurementUnits = res.collection;
    },
      (error) => {
        //debugger;
        console.error(JSON.stringify(error));
        this.notification.showOperationFailed();
      }
    );
  }

  brandExpand(event){
    let brand: BrandLight = new BrandLight();
    brand.displyedName = this.loadingtext; 
          let loodingArray = new Array();
          loodingArray.push(loodingArray);
    this.brandService.getBrandChildren(event.dataItem.id).subscribe(res => {
      res.forEach(x => {
        x.childBrands = loodingArray;
      });
      event.dataItem.childBrands = res;
    });
  }
  //calc function
  calculateForProduct(index) {
    debugger;
    var product = (this.modelForm.get('products') as FormArray).at(index).value;
    if (product.quantity > 0) {
      var total = product.price * product.quantity;
      (this.modelForm.get('products') as FormArray).at(index).get('total').setValue(total);
    }
    this.fireProductListChanged();
  }


  addProduct() {
   
    const journalDetails = this.modelForm.get('products') as FormArray;
    journalDetails.push(this.createProduct());
    console.log(journalDetails)

  }
  deleteProduct(item, product) {
    debugger
    if(item<this.productsCount)
    {
      this.productsCount-=1;
    }
    debugger;
    // if(product.value.id>0){
    //   this.storeServ.deleteProduct(product.value.id).subscribe(res => {
    //     this.notification.showOperationSuccessed();
    //   }, (error) => {
    //     console.error(JSON.stringify(error));
    //     this.notification.showOperationFailed();
    //   }, () => {
    //   });
    // }
    (this.modelForm.get('products') as FormArray).removeAt(item);
  }

  buildForms(): void {
    this.modelForm = this.fb.group({
      products: this.fb.array([])
    });
  }

  createProduct(): FormGroup {
    return this.fb.group({
      id: [],
      brandId: [null, [Validators.required]],
      brandName: [null],
      measurementUnitId: [null, [Validators.required]],
      quantity: [1, [Validators.required, Validators.min(1)]],
      oldQuantity: [],
      price: [null, [Validators.min(1)]],
      total: [null, [Validators.required]],
      productId: [1],
      discount: [0],
      totalDiscount: [0],
      netValue: [0]
    });
  }

}