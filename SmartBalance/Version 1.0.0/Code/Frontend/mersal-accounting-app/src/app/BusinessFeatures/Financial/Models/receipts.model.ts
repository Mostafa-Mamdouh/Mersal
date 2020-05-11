export class Receipt {
    id: number;
    date: Date;
    descriptionEN: string;
    descriptionAR: string;
    amount: number;
    code:string;

    cases: Cases[];
    inventorys: Inventorys[]; //
    products: Products[];
    costCenters: CostCenters[];

    branchId: number;
    vendorId: number;
    sourceType: number;
    accountChartId: string;

    receivingMethodId: number;
    safeId: number;
    bankId: number;

    donatorId: number;
    donator: Donator;

    DonationTypeId: number;
    donationTypeId: number;
    
    visaNumber: string;

    VisaBankId:number;
    visaBankId:number;
   
    duedate: Date;
    chequeNumber: string;
    
    FromBankId:number;
    fromBankId:number;
    
    ToBankId:number;
    toBankId:number;

    //ToBankAccountChartId :number;
    toBankAccountChartId :number;

    CurrencyId: number;
    currencyId: number;
    
    /*قابل للصرف في حالة الشيك*/
    exchangeable:boolean;

    //delegate
    delegateManId:number;
    delegateManReciptNumber: string;
    reciptDate: any;
    documentId: number;
    safeAccountChartId: number;
    journal: any;

    donatoinTypesLevel: number[];
}
export class Donator {
    name: string;
    // accountChartId: string;
    phone: string;
    email:string;
    address:string;
}
export class Cases {
    CaseId: string;
    Amount: number;
    Name:string;
}
export class Inventorys {
    inventoryId: number;
    amount: number;
}
export class Products {
    productId: number;
    quantity: number;
    amount: number;
}
export class CostCenters {
    costCenterId: number;
    id: number;
    amount: number;
    assignValue: number;
}

