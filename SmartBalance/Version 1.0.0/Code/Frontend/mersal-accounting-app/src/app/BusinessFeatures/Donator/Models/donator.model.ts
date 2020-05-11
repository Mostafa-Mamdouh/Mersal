export class Donator { 
    id: any;

    creationDate: any; 
    firstModificationDate: any;  
    lastModificationDate: any;
   

    name: string;
    code: string;
    date: any;
    displyedName: string;

    phone: any;
    email: any;
    address: any;

    accountChartId?: any;
    accountChart: any; //AccountChartViewModel

    
    language: any; //Language

    parentKeyDonatorId?: any;
    parentKeyDonator: any;  //Donator

    childTranslatedDonators: any[];  //Donator  

    descriptionAr: string;
    descriptionEn: string;
    nameAr: string;
    nameEn: string;
}

export class DonatorLight {
    id: string;
    name: string;
    code: string;
    displyedName: string;
    date: any;

    accountChartId?: any;
    accountChart: any; //AccountChartLightViewModel
    

}