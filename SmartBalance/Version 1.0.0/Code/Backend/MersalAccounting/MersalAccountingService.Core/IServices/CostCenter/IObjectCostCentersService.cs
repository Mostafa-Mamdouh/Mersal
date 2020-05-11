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
    public interface IObjectCostCentersService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(ObjectCostCenterViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ObjectCostCenterViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ObjectCostCenterViewModel> Get(ConditionFilter<ObjectCostCenter, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ObjectCostCenterViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<ObjectCostCenterViewModel> Get(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ObjectCostCenterLightViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        //GenericCollectionViewModel<ObjectCostCenterLightViewModel> GetLightModel(ConditionFilter<ObjectCostCenter, long> condition);

        /// <summary>
        /// Gets a GenericCollectionViewModel of ObjectCostCenterLightViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        //GenericCollectionViewModel<ObjectCostCenterLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		GenericCollectionViewModel<ListObjectCostCenterLightViewModel> GetByFilter(ObjectCostCenterFilterViewModel model);

        //List<ObjectCostCenterLightViewModel> GetLookUp();

        /// <summary>
        /// Gets a ObjectCostCenterViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ObjectCostCenterViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<ObjectCostCenterViewModel> Add(IEnumerable<ObjectCostCenterViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ObjectCostCenterViewModel Add(ObjectCostCenterViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<ObjectCostCenterViewModel> Update(IEnumerable<ObjectCostCenterViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ObjectCostCenterViewModel Update(ObjectCostCenterViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<ObjectCostCenterViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(ObjectCostCenterViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
