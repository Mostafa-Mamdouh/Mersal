export class PostSearch {
    id?: any;
    brandId: any;
    assetId: any;
    locationId: any;
    depreciationRateId: any;
    depreciationTypeId: any;
    accountChartId: any;
    PurchaseInvoiceId: any;
    depreciationValueFrom: number;
    depreciationValueTo:  number;

    expensesTypeId: number;
    amountFrom: number;
    amountTo: number;

    dateFrom: any;
    dateTo: any;
    
    pageIndex:number;
    pageSize:number;
    filters:any[];
    sort:any[];  
}
