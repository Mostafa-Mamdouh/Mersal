import { Component, OnInit, Output, EventEmitter, Input, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { forEach } from '@angular/router/src/utils/collection';
import * as $ from 'jquery';
import { FinancialService } from '../../../Financial/Services/financial.service';
import { CostCenters } from '../../../Financial/Models/receipts.model';

@Component({
  selector: 'app-store-cost-center',
  templateUrl: './store-cost-center.component.html',
  styleUrls: ['./store-cost-center.component.scss'],
  providers: [FinancialService]
})
export class StoreCostCenterComponent implements OnInit {
  @Input() DetailsCostCenters;
  costCentersLookup: any[] = [];
  costCentersList: any[] = [];
  outputCostCenters: any[] = [];
  totalAssign: number = 0;
  addCostCenter: FormGroup;
  @Output() costCentersListChanged: EventEmitter<CostCenters[]> = new EventEmitter();
  IsDetails = false;
  editQuantity: any;
  allCostCenters: any[];
  CostId: any;
  initialized = false;


  constructor(
    public router: Router,
    private fb: FormBuilder,
    private financialService: FinancialService,
    private notification: NotificationService) {
  }

  ngOnInit() {
    this.buildForm();
    this.getCostCentersLookup();

  }
  ngOnChanges(changes: SimpleChanges) {
  }

  getCostCentersLookup() {

    this.financialService.getCostCentersLookups()
      .subscribe(res => {
        this.initialized = true;

        this.costCentersLookup = res;
        var CostCenters = new Array<any>();
        res.forEach(function (item) {
          CostCenters.push(
            {
              name: item.name,
              id: item.id,
              costCenterId: item.id,
              code: item.code,
              checked: false,
              display: true,
              assignValue: 0
            });
        });
        this.costCentersList = CostCenters;
        if (this.DetailsCostCenters != null &&
          this.DetailsCostCenters != undefined &&
          this.DetailsCostCenters.length > 0 &&
          this.initialized) {
          // this.buildForm();
          this.setDeatilsValues();
        }
      });

  }

  //build list for cost Center gride
  addCostCenterItems() {
    this.outputCostCenters = [];
    const selectedItem = this.allCostCenters.find(x => x.id == this.addCostCenter.controls['costCenterCode'].value);
    if (this.costCentersList.find(x => x.id == selectedItem.id) == undefined) {
      this.costCentersList.push({
        id: selectedItem.id,
        costCenterId: selectedItem.id,
        name: selectedItem.name,
        display: true
      });
    }


    this.getTotalAssign();
    // this.deleteFromlookup(selectedItem);
    this.buildForm();
  }
  search(key) {
    if (key == "" || key == " ") {
      this.costCentersList.forEach(function (item) {
        item.display = true;
      });
    }
    else {
      var resluts = this.costCentersList.filter(x => x.name.search(key) != -1)
      if (resluts != null) {
        this.costCentersList.forEach(function (item) {
          if (resluts.find(x => x.id == item.id) != null) {
            item.display = true;
          }
          else {
            item.display = false;
          }

        });
      }
      else {
        this.costCentersList.forEach(function (item) {
          item.display = false;
        });
      }
    }
  }
  //build object For Sended View Model Collection
  submitAddCostCenter() {
    this.outputCostCenters = [];
    this.costCentersList.filter(x => x.checked == true).forEach((item, index) => {
      this.outputCostCenters.push({
        costCenterId: item.id
      });
      this.fireOutputListChanged();
      $('#openCostCentersModalBTN').click();
    });
  }
  //searchMethod
  setDeatilsValues() {
    this.IsDetails = true;
    this.DetailsCostCenters.forEach((costcenter) => {
      this.costCentersList.find(x => x.id == costcenter.costCenterId).checked = true;
      this.costCentersList.find(x => x.id == costcenter.costCenterId).assignValue = costcenter.amount;
    });
  }

  getTotalAssign() {
    this.totalAssign = 0;
    for (let item of this.costCentersList) {
      this.totalAssign = this.totalAssign + item.assignValue;
    }
  }

  fireOutputListChanged(): void {
    console.log("Cost Centers Ready To Submit " + JSON.stringify(this.outputCostCenters));
    this.costCentersListChanged.emit(this.outputCostCenters);
  }

  buildForm(): void {
    this.addCostCenter = this.fb.group({
      costCenterCode: [null, [Validators.required]],
      beneficiaries: []
    });
  }

  close() {
    debugger;
    for (let index = 0; index < this.costCentersList.length; index++) {
      const element = this.costCentersList[index];
      element.checked = false;
    }
    let c = document.getElementById("multiCostCenter") as HTMLInputElement
    c.checked = false;
    $("#openCostCentersModalBTN").click();
  }

}
