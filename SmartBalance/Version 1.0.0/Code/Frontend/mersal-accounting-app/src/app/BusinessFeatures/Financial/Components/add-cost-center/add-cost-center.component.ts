import { FinancialService } from "../../Services/financial.service";
import {
  Component,
  OnInit,
  Output,
  EventEmitter,
  Input,
  SimpleChanges
} from "@angular/core";
import { Router } from "@angular/router";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Beneficiaries } from "../../Models/beneficiaries.model";
import { NotificationService } from "../../../../SharedFeatures/SharedMain/Services/notification.service";
import { CostCenters } from "../../Models/receipts.model";
import { forEach } from "@angular/router/src/utils/collection";
import * as $ from "jquery";

@Component({
  selector: "app-add-cost-center",
  templateUrl: "./add-cost-center.component.html",
  styleUrls: ["./add-cost-center.component.scss"],
  providers: [FinancialService]
})
export class AddCostCenterComponent implements OnInit {
  @Input() donationValue: number;
  @Input() DetailsCostCenters;
  @Input() EditeCostCenters;
  @Input() IsInventory: boolean;
  @Input() costCentersList: any[] = [];
  costCentersLookup: any[] = [];
  //costCentersList: any[] = [];
  outputCostCenters: CostCenters[] = [];
  totalAssign: number = 0;
  addCostCenter: FormGroup;
  @Output() costCentersListChanged: EventEmitter<CostCenters[]> = new EventEmitter();
  @Input() IsDetails = false;
  editQuantity: any;
  allCostCenters: any[];
  CostId: any;
  initialized = false;

  constructor(
    public router: Router,
    private fb: FormBuilder,
    private financialService: FinancialService,
    private notification: NotificationService
  ) { }

  ngOnInit() {
    debugger;
    this.buildForm();
    this.getCostCentersLookup();
  }
  ngOnChanges(changes: SimpleChanges) {
    debugger;
    this.setValues();

    //   if (this.DetailsCostCenters!=null&&this.DetailsCostCenters!=undefined&&this.DetailsCostCenters.length>0
    //     &&this.initialized)
    //   {
    //     // this.buildForm();
    //     this.setDeatilsValues();
    // }
  }

  getCostCentersLookup() {
    this.financialService.getCostCentersLookups().subscribe(res => {
      this.initialized = true;

      this.costCentersLookup = res;
      let CostCenters = new Array<any>();
      res.forEach(function (item) {
        CostCenters.push({
          name: item.name,
          id: item.id,
          code: item.code,
          checked: false,
          display: true,
          assignValue: 0
        });
      });
      this.costCentersList = CostCenters;

      console.log(this.DetailsCostCenters);
      this.setValues();     
    });
  }

  setValues() {
    if (
      this.DetailsCostCenters != null &&
      this.DetailsCostCenters != undefined &&
      this.DetailsCostCenters.length > 0 &&
      this.initialized
    ) {
      // this.buildForm();
      this.setDeatilsValues();
    }
    else if (
      this.EditeCostCenters != null &&
      this.EditeCostCenters != undefined &&
      this.EditeCostCenters.length > 0 &&
      this.initialized
    ) {
      this.setEditValues();
    }
  }

  //build list for cost Center gride setEditValues
  addCostCenterItems() {
    this.outputCostCenters = [];
    const selectedItem = this.allCostCenters.find(
      x => x.id == this.addCostCenter.controls["costCenterCode"].value
    );
    if (this.costCentersList.find(x => x.id == selectedItem.id) == undefined) {
      this.costCentersList.push({
        id: selectedItem.id,
        name: selectedItem.name,
        assignValue: 0,
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
    } else {
      var resluts = this.costCentersList.filter(x => x.name.search(key) != -1);
      if (resluts != null) {
        this.costCentersList.forEach(function (item) {
          if (resluts.find(x => x.id == item.id) != null) {
            item.display = true;
          } else {
            item.display = false;
          }
        });
      } else {
        this.costCentersList.forEach(function (item) {
          item.display = false;
        });
      }
    }
  }
  //build object For Sended View Model Collection
  submitAddCostCenter() {
    debugger;
    this.outputCostCenters = [];
    var vaildvalues = true;
    this.costCentersList
      .filter(x => x.checked == true)
      .forEach((item, index) => {
        if (!this.IsInventory) {
          if (
            item.assignValue != 0 &&
            item.assignValue > 0 &&
            item.assignValue != null
          ) {
            this.outputCostCenters.push({
              id: item.id,
              costCenterId: item.id,
              amount: item.assignValue,
              assignValue: item.assignValue
            });
          } else {
            item.assignValue = 0;
            vaildvalues = false;
          }
        }
        else {
          this.outputCostCenters.push({
            id: item.id,
            costCenterId: item.id,
            amount: 0,
            assignValue: 0
          })
        }
      })
    this.outputCostCenters = this.costCentersList
      .filter(x => x.checked == true);
    if (this.outputCostCenters.length > 0) {
      if (vaildvalues) {
        this.fireOutputListChanged();
        $("#openCostCentersModalBTN").click();
      } else {
        this.notification.showTranslateError("movements.costcenteramounterror");
      }
    } else {
      this.notification.showTranslateError("purchasing.rebate.costCenteReq");
    }
  }
  //searchMethod
  setDeatilsValues() {
    debugger;
    console.log(this.DetailsCostCenters);
    this.IsDetails = true;
    this.DetailsCostCenters.forEach(costcenter => {
      let costCenterItem = this.costCentersList.find(x => x.id == costcenter.costCenterId);
      costCenterItem.checked = true;
      costCenterItem.assignValue = costcenter.amount;
      if (!costCenterItem.amount && costcenter.amount) {
        costCenterItem.amount = costcenter.amount;
      }
    });
  }
  setEditValues() {
    debugger;
    this.IsDetails = false;
    this.EditeCostCenters.forEach(costcenter => {
      debugger;
      var costCenterItem = this.costCentersList.find(x => x.id == costcenter.costCenterId);
      if (costCenterItem) {
        costCenterItem.checked = true;
        costCenterItem.assignValue = costcenter.amount;
        // if (!costCenterItem.amount && costcenter.amount) {
        //   costCenterItem.amount = costcenter.amount;
        // }
      }
    });
  }

  getTotalAssign() {
    this.totalAssign = 0;
    for (let item of this.costCentersList) {
      this.totalAssign = this.totalAssign + item.assignValue;
    }
  }
  changeCheckingBox(id, value) {
    var val = !value.target.checked;
    if (val) $("#amount" + id).removeAttr("disabled");
    else $("#amount" + id).attr("disabled", "disabled");
    //  $("#amount"+id).prop("disabled","'"+val+"'")
  }
  // delete(item) {
  //   this.costCentersList.forEach((itm, index) => {
  //     if (item === itm) {
  //       this.costCentersList.splice(index, 1);
  //       this.returnTolookup(this.allCostCenters.find(x => x.id == item.id));
  //     }
  //   });
  //   this.getTotalAssign();
  //   this.fireBeneficiariesListChanged();
  // }

  // deleteFromlookup(item) {
  //   this.costCentersLookup.forEach((itm, index) => {
  //     if (item.id === itm.id) {
  //       this.costCentersLookup.splice(index, 1);
  //     }
  //   });
  //   // this.returnTolookup(this.allCostCenters.find(x => x.id == item.id))
  // }

  // returnTolookup(item) {
  //   this.costCentersLookup.push(item);
  // }
  //fire event cost center changes
  fireOutputListChanged(): void {
    console.log(
      "Cost Centers Ready To Submit " + JSON.stringify(this.outputCostCenters)
    );
    this.costCentersListChanged.emit(this.outputCostCenters);
  }

  buildForm(): void {
    this.addCostCenter = this.fb.group({
      costCenterCode: [null, [Validators.required]],
      beneficiaries: []
    });
  }

  Cancel() {
    debugger;
    if (!this.IsDetails) {
      for (let index = 0; index < this.costCentersList.length; index++) {
        const element = this.costCentersList[index];
        element.checked = false;
        element.assignValue = 0;
      }
      let c = document.getElementById("multiCostCenter") as HTMLInputElement
      c.checked = false;
      $("#openCostCentersModalBTN").click();
    }
  }
}
