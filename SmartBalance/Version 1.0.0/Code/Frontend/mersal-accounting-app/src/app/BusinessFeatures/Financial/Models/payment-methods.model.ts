export class PaymentMethod {

    ReceivingMethodId:number;
    SafeId:number;
  
    VisaBankId:number;
    VisaNumber:string;

    Duedate:Date;
    ChequeNumber:string;
    FromBankId:number;
    ToBankId:number;
    /*قابل للصرف في حالة الشيك*/
    exchangeable:boolean;
    ischanged:boolean=false;
    toBankAccountChartId : number;
    safeAccountChartId: number;
}