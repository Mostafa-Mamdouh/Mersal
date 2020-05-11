#region Using ...
using Framework.Core.Filters;
using Framework.Core.IServices.Base;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using System.Collections.Generic;
#endregion

namespace MersalAccountingService.Core.IServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDepreciationTypesService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(DepreciationTypeViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationTypeViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<DepreciationTypeViewModel> Get(ConditionFilter<DepreciationType, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationTypeViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<DepreciationTypeViewModel> Get(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationTypeLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<DepreciationTypeLightViewModel> GetLightModel(ConditionFilter<DepreciationType, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationTypeLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<DepreciationTypeLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a DepreciationTypeViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DepreciationTypeViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<DepreciationTypeViewModel> Add(IEnumerable<DepreciationTypeViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DepreciationTypeViewModel Add(DepreciationTypeViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<DepreciationTypeViewModel> Update(IEnumerable<DepreciationTypeViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DepreciationTypeViewModel Update(DepreciationTypeViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<DepreciationTypeViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(DepreciationTypeViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
