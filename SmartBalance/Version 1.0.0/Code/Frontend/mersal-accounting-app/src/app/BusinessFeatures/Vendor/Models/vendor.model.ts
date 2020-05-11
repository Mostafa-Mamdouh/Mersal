export class Vendor {
    id: any;

    creationDate: any; 
    firstModificationDate: any;  
    lastModificationDate: any;
    
    name: string;
    code: string;
    date: any;
    description: string;
    displyedName: string;

    accountChartId?: any;
    accountChart: any; //AccountChartViewModel

    openingCredit : number;
    isDebt : boolean;

    childTranslatedVendor: any[];

    nameAr: string;
    nameEn: string;

    descriptionAr: string;
    descriptionEn: string;

    commercialRegister: string;
    taxCard: string;
    exemptFromTax: string;
    payeeName: string;
    address: string;
    phone: string;
    vatRegistrationCertificate: string;
}

export class VendorLight
{
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