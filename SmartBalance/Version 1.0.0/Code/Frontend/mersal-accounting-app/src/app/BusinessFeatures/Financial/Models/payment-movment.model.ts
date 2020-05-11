import { Inventorys, CostCenters, Donator, Cases } from './receipts.model';

export class PaymentMovment {
    Id: number;
    reciptNumber: string;
    DescriptionEN: string;
    DescriptionAR: string;
    Date: Date;
    Amount: number;
    code:string;
    Inventorys: Inventorys[]; //
    CostCenters: CostCenters[];
    costCenters: CostCenters[];
    BranchId: number;
    VendorId: number;
    sourceType: number;
    AccountChartId: string;
    ReceivingMethodId: number;
    SafeId: number;
    bankId: number;
    VisaNumber: string;
    VisaBankId:number;
    Duedate: Date;
    ChequeNumber: string;
    FromBankId:number;
    ToBankId:number;
    toBankAccountChartId:number;

    CurrencyId:number;
    /*قابل للصرف في حالة الشيك*/
    exchangeable:boolean;
    //delegate
    DelegateManId:number;
    DelegateManReciptNumber: string;
    documentId: any;

    expensesTypeId: any;

    paymentDueDate: Date;

    // discountpercentageId:number;
    // discountAmount: number;
    // invoiceAmount: number;
    // notificationReceiptNumber: any;

    notificationsDiscount:any[];

    donatorId: any;
    donationTypeId: any;
    donator: Donator;
    cases: Cases[];
    safeAccountChartId: number;
    journal: any;
    liquidationNumber: any;

    donatoinTypesLevel: []
    
}
