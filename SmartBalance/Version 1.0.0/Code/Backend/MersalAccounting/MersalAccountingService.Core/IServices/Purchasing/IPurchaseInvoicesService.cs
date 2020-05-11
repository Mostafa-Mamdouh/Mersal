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
    public interface IPurchaseInvoicesService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(PurchaseInvoiceViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of PurchaseInvoiceViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<PurchaseInvoiceViewModel> Get(ConditionFilter<PurchaseInvoice, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of PurchaseInvoiceViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<PurchaseInvoiceViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of PurchaseInvoiceLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<PurchaseInvoiceLightViewModel> GetLightModel(ConditionFilter<PurchaseInvoice, long> condition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IList<PurchaseInvoiceLookupViewModel> GetLookupLightModel();

        /// <summary>
        /// Gets a GenericCollectionViewModel of PurchaseInvoiceLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<PurchaseInvoiceLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ListPurchasLightViewModel> GetByFilter(PurchasInvoiceFilterViewModel model);

        /// <summary>
        /// Gets a PurchaseInvoiceViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PurchaseInvoiceViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<PurchaseInvoiceViewModel> Add(IEnumerable<PurchaseInvoiceViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        PurchaseInvoiceViewModel Add(PurchaseInvoiceViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<PurchaseInvoiceViewModel> Update(IEnumerable<PurchaseInvoiceViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        PurchaseInvoiceViewModel Update(PurchaseInvoiceViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<PurchaseInvoiceViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(PurchaseInvoiceViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
