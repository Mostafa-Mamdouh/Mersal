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
    public interface IDistrictsService : IBaseService
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void ThrowExceptionIfExist(DistrictViewModel model);

        /// <summary>
        /// Gets a GenericCollectionViewModel of DistrictViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        GenericCollectionViewModel<DistrictViewModel> Get(ConditionFilter<District, long> condition);
        
        /// <summary>
        /// Gets a GenericCollectionViewModel of DistrictViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        GenericCollectionViewModel<DistrictViewModel> Get(int? pageIndex, int? pageSize);

		/// <summary>
		/// Gets a GenericCollectionViewModel of DistrictLightViewModel by condition.
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		GenericCollectionViewModel<DistrictLightViewModel> GetLightModel(ConditionFilter<District, long> condition);

		/// <summary>
		/// Gets a GenericCollectionViewModel of DistrictLightViewModel by pagination.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		GenericCollectionViewModel<DistrictLightViewModel> GetLightModel(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets a DistrictViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DistrictViewModel Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<DistrictViewModel> Add(IEnumerable<DistrictViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DistrictViewModel Add(DistrictViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        IList<DistrictViewModel> Update(IEnumerable<DistrictViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DistrictViewModel Update(DistrictViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<DistrictViewModel> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        void Delete(IEnumerable<long> collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void Delete(DistrictViewModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        #endregion
    }
}
