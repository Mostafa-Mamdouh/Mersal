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
    public interface IAssetLocationsService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(AssetLocationViewModel model);


        //IList<AssetLocationLightViewModel> GetLookup();

        GenericCollectionViewModel<ListAssetLocationsLightViewModel> GetByFilter(AssetLocationsFilterViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetLocationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<AssetLocationViewModel> Get(ConditionFilter<AssetLocation, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetLocationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<AssetLocationViewModel> Get(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetLocationLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<AssetLocationLightViewModel> GetLightModel(ConditionFilter<AssetLocation, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetLocationLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<AssetLocationLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a AssetLocationViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AssetLocationViewModel Get(long id);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="collection"></param>
        ///// <returns></returns>
        //IList<AssetLocationViewModel> Add(IEnumerable<AssetLocationViewModel> collection);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //AssetLocationViewModel Add(AssetLocationViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<AssetLocationViewModel> Update(IEnumerable<AssetLocationViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        AssetLocationViewModel Update(AssetLocationViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<AssetLocationViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(AssetLocationViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
