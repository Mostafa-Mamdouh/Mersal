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
	/// <summary>
	/// إعدادات الحركة المالية
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class TestamentAndAdvancesSettingViewModel : BaseViewModel
    {
        #region Properties      


        /// <summary>
        ///  رقم حساب العهد
        /// </summary>
        public string TestamentAccountNumber { get; set; }
        public AccountChartLightViewModel TestamentAccount { get; set; }


        /// <summary>
        /// رقم حساب السلفيات
        /// </summary>
        public string AdvancesAccountNumber { get; set; }
        public AccountChartLightViewModel AdvancesAccount { get; set; }



        #endregion
    }
}
