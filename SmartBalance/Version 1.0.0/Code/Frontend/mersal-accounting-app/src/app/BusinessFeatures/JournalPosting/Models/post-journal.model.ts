
export class PostJournal {
    id?: any;

    creationDate: any;
    firstModificationDate: any;
    lastModificationDate: any;

    createdByUserId: any;
    firstModifiedByUserId: any;
    lastModifiedByUserId: any;

    isAutomaticPosting: boolean;
    isBulkPosting: boolean;
    toDate: any;

    postReceiptsMovement: boolean;
    postPaymentMovement: boolean;
    postBankMovement: boolean;
    postPurchaseInvoice: boolean;
    postPurchaseRebate: boolean;
    postStoreMovement: boolean;
    postSalesInvoice: boolean;
    postSalesRebate: boolean;

    postedReceiptsMovementCount: number;
    postedPaymentMovementCount: number;
    postedBankMovementCount: number;
    postedPurchaseInvoiceCount: number;
    postedPurchaseRebateCount: number;
    postedStoreMovementCount: number;
    postedSalesInvoiceCount: number;
    postedSalesRebateCount: number;
}