#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
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
	public class InventoryCostCentersViewModel
	{
		#region Properties
		public long Id { get; set; }

		public long CostCenterId { get; set; }

		public long InventoryOpeningBalanceId { get; set; } 
		#endregion
	}
}
