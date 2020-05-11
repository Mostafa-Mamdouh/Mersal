#region Using ...
using Framework.Core.Filters;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
#endregion

namespace MersalAccountingService.WebAPI.Controllers.API
{
    /// <summary>
    /// Settings Controller
    /// </summary>
    [RoutePrefix("api/Settings")]
    public class SettingsController : Base.BaseAPIController
    {
        #region Data Members
        private readonly ISettingsService _SettingsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type AccountChartCategoryController.
        /// </summary>
        /// <param name="AccountChartCategorysService">The injected service.</param>
        public SettingsController(ISettingsService _SettingsService)
        {
            this._SettingsService = _SettingsService;
        }
        #endregion

        #region Actions

        /// <summary>
        /// ضريبة القيمة المضافة
        /// </summary>       
        /// <returns></returns>
        [Route("get-vat")]
        [HttpGet]
        /*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Settings/get-vat
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Settings/get-vat 
		 */
        public double GetVAT()
        {
            var result = this._SettingsService.GetVAT();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("update-vat")]
        [HttpPost]       
        public VATSettingViewModel UpdateVAT(VATSettingViewModel model)
        {
            var result = this._SettingsService.UpdateVAT(model);
            return result;
        }

       

        /// <summary>
        /// إعدادات نظام الموردين
        /// </summary>
        /// <returns></returns>
        [Route("get-vendor-setting")]
        [HttpGet]
        public VendorSettingViewModel GetVendorSetting()
        {
            var result = this._SettingsService.GetVendorSetting();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("update-vendor-setting")]
        [HttpPost]
        public VendorSettingViewModel UpdateVendorSetting(VendorSettingViewModel model)
        {
            var result = this._SettingsService.UpdateVendorSetting(model);
            return result;
        }



        /// <summary>
        /// إعدادات الحركة المالية
        /// </summary>
        /// <returns></returns>
        [Route("get-financial-setting")]
        [HttpGet]
        public FinancialSettingViewModel GetFinancialSetting()
        {
            var result = this._SettingsService.GetFinancialSetting();
            return result;
        }

        [Route("update-financial-setting")]
        [HttpPost]
        public FinancialSettingViewModel UpdateFinancialSetting(FinancialSettingViewModel model)
        {
            var result = this._SettingsService.UpdateFinancialSetting(model);
            return result;
        }


        /// <summary>
        /// إعدادات العهد و السلفيات
        /// </summary>
        /// <returns></returns>
        [Route("get-testament-and-advances-setting")]
        [HttpGet]
        public TestamentAndAdvancesSettingViewModel GetTestamentAndAdvancesSetting()
        {
            var result = this._SettingsService.GetTestamentAndAdvancesSetting();
            return result;
        }

        [Route("update-testament-and-advances-setting")]
        [HttpPost]
        public TestamentAndAdvancesSettingViewModel UpdateTestamentAndAdvancesSetting(TestamentAndAdvancesSettingViewModel model)
        {
            var result = this._SettingsService.UpdateTestamentAndAdvancesSetting(model);
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("get-posting-setting")]
        [HttpGet]
        public PostingSettingSettingViewModel GetPostingSetting()
        {
            var result = this._SettingsService.GetPostingSetting();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("update-posting-setting")]
        [HttpPost]
        public PostingSettingSettingViewModel UpdatePostingSetting(PostingSettingSettingViewModel model)
        {
            var result = this._SettingsService.UpdatePostingSetting(model);
            return result;
        }



        [Route("get-general-setting")]
        [HttpGet]
        public GeneralSettingViewModel GetGeneralSetting()
        {
            var result = this._SettingsService.GetGeneralSetting();
            return result;
        }

        [Route("update-general-setting")]
        [HttpPost]
        public GeneralSettingViewModel UpdateGeneralSetting(GeneralSettingViewModel model)
        {
            var result = this._SettingsService.UpdateGeneralSetting(model);
            return result;
        }


		/// <summary>
		/// عملة النظام
		/// </summary>       
		/// <returns></returns>
		[Route("get-system-currency-setting")]
		[HttpGet]
		/*
		 * HttpVerb: Get
		 * URL Pattern: http[s]://IPAddress:PortNumber/api/Settings/get-system-currency
		 * Usage: http://localhost/MersalAccountingService.WebAPI/api/Settings/get-system-currency
		 */
		public SystemCurrencySettingViewModel GetSystemCurrency()
		{
			var result = this._SettingsService.GetSystemCurrency();
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[Route("update-system-currency-setting")]
		[HttpPost]
		public SystemCurrencySettingViewModel UpdateSystemCurrency(SystemCurrencySettingViewModel model)
		{
			var result = this._SettingsService.UpdateSystemCurrency(model);
			return result;
		}


        [Route("get-fixed-asset-account-setting")]
        [HttpGet]
        public List<FixedAssetAccountChartSettingViewModel> GetFixedAssetAccount()
        {
            var result = this._SettingsService.GetFixedAssetAccount();
            return result;
        }

        [Route("update-fixed-asset-account-setting")]
        [HttpPost]
        public List<FixedAssetAccountChartSettingViewModel> UpdateFixedAssetAccount(ICollection<FixedAssetAccountChartSettingViewModel> models)
        {
            var result = this._SettingsService.UpdateFixedAssetAccount(models);
            return result;
        }

        #endregion
    }
}
