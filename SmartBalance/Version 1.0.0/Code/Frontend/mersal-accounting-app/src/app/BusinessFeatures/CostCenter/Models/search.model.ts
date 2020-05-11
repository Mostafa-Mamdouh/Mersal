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
    isActive: any;

    openingCreditTo: any;
    openingCreditFrom: any;
    
    costCenterTypeId: number;
    
    pageIndex:number;
    pageSize:number;
    filters:any[];
    sort:any[];    
}
