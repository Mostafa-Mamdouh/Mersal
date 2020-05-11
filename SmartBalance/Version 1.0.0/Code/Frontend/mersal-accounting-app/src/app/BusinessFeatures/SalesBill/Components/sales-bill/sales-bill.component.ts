import { ProductList } from '../../../Products/Models/product-list.model';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BsDatepickerViewMode } from 'ngx-bootstrap/datepicker/models';
import { BsDatepickerConfig } from 'ngx-bootstrap';
import { BillSummary } from '../../Models/bill-summary.model';
import { Costumer } from '../../Models/customer.model';
import { CostCenter } from '../../Models/cost-center.model';
import { Delegate } from '../../Models/delegate.model';

import { SalesService } from '../../Services/sales-bill.service';
import { Inventory } from '../../Models/inventory.model';



@Component({
  selector: 'app-sales-bill',
  templateUrl: './sales-bill.component.html',
  styleUrls: ['./sales-bill.component.scss'],
  providers: [SalesService]
})

export class SalesBillsComponent implements OnInit {
  addSalesBill: FormGroup;
  BillTypes: any[];
  BillSummary: BillSummary[];
  ProductList: ProductList[];
  CostumersList: Costumer[];
  CostCenterList: CostCenter[];
  DelegateList: Delegate[];
  InventoryList: Inventory[];
  bsDatePickerValue: Date;
  salesBill: any[];
  // @Output() salesBillsChanged: EventEmitter<SalesBillDetails[]> = new EventEmitter();

  constructor(
    public router: Router,
    private fb: FormBuilder,
    private salesService: SalesService) { }

  ngOnInit() {
    this.bsDatePickerValue = new Date();
    this.SalesBillForm();
    this.getBillTypesLookups();
    this.getCostumersLookups();
    this.getCostCentersLookups();
    this.getDelegatesListLookups();
    this.getInventoriessListLookups();

  }

  getBillTypesLookups() {
    this.salesService.getBillTypesLookups().subscribe(data => this.BillTypes = data);
  }
  getCostumersLookups() {
    this.salesService.getCostumersLookups().subscribe(data => this.CostumersList = data);
  }
  getCostCentersLookups() {
    this.salesService.getCostCentersLookups().subscribe(data => this.CostCenterList = data);
  }
  getDelegatesListLookups() {
    this.salesService.getDelegatesListLookups().subscribe(data => this.DelegateList = data);
  }
  getInventoriessListLookups() {
    this.salesService.getInventoriesLookups().subscribe(data => this.InventoryList = data);
  }

  handleBillSummaryChange(billSummary: BillSummary[]) {
    console.log('From Sales Component => ', billSummary);
    this.BillSummary = billSummary;
  }

  handleProductListChange(productList: ProductList[]) {
    console.log('From Sales Component =>', productList);
    this.ProductList = productList;
  }

  AddSales() { }

  AddProduct() {
    debugger;
    this.salesBill.push({
      BillId: 2,
      BillNumber: this.addSalesBill.controls['BillNumber'].value,
      BillDate: this.addSalesBill.controls['BillDate'].value,
      LinkedToCostCenter: this.addSalesBill.controls['LinkedToCostCenter'].value,
      CostCenter: this.addSalesBill.controls['CostCenter'].value,
      BillType: this.addSalesBill.controls['BillType'].value,
      Customer: this.addSalesBill.controls['Customer'].value,
      Delegate: this.addSalesBill.controls['Delegate'].value,
      InventoryNumber: this.addSalesBill.controls['InventoryNumber'].value,
      BillSummary: this.BillSummary,
      ProductList: this.ProductList
    });
    console.log(this.salesBill);
    this.SalesBillForm();
  }

  cancel() {
    this.SalesBillForm();
  }

  SalesBillForm(): void {
    this.addSalesBill = this.fb.group({
      BillNumber: [null, [Validators.required]],
      BillDate: [new Date(), [Validators.required]],
      LinkedToCostCenter: [null, []],
      CostCenter: [null, [Validators.required]],
      BillType: [null, [Validators.required]],
      Customer: [null, [Validators.required]],
      Delegate: [null, [Validators.required]],
      InventoryNumber: [null, [Validators.required]],
      Products: [null, [Validators.required]]
    });
  }
}
