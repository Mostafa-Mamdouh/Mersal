#region Using ...
using MersalAccountingService.Core.Models.ViewModels.Reports;
using MersalReports.ExternalResources;
using MersalReports.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
#endregion

namespace MersalReports.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult SafeAccountReport(long? SafeId, DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Safe Account";
            }
            else
            {
                ViewData["title"] = "التقارير - كشف حساب خزينة";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"SafeReports/get-Safe-report/{SafeId}?dateFrom={DateFrom}&dateTo={DateTo}";
            var DataSet1 = MersalAPIs.CreateDataTable<SafeReportDTO>(MersalAPIs.Get<SafeReportDTO>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);
            ReportViewer reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/SafeAccountReport-{lang}.rdlc");

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", DataSet3));

            ViewBag.reportViewer = reportViewer;
            return View();
        }

        public ActionResult AccountReport(long accountChartId, long? currencyId, DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Account";
            }
            else
            {
                ViewData["title"] = "التقارير - كشف حساب";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"AccountReports/get-accounts-report/{accountChartId}?currencyId={currencyId}&dateFrom={DateFrom}&dateTo={DateTo}";
            //string pathuri1 = $"AccountReports/get-accounts-report?accountChartId={accountChartId}&dateFrom={DateFrom}&dateTo={DateTo}";
            var DataSet1 = MersalAPIs.CreateDataTable<AccountsReportViewModel>(MersalAPIs.Get<AccountsReportViewModel>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);

            ReportViewer reportViewer = null;

            if (currencyId.HasValue)
                reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/CurrencyAccountReport-{lang}.rdlc");
            else
                reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/AccountReport-{lang}.rdlc");


            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", DataSet3));

            ViewBag.reportViewer = reportViewer;
            return View();
        }

        public ActionResult VendorAccountReport(long? vendorId, DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Vendor Account";
            }
            else
            {
                ViewData["title"] = "التقارير - كشف حساب مورد";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"VendorReports/get-vendor-account-report/{vendorId}?dateFrom={DateFrom}&dateTo={DateTo}";
            var DataSet1 = MersalAPIs.CreateDataTable<VendorReportDTO>(MersalAPIs.Get<VendorReportDTO>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);
            ReportViewer reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/VendorAccountReport-{lang}.rdlc");

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", DataSet3));

            ViewBag.reportViewer = reportViewer;
            return View();
        }

        public ActionResult BankAccountReport(long? bankId, DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Bank Account";
            }
            else
            {
                ViewData["title"] = "التقارير - كشف حساب بنك";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"BankReports/get-bank-account-report/{bankId}?dateFrom={DateFrom}&dateTo={DateTo}";
            var DataSet1 = MersalAPIs.CreateDataTable<BankReportDTO>(MersalAPIs.Get<BankReportDTO>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);
            ReportViewer reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/BankAccountReport-{lang}.rdlc");

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", DataSet3));

            ViewBag.reportViewer = reportViewer;
            return View();
        }

        public ActionResult CostCenterAccountReport(long? costCenterId, DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Cost Center Account";
            }
            else
            {
                ViewData["title"] = "التقارير - كشف حساب مركز تكلفة";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"CostCenterReports/get-cost-center-account-report/{costCenterId}?dateFrom={DateFrom}&dateTo={DateTo}";
            var DataSet1 = MersalAPIs.CreateDataTable<CostCenterReportDTO>(MersalAPIs.Get<CostCenterReportDTO>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);
            ReportViewer reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/CostCenterAccountReport-{lang}.rdlc");

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", DataSet3));

            ViewBag.reportViewer = reportViewer;
            return View();
        }

        public ActionResult BalanceSheetReport(int level, DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Balance Sheet Account";
            }
            else
            {
                ViewData["title"] = "التقارير - ميزان المراجعة";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"AccountReports/get-balance-sheet-report/{level}?dateFrom={DateFrom}&dateTo={DateTo}";
            var DataSet1 = MersalAPIs.CreateDataTable<BalanceSheetReportDTO>(MersalAPIs.Get<BalanceSheetReportDTO>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);
            ReportViewer reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/BalanceSheetReport-{lang}.rdlc");

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", DataSet3));

            ViewBag.reportViewer = reportViewer;
            return View();
        }




        public ActionResult AccountBalanceReport(long? AccountChartId, long? currencyId, DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Account Balance";
            }
            else
            {
                ViewData["title"] = "التقارير - رصيد حساب";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"AccountReports/get-accounts-balance-report/{AccountChartId}?currencyId={currencyId}&dateFrom={DateFrom}&dateTo={DateTo}";
            //string pathuri1 = "AccountReport/get-accounts-balance-report?accountChartId=" + AccountChartId + "&dateFrom=" + DateFrom + "&dateTo=" + DateTo;
            var DataSet1 = MersalAPIs.CreateDataTable<AccountsReportViewModel>(MersalAPIs.Get<AccountsReportViewModel>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);

            ReportViewer reportViewer = null;

            if (currencyId.HasValue)
                reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/CurrencyAccountBalanceReport-{lang}.rdlc");
            else
                reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/AccountBalanceReport-{lang}.rdlc");


            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", DataSet3));

            ViewBag.reportViewer = reportViewer;
            return View();
        }

        public ActionResult SafeBalanceReport(long? SafeId, DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Safe Balance";
            }
            else
            {
                ViewData["title"] = "التقارير - رصيد خزينة";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"SafeReports/get-Safe-balance-report/{SafeId}?dateFrom={DateFrom}&dateTo={DateTo}";
            var DataSet1 = MersalAPIs.CreateDataTable<SafeReportDTO>(MersalAPIs.Get<SafeReportDTO>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);
            ReportViewer reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/SafeBalanceReport-{lang}.rdlc");

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", DataSet3));


            ViewBag.reportViewer = reportViewer;
            return View();
        }

        public ActionResult VendorBalanceReport(long? vendorId, DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Vendor Balance";
            }
            else
            {
                ViewData["title"] = "التقارير - رصيد مورد";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"VendorReports/get-vendor-balance-report/{vendorId}?dateFrom={DateFrom}&dateTo={DateTo}";
            var DataSet1 = MersalAPIs.CreateDataTable<VendorReportDTO>(MersalAPIs.Get<VendorReportDTO>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);
            ReportViewer reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/VendorBalanceReport-{lang}.rdlc");

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", DataSet3));

            ViewBag.reportViewer = reportViewer;
            return View();
        }

        public ActionResult BankBalanceReport(long? bankId, DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            ViewData["lang"] = lang;
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Bank Balance";
            }
            else
            {
                ViewData["title"] = "التقارير - رصيد بنك";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"BankReports/get-bank-balance-report/{bankId}?dateFrom={DateFrom}&dateTo={DateTo}";
            var DataSet1 = MersalAPIs.CreateDataTable<BankReportDTO>(MersalAPIs.Get<BankReportDTO>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);
            ReportViewer reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/BankBalanceReport-{lang}.rdlc");

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", DataSet3));

            ViewBag.reportViewer = reportViewer;
            return View();
        }

        public ActionResult CostCenterBalanceReport(long? costCenterId, DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            ViewData["lang"] = lang;
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Cost Center Balance";
            }
            else
            {
                ViewData["title"] = "التقارير - رصيد مركز تكلفة";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"CostCenterReports/get-cost-center-balance-report/{costCenterId}?dateFrom={DateFrom}&dateTo={DateTo}";
            var DataSet1 = MersalAPIs.CreateDataTable<CostCenterReportDTO>(MersalAPIs.Get<CostCenterReportDTO>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);
            ReportViewer reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/CostCenterBalanceReport-{lang}.rdlc");

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", DataSet3));

            ViewBag.reportViewer = reportViewer;
            return View();
        }


        //public ActionResult DepreciationReport(DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        //{
        //    ViewData["lang"] = lang;
        //    if (lang == "en")
        //    {
        //        ViewData["title"] = "Reports - Depreciation";
        //    }
        //    else
        //    {
        //        ViewData["title"] = "التقارير -الأهلاك";
        //    }

        //    List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

        //    Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

        //    string pathuri1 = $"CostCenterReports/get-cost-center-balance-report?dateFrom={DateFrom}&dateTo={DateTo}";
        //    var DataSet1 = MersalAPIs.CreateDataTable<DepreciationReportDTO>(MersalAPIs.Get<DepreciationReportDTO>(pathuri1, lang));
        //    var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);
        //    ReportViewer reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/DepreciationReport-{lang}.rdlc");

        //    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
        //    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", DataSet3));

        //    ViewBag.reportViewer = reportViewer;
        //    return View();
        //}


        public ActionResult InventoryBalanceReport(long? inventoryId, DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Inventory Balance";
            }
            else
            {
                ViewData["title"] = "التقارير - ارصدة المخزون";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"InventoryReports/get-inventory-balance-report/{inventoryId}?dateFrom={DateFrom}&dateTo={DateTo}";
            var DataSet1 = MersalAPIs.CreateDataTable<InventoryBalanceReportViewModel>(MersalAPIs.Get<InventoryBalanceReportViewModel>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);
            ReportViewer reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/InventoryBalanceReport-{lang}.rdlc");

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("FilterDataSet", DataSet3));

            ViewBag.reportViewer = reportViewer;
            return View();
        }



        public ActionResult FixedAssetsDepreciationReport(DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Fixed Asset Depreciation";
            }
            else
            {
                ViewData["title"] = "التقارير - اهلاكات الاصول الثابتة";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"FixedAssetReports/get-fixed-assets-depreciation-report?dateFrom={DateFrom}&dateTo={DateTo}";
            var DataSet1 = MersalAPIs.CreateDataTable<FixedAssetDepreciationReportViewModel>(MersalAPIs.Get<FixedAssetDepreciationReportViewModel>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);
            ReportViewer reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/FixedAssetsDepreciationReport-{lang}.rdlc");

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("FilterDataSet", DataSet3));

            ViewBag.reportViewer = reportViewer;
            return View();
        }

        public ActionResult FixedAssetsLocationReport(long? locationId, DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Fixed Asset Location";
            }
            else
            {
                ViewData["title"] = "التقارير - اماكن الاصول الثابتة";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"FixedAssetReports/get-fixed-assets-location-report?locationId={locationId}&dateFrom={DateFrom}&dateTo={DateTo}";
            var DataSet1 = MersalAPIs.CreateDataTable<FixedAssetLocationReportViewModel>(MersalAPIs.Get<FixedAssetLocationReportViewModel>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);
            ReportViewer reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/FixedAssetsLocationReport-{lang}.rdlc");

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("FilterDataSet", DataSet3));

            ViewBag.reportViewer = reportViewer;
            return View();
        }

        public ActionResult FixedAssetsExcludedReport(DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Fixed Asset Excluded";
            }
            else
            {
                ViewData["title"] = "التقارير - الاصول المستبعدة";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"FixedAssetReports/get-fixed-assets-excluded-report?dateFrom={DateFrom}&dateTo={DateTo}";
            var DataSet1 = MersalAPIs.CreateDataTable<FixedAssetExcludedReportViewModel>(MersalAPIs.Get<FixedAssetExcludedReportViewModel>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);
            ReportViewer reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/FixedAssetsExcludedReport-{lang}.rdlc");

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("FilterDataSet", DataSet3));

            ViewBag.reportViewer = reportViewer;
            return View();
        }

        public ActionResult FixedAssetsInventoryReport(long? locationId, DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Fixed Asset Inventory";
            }
            else
            {
                ViewData["title"] = "التقارير - جرد الاصول الثابتة";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"FixedAssetReports/get-fixed-assets-inventory-report?locationId={locationId}&dateFrom={DateFrom}&dateTo={DateTo}";
            var DataSet1 = MersalAPIs.CreateDataTable<FixedAssetInventoryReportViewModel>(MersalAPIs.Get<FixedAssetInventoryReportViewModel>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);
            ReportViewer reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/FixedAssetsInventoryReport-{lang}.rdlc");

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("FilterDataSet", DataSet3));

            ViewBag.reportViewer = reportViewer;
            return View();
        }

        public ActionResult FixedAssetsLostReport(long? locationId, DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Fixed Asset Lost";
            }
            else
            {
                ViewData["title"] = "التقارير - مفقودات الاصول الثابتة";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"FixedAssetReports/get-fixed-assets-lost-report?locationId={locationId}&dateFrom={DateFrom}&dateTo={DateTo}";
            var DataSet1 = MersalAPIs.CreateDataTable<FixedAssetLostReportViewModel>(MersalAPIs.Get<FixedAssetLostReportViewModel>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);
            ReportViewer reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/FixedAssetsLostReport-{lang}.rdlc");

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("FilterDataSet", DataSet3));

            ViewBag.reportViewer = reportViewer;
            return View();
        }




        public ActionResult DonatorCasesHistoryReport(long? donatorId, DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Donator Cases History";
            }
            else
            {
                ViewData["title"] = "التقارير - تاريخ تبرعات المتبرع";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"DonationCaseReports/get-donator-cases-history-report/{donatorId}?dateFrom={DateFrom}&dateTo={DateTo}";
            var DataSet1 = MersalAPIs.CreateDataTable<DonatorCasesHistoryReportViewModel>(MersalAPIs.Get<DonatorCasesHistoryReportViewModel>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);
            ReportViewer reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/DonatorCasesHistoryReport-{lang}.rdlc");

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("FilterDataSet", DataSet3));

            ViewBag.reportViewer = reportViewer;
            return View();
        }

        public ActionResult DonationCasesBalanceReport(string caseId, DateTime? DateFrom, DateTime? DateTo, string lang = "ar")
        {
            if (lang == "en")
            {
                ViewData["title"] = "Reports - Donation Cases Balance";
            }
            else
            {
                ViewData["title"] = "التقارير - ارصدة الحالات";
            }

            List<ReportFiltersDTO> Filters = new List<ReportFiltersDTO>();

            Filters.Add(new ReportFiltersDTO(DateFrom, DateTo));

            string pathuri1 = $"DonationCaseReports/get-donation-cases-balance-report?caseId={caseId}&dateFrom={DateFrom}&dateTo={DateTo}";
            var DataSet1 = MersalAPIs.CreateDataTable<DonationCasesBalanceReportViewModel>(MersalAPIs.Get<DonationCasesBalanceReportViewModel>(pathuri1, lang));
            var DataSet3 = MersalAPIs.CreateDataTable<ReportFiltersDTO>(Filters);
            ReportViewer reportViewer = this.InitializeNewReportViewerInstance($"~/Reports/DonationCasesBalanceReport-{lang}.rdlc");

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DataSet1));
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("FilterDataSet", DataSet3));

            ViewBag.reportViewer = reportViewer;
            return View();
        }



        private ReportViewer InitializeNewReportViewerInstance(string reportPath)
        {
            ReportViewer reportViewerInstance = new ReportViewer();
            reportViewerInstance.ProcessingMode = ProcessingMode.Local;
            reportViewerInstance.SizeToReportContent = true;
            reportViewerInstance.Width = Unit.Percentage(100);
            reportViewerInstance.Height = Unit.Percentage(100);
            reportViewerInstance.LocalReport.EnableExternalImages = true;
            reportViewerInstance.LocalReport.ReportPath = Server.MapPath(reportPath);

            return reportViewerInstance;
        }
    }
}