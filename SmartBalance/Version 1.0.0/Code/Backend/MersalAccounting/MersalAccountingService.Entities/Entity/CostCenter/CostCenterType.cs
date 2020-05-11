#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using MersalAccountingService.Common.Enums;
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
	/// Provides a CostCenterType entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * نوع الاهلاك
	 */
	public class CostCenterType : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type CostCenterType.
		/// </summary>
		public CostCenterType()
		{
			this.CostCenters = new HashSet<CostCenter>();
			this.ChildTranslatedCostCenterTypes = new HashSet<CostCenterType>();
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

		public string Code { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }


		public virtual ICollection<CostCenter> CostCenters { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyCostCenterTypeId { get; set; }
		public virtual CostCenterType ParentKeyCostCenterType { get; set; }


		public virtual ICollection<CostCenterType> ChildTranslatedCostCenterTypes { get; set; }
		#endregion

		#endregion
	}
}
