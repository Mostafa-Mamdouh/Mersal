import { LocationModel } from '../../Location/Models/location.model';
import { EffiencyRaise } from 'src/app/SharedFeatures/SharedMain/Models/effiency-raise.model';

export class FixedAsset {
    id: any;

    creationDate: any; 
    firstModificationDate: any;  
    lastModificationDate: any;
   

    brandId: string;
    locationId: string;
    location: LocationModel
    date?: any;
    depreciationValue: any;
    depreciationRateId: any;
    depreciationTypeId: any;
    startDepreciationDate?: any;
    purchaseInvoiceId: any;
    properties: any;
    description: string;
    displyedName: string;
    raiseAmount:number;
    raiseDate:number;
    accountChartId?: any;
    accountChart: any; //AccountChartViewModel
    vendor?: any;
    amount?: any;
    quantity?: any;

    
    language: any; //Language

    serial: any;
    model: any;
    color: any;
    size: any;
    status: any;

    costCenterId: any;
    
    childTranslatedBanks: any[];  //Bank  
    openingCredit : number;
    descriptionAr: string;
    descriptionEn: string;
    nameAr: string;
    nameEn: string;
}

export class FixedAssetLight {
    
}

export class ExpenseAsset {
    assetId: any;
    expensesTypeId: any;
    accountChartId: any;
    amount: number;

    descriptionAr: string;
    descriptionEn: string;
}

export class Depreciation
{
    id: number;
    assetId: number;
    checked: boolean = false;
}

export class Exclude
{
    id: number;

    assetId: any;

    isSpeculation: boolean;

    IsSaled: boolean;
    amount: number;

    accountChartId: any;

}

export class AssetInventory
{
    id: any;

    date: any;
    locationId: any;

    assetInventoryDetails: AssetInventoryDetail[];

    descriptionAr: string;
    descriptionEn: string;
}

export class AssetInventoryDetail
{
    brandId: any;
    expectedQuantity: number;
    actualQuantity: number;
    difference: number;
}

export class AssetLocation {
   
    id: number;
    
    creationDate: any;
    firstModificationDate: any;
    lastModificationDate: any;    

    description: string;
    date: any;

    assetId: number;
    asset: FixedAsset;

    locationId: number;
    location: Location;
  
    descriptionAr: string;
    descriptionEn: string;

  
   
    language: any;// Language

    parentKeyAssetLocationId: number;
    parentKeyAssetLocation: AssetLocation;


    //childTranslatedAssetLocations: AssetLocation[];
 
}

export class AssetLocationLight {
    id: number;
    date: any;
    
    assetId: number;
    asset: any;

    locationId: number;
    location: any;
}