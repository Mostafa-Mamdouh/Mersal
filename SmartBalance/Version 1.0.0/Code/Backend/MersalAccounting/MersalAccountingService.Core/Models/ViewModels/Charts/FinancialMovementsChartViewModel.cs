﻿#region Using ...
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
	public class FinancialMovementsChartViewModel : BaseViewModel
	{
		#region Properties
		public string MovementName { get; set; }
		public double January { get; set; }
		public double February { get; set; }
		public double March { get; set; }
		public double April { get; set; }
		public double May { get; set; }
		public double June { get; set; }
		public double July { get; set; }
		public double August { get; set; }
		public double September { get; set; }
		public double October { get; set; }
		public double November { get; set; }
		public double December { get; set; }
		#endregion
	}
}
