﻿#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
	[DebuggerDisplay("Id={Id}")]
	public class VATSettingViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type VATSettingViewModel.
        /// </summary>
        public VATSettingViewModel()
        {

        }
        #endregion

        #region Properties
        public double VAT { get; set; }
        #endregion
    }
}

