#region Using ...
#endregion

namespace MersalAccountingService.Common.Enums
{
	/// <summary>
	/// 
	/// </summary>
    public enum ResourceKeyEnum
    {
        OpeningBalance,
        BankMovement,
        PaymentMovement,
        PurchaseInvoice,
        PurchaseRebate,
        ReceiptsMovement,
        SalesInvoice,
        SalesRebate,
        StoreMovement,
        TotalCreditBalanceBeforePeriod,
        TotalDebtBalanceBeforePeriod,
        TotalCreditBalanceInPeriod,
        TotalDebtBalanceInPeriod,
        RelayFromMovementOfBankNo,
		CreditTransactionForBankMovement,
		DebitTransactionForBankMovement,
		RelayFromPaymentMovementNo,
		CreditTransactionForPaymentMovement,
		DebitTransactionForPaymentMovement,
		RelayFromPurchaseInvoiceNo,
		CreditTransactionForPurchaseInvoiceNetAmount,
		CreditTransactionForPurchaseInvoiceTotalDiscount,
		DebitTransactionForPurchaseInvoiceTotalExpenses,
		DebitTransactionForPurchaseInvoiceTaxAmount,
		DebitTransactionForPurchaseInvoiceTotalAmount,
		RelayFromPurchaseRebateNo,
		CreditTransactionForPurchaseRebateTotalExpenses,
		CreditTransactionForPurchaseRebateTaxAmount,
		CreditTransactionForPurchaseRebateTotalAmount,
		DebitTransactionForPurchaseRebateNetAmount,
		DebitTransactionForPurchaseRebateTotalDiscount,
		RelayFromReceiptsMovementNo,
		CreditTransactionForReceiptsMovement,
		DebitTransactionForReceiptsMovement,

	}
}
