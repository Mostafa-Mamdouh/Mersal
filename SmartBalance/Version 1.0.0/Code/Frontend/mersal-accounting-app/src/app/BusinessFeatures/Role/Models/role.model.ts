
export class Role {
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

    childTranslatedRoles: any[];

    nameAr: string;
    nameEn: string;

    descriptionAr: string;
    descriptionEn: string;
}

export class RoleLight {
    id: string;
    name: string;
    code: number;
    displyedName: string;
    isActive: boolean;
    date: any;
}

export class RolePermissionList {
    roleId: number;
    list: any[];
}