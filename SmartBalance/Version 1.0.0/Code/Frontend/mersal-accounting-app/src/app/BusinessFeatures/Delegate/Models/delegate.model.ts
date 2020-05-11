export class Delegate { 
    id: any;

    creationDate: any; 
    firstModificationDate: any;  
    lastModificationDate: any;
   

    name: string;
    code: string;
    date: any;
    description: string;
    displyedName: string;
    
    language: any; //Language


    childTranslatedDelegMans: any[];  //Bank  
    
    email: string;
    phone: string;
    address: string;

    descriptionAr: string;
    descriptionEn: string;
    nameAr: string;
    nameEn: string;
}

export class DelegateLight {
    id: string;
    name: string;
    code: string;
    displyedName: string;
    date: any;

}