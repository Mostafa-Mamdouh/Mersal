
export class User {
    id: any;
    name: string;
    nameAr: string;
    nameEn: string;
    branchId: any;
    
    userName: string;
    isActive: any;
    password: string;
    birthDate: any;
    maxPaymentLimit: any;

    address: string;
    phone: string;
    email: string;
}

export class UserLight {
    id: string;
    name: string;
    userName: string;
    code: number;
    displyedName: string;
    isActive: boolean;
    birthDate: any;
}

export class UserPermissionList {
    userId: number;
    list: any[];
}
export class UserRoleList {
    userId: number;
    list: any[];
}
export class UserGroupList {
    userId: number;
    list: any[];
}
export class UserBranchList {
    userId: number;
    list: any[];
}
