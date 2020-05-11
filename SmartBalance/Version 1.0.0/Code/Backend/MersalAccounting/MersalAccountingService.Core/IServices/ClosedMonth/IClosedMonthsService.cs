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
    public interface IClosedMonthsService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(ClosedMonthViewModel model);

        void ValidateFromAndTo(ClosedMonthViewModel model);

        bool IsClosed(DateTime dateTime);
        void ValidateIfMonthIsClosed(DateTime dateTime);


        GenericCollectionViewModel<ListClosedMonthsLightViewModel> GetByFilter(ClosedMonthsFilterViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ClosedMonthViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ClosedMonthViewModel> Get(ConditionFilter<ClosedMonth, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ClosedMonthViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ClosedMonthViewModel> Get(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ClosedMonthLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ClosedMonthLightViewModel> GetLightModel(ConditionFilter<ClosedMonth, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ClosedMonthLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ClosedMonthLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a ClosedMonthViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ClosedMonthViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<ClosedMonthViewModel> Add(IEnumerable<ClosedMonthViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ClosedMonthViewModel Add(ClosedMonthViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<ClosedMonthViewModel> Update(IEnumerable<ClosedMonthViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ClosedMonthViewModel Update(ClosedMonthViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<ClosedMonthViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(ClosedMonthViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
