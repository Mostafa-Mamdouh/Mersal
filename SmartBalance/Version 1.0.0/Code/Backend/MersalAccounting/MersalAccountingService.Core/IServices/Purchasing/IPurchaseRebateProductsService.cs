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
    public interface IPurchaseRebateProductsService : IBaseService
    {
        #region Methods      
        /// <summary>
        /// Gets a GenericCollectionViewModel of PurchaseRebateProductViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<PurchaseRebateProductViewModel> Get(ConditionFilter<PurchaseRebateProduct, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of PurchaseRebateProductViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<PurchaseRebateProductViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateProductLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<PurchaseRebateProductLightViewModel> GetLightModel(ConditionFilter<PurchaseRebateProduct, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseRebateProductLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<PurchaseRebateProductLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a PurchaseRebateProductViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PurchaseRebateProductViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<PurchaseRebateProductViewModel> Add(IEnumerable<PurchaseRebateProductViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        PurchaseRebateProductViewModel Add(PurchaseRebateProductViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<PurchaseRebateProductViewModel> Update(IEnumerable<PurchaseRebateProductViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        PurchaseRebateProductViewModel Update(PurchaseRebateProductViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<PurchaseRebateProductViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(PurchaseRebateProductViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
