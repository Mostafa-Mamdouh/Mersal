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
    public interface IInventorysService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(InventoryViewModel model);

        GenericCollectionViewModel<ListInventoryLightViewModel> GetByFilter(InventoryFilterViewModel model);
            
        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<InventoryViewModel> Get(ConditionFilter<Inventory, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of InventoryViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<InventoryViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<InventoryLightViewModel> GetLightModel(ConditionFilter<Inventory, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of InventoryLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<InventoryLightViewModel> GetLightModel(int? pageIndex, int? pageSize);
        /// <summary>
        /// Gets a Lookup of InventoryLightViewModel
        /// </summary>

        /// <returns></returns>

        List<InventoryLightViewModel> GetLookUp();


        /// <summary>
        /// get product by inventory
        /// </summary>
        List<ProductLightViewModel> GetInventoryProduct(long id);
        /// <summary>
        /// Gets a InventoryViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        InventoryViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<InventoryViewModel> Add(IEnumerable<InventoryViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        InventoryViewModel Add(InventoryViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<InventoryViewModel> Update(IEnumerable<InventoryViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        InventoryViewModel Update(InventoryViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<InventoryViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(InventoryViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
