import { StoreProducts, InventoryCostCenters } from "./opening-balance.model";

export class InventoryMovement {
    id: number;
    date: Date;
    descriptionAr: string;
    descriptionEn: string;
    code:string;
    referenceNumber:any;
    inventoryMovementTypeId:any;    
    outgoingTypeId: any;

    inventoryId:  any;
    vendorId: any;
    billNumber: any;
    
    products: StoreProducts[];
    inventoryMovementCostCenter: InventoryCostCenters[]; 
    
    journal: any;
}
