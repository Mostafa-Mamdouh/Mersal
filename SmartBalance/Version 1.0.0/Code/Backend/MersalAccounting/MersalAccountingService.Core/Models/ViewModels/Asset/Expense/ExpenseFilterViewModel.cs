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
    public class ExpenseFilterViewModel : BaseFilterViewModel
	{
        #region Properties
        public long Id { get; set; }
        public string Code { get; set; }           
        public long? AccountChartId { get; set; }       
        public long? ExpensesTypeId { get; set; }
      
        public decimal? AmountFrom { get; set; }
        public decimal? AmountTo { get; set; }

        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        #endregion
    }
}

