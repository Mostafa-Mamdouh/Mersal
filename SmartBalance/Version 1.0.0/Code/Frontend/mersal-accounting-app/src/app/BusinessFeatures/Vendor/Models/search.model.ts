// export class Search {      
//     bank: {value:any};
//     journalType: {value:any};
//     DateTo: Date;
//     DateFrom: Date;  
// }
export class PostSearch {
    id: any;
    code: any;   
    name: any;

    openingCreditFrom: number;
    openingCreditTo: number;

    dateTo: any;
    dateFrom: any;
    
    pageIndex:number;
    pageSize:number;
    filters:any[];
    sort:any[];    
}
