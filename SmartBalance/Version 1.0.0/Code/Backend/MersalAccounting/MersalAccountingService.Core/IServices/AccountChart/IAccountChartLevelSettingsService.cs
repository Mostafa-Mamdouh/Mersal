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
    public interface IAccountChartLevelSettingsService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(AccountChartLevelSettingViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of AccountChartLevelSettingViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<AccountChartLevelSettingViewModel> Get(ConditionFilter<AccountChartLevelSetting, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of AccountChartLevelSettingViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<AccountChartLevelSettingViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartLevelSettingLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<AccountChartLevelSettingLightViewModel> GetLightModel(ConditionFilter<AccountChartLevelSetting, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of AccountChartLevelSettingLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<AccountChartLevelSettingLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a GenericCollectionViewModel of AccountChartLevelSettingLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<AccountChartLevelSettingLightViewModel> GetLightModel();

        /// <summary>
        /// Gets a AccountChartLevelSettingViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AccountChartLevelSettingViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<AccountChartLevelSettingViewModel> Add(IEnumerable<AccountChartLevelSettingViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        AccountChartLevelSettingViewModel Add(AccountChartLevelSettingViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<AccountChartLevelSettingViewModel> Update(IEnumerable<AccountChartLevelSettingViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        AccountChartLevelSettingViewModel Update(AccountChartLevelSettingViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<AccountChartLevelSettingViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(AccountChartLevelSettingViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
