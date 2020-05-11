import { PurchaseInvoiceCostCenter } from './purchase-invoice-cost-center.model';

export class PurchaseInvoice {
    id?: any;
    creationDate: any;
    firstModificationDate?: any;
    lastModificationDate?: any;
    createdByUserId?: any;
    firstModifiedByUserId?: any;
    lastModifiedByUserId?: any;
    code: any;
    vendorInvoiceCode: any;
    date: any;
    vendorId?: any;
    vendor: any;
    inventoryId?: any;
    inventory: any;
    purchaseInvoiceTypeId?: any;
    purchaseInvoiceType: any;
    safeId?: any;
    safe: any;
    visaBankId?: any;
    visaBank: any;
    visaNumber: any;
    hasAdditionalExpenses: boolean;
    additionalExpensesAmount?: any;
    hasDiscount: boolean;
    discountAmount?: any;
    totalAmountBeforeTax: any;
    taxAmount: any;
    totalAmountAfterTax: any;
    totalExpenses: any;
    totalDiscount: any;
    netAmount: any;
    purchaseInvoiceCostCenters: PurchaseInvoiceCostCenter[];
    products: any[];
    brands: any[];

    fromBankId?: number;
    toBankId?: number;
    chequeNumber?: string;
    dueDate?: any;
    toBankAccountChartId:number;

    journal: any;
}
