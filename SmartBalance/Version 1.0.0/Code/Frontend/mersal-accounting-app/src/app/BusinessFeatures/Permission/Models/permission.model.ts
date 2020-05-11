
export class Permission {
    id: any;

    creationDate: any; 
    firstModificationDate: any;  
    lastModificationDate: any;
    
    name: string;
    code: number;
    description: string;
    isActive: boolean;
    //displyedName: string;

    childTranslatedPermissions: any[];

    nameAr: string;
    nameEn: string;

    descriptionAr: string;
    descriptionEn: string;
}

export class PermissionLight
{
    id: string;
    name: string;
    code: number;
    displyedName: string;
    isActive: boolean;
}