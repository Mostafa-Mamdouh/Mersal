export class BankAccountChart {
    id: any;

    creationDate: any;
    firstModificationDate: any;
    lastModificationDate: any;
    currencyId: number;
    accountChartId: number;
    bankId: number;

    modelStatus: ModelStatus
}

export class BankAccountChartLight {
    id: string;
    displyedName: string;

    accountChartId: number;
    bankId: number;
    documentNumber: number;
    countReceipts: number;

    modelStatus: ModelStatus = ModelStatus.Unmodify;
}

export enum ModelStatus {
    Delete = 1,
    Add = 2,
    Unmodify = 3
}