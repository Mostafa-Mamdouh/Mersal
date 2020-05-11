import {MovementTypeEnum} from '../../JournalEntries/Models/movement-type-enum';

//export class Search {      
    // bank: {value:any};
    // journalType: {value:any};
    // DateTo: Date;
    // DateFrom: Date;  
//}
export class PostSearch {
    id: any;
    
    isAutomaticPosting: boolean;
    isBulkPosting: boolean;
    movementType: MovementTypeEnum;

    dateTo: any;
    dateFrom: any;
    
    pageIndex:number;
    pageSize:number;
    filters:any[];
    sort:any[];    
}
