export class BankDocument {
    id: any;

    creationDate: any; 
    firstModificationDate: any;  
    lastModificationDate: any;
    
    bankId: number;
    documentId: number;
}



export class BankDocumentLight
{
    id: string;
    displyedName: string;

    bankId: number;
    documentId: number;
    documentNumber: number;
    countReceipts:number;
}