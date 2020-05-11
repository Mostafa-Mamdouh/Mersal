export class Search {      
    vendor: {value:any};
    inventory: {value:any};
    DateTo: Date;
    DateFrom: Date;  
}
export class PostSearch {
    id: any;
    code: any;
    dateTo: any;
    dateFrom: any;
    vendor: number;
    inventory: number;
    pageIndex:number;
    pageSize:number;
    description: any;
    filters:any[];
    sort:any[];    
}
