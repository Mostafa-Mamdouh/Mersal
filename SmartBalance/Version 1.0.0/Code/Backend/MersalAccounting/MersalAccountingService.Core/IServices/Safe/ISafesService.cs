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
    public interface ISafesService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(SafeViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of SafeViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<SafeViewModel> Get(ConditionFilter<Safe, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of SafeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<SafeViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of SafeLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<SafeLightViewModel> GetLightModel(ConditionFilter<Safe, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of SafeLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<SafeLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a SafeViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SafeViewModel Get(long id);

		/// <summary>
		/// Gets a SafeViewModel by branch id.
		/// </summary>
		/// <param name="branchId"></param>
		/// <returns></returns>
		SafeViewModel GetByBranchId(long branchId);

        List<SafeLightViewModel> GetLookUp();

        List<AccountChartLightViewModel> GetAccountCharts(long safeId, long currencyId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		GenericCollectionViewModel<ListSafesLightViewModel> GetByFilter(SafeFilterViewModel model);


        SafeAccountChartListViewModel GetSafeAccountChart(long safeId);

        SafeAccountChartListViewModel UpdateSafeAccountChart(SafeAccountChartListViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<SafeViewModel> Add(IEnumerable<SafeViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        SafeViewModel Add(SafeViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<SafeViewModel> Update(IEnumerable<SafeViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        SafeViewModel Update(SafeViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<SafeViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(SafeViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
