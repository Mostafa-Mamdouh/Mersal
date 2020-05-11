export class Bank { 
    id: any;

    creationDate: any; 
    firstModificationDate: any;  
    lastModificationDate: any;
   

    name: string;
    code: string;
    date: any;
    description: string;
    displyedName: string;

    // accountChartId?: any;
    // accountChart: any; //AccountChartViewModel


    donationsfromBanks: any[];  //DonationViewModel
    donationstoBanks: any[] //DonationViewModel

    paymentMovments: any[];  //PaymentMovmentViewModel

    bankMovements: any[];  //BankMovementViewModel
    toBankMovement: any;  //BankMovementViewModel

    visaBanks: any[];  //PurchaseInvoiceViewModel

    
    language: any; //Language

    parentKeyBankId?: any;
    parentKeyBank: any;  //Bank

    childTranslatedBanks: any[];  //Bank  
    openingCredit : number;
    isDebt : boolean;
    descriptionAr: string;
    descriptionEn: string;
    nameAr: string;
    nameEn: string;
}

export class BankLight {
    id: string;
    name: string;
    code: string;
    displyedName: string;
    date: any;

    accountChartId?: any;
    accountChart: any; //AccountChartLightViewModel
    
    openingCredit : number;
    isDebt : boolean;
}