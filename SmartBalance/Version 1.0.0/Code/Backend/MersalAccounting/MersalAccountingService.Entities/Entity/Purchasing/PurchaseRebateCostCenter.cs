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
	/// Provides a PurchaseRebateCostCenter entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * 
	 */
	public class PurchaseRebateCostCenter : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type PurchaseRebateCostCenter.
		/// </summary>
		public PurchaseRebateCostCenter()
		{

		}
		#endregion

		#region Properties

		#region IEntityIdentity<T>
		public long Id { get; set; }
		#endregion

		#region IEntityDateTimeSignature
		public DateTime CreationDate { get; set; }
		public DateTime? FirstModificationDate { get; set; }
		public DateTime? LastModificationDate { get; set; }
		#endregion

		public Nullable<long> CostCenterId { get; set; }
		public virtual CostCenter CostCenter { get; set; }

		public Nullable<long> PurchaseRebateId { get; set; }
		public virtual PurchaseRebate PurchaseRebate { get; set; }

		public decimal Amount { get; set; }

		#endregion
	}
}
