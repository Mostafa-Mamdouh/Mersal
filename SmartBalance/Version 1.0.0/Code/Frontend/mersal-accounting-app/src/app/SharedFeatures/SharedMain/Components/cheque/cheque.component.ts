import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Router } from '@angular/router';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
import { FormGroup, FormBuilder, Validators, FormsModule } from '@angular/forms';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { BankService } from '../../../../BusinessFeatures/Bank/Services/bank.service';
import { Cheque } from '../../Models/cheque.mode';
import { BankAccountChartService } from 'src/app/BusinessFeatures/Bank-Account-Chart/Services/bank-account-chart.service';
import { BankAccountChart } from 'src/app/BusinessFeatures/Bank-Account-Chart/Models/bank-account-chart.model';
import { KendoDropDown } from '../../Models/KendoDropDown.model';
import { EditorMode } from '../../Models/editor-mode.enum';
//import { eventNames } from 'cluster';


@Component({
    selector: 'cheque',
    templateUrl: './cheque.component.html',
    styleUrls: ['./cheque.component.scss'],
})
export class chequeComponent implements OnInit {
    @Input() canEdit: boolean;
    @Input() cheque: Cheque;
isRequired : boolean=false;
    @Output() chequeFormValueChanged: EventEmitter<any> = new EventEmitter();

    chequeFormGroup: FormGroup;
    isSubmited: boolean = false;
    banks: any[];
    public filterSettings: DropDownFilterSettings = {
        caseSensitive: false,
        operator: 'contains'
    };
    BankAcountChartsDropDownData: BankAccountChart[];
    editorMode: EditorMode = EditorMode.add;
    editorModeEnum = EditorMode;
    constructor(
        private fb: FormBuilder,
        private notification: NotificationService,
        private bankService: BankService,
        private BankAccountChart: BankAccountChartService
    ) { }

    ngOnInit() {
        this.buildForm();
        this.getBanks();
    }

    getBanks() {
        this.bankService.getBanksLookups()
            .subscribe(
                res => {
                    //this.PageLoading = false;
                    // var array = new Array<any>();
                    // res.collection.forEach(function (item) {
                    //   var record = new KendoDropDown();
                    //   record.text = item.name;
                    //   record.value = item.id;
                    //   array.push(record);
                    // });
                    this.banks = res.collection;
                }, () => {
                    //this.PageLoading = false;
                    this.notification.showOperationFailed();
                }
            );
    }
    ToBankCahnged(value) {
      if(value!=null && value!=undefined && value!=""){
        this.chequeFormGroup.controls['bankaccountchartId'].setValidators([Validators.required]);
        this.chequeFormGroup.controls['bankaccountchartId'].updateValueAndValidity();
        this.isRequired=true;
        
        }
          else  
        {
            this.chequeFormGroup.controls['bankaccountchartId'].setValidators(null);
            this.chequeFormGroup.controls['bankaccountchartId'].updateValueAndValidity();
            this.isRequired=false;

        }
        this.BankAccountChart.getAccountCharts(value.id).subscribe(res => {
            //debugger;  
            var array = new Array<any>();
            res.forEach(function (item) {
                var record = new KendoDropDown();
                record.text = item.displyedName;
                record.value = +item.id;
                array.push(record);
            });
            this.BankAcountChartsDropDownData = array;
        }, (error) => {
            this.notification.showOperationFailed();
        }, () => {
        });
    }

    buildForm(): void {
        debugger;
        this.chequeFormGroup = this.fb.group({
            fromBankId: [this.cheque.fromBankId, [Validators.required]],
            chequeNumber: [this.cheque.chequeNumber, [Validators.required]],
            dueDate: [(this.cheque.dueDate) ? this.cheque.dueDate : new Date(), [Validators.required]],
            toBankId: [this.cheque.toBankId],
            bankaccountchartId: [this.cheque.bankaccountchartId]
        });

        this.chequeFormGroup.valueChanges.subscribe(res => {
            this.chequeFormValueChanged.emit(res);
        });
    }


}
