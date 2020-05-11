#region Using ...
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
	[DebuggerDisplay("Id={Id}, Code={Code}, Name={Name}, IsActive={IsActive}")]
	public class MenuItemFilterViewModel : BaseFilterViewModel
	{
		#region Properties
		public string Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public bool? IsActive { get; set; }
		public int? ItemOrder { get; set; }
		public string Url { get; set; }
		public bool? HasParent { get; set; }
		public long? ParentMenuItemId { get; set; }
		#endregion
	}
}
