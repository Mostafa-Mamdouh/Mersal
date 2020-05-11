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
    public interface ICostCentersService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(CostCenterViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of CostCenterViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<CostCenterViewModel> Get(ConditionFilter<CostCenter, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of CostCenterViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<CostCenterViewModel> Get(int? pageIndex, int? pageSize);

        GenericCollectionViewModel<CostCenterLightViewModel> GetEmployeesCostCenter();

        /// <summary>
        /// Gets a GenericCollectionViewModel of CostCenterLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<CostCenterLightViewModel> GetLightModel(ConditionFilter<CostCenter, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of CostCenterLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<CostCenterLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		GenericCollectionViewModel<ListCostCenterLightViewModel> GetByFilter(CostCenterFilterViewModel model);

        List<CostCenterLightViewModel> GetLookUp();

        /// <summary>
        /// Gets a CostCenterViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CostCenterViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<CostCenterViewModel> Add(IEnumerable<CostCenterViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        CostCenterViewModel Add(CostCenterViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<CostCenterViewModel> Update(IEnumerable<CostCenterViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        CostCenterViewModel Update(CostCenterViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<CostCenterViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(CostCenterViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
