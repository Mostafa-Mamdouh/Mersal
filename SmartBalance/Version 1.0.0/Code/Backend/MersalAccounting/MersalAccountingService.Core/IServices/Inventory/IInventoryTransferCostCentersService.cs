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
    public interface IInventoryTransferCostCentersService : IBaseService
    {
        #region Methods

        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryTransferCostCenterViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<InventoryTransferCostCenterViewModel> Get(ConditionFilter<InventoryTransferCostCenter, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryTransferCostCenterViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<InventoryTransferCostCenterViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryTransferCostCenterLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<InventoryTransferCostCenterViewModel> GetLightModel(ConditionFilter<InventoryTransferCostCenter, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryTransferCostCenterLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<InventoryTransferCostCenterViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a InventoryTransferCostCenterViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        InventoryTransferCostCenterViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<InventoryTransferCostCenterViewModel> Add(IEnumerable<InventoryTransferCostCenterViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        InventoryTransferCostCenterViewModel Add(InventoryTransferCostCenterViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<InventoryTransferCostCenterViewModel> Update(IEnumerable<InventoryTransferCostCenterViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        InventoryTransferCostCenterViewModel Update(InventoryTransferCostCenterViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<InventoryTransferCostCenterViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(InventoryTransferCostCenterViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
