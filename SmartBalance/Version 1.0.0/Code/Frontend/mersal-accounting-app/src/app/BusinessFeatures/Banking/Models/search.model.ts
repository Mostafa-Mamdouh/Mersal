export class Search {      
    bank: {value:any};
    journalType: {value:any};
    DateTo: Date;
    DateFrom: Date;  
}
export class PostSearch {
    id: any;
    code: any;
    bank: number;
    journalType: number;

    amountTo: any;
    amountFrom: any;

    dateTo: any;
    dateFrom: any;
    
    pageIndex:number;
    pageSize:number;
    filters:any[];
    sort:any[];    
}
