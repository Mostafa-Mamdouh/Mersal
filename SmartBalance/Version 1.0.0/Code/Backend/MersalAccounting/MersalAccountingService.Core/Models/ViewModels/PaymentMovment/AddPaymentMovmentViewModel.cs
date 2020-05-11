#region Using ...
using Framework.Common.Enums;
using MersalAccountingService.Core.Models.ViewModels.Donation;
using MersalAccountingService.Core.Models.ViewModels.JournalEntries;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels.PaymentMovment
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class AddPaymentMovmentViewModel
	{
		#region Properties
		public List<long> DonatoinTypesLevel { get; set; }
		public long Id { get; set; }
		public string DescriptionAR { get; set; }
		public string DescriptionEN { get; set; }
		public DateTime Date { get; set; }
		public string code { get; set; }
		public String ReciptNumber { get; set; }

		public long? DocumentId { get; set; }

        public string LiquidationNumber { get; set; }


        public DateTime? PaymentDueDate { get; set; }

		#region relation
		public List<PaymentCaseViewModel> Cases { get; set; }
		public List<AddPaymentMovmentInventoryViewModel> Inventorys { get; set; }
		public List<AddPaymentMovmentCostCenterViewModel> CostCenters { get; set; }
		public int BranchId { get; set; }
		public SourceType SourceType { get; set; }
        public List<long> VendorId { get; set; }
        public List<long> AccountChartId { get; set; }
        public List<long> DonatorId { get; set; }
        public long? ToBankAccountChartId { get; set; }

	

		public long? DonationTypeId { get; set; }

		public long? DelegateManId { get; set; }

		public string DelegateManReciptNumber { get; set; }
		public long? ExpensesTypeId { get; set; }

        public List<NotificationsDiscountViewModel>NotificationsDiscount { get; set; }

        public AddDonatorViewModel Donator { get; set; }

		//if donator is a new Donator  
		#endregion

		#region payment 
		public int ReceivingMethodId { get; set; }
		//props if cheque
		public string ChequeNumber { get; set; }
		//تاريخ الاستحقاق
		public DateTime? Duedate { get; set; }
		//prop if visa
		public string VisaNumber { get; set; }
		//in case of cash you need to set safe Id
		public long? SafeId { get; set; }
		//in case of Visa or Chique you need to set Bank Id
		public long? FromBankId { get; set; }
		public long? ToBankId { get; set; }
		public long? VisaBankId { get; set; }
		public bool Exchangeable { get; set; }
		//acctual Paid Amount what our Source Pay
		public decimal Amount { get; set; }
		public long CurrencyId { get; set; }
		public long? SafeAccountChartId { get; set; }

		#endregion


		public AddJournalEntriesViewModel Journal { get; set; }
		#endregion
	}
}
