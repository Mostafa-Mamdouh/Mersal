import { StoreProducts, InventoryCostCenters } from "./opening-balance.model";

export class InventoryTransfer {
  id: number;
  date: Date;
  descriptionAr: string;
  descriptionEn: string;
  code: string;

  products: StoreProducts[];
  inventoryTransferCostCenter: InventoryCostCenters[];

  //  inventoryId: any;
  inventoryFromId: any;
  inventoryToId: any;
}