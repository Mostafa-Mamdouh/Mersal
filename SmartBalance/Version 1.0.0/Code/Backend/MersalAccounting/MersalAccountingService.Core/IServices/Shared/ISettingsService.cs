#region Using ...
using Framework.Core.Filters;
using Framework.Core.IServices.Base;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.IServices
{
	/// <summary>
	/// 
	/// </summary>
	public interface ISettingsService : IBaseService
	{
        #region Methods

        /// <summary>
        /// ضريبة القيمة المضافة
        /// </summary>
        /// <returns></returns>
        double GetVAT();
        VATSettingViewModel UpdateVAT(VATSettingViewModel model);

        /// <summary>
        /// إعدادات نظام الموردين
        /// </summary>
        /// <returns></returns>
        VendorSettingViewModel GetVendorSetting();
        VendorSettingViewModel UpdateVendorSetting(VendorSettingViewModel model);

        /// <summary>
        /// إعدادات الحركة المالية
        /// </summary>
        /// <returns></returns>
        FinancialSettingViewModel GetFinancialSetting();
        FinancialSettingViewModel UpdateFinancialSetting(FinancialSettingViewModel model);

        /// <summary>
        /// إعدادات العهد و السلفيات
        /// </summary>
        /// <returns></returns>
        TestamentAndAdvancesSettingViewModel GetTestamentAndAdvancesSetting();
        TestamentAndAdvancesSettingViewModel UpdateTestamentAndAdvancesSetting(TestamentAndAdvancesSettingViewModel model) ;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        PostingSettingSettingViewModel GetPostingSetting();
        PostingSettingSettingViewModel UpdatePostingSetting(PostingSettingSettingViewModel model);


        /// <summary>
        /// إعدادات عامة
        /// </summary>
        /// <returns></returns>
        GeneralSettingViewModel GetGeneralSetting();
        GeneralSettingViewModel UpdateGeneralSetting(GeneralSettingViewModel model);


		/// <summary>
		/// عملة النظام
		/// </summary>
		/// <returns></returns>
		SystemCurrencySettingViewModel GetSystemCurrency();
		SystemCurrencySettingViewModel UpdateSystemCurrency(SystemCurrencySettingViewModel model);

        /// <summary>
        /// حسبات الاصول الثابتة
        /// </summary>
        /// <returns></returns>
        List<FixedAssetAccountChartSettingViewModel> GetFixedAssetAccount();
        List<FixedAssetAccountChartSettingViewModel> UpdateFixedAssetAccount(ICollection<FixedAssetAccountChartSettingViewModel> models);



        /// <summary>
        /// Gets a GenericCollectionViewModel of SettingViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<SettingViewModel> Get(ConditionFilter<Setting, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of SettingViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<SettingViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of SettingLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<SettingLightViewModel> GetLightModel(ConditionFilter<Setting, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of SettingLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<SettingLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a SettingViewModel by its id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		SettingViewModel Get(long id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		IList<SettingViewModel> Add(IEnumerable<SettingViewModel> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		SettingViewModel Add(SettingViewModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		/// <returns></returns>
		IList<SettingViewModel> Update(IEnumerable<SettingViewModel> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		SettingViewModel Update(SettingViewModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		void Delete(IEnumerable<SettingViewModel> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="collection"></param>
		void Delete(IEnumerable<long> collection);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		void Delete(SettingViewModel model);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		void Delete(long id);
		#endregion
	}
}
