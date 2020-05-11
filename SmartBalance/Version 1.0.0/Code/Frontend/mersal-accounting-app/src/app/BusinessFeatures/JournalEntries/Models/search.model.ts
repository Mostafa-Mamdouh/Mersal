// export class Search {
//     Branch: {value:any};
//     DateTo: Date;
//     DateFrom: Date;
//     AmountFrom: number;
//     AmountTo:  number;
// }
export class PostSearch {
    preview: boolean = false;
    
     postReceiptsMovement: boolean;
     postPaymentMovement: boolean;
     postBankMovement: boolean;
     postPurchaseInvoice: boolean;
     postPurchaseRebate: boolean;
     postStoreMovement: boolean;
     postSalesInvoice: boolean;
     postSalesRebate: boolean;

    id?: any;
    code: string;
    
    dateTo: any;
    dateFrom: any;

    descriptionAr: string;
    descriptionEn: string;

    pageIndex:number;
    pageSize:number;
    filters:any[];
    sort:any[];    
}
