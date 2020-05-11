
export class ChecksUnderCollection {
    id: any;
    date: any;
    code: string;

    //donatorId: any;
    //donator: any; //DonatorLightViewModel

    // public long? AccountChartId { get; set; }
    // public virtual AccountChartLightViewModel AccountChart { get; set; }

    currencyId: any;
    currency: any; //CurrencyLightViewModel

    receivingMethodId: any;
    receivingMethod: any; //ReceivingMethodLightViewModel

    //props if cheque
    chequeNumber: string;
    //تاريخ الاستحقاق
    duedate: any;
    chequeToBankId: any;
    chequeToBank: any; //BankLightViewModel
    exchangeable: boolean;
    //prop if visa
    visaNumber: string;

    //in case of Visa or Chique you need to set Bank Id
    bankId: any;
    bank: any; //BankLightViewModel

    //المبلغ المدفوع
    amount: any;
}
