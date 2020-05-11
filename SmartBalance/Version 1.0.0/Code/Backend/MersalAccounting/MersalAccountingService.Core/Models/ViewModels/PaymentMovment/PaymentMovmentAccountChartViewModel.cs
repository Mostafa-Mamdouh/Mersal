#region Using ...
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels.PaymentMovment
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class PaymentMovmentAccountChartViewModel
    {
        #region Properties
        #region IEntityIdentity<T>
        public long Id { get; set; }
        #endregion
        public long? PaymentMovmentId { get; set; }

        public long? AccountChartId { get; set; }

        #endregion
    }
}
