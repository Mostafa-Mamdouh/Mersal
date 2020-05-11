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
    public interface IPurchaseRebateCostCentersService : IBaseService
    {
        #region Methods
       
        /// <summary>
        /// Gets a GenericCollectionViewModel of PurchaseRebateCostCenterViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<PurchaseRebateCostCenterViewModel> Get(ConditionFilter<PurchaseRebateCostCenter, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of PurchaseRebateCostCenterViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<PurchaseRebateCostCenterViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateCostCenterLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<PurchaseRebateCostCenterLightViewModel> GetLightModel(ConditionFilter<PurchaseRebateCostCenter, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateCostCenterLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<PurchaseRebateCostCenterLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a PurchaseRebateCostCenterViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PurchaseRebateCostCenterViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<PurchaseRebateCostCenterViewModel> Add(IEnumerable<PurchaseRebateCostCenterViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        PurchaseRebateCostCenterViewModel Add(PurchaseRebateCostCenterViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<PurchaseRebateCostCenterViewModel> Update(IEnumerable<PurchaseRebateCostCenterViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        PurchaseRebateCostCenterViewModel Update(PurchaseRebateCostCenterViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<PurchaseRebateCostCenterViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(PurchaseRebateCostCenterViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
