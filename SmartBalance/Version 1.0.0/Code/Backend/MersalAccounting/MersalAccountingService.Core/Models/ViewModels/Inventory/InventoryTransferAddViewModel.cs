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
	public class InventoryTransferAddViewModel : BaseViewModel
	{
		#region Properties
		public long Id { get; set; }
		public string Code { get; set; }
		public string DescriptionAr { get; set; }
		public string DescriptionEn { get; set; }
		public long InventoryFromId { get; set; }
		public long InventoryToId { get; set; }
		public DateTime? Date { get; set; }

		public virtual ICollection<InventoryCostCentersViewModel> InventoryTransferCostCenter { get; set; }
		public virtual ICollection<InventoryOpeningBalanceProductViewModel> Products { get; set; }
		#endregion
	}
}
