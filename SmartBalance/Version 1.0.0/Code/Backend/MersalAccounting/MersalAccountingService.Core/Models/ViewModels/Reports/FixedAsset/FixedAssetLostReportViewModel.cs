#region Using ...
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels.Reports
{
    [DebuggerDisplay("BrandCode={BrandCode}, BrandName={BrandName}, Date={Date}, LocationName={LocationName}")]
    public class FixedAssetLostReportViewModel
    {
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public string LocationName { get; set; }
        public DateTime? Date { get; set; }

        public int? ExpectedQuantity { get; set; }
        public int? ActualQuantity { get; set; }
        public int? Difference { get; set; }
    }
}
