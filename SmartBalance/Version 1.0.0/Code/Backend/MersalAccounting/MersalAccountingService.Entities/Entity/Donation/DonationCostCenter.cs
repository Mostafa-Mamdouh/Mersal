#region Using ...
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
	public class DonationCostCenter
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type AccountChart.
		/// </summary>
		public DonationCostCenter()
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

		public long CostCenterId { get; set; }
		public virtual CostCenter CostCenter { get; set; }

		public long DonationId { get; set; }
		public virtual Donation Donation { get; set; }
		/// <summary>
		/// this proprety represents CostCenter share of total donation amount.
		/// </summary>
		public decimal Amount { get; set; }

		#endregion
	}
}
