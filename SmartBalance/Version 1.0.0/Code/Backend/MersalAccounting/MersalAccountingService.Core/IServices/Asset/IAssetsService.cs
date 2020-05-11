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
    public interface IAssetsService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(AssetViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<AssetViewModel> Get(ConditionFilter<Asset, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<AssetViewModel> Get(int? pageIndex, int? pageSize);

        GenericCollectionViewModel<AssetLookupViewModel> GetLookup();

        /// <summary>
        /// Gets a GenericCollectionViewModel of AssetLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<AssetLightViewModel> GetLightModel(ConditionFilter<Asset, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of AssetLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<AssetLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a AssetViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AssetViewModel Get(long id);

        GenericCollectionViewModel<ListAssetLightViewModel> GetByFilter(AssetFilterViewModel model);

        IList<AssetInventoryDetailLightViewModel> GetAssetDetailsByLocation(long locationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<AssetViewModel> Add(IEnumerable<AssetViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        AssetViewModel Add(AssetViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<AssetViewModel> Update(IEnumerable<AssetViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        AssetViewModel Update(AssetViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<AssetViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(AssetViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
