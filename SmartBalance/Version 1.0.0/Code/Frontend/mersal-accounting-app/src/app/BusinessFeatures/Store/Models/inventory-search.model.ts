export class InventorySearch {
    id: any;
    code: any;
    dateTo: any;
    dateFrom: any;

    name: string;
    description: string;

    nameAr: string;
    nameEn: string;
    
    vendor: number;
    inventoryFromId: number;
    inventoryToId: number;

    pageIndex:number;
    pageSize:number;
    filters:any[];
    sort:any[];    
}

export class InventoryMovementSearch {
    id: any;
    code: any;
    dateTo: any;
    dateFrom: any;
    vendor: number;
    inventory: number;
    description: any;
    inventoryMovementTypeId: number;
    pageIndex:number;
    pageSize:number;
    filters:any[];
    sort:any[];    
}