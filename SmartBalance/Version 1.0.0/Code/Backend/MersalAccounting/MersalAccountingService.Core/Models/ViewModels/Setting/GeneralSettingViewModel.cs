#region Using ...
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
	public class GeneralSettingViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type PostingSettingSettingViewModel.
        /// </summary>
        public GeneralSettingViewModel()
        {

        }
        #endregion

        #region Properties
        public string FiscalYearStartDay { get; set; }
        public string FiscalYearStartMonth { get; set; }
        public string FiscalYearEndDay { get; set; }
        public string FiscalYearEndMonth { get; set; }
        public string IsInventoryRequiredSetting { get; set; }
        public bool? IsInventoryRequired { get; set; }
        #endregion
    }
}
