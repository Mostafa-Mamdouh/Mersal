﻿#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels.LightViewModels
{
	/// <summary>
	/// Provides a lite model for entity 
	/// DonationType, and this lite model 
	/// do not contains a children 
	/// relations for speeding up the 
	/// retrivement process.
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class DonationTypeLightViewModel : BaseViewModel
	{
        #region Properties
        public long Id { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        #endregion
    }
}
