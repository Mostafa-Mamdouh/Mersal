
export class MenuItems {
    id: any;

    creationDate: any;
    firstModificationDate: any;
    lastModificationDate: any;

    name: string;
    title: string;
    code: number;
    description: string;
    isActive: boolean;

    //displyedName: string;
    url: string;
    itemOrder: string;
    allowAnonymous: boolean;
    rootUrl: string;
    onErrorGoToURL: string;

    childTranslatedRoles: any[];

    nameAr: string;
    nameEn: string;

    titleAr: string;
    titleEn: string;

    descriptionAr: string;
    descriptionEn: string;

    parentMenuItemId: any;
}

export class RoleLight {
    id: string;
    name: string;
    code: number;
    displyedName: string;
    isActive: boolean;
    itemOrder: string;
    date: any;
}

export class MenuItemUsersLisrt {
    MenuItemId: number;
    list: any[];
}

export class UserMenuItemsLisrt {
    userId: number;
    list: any[];
}