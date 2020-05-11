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
    public class AssetFilterViewModel : BaseFilterViewModel
	{
        #region Properties
        public long? BrandId { get; set; }
        public long? LocationId { get; set; }
        public long? AccountChartId { get; set; }
        public long? DepreciationRateId { get; set; }      
        public long? DepreciationTypeId { get; set; }
        public long? PurchaseInvoiceId { get; set; }


        public decimal? DepreciationValueFrom { get; set; }
        public decimal? DepreciationValueTo { get; set; }

        //public DateTime? DateFrom { get; set; }
        //public DateTime? DateTo { get; set; }
        #endregion
    }
}
