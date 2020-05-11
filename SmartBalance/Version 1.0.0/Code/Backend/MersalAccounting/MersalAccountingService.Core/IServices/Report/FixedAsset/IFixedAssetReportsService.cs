#region Using ...
using Framework.Core.IServices.Base;
using MersalAccountingService.Core.Models.ViewModels.Reports;
using System;
using System.Collections.Generic;
#endregion

namespace MersalAccountingService.Core.IServices
{
    public interface IFixedAssetReportsService : IBaseService
    {
        #region Methods
        IList<FixedAssetDepreciationReportViewModel> GetFixedAssetsDepreciationReport(DateTime? dateFrom, DateTime? dateTo);
        IList<FixedAssetLocationReportViewModel> GetFixedAssetsLocationReport(long? locationId, DateTime? dateFrom, DateTime? dateTo);
        IList<FixedAssetExcludedReportViewModel> GetFixedAssetsExcludedReport(DateTime? dateFrom, DateTime? dateTo);
        IList<FixedAssetInventoryReportViewModel> GetFixedAssetsInventoryReport(long? locationId, DateTime? dateFrom, DateTime? dateTo);
        IList<FixedAssetLostReportViewModel> GetFixedAssetsLostReport(long? locationId, DateTime? dateFrom, DateTime? dateTo);
        #endregion
    }
}
