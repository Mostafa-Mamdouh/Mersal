﻿#region Using ...
using Framework.Core.Models.ViewModels.Base;
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
	public class AssetLocationsFilterViewModel : BaseFilterViewModel
	{
		#region Properties
		public string Description { get; set; }
		public DateTime? Date { get; set; }

		public long? AssetId { get; set; }
		public long? LocationId { get; set; }
		#endregion
	}
}
