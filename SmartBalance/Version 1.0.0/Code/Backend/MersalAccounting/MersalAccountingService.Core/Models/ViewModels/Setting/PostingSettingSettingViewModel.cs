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
	[DebuggerDisplay("IsPostingAutomatic={IsPostingAutomatic}, IsBulkPosting={IsBulkPosting}, AllowPostingAccountCurrencyMisMatch={AllowPostingAccountCurrencyMisMatch}")]
	public class PostingSettingSettingViewModel : BaseViewModel
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type PostingSettingSettingViewModel.
        /// </summary>
        public PostingSettingSettingViewModel()
        {

        }
        #endregion

        #region Properties
        public bool IsPostingAutomatic { get; set; }
        public bool IsBulkPosting { get; set; }
        /// <summary>
        /// السماح بالترحيل لحساب عملته لا تماثل عملة الحركة
        /// </summary>
        public bool AllowPostingAccountCurrencyMisMatch { get; set; }
        #endregion
    }
}
