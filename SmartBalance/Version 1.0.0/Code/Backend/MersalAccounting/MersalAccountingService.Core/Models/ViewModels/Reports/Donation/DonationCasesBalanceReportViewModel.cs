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
    [DebuggerDisplay("Id={Id}")]
    public class DonationCasesBalanceReportViewModel
    {
        #region Properties
        public decimal TotalAmount { get; set; }
        public string ExternalId { get; set; }
        public string CaseName { get; set; }       
        //public DateTime? DateFrom { get; set; }
        //public DateTime? DateTo { get; set; }
        #endregion
    }
}
