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

    email: any;
    phone: any;

    dateTo: any;
    dateFrom: any;
    
    pageIndex:number;
    pageSize:number;
    filters:any[];
    sort:any[];    
}
