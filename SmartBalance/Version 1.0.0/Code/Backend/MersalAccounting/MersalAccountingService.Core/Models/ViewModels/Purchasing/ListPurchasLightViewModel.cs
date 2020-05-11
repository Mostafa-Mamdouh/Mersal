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
	public class ListPurchasLightViewModel : BaseViewModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Vendor { get; set; }
        public string Inventory { get; set; }
        public DateTime Date { get; set; }
    }
}
