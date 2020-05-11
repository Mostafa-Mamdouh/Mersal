
export class Branch {
    id: any;

    creationDate: any; 
    firstModificationDate: any;  
    lastModificationDate: any;
    
    name: string;
    code: string;
    date: any;
    description: string;
    displyedName: string;

    childTranslatedBranch: any[];

    nameAr: string;
    nameEn: string;

    descriptionAr: string;
    descriptionEn: string;
}

export class BranchLight
{
    id: string;
    name: string;
    code: string;
    displyedName: string;
    date: any;
}