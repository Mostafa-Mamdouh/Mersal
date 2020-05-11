#region Using ...
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
    [DebuggerDisplay("Id={Id}, Code={Code}, Name={Name}, Date={Date}, ItemOrder={ItemOrder}, IsActive={IsActive}, ParentMenuItemId={ParentMenuItemId}")]
    public class ListMenuItemsLightViewModel : BaseViewModel
    {
		#region Properties
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public string ItemOrder { get; set; }
		public bool IsActive { get; set; }
		public bool? HasParent { get; set; }
		public string ParentMenuItemName { get; set; } 
		#endregion
	}
}
