// export class Search {      
//     bank: {value:any};

//     DateTo: Date;
//     DateFrom: Date;  
// }
export class PostSearch {
    id: any;
    code: any;
    name: string;

    //bank: number;

    openingCreditTo: any;
    openingCreditFrom: any;

    dateTo: any;
    dateFrom: any;
    
    pageIndex:number;
    pageSize:number;
    filters:any[];
    sort:any[];    
}
