
export class UserLoggedIn {
     access_token: string;
     email: string;
     expires: any;
     expires_in: any;
     nameAr: string;
     nameEn: string;
     branchId: any;
     firstName: string;
     firstNameOther: string;
     id: number;
     issued: any;
     lastName: string;
     lastNameOther: string;
     locationId: string;
     menuItemList: any[];
     menuItems: string;
     middleName: string;
     middleNameOther: string;
     mobile: string;
     phone: string;
     privilegeList: any[];
     privileges: string;
     permissions: number[];
     token_type: string;
     userName: string;
}

// export class Role {
//      Id: number;
//      Name: string;
//      NameOther: string;
//      Description: string;
//      DescriptionOther: string;
//      IsActive?: boolean;
//      IsChecked?: boolean;
// }

export class MenuItemViewModel {
     id: number;
     name: string;
     nameOther: string;
     isActive: boolean;
     actionName: string;
     controllerName: string;
     url: string;
     applicationId?: number;
     icon: string;
     itemOrder: number;
     parentId?: number;
     parent: MenuItemViewModel;
     allowAnonymous: boolean;

     show: boolean;
     // Id: number;
     // Name: string;
     // NameOther?: string;
     // ParentId?: number;
     // URL: string;
     // ApplicationId?: number;
     // ItemOrder?: number;
}

export class PrivilegeViewModel
{
    id: number;
    name: string;
    nameOther: string;
    description: string;
    descriptionOther: string;
    controlId: string;
    isActive: boolean;
}
