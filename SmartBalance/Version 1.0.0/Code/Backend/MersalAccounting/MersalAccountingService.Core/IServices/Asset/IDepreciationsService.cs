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
    public interface IDepreciationsService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(DepreciationViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<DepreciationViewModel> Get(ConditionFilter<Depreciation, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<DepreciationViewModel> Get(int? pageIndex, int? pageSize);


        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<DepreciationLightViewModel> GetLightModel(ConditionFilter<Depreciation, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of DepreciationLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<DepreciationLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a DepreciationViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DepreciationViewModel Get(long id);

        GenericCollectionViewModel<ListAssetLightViewModel> GetByFilter(AssetFilterViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<DepreciationViewModel> Add(IEnumerable<DepreciationViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DepreciationViewModel Add(DepreciationViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<DepreciationViewModel> Update(IEnumerable<DepreciationViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DepreciationViewModel Update(DepreciationViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<DepreciationViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(DepreciationViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
