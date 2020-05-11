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
    public interface IPurchaseInvoiceCostCentersService : IBaseService
    {
        #region Methods

        /// <summary>
        /// Gets a GenericCollectionViewModel of PurchaseInvoiceCostCenterViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<PurchaseInvoiceCostCenterViewModel> Get(ConditionFilter<PurchaseInvoiceCostCenter, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of PurchaseInvoiceCostCenterViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<PurchaseInvoiceCostCenterViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceCostCenterLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<PurchaseInvoiceCostCenterLightViewModel> GetLightModel(ConditionFilter<PurchaseInvoiceCostCenter, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceCostCenterLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<PurchaseInvoiceCostCenterLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a PurchaseInvoiceCostCenterViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PurchaseInvoiceCostCenterViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<PurchaseInvoiceCostCenterViewModel> Add(IEnumerable<PurchaseInvoiceCostCenterViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        PurchaseInvoiceCostCenterViewModel Add(PurchaseInvoiceCostCenterViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<PurchaseInvoiceCostCenterViewModel> Update(IEnumerable<PurchaseInvoiceCostCenterViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        PurchaseInvoiceCostCenterViewModel Update(PurchaseInvoiceCostCenterViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<PurchaseInvoiceCostCenterViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(PurchaseInvoiceCostCenterViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
