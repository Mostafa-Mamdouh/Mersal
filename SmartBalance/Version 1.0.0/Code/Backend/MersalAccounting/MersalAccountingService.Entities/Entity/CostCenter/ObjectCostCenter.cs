#region Using ...
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
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	public class ObjectCostCenter : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		public ObjectCostCenter()
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

		public ObjectType ObjectType { get; set; }
		public long ObjectId { get; set; }

		//public ObjectCostCenterType ObjectCostCenterType { get; set; }
		//public long ObjectCostCenterId { get; set; }

		#endregion
	}
}
