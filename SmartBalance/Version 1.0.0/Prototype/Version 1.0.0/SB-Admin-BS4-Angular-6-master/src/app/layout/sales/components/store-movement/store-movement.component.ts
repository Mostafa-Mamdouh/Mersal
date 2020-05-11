import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../../../router.animations';
import { TranslateService } from '@ngx-translate/core';
import { Router, NavigationEnd } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { StoreMovementService } from '../../services/store-movement.service';

@Component({
  selector: 'app-store-movement',
  templateUrl: './store-movement.component.html',
  styleUrls: ['./store-movement.component.scss'],
  animations: [routerTransition()],
  providers: [StoreMovementService]
})
export class StoreMovementComponent implements OnInit {
  products: any = [];
  addBill: FormGroup;

  Bill: any = [];
  HasDisCountValue = false;
  HasExpensesValue = false;
  MovementTypes: { id: string; name: string; }[];

  constructor(private translate: TranslateService, public router: Router, private fb: FormBuilder,
    private storeServ: StoreMovementService) {
    // this.translate.addLangs(['en', 'ar', 'ur', 'es', 'it', 'fa', 'de', 'zh-CHS']);
    // this.translate.setDefaultLang('en');
    // const browserLang = this.translate.getBrowserLang();
    // this.translate.use(browserLang.match(/en|ar|ur|es|it|fa|de|zh-CHS/) ? browserLang : 'en');
  }
  // tslint:disable-next-line:semicolon
  ngOnInit() {
    this.buildForm();
    this.getAllMovementTypes();
  }
  getAllMovementTypes() {
    this.MovementTypes = this.storeServ.getAllBillTypes();
  }
  AddBill() {
    this.Bill.push({
      id: 2,
      DocumentNumber: this.addBill.controls['DocumentNumber'].value,
      DateDocument: this.addBill.controls['DateDocument'].value,
      CostCenter: this.addBill.controls['CostCenter'].value,
      Organization: this.addBill.controls['Organization'].value,
      // AssociatedProducts: this.addBill.controls['AssociatedProducts'].value,
      MovementType: this.addBill.controls['MovementType'].value,
      StoreNumber: this.addBill.controls['StoreNumber'].value,
      MultiCostCenter: this.addBill.controls['MultiCostCenter'].value,
      ReferenceNumber: this.addBill.controls['ReferenceNumber'].value,
      SupplierCode: this.addBill.controls['SupplierCode'].value,
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
      CostCenter: [null, [Validators.required]],
      Organization: [null, [Validators.required]],
      // AssociatedProducts: [null, [Validators.required]],
      MovementType: [null, [Validators.required]],
      StoreNumber: [null, [Validators.required]],
      MultiCostCenter: [null, [Validators.required]],
      ReferenceNumber: [null, [Validators.required]],
      SupplierCode: [null, [Validators.required]],
      StatementEn: [null, [Validators.required]],
      StatementAr: [null, [Validators.required]]
    });
  }
}
