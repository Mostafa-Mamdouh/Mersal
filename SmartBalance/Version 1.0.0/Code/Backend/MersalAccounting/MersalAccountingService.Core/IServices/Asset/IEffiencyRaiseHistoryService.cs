using Framework.Core.Filters;
using Framework.Core.IServices.Base;
using Framework.Core.Models.DTOs;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersalAccountingService.Core.IServices
{
   public interface IEffiencyRaiseHistoryService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(MersalAccountingService.Core.Models.ViewModels.EffiencyRaiseHistoryViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of EffiencyRaiseHistoryViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<EffiencyRaiseHistoryViewModel> Get(ConditionFilter<EfficiencyRaiseHistory, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of EffiencyRaiseHistoryViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<EffiencyRaiseHistoryViewModel> Get(int? pageIndex, int? pageSize);


        /// <summary>
        /// Gets a EffiencyRaiseHistoryViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EffiencyRaiseHistoryViewModel Get(long id);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<EffiencyRaiseHistoryViewModel> Add(IEnumerable<EffiencyRaiseHistoryViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        EffiencyRaiseHistoryViewModel Add(EffiencyRaiseHistoryViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<EffiencyRaiseHistoryViewModel> Update(IEnumerable<EffiencyRaiseHistoryViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        EffiencyRaiseHistoryViewModel Update(EffiencyRaiseHistoryViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<EffiencyRaiseHistoryViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(EffiencyRaiseHistoryViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
