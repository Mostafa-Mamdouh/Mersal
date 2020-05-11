export class Testament{
    id: any;

    code: any;

    advancesTypeId: any;
    vendorId?: any;
    date: any;
    totalValue: number;
    advances: any[];

    descriptionAr: string;
    descriptionEn: string;

    journal: any;
}

enum LiquidationTypeEnum
    {
        Testament = 1,
        Advance = 2
    }