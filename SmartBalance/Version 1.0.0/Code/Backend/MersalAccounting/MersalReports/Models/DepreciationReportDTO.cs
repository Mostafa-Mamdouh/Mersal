using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MersalReports.Models
{
    public class DepreciationReportDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string AssetTypeName { get; set; }
        public DateTime? PurchaseDate { get; set; }

        public decimal? count { get; set; }
        public decimal? TotalValue { get; set; }
        public decimal? DepreciationRate { get; set; }
           
    }
}