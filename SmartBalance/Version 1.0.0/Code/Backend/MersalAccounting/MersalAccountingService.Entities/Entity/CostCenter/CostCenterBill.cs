#region Using
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
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	public class CostCenterBill : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public CostCenterBill()
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

		public Nullable<long> SalesBillId { get; set; }
		public virtual SalesBill SalesBill { get; set; }

		public Nullable<long> CostCeneterId { get; set; }
		public virtual CostCenter CostCenter { get; set; }

		#region Translation Functionality
		public Language? Language { get; set; }
		#endregion

		#endregion
	}
}
