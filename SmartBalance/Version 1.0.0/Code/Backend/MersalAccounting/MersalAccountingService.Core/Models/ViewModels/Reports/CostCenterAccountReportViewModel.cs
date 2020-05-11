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
	public class CostCenterAccountReportViewModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string FullCode { get; set; }

        public DateTime? CreationDate { get; set; }
        public string DocumentCode { get; set; }
        public string Description { get; set; }
        public string MovementType { get; set; }
        public decimal? CreditorValue { get; set; }
        public decimal? DebtorValue { get; set; }

        public string CostCenterName { get; set; }
    }
}
