import { PurchaseInvoice } from './purchase-invoice.model';

export class PurchaseInvoiceCostCenter {

    id?: any;
    creationDate: any;
    firstModificationDate?: any;
    lastModificationDate?: any;

    costCenterId?: any;
    costCenter: any; //CostCenterViewModel

    purchaseInvoiceId?: number;
    purchaseInvoice: PurchaseInvoice;

    amount: any;
}