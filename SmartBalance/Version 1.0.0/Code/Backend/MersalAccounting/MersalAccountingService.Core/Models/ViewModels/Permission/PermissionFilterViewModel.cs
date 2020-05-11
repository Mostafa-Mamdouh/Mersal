﻿#region Using ...
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
	[DebuggerDisplay("Id={Id}, Code={Code}, Name={Name}, DateFrom={DateFrom}, DateTo={DateTo}")]
	public class PermissionFilterViewModel : BaseFilterViewModel
	{
		#region Properties
		public string Id { get; set; }
		public int? Code { get; set; }
		public string Name { get; set; }
		public bool? IsActive { get; set; }
		#endregion
	}
}
