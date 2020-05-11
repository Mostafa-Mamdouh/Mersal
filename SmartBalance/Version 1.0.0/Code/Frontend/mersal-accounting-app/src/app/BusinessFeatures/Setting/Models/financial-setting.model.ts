export class FinancialSetting {
    /*
    /// اظهار الحالات التى استوفت المبلغ المطلوب
    */
    showCasesThatMetRequiredAmount: boolean;

    
    /*
    /// رقم حساب ضريبة الخصم والاضافة
    */
   vatAccountNumber: string;
   vatAccount: any; //AccountChartLightViewModel

    /*
    /// رقم حساب التبرعات
    */
    donationAccountNumber: string;
    donationAccount: any; //AccountChartLightViewModel

    /*
    /// استخدام شيكات تحت التحصيل
    */
    useChecksUnderCollection: boolean;

    /*
    /// حساب شيكات تحت التحصيل
    */
    checksUnderCollectionAccountNumber: string;
    checksUnderCollectionAccount: any; //AccountChartLightViewModel   

    /*
    /// رقم حساب رد التبرعات
    */
    donationReturnAccountNumber: string;
    donationReturnAccount: any;



    /// رقم حساب العهد المؤقتة

    temporaryCovenantAccountNumber: string;
    temporaryCovenantAccount: any;

    /// رقم حساب المصروفات البنكية

    bankingPaymentsAccountNumber: string;
    bankingPaymentsAccount: any;

    /// رقم حساب اوراق القبض

    receiptPapersAccountNumber: string;
    receiptPapersAccount: any;


    //رقم حساب اوراق القبض تحت التحصيل

    checksUnderReceiptPapersAccountNumber: string;
    checksUnderReceiptPapersAccount: any;


    /// رقم حساب التبرعات العامة

    generalDonationsAccountNumber: string;
    generalDonationsAccount: any;
}