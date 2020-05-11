
export class StoreStartBalance {
    id: number;
    date: Date;
    descriptionAr: string;
    descriptionEn: string;
    code:string;

    storeProducts: StoreProducts[];
    costCenters: InventoryCostCenters[];

    products: StoreProducts[];
    inventoryOpeningBalanceCostCenter: InventoryCostCenters[];


    inventoryId: any;
    vendorId: any;
    billNumber: any;
}
export class StoreProducts {
    id?: any;
    brandId :any;
    brandName: string;
    brand :any;
    measurementUnitId :any;
    measurementUnit :any;
    code :any;
    price :any;
    quantity :any;

    productId  :any;
    discount   :any;
    totalDiscount:any;
    netValue  : any;

   //angular
    total:any;
}
export class InventoryCostCenters {
    id: any;
    costCenterId: any;
    inventoryOpeningBalanceId :any;
}
