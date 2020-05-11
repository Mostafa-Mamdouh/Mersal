export class AccountDocument {
    id: any;

    creationDate: any;
    firstModificationDate: any;
    lastModificationDate: any;

    accountChartId: number;
    documentId: number;

    modelStatus: ModelStatus
}

export class AccountDocumentLight {
    id: string;
    displyedName: string;

    accountChartId: number;
    documentId: number;
    documentNumber: number;
    countReceipts: number;

    modelStatus: ModelStatus = ModelStatus.Unmodify;
}

export enum ModelStatus {
    Delete = 1,
    Add = 2,
    Unmodify = 3
}