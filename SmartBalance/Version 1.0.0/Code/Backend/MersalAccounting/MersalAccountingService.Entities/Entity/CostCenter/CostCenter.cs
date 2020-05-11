#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
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
	/// Provides a CostCenter entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * مراكز التكلفة
	 */
	public class CostCenter : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type CostCenter.
		/// </summary>
		public CostCenter()
		{
			this.ChildTranslatedCostCenters = new HashSet<CostCenter>();
			this.DonationCostCenters = new HashSet<DonationCostCenter>();
			this.CostCenterBills = new HashSet<CostCenterBill>();
			this.PaymentMovmentCostCenters = new HashSet<PaymentMovmentCostCenter>();
			this.PurchaseInvoiceCostCenters = new HashSet<PurchaseInvoiceCostCenter>();
			this.PurchaseRebateCostCenters = new HashSet<PurchaseRebateCostCenter>();
			this.BankMovementCostCenters = new HashSet<BankMovementCostCenters>();
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

		public string Name { get; set; }
		public string Code { get; set; }
		public DateTime? Date { get; set; }
		public string Description { get; set; }
		//public bool IsActive { get; set; }

		public decimal? OpeningCredit { get; set; }
		public bool? IsDebt { get; set; }


		public long? CostCenterTypeId { get; set; }
		public virtual CostCenterType CostCenterType { get; set; }



		#region relations
		public long? AccountChartId { get; set; }
		public virtual AccountChart AccountChart { get; set; }

		public virtual ICollection<DonationCostCenter> DonationCostCenters { get; set; }
		public virtual ICollection<CostCenterBill> CostCenterBills { get; set; }
		public virtual ICollection<PaymentMovmentCostCenter> PaymentMovmentCostCenters { get; set; }

		public virtual ICollection<PurchaseInvoiceCostCenter> PurchaseInvoiceCostCenters { get; set; }
		public virtual ICollection<PurchaseRebateCostCenter> PurchaseRebateCostCenters { get; set; }


		public virtual ICollection<BankMovementCostCenters> BankMovementCostCenters { get; set; }
		#endregion

		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyCostCenterId { get; set; }
		public virtual CostCenter ParentKeyCostCenter { get; set; }


		public virtual ICollection<CostCenter> ChildTranslatedCostCenters { get; set; }
		#endregion

		#endregion
	}
}
