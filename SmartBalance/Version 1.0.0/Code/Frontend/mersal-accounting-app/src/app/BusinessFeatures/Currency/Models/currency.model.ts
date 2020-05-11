export class Currency { 
    id: any;

    creationDate: any; 
    firstModificationDate: any;  
    lastModificationDate: any;
   
    name: string;
    code: string;
    date: Date;

    nameAr: string;
    nameEn: string;

    description: string;
    descriptionAr: string;
    descriptionEn: string;

    symbol: string;

    price: number;

    exchangeCurrencyId:any;
}

// export class BankLight {
//     id: string;
//     name: string;
//     code: string;
//     displyedName: string;
//     date: any;

//     accountChartId?: any;
//     accountChart: any; //AccountChartLightViewModel
    
//     openingCredit : number;
//     isDebt : boolean;
// }