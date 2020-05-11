#region using...
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class ObjectCostCenterViewModel : BaseViewModel
	{
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

		public ObjectType ObjectType { get; set; }
		public long ObjectId { get; set; }

		//public ObjectCostCenterType ObjectCostCenterType { get; set; }

		//public long ObjectCostCenterId { get; set; }
		#endregion
	}
}
