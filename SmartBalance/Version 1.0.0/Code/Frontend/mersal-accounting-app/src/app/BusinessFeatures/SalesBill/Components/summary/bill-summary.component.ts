import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Router, NavigationEnd } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BillSummary } from '../../Models/bill-summary.model';
@Component({
  selector: 'app-bill-summary',
  templateUrl: './bill-summary.component.html',
  styleUrls: ['./bill-summary.component.scss'],
})
export class BillSummaryComponent implements OnInit {
  addBillSummary: FormGroup;
  BillSummary: BillSummary[] = [];
  @Output() billSummaryChange: EventEmitter<BillSummary[]> = new EventEmitter();

  constructor(private translate: TranslateService, public router: Router, private fb: FormBuilder) {
  }

  ngOnInit() {
    this.buildForm();
  }


  AddBillSummary() {
    this.BillSummary.push({
      BillTotal: this.addBillSummary.controls['BillTotal'].value,
      TotalCost: this.addBillSummary.controls['TotalCost'].value,
      TotalDiscount: this.addBillSummary.controls['TotalDiscount'].value,
      BillNet: this.addBillSummary.controls['BillNet'].value,
    });
    console.log(this.BillSummary);
    this.billSummaryChange.emit(this.BillSummary);
    this.buildForm();
  }

  cancel() {
    this.buildForm();
  }


  buildForm(): void {
    this.addBillSummary = this.fb.group({
      BillTotal: [null, [Validators.required]],
      TotalCost: [null, [Validators.required]],
      TotalDiscount: [null, [Validators.required]],
      BillNet: [null, [Validators.required]],
    });
  }
}
