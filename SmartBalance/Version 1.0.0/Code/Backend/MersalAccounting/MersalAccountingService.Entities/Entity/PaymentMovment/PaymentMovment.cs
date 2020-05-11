#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using MersalAccountingService.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Entities.Entity
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	public class PaymentMovment : IEntityIdentity<long>, IEntityDateTimeSignature, IPostingSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PaymentMovment.
		/// </summary>
		public PaymentMovment()
		{
			this.ChildTranslatedPaymentMovments = new HashSet<PaymentMovment>();
			this.PaymentMovmentCostCenters = new HashSet<PaymentMovmentCostCenter>();
			this.PaymentMovmentInventorys = new HashSet<PaymentMovmentInventory>();
			this.PaymentCases = new HashSet<PaymentCase>();
            this.PaymentMovmentVendors = new HashSet<PaymentMovmentVendor>();
            this.PaymentMovementDonators = new HashSet<PaymentMovementDonator>();
            this.PaymentMovmentAccountCharts = new HashSet<PaymentMovmentAccountChart>();
            this.PaymentMovmentNotificationDiscounts = new HashSet<PaymentMovmentNotificationDiscount>();


        }
        #endregion

        #region Properties

        #region IEntityIdentity<T>
        public long Id { get; set; }
		#endregion

		#region IEntityDateTime
		public DateTime CreationDate { get; set; }
		public DateTime? FirstModificationDate { get; set; }
		public DateTime? LastModificationDate { get; set; }
		#endregion

		#region IPostingSignature
		public bool IsPosted { get; set; }
		public DateTime? PostingDate { get; set; }
		public long? PostedByUserId { get; set; }
		#endregion


		public DateTime Date { get; set; }
		public string Description { get; set; }
		public string Code { get; set; }
		public string ReciptNumber { get; set; }

		public long? DocumentId { get; set; }
		public virtual Document Document { get; set; }

        public string LiquidationNumber { get; set; }

        public DateTime? PaymentDueDate { get; set; }

		#region relations
		//sources
		//public long? VendorId { get; set; }
		//public virtual Vendor Vendor { get; set; }

        public virtual ICollection<PaymentMovmentVendor> PaymentMovmentVendors { get; set; }
        public virtual ICollection<PaymentMovmentAccountChart> PaymentMovmentAccountCharts { get; set; }
        public virtual ICollection<PaymentMovementDonator> PaymentMovementDonators { get; set; }
        public virtual ICollection<PaymentMovmentNotificationDiscount> PaymentMovmentNotificationDiscounts { get; set; }



        //      public long? AccountChartId { get; set; }
        //public virtual AccountChart AccountChart { get; set; }

        //public long? DonatorId { get; set; }
        //public virtual Donator Donator { get; set; }
        public long? DonationTypeId { get; set; }
		public virtual DonationType DonationType { get; set; }

		public long? ToBankAccountChartId { get; set; }
		public virtual AccountChart ToBankAccountChart { get; set; }


		public long? GeneralAccountId { get; set; }
		public virtual GeneralAccount GeneralAccount { get; set; }

		public virtual ICollection<PaymentMovmentInventory> PaymentMovmentInventorys { get; set; }
		public virtual ICollection<PaymentMovmentCostCenter> PaymentMovmentCostCenters { get; set; }

		public virtual ICollection<PaymentCase> PaymentCases { get; set; }

		public int? BranchId { get; set; }
		public virtual Branch Branch { get; set; }
		public long? CurrencyId { get; set; }
		public virtual Currency Currency { get; set; }

		public long? ExpensesTypeId { get; set; }
		public virtual ExpensesType ExpensesType { get; set; }


	
		#endregion

		#region Receiving Method Of Payment
		public long? DelegateManId { get; set; }
		public string DelegateManReciptNumber { get; set; }
		public virtual DelegateMan DelegateMan { get; set; }

		public int? ReceivingMethodId { get; set; }
		public virtual ReceivingMethod ReceivingMethod { get; set; }
		//public ReceivingPaymentMethod ReceivingPaymentMethod { get; set; }

		//props if cheque
		public string ChequeNumber { get; set; }
		//تاريخ الاستحقاق
		public DateTime? Duedate { get; set; }
		//بنك الصرف
		public long? ChequeToBankId { get; set; }
		public Bank ChequeToBank { get; set; }

		public bool Exchangeable { get; set; }
		//prop if visa
		public string VisaNumber { get; set; }

		//in case of cash you need to set safe Id
		public long? SafeId { get; set; }
		public virtual Safe Safe { get; set; }

		//in case of Visa or Chique you need to set Bank Id
		public long? BankId { get; set; }
		public virtual Bank Bank { get; set; }

		public long? SafeAccountChartId { get; set; }
		public virtual AccountChart SafeAccountChart { get; set; }



		//المبلغ المدفوع
		public decimal Amount { get; set; }
		#endregion

		#region Translation Functionality
		public Language? Language { get; set; }
		public long? ParentKeyPaymentMovmentId { get; set; }
		public virtual PaymentMovment ParentKeyPaymentMovment { get; set; }
		public virtual ICollection<PaymentMovment> ChildTranslatedPaymentMovments { get; set; }
		#endregion

		#endregion
	}
}
