export class Document {
    id: any;

    creationDate: any; 
    firstModificationDate: any;  
    lastModificationDate: any;
    
    name: string;
    code: string;
    date: any;
    description: string;
    displyedName: string;

    documentNumber: any;

    countReceipts:number

    firstNumber: any;
}

export class DocumentLight
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