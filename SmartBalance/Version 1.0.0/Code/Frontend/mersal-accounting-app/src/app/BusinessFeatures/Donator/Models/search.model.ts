// export class Search {      
//     bank: {value:any};

//     DateTo: Date;
//     DateFrom: Date;  
// }
export class PostSearch {
    id: any;
    description: any;
    name: string;

    phone: any;
    email: any;

    //bank: number;


    dateTo: any;
    dateFrom: any;
    
    pageIndex:number;
    pageSize:number;
    filters:any[];
    sort:any[];    
}
