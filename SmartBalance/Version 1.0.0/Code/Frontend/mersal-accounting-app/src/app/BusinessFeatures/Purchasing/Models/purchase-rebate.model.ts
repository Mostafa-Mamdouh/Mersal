
export class PurchaseRebate {
    id?: any;
    creationDate: any;
    firstModificationDate?: any;
    lastModificationDate?: any;
    createdByUserId?: any;
    firstModifiedByUserId?: any;
    lastModifiedByUserId?: any;
    code: any;
    date: any;
    vendorId?: any;
    vendor: any;
    inventoryId?: any;
    inventory: any;
    purchaseInvoiceTypeId?: any;
    purchaseInvoiceType: any;
    safeId?: any;
    safe: any;
    totalAmount :any;
    taxAmount: any; 
    totalExpenses :any;
    totalDiscount :any;
    netAmount :any;
    purchaseRebateCostCenters: PurchaseRebateCostCenters[];
    purchaseRebateProducts: PurchaseRebateProduct[];

    fromBankId?: number;
    toBankId?: number;
    chequeNumber?: string;
    dueDate?: any;

    journal: any;

//angular
hasCostCenter:boolean;
costCenterId:any;

}
export class PurchaseRebateProduct {
    id?: any;
    creationDate: any;
    firstModificationDate?: any;
    lastModificationDate?: any;
    createdByUserId?: any;
    firstModifiedByUserId?: any;
    lastModifiedByUserId?: any;
    brandId :any;
    brand :any;
    code :any;
    price :any;
    quantity :any;
    expenses
    discount :any;
    totalDiscount:any;
    netValue :any;
    productTypeId :any;
    productType :any;
    measurementUnitId: any;
    measurementUnit: any;
    countChartId :any;
    accountChart :any;
    purchaseInvoiceId :any;
    purchaseInvoice :any;
    productPrices :any;
    salesRebateProducts :any;       
    inventoryDifferences :any;
    donatorProducts :any;
    salesBillProducts :any;
    donationProducts :any;


    //angular
    total:any;
}
export class PurchaseRebateCostCenters {
        id?: any;
        costCenterId: any;
		costCenter?: any;
		purchaseRebateId?: any;
		purchaseRebate?: any;
		amount: any;
}