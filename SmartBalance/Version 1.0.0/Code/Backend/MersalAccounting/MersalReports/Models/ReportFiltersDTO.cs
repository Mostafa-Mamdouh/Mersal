#region Using ...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
#endregion

namespace MersalReports.Models
{
    public class ReportFiltersDTO
    {
        #region Constructors
        public ReportFiltersDTO(DateTime? dateFrom, DateTime? dateTo)
        {
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
        } 
        #endregion


        #region Properties
        public long? AccountChartId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; } 
        #endregion
    }
}