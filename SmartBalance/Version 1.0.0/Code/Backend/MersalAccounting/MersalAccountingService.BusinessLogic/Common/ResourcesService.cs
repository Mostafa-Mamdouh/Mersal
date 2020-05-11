#region Using ...
using Framework.Common.Enums;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Common.Types;
using MersalAccountingService.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace MersalAccountingService.BusinessLogic.Common
{
    public class ResourcesService : IResourcesService
    {
		#region Data Members
		private List<ResourceKey> _resources;
		#endregion

		#region Constructors
		public ResourcesService()
		{
			this.InitializeResources();
		} 
		#endregion

		private void InitializeResources()
        {
            this._resources = new List<ResourceKey>();

            ResourceKey key_OpeningBalance = new ResourceKey(ResourceKeyEnum.OpeningBalance);
            key_OpeningBalance.ResourceValues.Add(new ResourceValue(Language.Arabic, "الرصيد الافتتاحى"));
            key_OpeningBalance.ResourceValues.Add(new ResourceValue(Language.English, "Opening Balance"));

            ResourceKey key_BankMovement = new ResourceKey(ResourceKeyEnum.BankMovement);
            key_BankMovement.ResourceValues.Add(new ResourceValue(Language.Arabic, "حركة بنوك"));
            key_BankMovement.ResourceValues.Add(new ResourceValue(Language.English, "Bank Movement"));

            ResourceKey key_PaymentMovement = new ResourceKey(ResourceKeyEnum.PaymentMovement);
            key_PaymentMovement.ResourceValues.Add(new ResourceValue(Language.Arabic, "حركة مدفوعات"));
            key_PaymentMovement.ResourceValues.Add(new ResourceValue(Language.English, "Payment Movement"));

            ResourceKey key_PurchaseInvoice = new ResourceKey(ResourceKeyEnum.PurchaseInvoice);
            key_PurchaseInvoice.ResourceValues.Add(new ResourceValue(Language.Arabic, "فاتورة مشتريات"));
            key_PurchaseInvoice.ResourceValues.Add(new ResourceValue(Language.English, "Purchase Invoice"));

            ResourceKey key_PurchaseRebate = new ResourceKey(ResourceKeyEnum.PurchaseRebate);
            key_PurchaseRebate.ResourceValues.Add(new ResourceValue(Language.Arabic, "مرتد مشتريات"));
            key_PurchaseRebate.ResourceValues.Add(new ResourceValue(Language.English, "Purchase Rebate"));

            ResourceKey key_ReceiptsMovement = new ResourceKey(ResourceKeyEnum.ReceiptsMovement);
            key_ReceiptsMovement.ResourceValues.Add(new ResourceValue(Language.Arabic, "حركة مقبوضات"));
            key_ReceiptsMovement.ResourceValues.Add(new ResourceValue(Language.English, "Receipts Movement"));

            ResourceKey key_SalesInvoice = new ResourceKey(ResourceKeyEnum.SalesInvoice);
            key_SalesInvoice.ResourceValues.Add(new ResourceValue(Language.Arabic, "فاتورة مبيعات"));
            key_SalesInvoice.ResourceValues.Add(new ResourceValue(Language.English, "Sales Invoice"));

            ResourceKey key_SalesRebate = new ResourceKey(ResourceKeyEnum.SalesRebate);
            key_SalesRebate.ResourceValues.Add(new ResourceValue(Language.Arabic, "مرتد مبيعات"));
            key_SalesRebate.ResourceValues.Add(new ResourceValue(Language.English, "Sales Rebate"));

            ResourceKey key_StoreMovement = new ResourceKey(ResourceKeyEnum.StoreMovement);
            key_StoreMovement.ResourceValues.Add(new ResourceValue(Language.Arabic, "حركة مخازن"));
            key_StoreMovement.ResourceValues.Add(new ResourceValue(Language.English, "Store Movement"));

            ResourceKey key_TotalCreditBalanceBeforePeriod = new ResourceKey(ResourceKeyEnum.TotalCreditBalanceBeforePeriod);
            key_TotalCreditBalanceBeforePeriod.ResourceValues.Add(new ResourceValue(Language.Arabic, "اجمالى الرصيد الدائن قبل الفترة"));
            key_TotalCreditBalanceBeforePeriod.ResourceValues.Add(new ResourceValue(Language.English, "Total Credit Balance Before Period"));

            ResourceKey key_TotalDebtBalanceBeforePeriod = new ResourceKey(ResourceKeyEnum.TotalDebtBalanceBeforePeriod);
            key_TotalDebtBalanceBeforePeriod.ResourceValues.Add(new ResourceValue(Language.Arabic, "اجمالى الرصيد المدين قبل الفترة"));
            key_TotalDebtBalanceBeforePeriod.ResourceValues.Add(new ResourceValue(Language.English, "Total Debt Balance Before Period"));

            ResourceKey key_TotalCreditBalanceInPeriod = new ResourceKey(ResourceKeyEnum.TotalCreditBalanceInPeriod);
            key_TotalCreditBalanceInPeriod.ResourceValues.Add(new ResourceValue(Language.Arabic, "اجمالى الرصيد الدائن خلال الفترة"));
            key_TotalCreditBalanceInPeriod.ResourceValues.Add(new ResourceValue(Language.English, "Total Credit Balance In Period"));

            ResourceKey key_TotalDebtBalanceInPeriod = new ResourceKey(ResourceKeyEnum.TotalDebtBalanceInPeriod);
            key_TotalDebtBalanceInPeriod.ResourceValues.Add(new ResourceValue(Language.Arabic, "اجمالى الرصيد المدين خلال الفترة"));
            key_TotalDebtBalanceInPeriod.ResourceValues.Add(new ResourceValue(Language.English, "Total Debt Balance In Period"));

            ResourceKey key_RelayFromMovementOfBankNo = new ResourceKey(ResourceKeyEnum.RelayFromMovementOfBankNo);
			key_RelayFromMovementOfBankNo.ResourceValues.Add(new ResourceValue(Language.Arabic, "مرحل من حركة بنوك رقم "));
			key_RelayFromMovementOfBankNo.ResourceValues.Add(new ResourceValue(Language.English, "Relay from movement of bank No. "));

			ResourceKey key_CreditTransactionForBankMovement = new ResourceKey(ResourceKeyEnum.CreditTransactionForBankMovement);
			key_CreditTransactionForBankMovement.ResourceValues.Add(new ResourceValue(Language.Arabic, "معاملة طرف دائن لحركة بنوك"));
			key_CreditTransactionForBankMovement.ResourceValues.Add(new ResourceValue(Language.English, "Transaction of a crediting party for the movement of bank"));

			ResourceKey key_DebitTransactionForBankMovement = new ResourceKey(ResourceKeyEnum.DebitTransactionForBankMovement);
			key_DebitTransactionForBankMovement.ResourceValues.Add(new ResourceValue(Language.Arabic, "معاملة طرف مدين لحركة بنوك"));
			key_DebitTransactionForBankMovement.ResourceValues.Add(new ResourceValue(Language.English, "Transaction of a debiting party for the movement of bank"));

			ResourceKey key_RelayFromPaymentMovementNo = new ResourceKey(ResourceKeyEnum.RelayFromPaymentMovementNo);
			key_RelayFromPaymentMovementNo.ResourceValues.Add(new ResourceValue(Language.Arabic, "مرحل من حركة مدفوعات رقم "));
			key_RelayFromPaymentMovementNo.ResourceValues.Add(new ResourceValue(Language.English, "Relay from movement of payment No. "));

			ResourceKey key_CreditTransactionForPaymentMovement = new ResourceKey(ResourceKeyEnum.CreditTransactionForPaymentMovement);
			key_CreditTransactionForPaymentMovement.ResourceValues.Add(new ResourceValue(Language.Arabic, "معاملة طرف دائن لحركة مدفوعات"));
			key_CreditTransactionForPaymentMovement.ResourceValues.Add(new ResourceValue(Language.English, "Transaction of a crediting party for the movement of payment"));

			ResourceKey key_DebitTransactionForPaymentMovement = new ResourceKey(ResourceKeyEnum.DebitTransactionForPaymentMovement);
			key_DebitTransactionForPaymentMovement.ResourceValues.Add(new ResourceValue(Language.Arabic, "معاملة طرف مدين لحركة مدفوعات"));
			key_DebitTransactionForPaymentMovement.ResourceValues.Add(new ResourceValue(Language.English, "Treating the debtor of a payment transaction"));

			ResourceKey key_RelayFromPurchaseInvoiceNo = new ResourceKey(ResourceKeyEnum.RelayFromPurchaseInvoiceNo);
			key_RelayFromPurchaseInvoiceNo.ResourceValues.Add(new ResourceValue(Language.Arabic, "مرحل من فاتورة مشتريات رقم "));
			key_RelayFromPurchaseInvoiceNo.ResourceValues.Add(new ResourceValue(Language.English, "Relay from purchase invoice No. "));

			ResourceKey key_CreditTransactionForPurchaseInvoiceNetAmount = new ResourceKey(ResourceKeyEnum.CreditTransactionForPurchaseInvoiceNetAmount);
			key_CreditTransactionForPurchaseInvoiceNetAmount.ResourceValues.Add(new ResourceValue(Language.Arabic, "معاملة طرف دائن لفاتورة مشتريات - صافى القيمة"));
			key_CreditTransactionForPurchaseInvoiceNetAmount.ResourceValues.Add(new ResourceValue(Language.English, "Transaction of a crediting party for the purchase invoice - NetAmount"));

			ResourceKey key_CreditTransactionForPurchaseInvoiceTotalDiscount = new ResourceKey(ResourceKeyEnum.CreditTransactionForPurchaseInvoiceTotalDiscount);
			key_CreditTransactionForPurchaseInvoiceTotalDiscount.ResourceValues.Add(new ResourceValue(Language.Arabic, "معاملة طرف دائن لفاتورة مشتريات - إجمالى الخصم"));
			key_CreditTransactionForPurchaseInvoiceTotalDiscount.ResourceValues.Add(new ResourceValue(Language.English, "Transaction of a crediting party for the purchase invoice - TotalDiscount"));

			ResourceKey key_DebitTransactionForPurchaseInvoiceTotalExpenses = new ResourceKey(ResourceKeyEnum.DebitTransactionForPurchaseInvoiceTotalExpenses);
			key_DebitTransactionForPurchaseInvoiceTotalExpenses.ResourceValues.Add(new ResourceValue(Language.Arabic, "معاملة طرف مدين لفاتورة مشتريات - إجمالى المصروفات"));
			key_DebitTransactionForPurchaseInvoiceTotalExpenses.ResourceValues.Add(new ResourceValue(Language.English, "Treating the debtor of a purchase invoice transaction - TotalExpenses"));

			ResourceKey key_DebitTransactionForPurchaseInvoiceTaxAmount = new ResourceKey(ResourceKeyEnum.DebitTransactionForPurchaseInvoiceTaxAmount);
			key_DebitTransactionForPurchaseInvoiceTaxAmount.ResourceValues.Add(new ResourceValue(Language.Arabic, "معاملة طرف مدين لفاتورة مشتريات - قيمة الضريبة"));
			key_DebitTransactionForPurchaseInvoiceTaxAmount.ResourceValues.Add(new ResourceValue(Language.English, "Treating the debtor of a purchase invoice transaction - TaxAmount"));

			ResourceKey key_DebitTransactionForPurchaseInvoiceTotalAmount = new ResourceKey(ResourceKeyEnum.DebitTransactionForPurchaseInvoiceTotalAmount);
			key_DebitTransactionForPurchaseInvoiceTotalAmount.ResourceValues.Add(new ResourceValue(Language.Arabic, "معاملة طرف مدين لفاتورة مشتريات - إجمالى الفاتورة"));
			key_DebitTransactionForPurchaseInvoiceTotalAmount.ResourceValues.Add(new ResourceValue(Language.English, "Treating the debtor of a purchase invoice transaction - TotalAmount"));

			ResourceKey key_RelayFromPurchaseRebateNo = new ResourceKey(ResourceKeyEnum.RelayFromPurchaseRebateNo);
			key_RelayFromPurchaseRebateNo.ResourceValues.Add(new ResourceValue(Language.Arabic, "مرحل من مرتد مشتريات رقم "));
			key_RelayFromPurchaseRebateNo.ResourceValues.Add(new ResourceValue(Language.English, "Relay from purchase rebate No. "));

			ResourceKey key_CreditTransactionForPurchaseRebateTotalExpenses = new ResourceKey(ResourceKeyEnum.CreditTransactionForPurchaseRebateTotalExpenses);
			key_CreditTransactionForPurchaseRebateTotalExpenses.ResourceValues.Add(new ResourceValue(Language.Arabic, "معاملة طرف دائن لمرتد مشتريات - إجمالى المصروفات"));
			key_CreditTransactionForPurchaseRebateTotalExpenses.ResourceValues.Add(new ResourceValue(Language.English, "Transaction of a crediting party for the purchase rebate - TotalExpenses"));

			ResourceKey key_CreditTransactionForPurchaseRebateTaxAmount = new ResourceKey(ResourceKeyEnum.CreditTransactionForPurchaseRebateTaxAmount);
			key_CreditTransactionForPurchaseRebateTaxAmount.ResourceValues.Add(new ResourceValue(Language.Arabic, "معاملة طرف دائن لمرتد مشتريات - قيمة الضريبة"));
			key_CreditTransactionForPurchaseRebateTaxAmount.ResourceValues.Add(new ResourceValue(Language.English, "Transaction of a crediting party for the purchase rebate - TaxAmount"));

			ResourceKey key_CreditTransactionForPurchaseRebateTotalAmount = new ResourceKey(ResourceKeyEnum.CreditTransactionForPurchaseRebateTotalAmount);
			key_CreditTransactionForPurchaseRebateTotalAmount.ResourceValues.Add(new ResourceValue(Language.Arabic, "معاملة طرف دائن لمرتد مشتريات - إجمالى الفاتورة"));
			key_CreditTransactionForPurchaseRebateTotalAmount.ResourceValues.Add(new ResourceValue(Language.English, "Transaction of a crediting party for the purchase rebate - TotalAmount"));

			ResourceKey key_DebitTransactionForPurchaseRebateNetAmount = new ResourceKey(ResourceKeyEnum.DebitTransactionForPurchaseRebateNetAmount);
			key_DebitTransactionForPurchaseRebateNetAmount.ResourceValues.Add(new ResourceValue(Language.Arabic, "معاملة طرف مدين لمرتد مشتريات - صافى القيمة"));
			key_DebitTransactionForPurchaseRebateNetAmount.ResourceValues.Add(new ResourceValue(Language.English, "Treating the debtor of a purchase rebate transaction - NetAmount"));

			ResourceKey key_DebitTransactionForPurchaseRebateTotalDiscount = new ResourceKey(ResourceKeyEnum.DebitTransactionForPurchaseRebateTotalDiscount);
			key_DebitTransactionForPurchaseRebateTotalDiscount.ResourceValues.Add(new ResourceValue(Language.Arabic, "معاملة طرف مدين لمرتد مشتريات - إجمالى الخصم"));
			key_DebitTransactionForPurchaseRebateTotalDiscount.ResourceValues.Add(new ResourceValue(Language.English, "Treating the debtor of a purchase rebate transaction - TotalDiscount"));

			ResourceKey key_RelayFromReceiptsMovementNo = new ResourceKey(ResourceKeyEnum.RelayFromReceiptsMovementNo);
			key_RelayFromReceiptsMovementNo.ResourceValues.Add(new ResourceValue(Language.Arabic, "مرحل من حركة مقبوضات رقم "));
			key_RelayFromReceiptsMovementNo.ResourceValues.Add(new ResourceValue(Language.English, "Relay from movement of receipts No. "));

			ResourceKey key_CreditTransactionForReceiptsMovement = new ResourceKey(ResourceKeyEnum.CreditTransactionForReceiptsMovement);
			key_CreditTransactionForReceiptsMovement.ResourceValues.Add(new ResourceValue(Language.Arabic, "معاملة طرف دائن لحركة مقبوضات"));
			key_CreditTransactionForReceiptsMovement.ResourceValues.Add(new ResourceValue(Language.English, "Transaction of a crediting party for the movement of receipts"));

			ResourceKey key_DebitTransactionForReceiptsMovement = new ResourceKey(ResourceKeyEnum.DebitTransactionForReceiptsMovement);
			key_DebitTransactionForReceiptsMovement.ResourceValues.Add(new ResourceValue(Language.Arabic, "معاملة طرف مدين لحركة مقبوضات"));
			key_DebitTransactionForReceiptsMovement.ResourceValues.Add(new ResourceValue(Language.English, "Treating the debtor of a receivable transaction"));




			this._resources.Add(key_OpeningBalance);
            this._resources.Add(key_BankMovement);
            this._resources.Add(key_PaymentMovement);
            this._resources.Add(key_PurchaseInvoice);
            this._resources.Add(key_PurchaseRebate);
            this._resources.Add(key_ReceiptsMovement);
            this._resources.Add(key_SalesInvoice);
            this._resources.Add(key_SalesRebate);
            this._resources.Add(key_StoreMovement);
            this._resources.Add(key_TotalCreditBalanceBeforePeriod);
            this._resources.Add(key_TotalDebtBalanceBeforePeriod);
            this._resources.Add(key_TotalCreditBalanceInPeriod);
            this._resources.Add(key_TotalDebtBalanceInPeriod);
            this._resources.Add(key_RelayFromMovementOfBankNo);
			this._resources.Add(key_CreditTransactionForBankMovement);
			this._resources.Add(key_DebitTransactionForBankMovement);
			this._resources.Add(key_RelayFromPaymentMovementNo);
			this._resources.Add(key_CreditTransactionForPaymentMovement);
			this._resources.Add(key_DebitTransactionForPaymentMovement);
			this._resources.Add(key_RelayFromPurchaseInvoiceNo);
			this._resources.Add(key_CreditTransactionForPurchaseInvoiceNetAmount);
			this._resources.Add(key_CreditTransactionForPurchaseInvoiceTotalDiscount);
			this._resources.Add(key_DebitTransactionForPurchaseInvoiceTotalExpenses);
			this._resources.Add(key_DebitTransactionForPurchaseInvoiceTaxAmount);
			this._resources.Add(key_DebitTransactionForPurchaseInvoiceTotalAmount);
			this._resources.Add(key_RelayFromPurchaseRebateNo);
			this._resources.Add(key_CreditTransactionForPurchaseRebateTotalExpenses);
			this._resources.Add(key_CreditTransactionForPurchaseRebateTaxAmount);
			this._resources.Add(key_CreditTransactionForPurchaseRebateTotalAmount);
			this._resources.Add(key_DebitTransactionForPurchaseRebateNetAmount);
			this._resources.Add(key_DebitTransactionForPurchaseRebateTotalDiscount);
			this._resources.Add(key_RelayFromReceiptsMovementNo);
			this._resources.Add(key_CreditTransactionForReceiptsMovement);
			this._resources.Add(key_DebitTransactionForReceiptsMovement);
		}

		public ResourceKey GetResourceKey(ResourceKeyEnum resourceKeyEnum)
        {
            return this._resources.FirstOrDefault(x => x.Key == resourceKeyEnum);
        }
        public ResourceValue GetResourceValue(ResourceKeyEnum resourceKeyEnum, Language language)
        {
            var key = this.GetResourceKey(resourceKeyEnum);

            return key.ResourceValues.FirstOrDefault(x => x.Language == language);
        }

        public string GetMovementTypeName(MovementType? movementType, Language lang)
        {
            switch (movementType)
            {
                case MovementType.General:
                    return "";
                case MovementType.BankMovement:
                    return this.GetResourceValue(ResourceKeyEnum.BankMovement, lang).Value;
                case MovementType.PaymentMovement:
                    return this.GetResourceValue(ResourceKeyEnum.PaymentMovement, lang).Value;
                case MovementType.PurchaseInvoice:
                    return this.GetResourceValue(ResourceKeyEnum.PurchaseInvoice, lang).Value;
                case MovementType.PurchaseRebate:
                    return this.GetResourceValue(ResourceKeyEnum.PurchaseRebate, lang).Value;
                case MovementType.ReceiptsMovement:
                    return this.GetResourceValue(ResourceKeyEnum.ReceiptsMovement, lang).Value;
                case MovementType.SalesInvoice:
                    return this.GetResourceValue(ResourceKeyEnum.SalesInvoice, lang).Value;
                case MovementType.SalesRebate:
                    return this.GetResourceValue(ResourceKeyEnum.SalesRebate, lang).Value;
                case MovementType.StoreMovement:
                    return this.GetResourceValue(ResourceKeyEnum.StoreMovement, lang).Value;
                default:
                    return "";
            }
        }


        #region Indexers
        public ResourceKey this[ResourceKeyEnum resourceKeyEnum]
        {
            get { return this.GetResourceKey(resourceKeyEnum); }
        }
        public ResourceValue this[ResourceKeyEnum resourceKeyEnum, Language language]
        {
            get { return this.GetResourceValue(resourceKeyEnum, language); }
        }
        #endregion
    }
}
