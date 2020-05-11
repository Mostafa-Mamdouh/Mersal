export class CostCenter {

    id: any;
    date: any;
    name: string;
    code: string;
    description: string;
    isActive: boolean;
    openingCredit: number;
    isDebt: boolean;

    nameAr: string;
    nameEn: string;
    descriptionAr: string;
    descriptionEn: string;
    costCenterTypeId: any;
    
}

export class CostCenters {
    costCenterId: number;
    amount: number;
}