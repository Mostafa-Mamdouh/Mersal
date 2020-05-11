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
    public interface IJournalsService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(JournalViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of JournalViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<JournalViewModel> Get(ConditionFilter<Journal, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of JournalViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<JournalViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<JournalLightViewModel> GetLightModel(ConditionFilter<Journal, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of JournalLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<JournalLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        GenericCollectionViewModel<AddJournalEntriesViewModel> GetByFilter(FilterJournalEntriesViewModel collection);
        /// <summary>
        /// Gets a JournalViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        JournalViewModel Get(long id);
        /// <summary>
        /// Gets a AddJournalEntriesViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AddJournalEntriesViewModel getJournalsDetails(long id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<JournalViewModel> Add(IEnumerable<JournalViewModel> collection);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        AddJournalEntriesViewModel AddJournal(AddJournalEntriesViewModel model, PostingStatus postingStatus = PostingStatus.Approved);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        JournalViewModel Add(JournalViewModel model);


        ApprovedRejectedCollectionViewModel ApproveAndRejectCollection(ApprovedRejectedCollectionViewModel model);
        IdCollectionViewModel<long> Approve(IdCollectionViewModel<long> model);
        AddJournalEntriesViewModel Approve(AddJournalEntriesViewModel model);

        IdCollectionViewModel<long> Reject(IdCollectionViewModel<long> model);
    


        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<JournalViewModel> Update(IEnumerable<JournalViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        AddJournalEntriesViewModel Update(AddJournalEntriesViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<JournalViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(JournalViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
