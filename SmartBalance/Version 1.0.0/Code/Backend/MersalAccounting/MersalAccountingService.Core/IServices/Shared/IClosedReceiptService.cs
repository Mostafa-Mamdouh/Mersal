#region using...
using Framework.Core.Filters;
using Framework.Core.IServices.Base;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.IServices
{
    public interface IClosedReceiptService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(ClosedReceiptViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ClosedReceiptViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ClosedReceiptViewModel> Get(ConditionFilter<ClosedReceipt, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ClosedReceiptViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ClosedReceiptViewModel> Get(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ClosedReceiptLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        //GenericCollectionViewModel<ClosedReceiptLightViewModel> GetLightModel(ConditionFilter<ClosedReceipt, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ClosedReceiptLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        //GenericCollectionViewModel<ClosedReceiptLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a ClosedReceiptViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ClosedReceiptViewModel Get(long id);

        int GetMax(int documentId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<ClosedReceiptViewModel> Add(IEnumerable<ClosedReceiptViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ClosedReceiptViewModel Add(ClosedReceiptViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<ClosedReceiptViewModel> Update(IEnumerable<ClosedReceiptViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ClosedReceiptViewModel Update(ClosedReceiptViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<ClosedReceiptViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(ClosedReceiptViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
