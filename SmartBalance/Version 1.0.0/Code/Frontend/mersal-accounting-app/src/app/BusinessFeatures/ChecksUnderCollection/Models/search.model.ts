export class Search {      
    bank: {value:any};    
    DateTo: Date;
    DateFrom: Date;  
}
export class PostSearch {
    //id: any;
    code: any;
    dateTo: any;
    dateFrom: any;
    bank: number;
    amount?: any;
    
    pageIndex:number;
    pageSize:number;
    filters:any[];
    sort:any[];    
}
