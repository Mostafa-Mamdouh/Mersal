export class Search {
    Branch: { value: any };
    DateTo: Date;
    DateFrom: Date;
    AmountFrom: number;
    AmountTo: number;
}
export class PostSearch {
    id?: any;
    code: string;
    delegateManReciptNumber: string;
    branch: number;
    dateTo: any;
    dateFrom: any;
    payment: number;
    amountFrom: number;
    amountTo: number;
    pageIndex: number;
    pageSize: number;
    filters: any[];
    sort: any[];
}

export class TestamentSearch {
    code: any;
    advancesTypeId: any;
    dateFrom: any;
    dateTo: any;
    totalValueFrom: number;
    totalValueTo: number;
    description: string;
    isClosed: boolean;
    pageIndex: number;
    pageSize: number;
    filters: any[];
    sort: any[];
}