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

namespace MersalAccountingService.Core.IServices
{
    public interface IExcludesService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(ExcludeViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExcludeViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ExcludeViewModel> Get(ConditionFilter<Exclude, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExcludeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ExcludeViewModel> Get(int? pageIndex, int? pageSize);


        /// <summary>
        /// Gets a GenericCollectionViewModel of ExcludeLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ExcludeLightViewModel> GetLightModel(ConditionFilter<Exclude, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ExcludeLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ExcludeLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a ExcludeViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ExcludeViewModel Get(long id);

        GenericCollectionViewModel<ListExcludeLightViewModel> GetByFilter(AssetFilterViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<ExcludeViewModel> Add(IEnumerable<ExcludeViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ExcludeViewModel Add(ExcludeViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<ExcludeViewModel> Update(IEnumerable<ExcludeViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ExcludeViewModel Update(ExcludeViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<ExcludeViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(ExcludeViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
