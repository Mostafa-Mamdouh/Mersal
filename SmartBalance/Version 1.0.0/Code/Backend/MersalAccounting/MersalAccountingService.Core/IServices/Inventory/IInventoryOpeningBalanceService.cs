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
    public interface IInventoryOpeningBalanceService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(InventoryOpeningBalanceViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryOpeningBalanceViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<InventoryOpeningBalanceViewModel> Get(ConditionFilter<InventoryOpeningBalance, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryOpeningBalanceViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<InventoryOpeningBalanceViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryOpeningBalanceLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<InventoryOpeningBalanceLightViewModel> GetLightModel(ConditionFilter<InventoryOpeningBalance, long> condition);     

        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryOpeningBalanceLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<InventoryOpeningBalanceLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        GenericCollectionViewModel<InventoryOpeningBalanceLightViewModel> GetByFilter(InventoryOpeningBalanceFilterViewModel model);

        /// <summary>
        /// Gets a InventoryOpeningBalanceViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        InventoryOpeningBalanceViewModel Get(long id);

        /// <summary>
        /// Gets a InventoryOpeningBalanceViewModel by its vendor-id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GenericCollectionViewModel<InventoryOpeningBalanceLookupViewModel> GetOpeningBalancesByVendorID(long id);


        /// <summary>
        /// Gets a InventoryOpeningBalanceViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        InventoryOpeningBalanceAddViewModel GetOpeningBalances(long id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<InventoryOpeningBalanceViewModel> Add(IEnumerable<InventoryOpeningBalanceViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        InventoryOpeningBalanceViewModel Add(InventoryOpeningBalanceViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        InventoryOpeningBalanceAddViewModel AddInventoryOpeningBalance(InventoryOpeningBalanceAddViewModel model);

        InventoryOpeningBalanceAddViewModel UpdateInventoryOpeningBalance(InventoryOpeningBalanceAddViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<InventoryOpeningBalanceViewModel> Update(IEnumerable<InventoryOpeningBalanceViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        InventoryOpeningBalanceViewModel Update(InventoryOpeningBalanceViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<InventoryOpeningBalanceViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(InventoryOpeningBalanceViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
