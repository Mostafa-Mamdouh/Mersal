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
    public interface IAccountChartDocumentService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(AccountChartDocumentViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of BankViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<AccountChartDocumentViewModel> Get(ConditionFilter<AccountChartDocument, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of BankViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<AccountChartDocumentViewModel> Get(int? pageIndex, int? pageSize);

        /// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		GenericCollectionViewModel<ListAccountChartDocumentLightViewModel> GetByFilter(AccountChartDocumentFilterViewModel model);

        /// <summary>
        /// Gets a BankViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<AccountChartDocumentViewModel> Get(long bankId);

        AccountChartDocumentViewModel Get(long bankId, long documentId);

        //List<BankLightViewModel> GetLookUp();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<AccountChartDocumentViewModel> Add(IEnumerable<AccountChartDocumentViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        AccountChartDocumentViewModel Add(AccountChartDocumentViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<AccountChartDocumentViewModel> Update(IEnumerable<AccountChartDocumentViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        AccountChartDocumentViewModel Update(AccountChartDocumentViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<AccountChartDocumentViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(AccountChartDocumentViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
