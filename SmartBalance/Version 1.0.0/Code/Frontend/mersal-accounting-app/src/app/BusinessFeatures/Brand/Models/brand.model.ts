
export class Brand {
    id: any;

    creationDate: any; 
    firstModificationDate: any;  
    lastModificationDate: any;
    
    name: string;
    code: string;
    date: any;
    description: string;
    displyedName: string;

    childTranslatedBrands: any[];

    nameAr: string;
    nameEn: string;

    descriptionAr: string;
    descriptionEn: string;
    parentBrandId: number;
    childBrands: any;
}

export class BrandLight
{
    id: string;
    name: string;
    code: string;
    displyedName: string;
    date: any;
}