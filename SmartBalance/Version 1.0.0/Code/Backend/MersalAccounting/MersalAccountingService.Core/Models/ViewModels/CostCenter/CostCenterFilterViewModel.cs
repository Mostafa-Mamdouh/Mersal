#region Using ...
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
	public class CostCenterFilterViewModel : BaseFilterViewModel
	{
        #region Properties
        public string Name { get; set; }
        public string Code { get; set; }
        //public bool? IsActive { get; set; }

        public decimal? OpeningCreditFrom { get; set; }
        public decimal? OpeningCreditTo { get; set; }

        public long? CostCenterTypeId { get; set; }
        #endregion
    }
}
