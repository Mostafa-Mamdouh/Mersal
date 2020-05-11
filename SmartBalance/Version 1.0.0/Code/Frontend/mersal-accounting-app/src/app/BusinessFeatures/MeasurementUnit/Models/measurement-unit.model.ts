
export class MeasurementUnit {
    id: any;

    creationDate: any; 
    firstModificationDate: any;  
    lastModificationDate: any;
    
    name: string;
    code: string;
    date: any;
    description: string;
    displyedName: string;

    childTranslatedMeasurementUnits: any[];

    nameAr: string;
    nameEn: string;

    descriptionAr: string;
    descriptionEn: string;
}

export class MeasurementUnitLight
{
    id: string;
    name: string;
    code: string;
    displyedName: string;
    date: any;
}