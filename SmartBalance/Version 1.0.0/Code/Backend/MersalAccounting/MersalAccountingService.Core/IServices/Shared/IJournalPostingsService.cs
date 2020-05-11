#region Using ...
using Framework.Core.Filters;
using Framework.Core.IServices.Base;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.JournalEntries;
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
    public interface IJournalPostingsService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(JournalPostingViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of JournalPostingViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<JournalPostingViewModel> Get(ConditionFilter<JournalPosting, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of JournalPostingViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<JournalPostingViewModel> Get(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a GenericCollectionViewModel of JournalPostingLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<JournalPostingLightViewModel> GetLightModel(ConditionFilter<JournalPosting, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of JournalPostingLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<JournalPostingLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a JournalPostingViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        JournalPostingViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ListJournalPostingLightViewModel> GetByFilter(JournalPostingFilterViewModel model);

        JournalPostingViewModel PostJournal(JournalPostingViewModel model, long? id = 0);
        IList<Journal> PostBankMovement(DateTime toDate,bool IsAutomaticPosting = false, bool IsBulkPosting = false, long? id = 0, bool postInMemory = false);
        IList<Journal> PostPaymentMovement(DateTime toDate, bool IsAutomaticPosting = false, bool IsBulkPosting = false, long? id = 0, bool postInMemory = false);
        IList<Journal> PostPurchaseInvoice(DateTime toDate, bool IsAutomaticPosting = false, bool IsBulkPosting = false, long? id = 0, bool postInMemory = false);
        IList<Journal> PostPurchaseRebate(DateTime toDate, bool IsAutomaticPosting = false, bool IsBulkPosting = false, long? id = 0, bool postInMemory = false);
        IList<Journal> PostReceiptsMovement(DateTime toDate, bool IsAutomaticPosting = false, bool IsBulkPosting = false, long? id = 0, bool postInMemory = false);
        IList<Journal> PostSalesInvoice(DateTime toDate, bool IsAutomaticPosting = false, bool IsBulkPosting = false, long? id = 0);
        IList<Journal> PostSalesRebate(DateTime toDate, bool IsAutomaticPosting = false, bool IsBulkPosting = false, long? id = 0);
        IList<Journal> PostStoreMovement(DateTime toDate, bool IsAutomaticPosting = false, bool IsBulkPosting = false, long? id = 0, bool postInMemory = false);

        IList<Journal> PostChecksUnderCollectionOfReceiptsMovement(IList<long> idCollection);

        JournalPostingViewModel TryPostAutomatic(long id, MovementType movementType);
        AddJournalEntriesViewModel Post(long id, MovementType movementType);




        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<JournalPostingViewModel> Add(IEnumerable<JournalPostingViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        JournalPostingViewModel Add(JournalPostingViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<JournalPostingViewModel> Update(IEnumerable<JournalPostingViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        JournalPostingViewModel Update(JournalPostingViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<JournalPostingViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(JournalPostingViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
