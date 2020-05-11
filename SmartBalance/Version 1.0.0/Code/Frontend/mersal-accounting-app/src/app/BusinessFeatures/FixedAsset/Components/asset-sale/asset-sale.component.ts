import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import {Component, OnInit, EventEmitter, Output, Input, SimpleChanges} from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { EditorMode } from '../../../../SharedFeatures/SharedMain/Models/editor-mode.enum';

@Component({
    selector: 'asset-sale',
    styleUrls: ['./asset-sale.component.scss'],
    templateUrl: './asset-sale.component.html',
})

export class AssetSaleComponent implements OnInit {   
  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };
  modelForm: FormGroup;
  @Input() saleAssets:any[]; 
  @Output() assetListChanged: EventEmitter<FormArray> = new EventEmitter();
//calc
  //units: any[] = [];


  constructor(
    private fb: FormBuilder,
    private notification: NotificationService) {
      this.buildForms();
    }

  ngOnInit() {
    
    //this.getUnits();
    
    debugger;
    this.buildForms()
    this.modelForm.valueChanges.subscribe(() => {
       this.fireAssetListChanged();
    },() => {
    });
  }

  bindModelToForm(): void {
    debugger;
    if (this.saleAssets.length > 0) {
          this.saleAssets.forEach(element => {
            this.addAsset();
          });
          (this.modelForm.get('assets') as FormArray).patchValue(this.saleAssets);
          this.saleAssets.forEach((element,i) => {
            
            // if(element.productId){
            //   (this.modelForm.get('products') as FormArray).at(i).get('productId').setValue(element.productId);
            // }else{
            //   (this.modelForm.get('products') as FormArray).at(i).get('productId').setValue(element.id);
            // }     

           //debugger;
            this.calculateForAsset(i);
          });   
      }
  }

  fireAssetListChanged(): void {
    debugger;
    this.assetListChanged.emit(this.modelForm.get('saleAssets') as FormArray);
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


 //calc function

 calculateForAsset(index){
  //debugger;
 var product= (this.modelForm.get('saleAssets') as FormArray).at(index).value;
 if(product.price>0 && product.quantity>0){
   var total=product.price*product.quantity;
  (this.modelForm.get('saleAssets') as FormArray).at(index).get('total').setValue(total);
  (this.modelForm.get('saleAssets') as FormArray).at(index).get('netValue').setValue(((total+product.expenses)-(product.discount+product.totalDiscount)));
 }
 this.fireAssetListChanged();
}

 addAsset() {
  const saleAssets = this.modelForm.get('saleAssets') as FormArray;
  saleAssets.push(this.createAsset()); 
}

 
  buildForms(): void {
    debugger;
    this.modelForm = this.fb.group({
      saleAssets: this.fb.array([])
    });
  }

  createAsset(): FormGroup {
     debugger;
    return this.fb.group({
      brandCode: [null],
      assetId: [null],
      salePrice   : [null]
    });

  }

}