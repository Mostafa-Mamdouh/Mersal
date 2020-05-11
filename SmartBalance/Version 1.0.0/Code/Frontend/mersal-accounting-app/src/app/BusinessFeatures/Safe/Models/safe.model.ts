
export class Safe {
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

    branchId?: any;
    branch: any;
    
    openingCredit : number;
    isDebt : boolean;

    childTranslatedSafes: any[];

    nameAr: string;
    nameEn: string;

    descriptionAr: string;
    descriptionEn: string;
}

export class SafeLight
{
    id: string;
    name: string;
    code: string;
    displyedName: string;
    date: any;

    //accountChartId?: any;
    //accountChart: any; //AccountChartLightViewModel
    
    openingCredit : number;
    isDebt : boolean;
}

export class SafeAccountChartList {
    safeId: number;
    list: any[];
}