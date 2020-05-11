import {MovementTypeEnum} from './movement-type-enum';

export class AddJournal {
    date: Date;
    descriptionAr: string;
    descriptionEn: string;
    documentNumber: number;
    movementType: MovementTypeEnum ;
    journalDetails: JournalDetails[];

    isReversed: boolean;
    reversedFromId?: any = null;
    reversedToId?: any = null;
    docId: any;
    id: any;
}

export class JournalDetails {
    accountId:number;
    costCenterId: number;
    creditorValue:number;
    debtorValue: number;
    descriptionAr: string;
    descriptionEn: string;
    id: number;
    isCreditor: boolean
}
