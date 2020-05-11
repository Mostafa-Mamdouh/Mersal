import { CostCenters } from '../../Financial/Models/receipts.model';

export class BankMovement {
    id?: any;
    code?: any;
    date: any;
    amount: any;
    bankId: any;
    bankAccountChartId: any;
    toBankAccountChartId: any;
    currencyId: any;
    bank: any;
    safeId: any;
    safe: any;
    journalTypeId: any;
    journalType: any;
    descriptionAr: string;
    descriptionEn: string;
    toBankId: any;
    toBank: any;
    accountChartId: any;
    accountChart: any;
    remittanceVoucherNumber: string;
    directlyDonationBankId: any;
    cheques: any[];
    journal: any;
    capturePapersbankId: number;
    costCenterId:number;
    chequeNo:string;
    costCenters: CostCenters[];
}