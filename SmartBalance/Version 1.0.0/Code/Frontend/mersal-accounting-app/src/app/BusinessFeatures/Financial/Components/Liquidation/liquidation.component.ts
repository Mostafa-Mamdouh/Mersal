import { FinancialService } from '../../Services/financial.service';
import { Component, OnInit, Output, EventEmitter, Input, SimpleChanges, OnChanges, ViewChild, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { FormGroup, FormBuilder, Validators, FormsModule, FormArray } from '@angular/forms';
import { Donator } from '../../Models/receipts.model';
import { NotificationService } from '../../../../SharedFeatures/SharedMain/Services/notification.service';
import { TestamentService } from '../../Services/testament.service'
import { CostCenterService } from 'src/app/BusinessFeatures/CostCenter/Services/cost-center.service';
import { LiquidationType } from '../../Models/liquidation-type.enum';
import { ErrorService } from 'src/app/SharedFeatures/SharedMain/Services/error.service';
import { TranslateService } from '@ngx-translate/core';
import { KendoDropDown } from 'src/app/SharedFeatures/SharedMain/Models/KendoDropDown.model';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';
declare var $: any;


@Component({
    selector: 'app-liquidation',
    templateUrl: './liquidation.component.html',
    styleUrls: ['./liquidation.component.scss']
})
export class LiquidationComponent implements OnInit {
    liquidationType: any;
    costCenter: any;
    liquidationForm: FormGroup;
    isSubmited: boolean = false;
    doner: Donator = new Donator();
    paymentCodes: any[];
    testamentExtractions: any[];
    testamentCodes: any[];
    costCenterDropDown: any[];
    private itemModel: any;
    journalPreviewShow: boolean;
    journalPreview: any;
    total: number;
    advancesTypes: any[];
    status: any[];
    allKey: any;
    testamentKey: any;
    advanceKey: any;
    closedKey: any;
    openKey: any;
    state: any = false;
    lastCode: string = null;
    //@ViewChild("openPostlBTN") PostlBTN: ElementRef<HTMLElement> = new ElementRef<HTMLElement>()
    mode: string;
    public filterSettings: DropDownFilterSettings = {
        caseSensitive: false,
        operator: 'contains'
      };
      
    constructor(
        private router: Router,
        private fb: FormBuilder,
        private ReceiptsServ: FinancialService,
        private testamentService: TestamentService,
        private costCenterService: CostCenterService,
        private notification: NotificationService,
        private location: Location,
        private translateService: TranslateService,
        private errorService: ErrorService
    ) {

    }

    ngOnChanges(changes: SimpleChanges) {
        this.buildForm();
    }

    ngOnInit() {
        this.buildForm();
        this.getResourceKeys();
        this.getPaymentCodesLookup();
        this.getTestamentExtractionsLookup();
        this.getCostCenters();
        this.getAdvancesTypesLookups();
        this.getStatusLookups();
        debugger;
        let liquidation = JSON.parse(localStorage.getItem("liquidation"));
        if (liquidation != null) {
            this.liquidationForm.controls['code'].setValue(liquidation.code);
            this.liquidationForm.controls['costCenterId'].setValue(liquidation.costCenterId);
            this.liquidationForm.controls['liquidationType'].setValue(liquidation.liquidationType);
            for (let index = 0; index < liquidation.liquidationDetails.length; index++) {
                this.addUnliquidationDetails(liquidation.liquidationDetails[index])

            }
        }
    }

    buildForm(): void {
        this.liquidationForm = this.fb.group({
            code: [null],
            costCenterId: [],
            liquidationType: [this.liquidationType],
            liquidationDetails: this.fb.array([])
            //\\\ donerAccountChart: [null, [Validators.required]]
        });

        this.liquidationForm.valueChanges.subscribe(res => {
            this.total = 0;
            if (res.liquidationDetails.length > 0) {

                res.liquidationDetails.forEach(item => {
                    this.total += item.amount;
                })
            }
        })
    }

    getResourceKeys() {
        this.translateService.get([
            'shared.all'
        ]).subscribe(res => {
            debugger;
            if (res) {
                this.allKey = res['shared.all'];
            }
        });

        this.translateService.get([
            'liquidation.liquidationType.testament'
        ]).subscribe(res => {
            debugger;
            if (res) {
                this.testamentKey = res['liquidation.liquidationType.testament'];
            }
        });

        this.translateService.get([
            'liquidation.liquidationType.advance'
        ]).subscribe(res => {
            debugger;
            if (res) {
                this.advanceKey = res['liquidation.liquidationType.advance'];
            }
        });

        this.translateService.get([
            'liquidation.status.closed'
        ]).subscribe(res => {
            debugger;
            if (res) {
                this.closedKey = res['liquidation.status.closed'];
            }
        });

        this.translateService.get([
            'liquidation.status.open'
        ]).subscribe(res => {
            debugger;
            if (res) {
                this.openKey = res['liquidation.status.open'];
            }
        });
    }

    getPaymentCodesLookup() {
        this.ReceiptsServ.getPaymentCodes()
            .subscribe(res => {
                this.paymentCodes = res;
                //debugger;   
            }, (error) => {
                this.notification.showOperationFailed();
                // debugger;
            }, () => {
                // debugger;
            });
    }

    getTestamentExtractionsLookup() {
        this.testamentService.getTestamentExtractionsLookups()
            .subscribe(res => {
                this.testamentExtractions = res.collection;
                //debugger;   
                console.log(this.testamentExtractions);
            }, (error) => {
                this.notification.showOperationFailed();
                // debugger;
            }, () => {
                // debugger;
            });
    }

    getTestamentCodesLookup(id) {
        this.testamentService.getCodes(id).subscribe(res => {
            this.testamentCodes = res
            console.log(this.testamentCodes);
        })
    }

    getCostCenters() {
        this.costCenterService.getEmployeesCostCentersLookup()
            .subscribe(
                res => {
                    debugger;
                    //this.PageLoading = false;         
                    this.costCenterDropDown = res.collection;

                },
                // this.Branches = res,
                error => {
                    //this.PageLoading = false;         
                    //this.notificationService.showOperationFailed();
                }

            );
    }

    createAllFilter(): KendoDropDown {
        let record = new KendoDropDown();
        record.text = this.allKey;
        record.value = null;

        return record;
    }

    getAdvancesTypesLookups() {
        // this.testamentService.getAdvancesTypesLookups().subscribe(res => {
        //     this.advancesTypes = [];
        //     this.advancesTypes.push(this.createAllFilter());
        //     res.collection.forEach(item => {
        //         let record = new KendoDropDown();
        //         record.text = item.name;
        //         record.value = item.id;
        //         this.advancesTypes.push(record);
        //     })
        // })
        this.advancesTypes = [];

        this.advancesTypes.push(this.createAllFilter());

        let testament = new KendoDropDown();
        testament.text = this.testamentKey;
        testament.value = 1;
        this.advancesTypes.push(testament);

        let advance = new KendoDropDown();
        advance.text = this.advanceKey;
        advance.value = 4;
        this.advancesTypes.push(advance);
    }

    getStatusLookups() {
        this.status = [];
        this.status.push({ text: this.allKey, value: null });

        this.status.push({ text: this.closedKey, value: true });


        this.status.push({ text: this.openKey, value: false });
    }

    costCenterValueChange(event) {
        this.costCenter = event;
        this.removeLiquidationDetails()
        this.testamentService.getUnliquidation(this.costCenter, this.liquidationType, this.state).subscribe(res => {
            res.forEach(item => {
                this.addUnliquidationDetails(item);
            })
            console.log(res);
        })
    }

    liquidationTypeValueChange(event) {
        if (this.costCenter) {
            this.liquidationType = event;
            this.removeLiquidationDetails();
            this.testamentService.getUnliquidation(this.costCenter, this.liquidationType, this.state).subscribe(res => {
                debugger;
                res.forEach(item => {
                    debugger;
                    this.addUnliquidationDetails(item);
                })
                console.log(res);
            })
        }

        this.getTestamentCodesLookup(event);
    }
    statusValueChange(event) {
        if (this.costCenter) {
            this.state = event;
            this.removeLiquidationDetails();
            this.testamentService.getUnliquidation(this.costCenter, this.liquidationType, this.state).subscribe(res => {
                debugger;
                res.forEach(item => {
                    debugger;
                    this.addUnliquidationDetails(item);
                })
                console.log(res);
            })
        }
    }

    amountValueChange(event) {
        this.total = 0;
        let liquidationDetails = this.liquidationForm.controls['liquidationDetails'].value;
        liquidationDetails.forEach(item => {
            this.total += item.amount;
        })
    }

    createLiquidationDetails(code): FormGroup {
        return this.fb.group({
            liquidationNumber: [code, [Validators.required]],
            amount: [null, [Validators.required]],
            testamentExtractionId: [null, [Validators.required]],
            caseCode: [null],
            taxDiscount: [null],
            medicineDiscount: [null],
            liquidationType: [this.liquidationType],
            oddAmount: []
        });
    }

    addLiquidationDetails() {
        this.testamentService.generateNewDocumentCode(this.lastCode).subscribe(res => {
            this.lastCode = res;
            const liquidations = this.liquidationForm.get('liquidationDetails') as FormArray;
            liquidations.push(this.createLiquidationDetails(res));
        })
    }

    createUnliquidationDetails(unliquidation: any): FormGroup {
        return this.fb.group({
            liquidationNumber: [unliquidation.liquidationNumber, [Validators.required]],
            amount: [unliquidation.amount, [Validators.required]],
            testamentExtractionId: [(unliquidation.testamentExtractionId != 0) ? unliquidation.testamentExtractionId
                : null, [Validators.required]],
            caseCode: [unliquidation.caseCode],
            taxDiscount: [unliquidation.taxDiscount],
            medicineDiscount: [unliquidation.medicineDiscount],
            liquidationType: [this.liquidationType],
            advanceId: [unliquidation.advanceId],
            oddAmount: [unliquidation.amount]
        });
    }

    addUnliquidationDetails(unliquidation: any) {
        const liquidations = this.liquidationForm.get('liquidationDetails') as FormArray;
        liquidations.push(this.createUnliquidationDetails(unliquidation));
    }

    gotoList() {
        let url = [`/financial/testament/list`];
        this.router.navigate(url);
    }

    journalValueChange(event) {
        this.itemModel.journal = event;
    }

    journalApprove(event) {
        debugger;
        //this.collectModelFromForm();
        this.itemModel.journal = event;
        this.testamentService.addTestament(this.itemModel)
            .subscribe(res => {
                debugger;

                this.journalPreviewShow = false;
                this.notification.showOperationSuccessed();
                //this.Close();
                $('#openPostlBTN').click();
                this.gotoList()
                //debugger;
            }, (error) => {
                // debugger;
                console.error(JSON.stringify(error));

                this.errorService.handerErrors(error);
                // debugger;
            }, () => {

                // debugger;
            });
    }

    journalReject(event) {
        this.journalPreviewShow = false;
        this.notification.showOperationSuccessed();
        this.notification.showJournalcanceled();
        $('#openPostlBTN').click();
        this.gotoList()
    }

    save(): void {
        debugger;
        if (this.liquidationForm.valid) {
            this.itemModel = this.liquidationForm.value;
            this.itemModel.totalAmount = this.total;
            // if (this.total != this.liquidationForm.controls['totalAmount'].value) {
            //     this.notification.showTranslateError('liquidation.error.sumAmountNotEqualTotalValue');
            //     return;
            // }
            if (this.itemModel.liquidationDetails.length > 0) {

                this.itemModel.paymentMovements = JSON.parse(localStorage.getItem("paymentsMovements"))
                this.testamentService.addLiquidation(this.itemModel).subscribe(res => {
                    debugger;
                    this.itemModel = res;
                    this.journalPreview = res.journal;
                    this.journalPreviewShow = true;

                    $('#openPostlBTN').click();
                },
                    (error) => { this.notification.showOperationFailed() },

                    () => {
                        localStorage.setItem("liquidation", null);
                        localStorage.setItem("paymentsMovements", null);
                    })
            } else {
                this.notification.showDataMissingError()
            }
        }
    }

    cancel(): void {
        debugger;
        this.buildForm();
        this.liquidationForm.controls["liquidationType"].setValue(this.liquidationType);
        const liquidationDetails = this.liquidationForm.get('liquidationDetails') as FormArray;
        for (let index = 0; index < liquidationDetails.length; index++) {
            liquidationDetails.removeAt(index);

        }

    }

    removeLiquidationDetails() {
        debugger;
        const liquidationDetails = this.liquidationForm.get('liquidationDetails') as FormArray;
        while (liquidationDetails.length !== 0) {
            liquidationDetails.removeAt(0)
          }
    }

    goToBack() {
        this.location.back();
    }

    goToPaymentsMovement() {
        debugger;
        localStorage.setItem("liquidation", JSON.stringify(this.liquidationForm.value));
    }

    deleteLiquidationDetails(item) {
        (this.liquidationForm.get('liquidationDetails') as FormArray).removeAt(item);
        //this.calcTotal();
    }
}
