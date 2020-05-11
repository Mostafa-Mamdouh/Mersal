#region Using ...
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
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	public class PaymentMovmentInventory : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AccountChart.
		/// </summary>
		public PaymentMovmentInventory()
		{

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

		public long InventoryId { get; set; }
		public virtual Inventory Inventory { get; set; }

		public long PaymentMovmentId { get; set; }
		public virtual PaymentMovment PaymentMovment { get; set; }
		/// <summary>
		/// this proprety represents CostCenter share of total donation amount.
		/// </summary>
		public decimal Amount { get; set; }

		#endregion
	}
}
