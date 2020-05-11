
export class Group {
    id: any;

    creationDate: any;
    firstModificationDate: any;
    lastModificationDate: any;

    name: string;
    code: number;
    description: string;
    isActive: boolean;
    date: any;
    //displyedName: string;

    childTranslatedGroups: any[];

    nameAr: string;
    nameEn: string;

    descriptionAr: string;
    descriptionEn: string;
}

export class GroupLight {
    id: string;
    name: string;
    code: number;
    displyedName: string;
    isActive: boolean;
    date: any;
}

export class GroupPermissionList {
    groupId: number;
    list: any[];
}