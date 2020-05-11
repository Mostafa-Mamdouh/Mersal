#region using...
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.Models.ViewModels.Shared;
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
	public class ObjectCostCenterFilterViewModel : BaseFilterViewModel
	{
		#region Properties
		public long? CostCenterId { get; set; }

		public ObjectType? ObjectType { get; set; }

		public long? ObjectId { get; set; }
		#endregion
	}
}
