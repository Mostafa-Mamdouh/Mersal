export class LocationModel {
    id: any;

    creationDate: any;
    firstModificationDate: any;
    lastModificationDate: any;    

    code: string;
    title: string;
    description: string;
    date: any;


    titleAr: string;
    titleEn: string;
    descriptionAr: string;
    descriptionEn: string;

    
    language: any;

    parentKeyLocationId: any;
    parentKeyLocation: any;

    childTranslatedLocations: any[]; //LocationViewModel[]

    parentLocationId: number;
}

export class LocationLight {
    id: any;
    code: string;
    title: string;
    description: string;
    date: any;
    displyedName: string;
}