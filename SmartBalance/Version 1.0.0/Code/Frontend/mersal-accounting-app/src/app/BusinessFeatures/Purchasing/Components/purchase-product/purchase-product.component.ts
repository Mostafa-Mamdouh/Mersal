import { PurchasingService } from './../../Services/Purchasing.service';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { Component, OnInit, EventEmitter, Output, Input, SimpleChanges } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { PurchaseRebate } from '../../Models/purchase-rebate.model';
import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';
import { BrandService } from '../../../Brand/Services/brand.service';
import { BrandLight } from '../../../Brand/Models/brand.model';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'purchase-product',
  styleUrls: ['./purchase-product.component.scss'],
  templateUrl: './purchase-product.component.html',
  providers: [PurchasingService]
})

export class PurchaseProductComponent implements OnInit {
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };
  editorMode: EditorMode = EditorMode.add;
  editorModeEnum = EditorMode;
  model: PurchaseRebate;
  modelForm: FormGroup;
  @Input() editId: number;
  @Input() detailId: number;
  @Input() products: any[];
  @Input() isInvoice: boolean;
  @Output() productListChanged: EventEmitter<FormArray> = new EventEmitter();
  //calc
  totalAmount: number = 0;
  totalExpenses: number = 0;
  totalDiscount: number = 0;
  netValue: number = 0;
  brands: any[] = [];
  measurementUnits: any[] = [];
  loadingtext: string = "";
  //units: any[] = [];


  constructor(
    private serv: PurchasingService,
    private fb: FormBuilder,
    private brandService: BrandService,
    private notification: NotificationService,
    private translateService: TranslateService) {
    this.buildForms();
  }

  ngOnInit() {


    this.translateService.get('shared.loading').subscribe(
      success => {
          this.loadingtext = success;
          console.log("translation now " + success);
      })
    //this.getUnits();
    this.getBrands();
    this.getMeasurementUnits();
    

    if (this.detailId) {
      debugger
      this.editorMode = EditorMode.detail;
      this.modelForm.disable();
    }
    else if (this.editId) {
      this.editorMode = EditorMode.edit
    }
    else {
      this.editorMode = EditorMode.add;
      // this.buildForms();
      this.addProduct();
    }



    //;
    this.modelForm.valueChanges.subscribe(() => {
      this.fireProductListChanged();
    }, () => {
    });
  }

  ngOnChanges(changes: SimpleChanges) {

    if (this.detailId != null) {
      this.editorMode = EditorMode.detail;

    }
    if (this.detailId != null) {
      this.editId = EditorMode.detail;

    }
    if (this.products != null) {
      // this.buildForms();
      // console.log(this.modelForm.value)
      this.products.forEach((element, index) => {
        (this.modelForm.get('products') as FormArray).removeAt(index);
      });
      (this.modelForm.get('products') as FormArray).removeAt(0);
      console.log("this.modelForm")

      console.log(this.modelForm)
      this.bindModelToForm();
    }    
  }

  bindModelToForm(): void {
    if (this.products.length > 0) {
      debugger
      this.products.forEach(element => {
        this.addProduct();
      });
      (this.modelForm.get('products') as FormArray).patchValue(this.products);
      this.products.forEach((element, i) => {

        (this.modelForm.get('products') as FormArray).at(i).get('brandName').setValue(element.brandName);
        this.calculateForProduct(i);
      });
    }
  }

  fireProductListChanged(): void {
    //;
    this.productListChanged.emit(this.modelForm.get('products') as FormArray);
  }

  // getUnits() {
  //   this.serv.getUnits()
  //     .subscribe(
  //       res => {
  //         this.units= res;
  //       }, () => {
  //         this.notification.showOperationFailed();
  //       }
  //     );
  // }

  getBrands() {
    let brand: BrandLight = new BrandLight();
    brand.displyedName = this.loadingtext; 
          let loodingArray = new Array();
          loodingArray.push(loodingArray);
    this.serv.getBrands().subscribe(res => {
      //;
      this.brands = res.collection;
      this.brands.forEach(x => {
        x.childBrands = loodingArray;
      });

    });
  }
  getMeasurementUnits() {
    this.serv.getMeasurementUnitsLookups()
      .subscribe(
        res => {
          //;
          this.measurementUnits = res.collection;
        },
        (error) => {
          //;
          console.error(JSON.stringify(error));
          this.notification.showOperationFailed();
        }
      );
  }

  onBrandChange(index, brandId) {
    ;
    (this.modelForm.get('products') as FormArray).controls[index]['controls']['brandId'].setValue(brandId);
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
    debugger
    var product = (this.modelForm.get('products') as FormArray).at(index).value;
    if (product.price > 0 && product.quantity > 0) {
      (this.modelForm.get('products') as FormArray).at(index).get('description').setValue(product.description);

      var total = product.price * product.quantity;
      (this.modelForm.get('products') as FormArray).at(index).get('total').setValue(total);
      (this.modelForm.get('products') as FormArray).at(index).get('netValue').setValue(((total + product.expenses) - (product.discount + product.totalDiscount)));
    }
    this.fireProductListChanged();
  }



  addProduct() {
    
    const journalDetails = this.modelForm.get('products') as FormArray;
    journalDetails.push(this.createProduct());
  }
  deleteProduct(item) {
    (this.modelForm.get('products') as FormArray).removeAt(item);
    //this.calcTotal();
  }

  buildForms(): void {
    this.modelForm = this.fb.group({
      products: this.fb.array([])
    });
  }

  createProduct(): FormGroup {
    return this.fb.group({
      brandId: [null, [Validators.required]],
      brandName: [null],
      measurementUnitId: [null],
      productId: [1],
      quantity: [1, [Validators.required, Validators.min(1)] ],
      price: [1, [Validators.required, Validators.min(1)]],
      total: [0],
      expenses: [0],
      discount: [0],
      totalDiscount: [0],
      netValue: [0],
      description:[null]
    });

    // return this.fb.group({
    //   brandId: [null, [Validators.required]],
    //   measurementUnitId: [null, [Validators.required]],
    //   productId   : [null],//, [Validators.required]],
    //   quantity   : [1, [Validators.required,Validators.min(0)]],
    //   price      : [0, [Validators.required,Validators.min(0)]],
    //   total      : [0, [Validators.required]],
    //   expenses   : [0, [Validators.required]],
    //   discount: [0, [Validators.required]],
    //   totalDiscount: [0, [Validators.required]],
    //   netValue  : [0, [Validators.required]],
    // });
  }

}