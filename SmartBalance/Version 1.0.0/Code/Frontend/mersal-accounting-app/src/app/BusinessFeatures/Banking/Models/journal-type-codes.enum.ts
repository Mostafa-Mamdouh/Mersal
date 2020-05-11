
export enum JournalTypeCodes {
    /**
     * تحويلات بنكية 
     */
    bankTransfers = 1,
    // /**
    //  * سحب 
    //  */
    // withdrawal = 4,
    /**
     * ايداع
     */
    deposit = 7,
    /**
     * مصروفات بنكية
     */
    bankingExpenses = 10,
    /**
     * أوراق الدفع
     */
    paymentPapers = 13,
    /**
     * أوراق القبض
     */
    capturePapers = 16,
    /**
     * تبرعات مباشرة
     */
    directDonations = 19,
    /**
      أوراق دفع مرتدة
     */
    repatedPaymentPapers = 22,
}